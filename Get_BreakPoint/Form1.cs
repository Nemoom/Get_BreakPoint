using System;
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
            if (button1.Text=="Start")
            {
                if (Directory.Exists(textBox1.Text))
                {
                    fileSystemWatcher1.Path = textBox1.Text;
                    fileSystemWatcher1.IncludeSubdirectories = false;
                    fileSystemWatcher1.Created += new FileSystemEventHandler(fileSystemWatcher1_Created);
                    fileSystemWatcher1.Changed += new FileSystemEventHandler(fileSystemWatcher1_Changed);
                    fileSystemWatcher1.EnableRaisingEvents = true;
                    button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
                    button1.Text = "Stop";
                }
                else
                {
                    MessageBox.Show("不存在的监控路径");
                }                
            }
            else
            {
                fileSystemWatcher1.EnableRaisingEvents = false;
                fileSystemWatcher1.Created -= new FileSystemEventHandler(fileSystemWatcher1_Created);
                fileSystemWatcher1.Changed -= new FileSystemEventHandler(fileSystemWatcher1_Changed);
                button1.BackColor = System.Drawing.SystemColors.Control;
                button1.Text = "Start";
            }
            
        }

        void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {
            //throw new NotImplementedException();
        }        

        void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            label3.Text = "FileName:" + e.Name;
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
            try
            {
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
                    int Index_startX = 0;
                    while (sReader.Peek() >= 0)
                    {
                        string mStr = sReader.ReadLine();
                        if (mStr.Length > 8)
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
                                        for (int i = 1; i < mPoints1.Count - 1; i++)
                                        {
                                            if (Index_startX != 0 && mPoints1[i].Position > Convert.ToDouble(nUD_MinX_Value.Value))
                                            {
                                                Index_startX = i;
                                            }
                                            deltaPoints_position.Add(((mPoints1[i + 1].Force - mPoints1[i].Force) / ((mPoints1[i + 1].Position - mPoints1[i].Position)))
                                                - ((mPoints1[i].Force - mPoints1[i - 1].Force) / ((mPoints1[i].Position - mPoints1[i - 1].Position))));
                                            deltaPoints_time.Add(((mPoints1[i + 1].Force - mPoints1[i].Force))
                                                - ((mPoints1[i].Force - mPoints1[i - 1].Force)));
                                            ks.Add((mPoints1[i].Force - mPoints1[i - 1].Force) / ((mPoints1[i].Position - mPoints1[i - 1].Position)));
                                        }

                                        bool b_Triggered = false;
                                        for (int i = Index_startX; i < ks.Count; i++)
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
                                    //case 2:
                                    //    listBox1.Items.Add("Record 2");
                                    //    for (int i = 1; i < mPoints2.Count - 1; i++)
                                    //    {
                                    //        deltaPoints_position.Add(((mPoints2[i + 1].Force - mPoints2[i].Force) / ((mPoints2[i + 1].Position - mPoints2[i].Position) * 1000))
                                    //            - ((mPoints2[i].Force - mPoints2[i - 1].Force) / ((mPoints2[i].Position - mPoints2[i - 1].Position) * 1000)));
                                    //        deltaPoints_time.Add(((mPoints2[i + 1].Force - mPoints2[i].Force))
                                    //            - ((mPoints2[i].Force - mPoints2[i - 1].Force)));
                                    //        ks.Add((mPoints2[i].Force - mPoints2[i - 1].Force) / ((mPoints2[i].Position - mPoints2[i - 1].Position) * 10));
                                    //    }
                                    //    //maxIndex = deltaPoints_position.FindIndex(item => item.Equals(deltaPoints_position.Max()));
                                    //    //minIndex = deltaPoints_position.FindIndex(item => item.Equals(deltaPoints_position.Min()));
                                    //    //listBox1.Items.Add("Max_position     Index:" + (maxIndex + 1).ToString() + 
                                    //    //    " Position:" + mPoints2[maxIndex + 1].Position.ToString() +
                                    //    //    " Force:" + mPoints2[maxIndex + 1].Force.ToString());
                                    //    //listBox1.Items.Add("Min_position     Index:" + (minIndex + 1).ToString() +
                                    //    //    " Position:" + mPoints2[minIndex + 1].Position.ToString() +
                                    //    //    " Force:" + mPoints2[minIndex + 1].Force.ToString());

                                    //    maxIndex = deltaPoints_time.FindIndex(item => item.Equals(deltaPoints_time.Max()));
                                    //    minIndex = deltaPoints_time.FindIndex(item => item.Equals(deltaPoints_time.Min()));
                                    //    listBox1.Items.Add("陡增点     Index:" + (maxIndex + 1).ToString() +
                                    //        " Position:" + mPoints2[maxIndex + 1].Position.ToString() +
                                    //        " Force:" + mPoints2[maxIndex + 1].Force.ToString());
                                    //    listBox1.Items.Add("突降点     Index:" + (minIndex + 1).ToString() +
                                    //        " Position:" + mPoints2[minIndex + 1].Position.ToString() +
                                    //        " Force:" + mPoints2[minIndex + 1].Force.ToString());
                                    //    deltaPoints_position = new List<double>();
                                    //    deltaPoints_time = new List<double>();
                                    //    ks = new List<double>();
                                    //    break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                    mResult = true;
                }                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            if (jumpPoints.Count > 0)
            {
                //writeLog(label3.Text + " Index:" + jumpPoints[1].Index.ToString() +
                //            " Position:" + jumpPoints[1].Position.ToString() +
                //            " Force:" + jumpPoints[1].Force.ToString());
                writeCSV(jumpPoints[0].Index, jumpPoints[0].Position, jumpPoints[0].Force,
                    FileName.Split('_')[FileName.Split('_').Length - 1].Substring(0, 2) == "OK" ? "OK" : "NG",
                    FileName.Split('\\')[FileName.Split('\\').Length - 1]);
            }
            else
            {
                //writeCSV(jumpPoints[0].Index, jumpPoints[0].Position, jumpPoints[0].Force, FileName.Split('_')[FileName.Split('_').Length - 1].Substring(0, 2), FileName.Split('\\')[FileName.Split('\\').Length - 1]);
                writeCSV(-1, -1, -1,
                    FileName.Split('_')[FileName.Split('_').Length - 1].Substring(0, 2) == "OK" ? "OK" : "NG",
                    FileName.Split('\\')[FileName.Split('\\').Length - 1]);
            }
            return mResult;
        }
        int mNo = 0;
        public void writeCSV(int Index,double Position,double Force,string Result,string FileName)
        {            
            string line = string.Empty;
            const string LOG_DIR = "logs";
            string csvFilePath = Path.Combine(LOG_DIR, DateTime.Now.ToString("yyyy-MM-dd") + ".csv");
            if (!Directory.Exists(LOG_DIR)) Directory.CreateDirectory(LOG_DIR);
            
            if (!File.Exists(csvFilePath))
            {
                //写入表头
                using (StreamWriter csvFile = new StreamWriter(csvFilePath, true, Encoding.UTF8))
                {
                    line = "No.,Index,Position(mm),Force(N),Result,FileName,Time(h:m:s)";
                    csvFile.WriteLine(line);
                }
                
                mNo = 1;
            }
            else
            {
                //StreamReader mReader = new StreamReader(csvFilePath);
                //while (mReader.ReadLine() != null)
                //{ mNo += 1; }
                //mReader.Close();
                if (mNo==0)
                {
                    string oldValue = string.Empty, newValue = string.Empty;
                    using (StreamReader read = new StreamReader(csvFilePath, true))
                    {
                        do
                        {
                            newValue = read.ReadLine();
                            oldValue = newValue != null ? newValue : oldValue;
                        } while (newValue != null);
                    }
                    if (oldValue=="")
                    {
                        mNo = 1;

                    }
                    else
                    {
                        try
                        {
                            mNo = Convert.ToInt32(oldValue.Split(',')[0]) + 1;
                        }
                        catch (Exception)
                        {
                            mNo = 1;
                        }

                    }
                }                
            }
            using (StreamWriter csvFile = new StreamWriter(csvFilePath, true, Encoding.UTF8))
            {
                if (Index != -1)
                {
                    line = mNo++.ToString() + ","
                        + Index.ToString() + "," + Position.ToString() + "," + Force.ToString() + ","
                        + Result + "," + FileName + "," + DateTime.Now.ToString("HH:mm:ss");
                }
                else
                {
                    line = mNo++.ToString() + ",NULL,NULL,NULL,"                        
                        + Result + "," + FileName + "," + DateTime.Now.ToString("HH:mm:ss");
                }
                csvFile.WriteLine(line);
            }          

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
                if (button1.Text != "Start")
                {
                    button1_Click(sender, e);
                }
                textBox1.Text = folderBrowserDialog1.SelectedPath;
                
                //fileSystemWatcher1.Path = folderBrowserDialog1.SelectedPath;
                //fileSystemWatcher1.IncludeSubdirectories = false;
                //fileSystemWatcher1.Created += new FileSystemEventHandler(fileSystemWatcher1_Created);
            }
        }

        public string WatchPath 
        {
            get
            {
                if (File.Exists("config.ini"))
                {
                    IniFile ini = new IniFile("config.ini");
                    if (!ini.KeyExists("WatchPath"))
                    {
                        return "";
                    }
                    string s_max = ini.Read("WatchPath");
                    try
                    {
                        return s_max;
                    }
                    catch (Exception)
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }
            set
            {
                IniFile ini = new IniFile("config.ini");
                ini.Write("WatchPath", value.ToString());
                //if (File.Exists("config.ini"))
                //{
                    
                //}
            }
        }

        public double K_Threshold
        {
            get
            {
                if (File.Exists("config.ini"))
                {
                    IniFile ini = new IniFile("config.ini");
                    if (!ini.KeyExists("K_Threshold"))
                    {
                        return -1;
                    }
                    string s_max = ini.Read("K_Threshold");
                    try
                    {
                        return Convert.ToDouble(s_max);
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                IniFile ini = new IniFile("config.ini");
                ini.Write("K_Threshold", value.ToString());
            }
        }

        public double Min_X
        {
            get
            {
                if (File.Exists("config.ini"))
                {
                    IniFile ini = new IniFile("config.ini");
                    if (!ini.KeyExists("Min_X"))
                    {
                        return -1;
                    }
                    string s_max = ini.Read("Min_X");
                    try
                    {
                        return Convert.ToDouble(s_max);
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                IniFile ini = new IniFile("config.ini");
                ini.Write("Min_X", value.ToString());
            }
        }

        public int Continuity
        {
            get
            {
                if (File.Exists("config.ini"))
                {
                    IniFile ini = new IniFile("config.ini");
                    if (!ini.KeyExists("Continuity"))
                    {
                        return -1;
                    }
                    string s_max = ini.Read("Continuity");
                    try
                    {
                        return Convert.ToInt16(s_max);
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                IniFile ini = new IniFile("config.ini");
                ini.Write("Continuity", value.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = WatchPath;
            nUD_K.Value = Convert.ToDecimal(K_Threshold);
            nUD_Continuity.Value = Convert.ToDecimal(Continuity);
            nUD_MinX_Value.Value = Convert.ToDecimal(Min_X);
            if (textBox1.Text != "")
            {
                button1_Click(sender, e);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            WatchPath = textBox1.Text;
            K_Threshold = Convert.ToDouble(nUD_K.Value);
            Continuity = Convert.ToInt16(nUD_Continuity.Value);
            Min_X = Convert.ToDouble(nUD_MinX_Value.Value);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (button1.Text != "Start")
            {
                button1_Click(sender, e);
            }
        }
    }
}
