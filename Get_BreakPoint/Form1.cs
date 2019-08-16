﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Get_BreakPoint
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //openFileDialog1.InitialDirectory = "c:\\";//注意这里写路径时要用c:\\而不是c:\
            //openFileDialog1.Filter = "文本文件|*.txt|CSV文件|*.csv|所有文件|*.*";
            //openFileDialog1.RestoreDirectory = true;
            //openFileDialog1.FilterIndex = 1;
            //listBox1.Items.Clear();
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{                
            //    textBox1.Text = openFileDialog1.FileName;
            //    get_Points(openFileDialog1.FileName);
            //}
            
            //if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            //{                
            //    textBox1.Text = folderBrowserDialog1.SelectedPath;
            //    fileSystemWatcher1.Path = folderBrowserDialog1.SelectedPath;
            //    fileSystemWatcher1.IncludeSubdirectories = false;
            //    fileSystemWatcher1.Created += new FileSystemEventHandler(fileSystemWatcher1_Created);
            //}

            fileSystemWatcher1.Path = textBox1.Text ;
            fileSystemWatcher1.IncludeSubdirectories = false;
            fileSystemWatcher1.Created += new FileSystemEventHandler(fileSystemWatcher1_Created);
            
            fileSystemWatcher1.Changed += new FileSystemEventHandler(fileSystemWatcher1_Changed);
            button1.Text = "Started";
            button1.Enabled = false;
        }

        void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            //throw new NotImplementedException();
        }

        

        void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            label3.Text = "FileName：" + e.Name;
            get_Points(e.FullPath);
        }



        public class mPoint
        {
            public int Index;
            public double Position;
            public double Force;
            public mPoint()
            {
                Index = 0;
                Position = 0;
                Force = 0;
            }
            public mPoint(int mIndex, double mPosition, double mForce)
            {
                Index = mIndex;
                Position = mPosition;
                Force = mForce;
            }
            public mPoint(string mIndex, string mPosition, string mForce)
            {
                Index = Convert.ToInt32(mIndex);
                Position = Convert.ToDouble(mPosition);
                Force = Convert.ToDouble(mForce);
            }
        }
        List<mPoint> mPoints1 = new List<mPoint>();
        List<mPoint> mPoints2 = new List<mPoint>();
        List<mPoint> mPoints3 = new List<mPoint>();
        List<mPoint> mPoints4 = new List<mPoint>();
        List<mPoint> mPoints5 = new List<mPoint>();
        List<double> deltaPoints_position = new List<double>();
        List<double> deltaPoints_time = new List<double>();
        List<double> ks = new List<double>();

        int recordIndex = 0;
        int maxIndex;
        int minIndex;
        int touchIndex;
        List<mPoint> jumpPoints = new List<mPoint>();
        List<mPoint> dropPoints = new List<mPoint>();
        public bool get_Points(string FileName) 
        {
            bool mResult = false;
            listBox1.Items.Clear();
            while (true)
            {
                try
                {
                    using (StreamReader sReader = new StreamReader(FileName))
                    {
                        //if (stream != null)
                            break;
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(string.Format("Output file {0} not yet ready ({1})", FileName, ex.Message));
                }
                System.Threading.Thread.Sleep(500);
            }
            using (StreamReader sReader = new StreamReader(FileName))
            {
                deltaPoints_position = new List<double>();
                deltaPoints_time = new List<double>();
                ks = new List<double>();
                mPoints1 = new List<mPoint>();
                mPoints2 = new List<mPoint>();
                mPoints3 = new List<mPoint>();
                mPoints4 = new List<mPoint>();
                mPoints5 = new List<mPoint>();
                jumpPoints = new List<mPoint>();
                dropPoints = new List<mPoint>();
                while (sReader.Peek()>=0)
                {
                    string mStr = sReader.ReadLine();
                    if (mStr.Length>8)
                    {
                        if (mStr.Substring(0, 8) == "[Record ")
                        {
                            //recordIndex++;
                            recordIndex = Convert.ToInt32(mStr.Split(' ')[1].Substring(0, mStr.Split(' ')[1].Length - 1));
                            mStr = sReader.ReadLine();//No. points:;1923
                            int recordLength = Convert.ToInt32(mStr.Split(';')[1]);
                            mStr = sReader.ReadLine();//[Point];[Position];[Force]
                            #region 将所有的点录入List
                            for (int i = 0; i < recordLength; i++)
                            {
                                mStr = sReader.ReadLine();
                                switch (recordIndex)
                                {
                                    case 1:
                                        mPoints1.Add(new mPoint(mStr.Split(';')[0], mStr.Split(';')[1], mStr.Split(';')[2]));
                                        break;
                                    case 2:
                                        mPoints2.Add(new mPoint(mStr.Split(';')[0], mStr.Split(';')[1], mStr.Split(';')[2]));
                                        break;
                                    default:
                                        break;
                                }
                            } 
                            #endregion

                            switch (recordIndex)
                            {
                                case 1:
                                    listBox1.Items.Add("Record 1");
                                    for (int i = 1; i < mPoints1.Count-1; i++)
                                    {
                                        deltaPoints_position.Add(((mPoints1[i + 1].Force - mPoints1[i].Force) / ((mPoints1[i + 1].Position - mPoints1[i].Position)))
                                            - ((mPoints1[i].Force - mPoints1[i - 1].Force) / ((mPoints1[i].Position - mPoints1[i - 1].Position))));
                                        deltaPoints_time.Add(((mPoints1[i + 1].Force - mPoints1[i].Force))
                                            - ((mPoints1[i].Force - mPoints1[i - 1].Force)));
                                        ks.Add((mPoints1[i].Force - mPoints1[i - 1].Force) / ((mPoints1[i].Position - mPoints1[i - 1].Position)));
                                    }

                                    bool b_Triggered = false;
                                    for (int i = 0; i < ks.Count; i++)
                                    {
                                        if (!b_Triggered)//寻找连续大于
                                        {
                                            if (ks[i] >= Convert.ToDouble(nUD_K.Value))
                                            {
                                                bool b_Continuity = true;
                                                for (int j = 0; j < Convert.ToInt32(nUD_Continuity.Value); j++)
                                                {
                                                    if (ks[i + 1 + j] < Convert.ToDouble(nUD_K.Value))
                                                    {
                                                        b_Continuity = false;
                                                    }
                                                }
                                                if (b_Continuity)//满足连续性，b_Triggered至1，jumpPoints.Add
                                                {
                                                    b_Triggered = true;
                                                    jumpPoints.Add(mPoints1[i + 1]);
                                                }
                                            }
                                        }
                                        else//寻找连续小于
                                        {
                                            if (ks[i] < Convert.ToDouble(nUD_K.Value))
                                            {
                                                bool b_Continuity = true;
                                                for (int j = 0; j < Convert.ToInt32(nUD_Continuity.Value); j++)
                                                {
                                                    if (ks[i + 1 + j] >= Convert.ToDouble(nUD_K.Value))
                                                    {
                                                        b_Continuity = false;
                                                    }
                                                }
                                                if (b_Continuity)//满足连续性，b_Triggered至0，dropPoints.Add
                                                {
                                                    b_Triggered = false;
                                                    dropPoints.Add(mPoints1[i + 1]);
                                                }
                                            }
                                        }                                        
                                    }
                                    for (int i = 0; i < jumpPoints.Count; i++)
                                    {
                                        listBox1.Items.Add("jumpPoints     Index:" + jumpPoints[i].Index.ToString() + 
                                        " Position:" + jumpPoints[i].Position.ToString() +
                                        " Force:" + jumpPoints[i].Force.ToString());
                                    }
                                    //maxIndex = deltaPoints_position.FindIndex(item => item.Equals(deltaPoints_position.Max()));
                                    //minIndex = deltaPoints_position.FindIndex(item => item.Equals(deltaPoints_position.Min()));
                                    //listBox1.Items.Add("Max_position     Index:" + (maxIndex + 1).ToString() + 
                                    //    " Position:" + mPoints1[maxIndex + 1].Position.ToString() +
                                    //    " Force:" + mPoints1[maxIndex + 1].Force.ToString());
                                    //listBox1.Items.Add("Min_position     Index:" + (minIndex + 1).ToString() +
                                    //    " Position:" + mPoints1[minIndex + 1].Position.ToString() +
                                    //    " Force:" + mPoints1[minIndex + 1].Force.ToString());
                                    //for (int i = 0; i < ks.Count; i++)
                                    //{
                                    //    if (ks[i] > Convert.ToDouble(nUD_K.Value))
                                    //    {
                                    //        bool b_Continuity = true;
                                    //        for (int j = 0; j < Convert.ToInt32(nUD_Continuity.Value); j++)
                                    //        {
                                    //            if (ks[i+1+j]< Convert.ToDouble(nUD_K.Value))
                                    //            {
                                    //                b_Continuity = false;
                                    //            }
                                    //        }
                                    //        if (b_Continuity)
                                    //        {
                                    //            touchIndex = i;
                                    //        break;
                                    //        }
                                            
                                    //    }
                                    //}
                                    //listBox1.Items.Add("接触点     Index:" + (touchIndex + 1).ToString() +
                                    //    " Position:" + mPoints1[touchIndex + 1].Position.ToString() +
                                    //    " Force:" + mPoints1[touchIndex + 1].Force.ToString());
                                    //maxIndex = deltaPoints_time.FindIndex(item => item.Equals(deltaPoints_time.Max()));
                                    //minIndex = deltaPoints_time.FindIndex(item => item.Equals(deltaPoints_time.Min()));
                                    //listBox1.Items.Add("陡增点     Index:" + (maxIndex + 1).ToString() + 
                                    //    " Position:" + mPoints1[maxIndex + 1].Position.ToString() +
                                    //    " Force:" + mPoints1[maxIndex + 1].Force.ToString());
                                    //listBox1.Items.Add("突降点     Index:" + (minIndex + 1).ToString() +
                                    //    " Position:" + mPoints1[minIndex + 1].Position.ToString() +
                                    //    " Force:" + mPoints1[minIndex + 1].Force.ToString());
                                    deltaPoints_position = new List<double>();
                                    deltaPoints_time = new List<double>();
                                    ks = new List<double>();
                                    break;
                                case 2:
                                    listBox1.Items.Add("Record 2");
                                    for (int i = 1; i < mPoints2.Count-1; i++)
                                    {
                                        deltaPoints_position.Add(((mPoints2[i + 1].Force - mPoints2[i].Force) / ((mPoints2[i + 1].Position - mPoints2[i].Position)* 1000))
                                            - ((mPoints2[i].Force - mPoints2[i - 1].Force) / ((mPoints2[i].Position - mPoints2[i - 1].Position) * 1000)));
                                        deltaPoints_time.Add(((mPoints2[i + 1].Force - mPoints2[i].Force))
                                            - ((mPoints2[i].Force - mPoints2[i - 1].Force)));
                                        ks.Add((mPoints2[i].Force - mPoints2[i - 1].Force) / ((mPoints2[i].Position - mPoints2[i - 1].Position)*10));
                                    }
                                    //maxIndex = deltaPoints_position.FindIndex(item => item.Equals(deltaPoints_position.Max()));
                                    //minIndex = deltaPoints_position.FindIndex(item => item.Equals(deltaPoints_position.Min()));
                                    //listBox1.Items.Add("Max_position     Index:" + (maxIndex + 1).ToString() + 
                                    //    " Position:" + mPoints2[maxIndex + 1].Position.ToString() +
                                    //    " Force:" + mPoints2[maxIndex + 1].Force.ToString());
                                    //listBox1.Items.Add("Min_position     Index:" + (minIndex + 1).ToString() +
                                    //    " Position:" + mPoints2[minIndex + 1].Position.ToString() +
                                    //    " Force:" + mPoints2[minIndex + 1].Force.ToString());

                                    maxIndex = deltaPoints_time.FindIndex(item => item.Equals(deltaPoints_time.Max()));
                                    minIndex = deltaPoints_time.FindIndex(item => item.Equals(deltaPoints_time.Min()));
                                    listBox1.Items.Add("陡增点     Index:" + (maxIndex + 1).ToString() + 
                                        " Position:" + mPoints2[maxIndex + 1].Position.ToString() +
                                        " Force:" + mPoints2[maxIndex + 1].Force.ToString());
                                    listBox1.Items.Add("突降点     Index:" + (minIndex + 1).ToString() +
                                        " Position:" + mPoints2[minIndex + 1].Position.ToString() +
                                        " Force:" + mPoints2[minIndex + 1].Force.ToString());
                                    deltaPoints_position = new List<double>();
                                    deltaPoints_time = new List<double>();
                                    ks = new List<double>();
                                    break;
                                default:
                                    break;
                            }
                        } 
                    }
                }
                mResult = true;
            }
            writeLog(label3.Text + " Index:" + jumpPoints[1].Index.ToString() +
                                        " Position:" + jumpPoints[1].Position.ToString() +
                                        " Force:" + jumpPoints[1].Force.ToString());
            return mResult;
        }

        public void writeLog(string content, params object[] logStringFormatArgs)
        {
            string line = string.Empty;
            const string LOG_DIR = "logs";
            string logFilePath = Path.Combine(LOG_DIR, DateTime.Now.ToString("yyyy-MM-dd") + ".log");
            if (!Directory.Exists(LOG_DIR)) Directory.CreateDirectory(LOG_DIR);
            line = string.IsNullOrWhiteSpace(content) ? "\r\n" : DateTime.Now.ToString("HH:mm:ss") + ": " + String.Format(content.TrimEnd(), logStringFormatArgs) + "\r\n";
            StreamWriter logFile = new StreamWriter(logFilePath, true, Encoding.UTF8);
            logFile.Write(line);
            logFile.Close();
            logFile.Dispose();

        }
        private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                button1.Text = "Start";
                button1.Enabled = true;
                //fileSystemWatcher1.Path = folderBrowserDialog1.SelectedPath;
                //fileSystemWatcher1.IncludeSubdirectories = false;
                //fileSystemWatcher1.Created += new FileSystemEventHandler(fileSystemWatcher1_Created);
            }
        }
    }
}