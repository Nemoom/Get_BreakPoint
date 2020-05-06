using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

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

        class mypoint //point类
        {
            public mypoint(string mPosition, string mForce)
            {
                Position = mPosition;
                Force = mForce;
            }
            public string Position { get; set; }
            public string Force { get; set; }
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
        List<mypoint> listp = new List<mypoint>();

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
                    listp = new List<mypoint>();
                    chart1.Series[0].Points.Clear();

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
                                            listp.Add(new mypoint(mStr.Split(';')[1], mStr.Split(';')[2]));
                                            break;
                                        case 2:
                                            mPoints2.Add(new mPoint(mStr.Split(';')[0], mStr.Split(';')[1], mStr.Split(';')[2]));
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                #endregion
                                chart1.Series[0].XValueMember = "Position";//将listp中所有Name元素作为X轴
                                chart1.Series[0].YValueMembers = "Force";//将listp中所有Value元素作为Y轴

                                switch (recordIndex)
                                {
                                    case 1:
                                        //chart1.DataSource = listp;
                                        //chart1.DataBind();
                                        
                                        listBox1.Items.Add("Record 1");
                                        for (int i = 1; i < mPoints1.Count - 1; i++)
                                        {
                                            if (Index_startX == 0 && mPoints1[i].Position > Convert.ToDouble(nUD_MinX_Value.Value))
                                            {
                                                Index_startX = i;
                                            }
                                            chart1.Series[0].Points.AddXY(mPoints1[i].Position, mPoints1[i].Force);
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
                                                    if (i + 1 + Convert.ToInt32(nUD_Continuity.Value) >= ks.Count)
                                                    {
                                                        b_Continuity = false;
                                                    }
                                                    else
                                                    {
                                                        for (int j = 0; j < Convert.ToInt32(nUD_Continuity.Value); j++)
                                                        {

                                                            if (ks[i + 1 + j] < Convert.ToDouble(nUD_K.Value))
                                                            {
                                                                b_Continuity = false;
                                                            }
                                                        }
                                                    }
                                                    
                                                    if (b_Continuity)//满足连续性，b_Triggered至1，jumpPoints.Add
                                                    {
                                                        b_Triggered = true;
                                                        jumpPoints.Add(mPoints1[i + 1]);
                                                    }
                                                    else
                                                    {
                                                        b_Triggered = false;
                                                    }
                                                }
                                            }
                                            //else//寻找骤降点（不合理）
                                            //{
                                            //    //if (ks[i] < Convert.ToDouble(nUD_K.Value))
                                            //    //{
                                            //    //    bool b_Continuity = true;
                                            //    //    for (int j = 0; j < Convert.ToInt32(nUD_Continuity.Value); j++)
                                            //    //    {
                                            //    //        if (ks[i + 1 + j] >= Convert.ToDouble(nUD_K.Value))
                                            //    //        {
                                            //    //            b_Continuity = false;
                                            //    //        }
                                            //    //    }
                                            //    //    if (b_Continuity)//满足连续性，b_Triggered至0，dropPoints.Add
                                            //    //    {
                                            //    //        b_Triggered = false;
                                            //    //        dropPoints.Add(mPoints1[i + 1]);
                                            //    //    }
                                            //    //}
                                            //}
                                        }
                                        chart1.Series[1].Points.Clear();
                                        for (int i = 0; i < jumpPoints.Count; i++)
                                        {
                                            listBox1.Items.Add("jumpPoints     Index:" + jumpPoints[i].Index.ToString() +
                                            " Position:" + jumpPoints[i].Position.ToString() +
                                            " Force:" + jumpPoints[i].Force.ToString());
                                            chart1.Series[1].Points.AddXY(jumpPoints[i].Position, jumpPoints[i].Force);
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
            if (jumpPoints.Count > 1)
            {
                //writeLog(label3.Text + " Index:" + jumpPoints[1].Index.ToString() +
                //            " Position:" + jumpPoints[1].Position.ToString() +
                //            " Force:" + jumpPoints[1].Force.ToString());
                writeCSV(jumpPoints[1].Index, jumpPoints[1].Position, jumpPoints[1].Force,
                    FileName.Split('_')[FileName.Split('_').Length - 1].Substring(0, 2) == "OK" ? "OK." : "NG",
                    FileName.Split('\\')[FileName.Split('\\').Length - 1]);
            }
            else if (jumpPoints.Count == 1)
            {
                writeCSV(jumpPoints[0].Index, jumpPoints[0].Position, jumpPoints[0].Force,
                    FileName.Split('_')[FileName.Split('_').Length - 1].Substring(0, 2) == "OK" ? "OK" : "NG",
                    FileName.Split('\\')[FileName.Split('\\').Length - 1]);
                //writeCSV(-1, -1, -1,
                //    FileName.Split('_')[FileName.Split('_').Length - 1].Substring(0, 2) == "OK" ? "OK" : "NG",
                //    FileName.Split('\\')[FileName.Split('\\').Length - 1]);
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
            ////////// Zoom into the X axis
            ////////chart1.ChartAreas[0].AxisX.ScaleView.Zoom(2, 3);

            //////// Enable range selection and zooming end user interface
            //////chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            //////chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            //////chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;

            ////////将滚动内嵌到坐标轴中
            //////chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

            //////// 设置滚动条的大小
            //////chart1.ChartAreas[0].AxisX.ScrollBar.Size = 10;

            //////// 设置滚动条的按钮的风格，下面代码是将所有滚动条上的按钮都显示出来
            //////chart1.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;

            ////////// 设置自动放大与缩小的最小量
            ////////chart1.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = double.NaN;
            ////////chart1.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 0.1;
            #region.......chart缩放功能.........

            // Enable range selection and zooming end user interface
            chart1.ChartAreas[0].CursorX.IsUserEnabled = true;
            chart1.ChartAreas[0].CursorX.IsUserSelectionEnabled = true;
            chart1.ChartAreas[0].AxisX.ScaleView.Zoomable = true;

            //将滚动内嵌到坐标轴中
            chart1.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;

            // 设置滚动条的大小
            chart1.ChartAreas[0].AxisX.ScrollBar.Size = 15;

            // 设置滚动条的按钮的风格
            chart1.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;

            // 设置自动放大与缩小的最小量
            chart1.ChartAreas[0].AxisX.ScaleView.SmallScrollSize = double.NaN;
            chart1.ChartAreas[0].AxisX.ScaleView.SmallScrollMinSize = 1;

            #endregion

            chart1.MouseWheel += new MouseEventHandler(chart1_MouseWheel);

            if (textBox1.Text != "")
            {
                button1_Click(sender, e);
            }
        }

        void chart1_MouseWheel(object sender, MouseEventArgs e)
        {
            //按住Ctrl，缩放
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {

                if (chart1.ChartAreas[0].AxisX.ScaleView.Size.ToString() == "NaN")
                {
                    chart1.ChartAreas[0].AxisX.ScaleView.Size = 1;
                }
                else
                {
                    if (e.Delta < 0)
                        chart1.ChartAreas[0].AxisX.ScaleView.Size += 4;
                    else
                    {
                        try
                        {
                            if (chart1.ChartAreas[0].AxisX.ScaleView.Size >4)
                            {
                                chart1.ChartAreas[0].AxisX.ScaleView.Size -= 4;
                            }
                            else
                            {
                                MessageBox.Show("MIN");
                            }
                        }
                        catch (Exception)
                        {
                            chart1.ChartAreas[0].AxisX.ScaleView.Size = 0;
                        }
                    }
                }

            }
            //不按Ctrl，滚动
            else
            {
                if (e.Delta < 0)
                    chart1.ChartAreas[0].AxisX.ScaleView.Position += 4;
                else
                    chart1.ChartAreas[0].AxisX.ScaleView.Position -= 4;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WatchPath != textBox1.Text||
                K_Threshold != Convert.ToDouble(nUD_K.Value)||
                Continuity != Convert.ToInt16(nUD_Continuity.Value)||
                Min_X != Convert.ToDouble(nUD_MinX_Value.Value))
            {
                if (MessageBox.Show("Save changes? ", "Confirm", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    // 保存
                    WatchPath = textBox1.Text;
                    K_Threshold = Convert.ToDouble(nUD_K.Value);
                    Continuity = Convert.ToInt16(nUD_Continuity.Value);
                    Min_X = Convert.ToDouble(nUD_MinX_Value.Value);
                }    
            }
                    
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (button1.Text != "Start")
            {
                button1_Click(sender, e);
            }
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            HitTestResult hit = chart1.HitTest(e.X, e.Y);
            if (hit.Series != null)
            {
                var xValue = hit.Series.Points[hit.PointIndex].XValue;
                var yValue = hit.Series.Points[hit.PointIndex].YValues.First();
                lbl_Value.Text = string.Format("{0:F0},{1:F0}", "x:" + xValue, "y:" + yValue);//textbox1也是自己建的一个专门用来显示的内容框，也可以用messagebox直接弹出内容
            }
            else
            {

            }
        }

        private void btn_AutoZoom_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();
        }

        private void btn_Enlarge_Click(object sender, EventArgs e)
        {
            //chart1.ChartAreas[0].AxisX.ScaleView.Zoom(chart1.ChartAreas[0].AxisX.ScaleView.ViewMinimum, 1.1, chart1.ChartAreas[0].AxisX.ScaleView.SizeType);
            if (chart1.ChartAreas[0].AxisX.ScaleView.Size.ToString()=="NaN")
            {
                chart1.ChartAreas[0].AxisX.ScaleView.Size = 0;
            }
            else
            {
                chart1.ChartAreas[0].AxisX.ScaleView.Size += 0.1;
            }
            
        }

        private void btn_Reduce_Click(object sender, EventArgs e)
        {
            if (chart1.ChartAreas[0].AxisX.ScaleView.Size.ToString() == "NaN")
            {
                chart1.ChartAreas[0].AxisX.ScaleView.Size = 0;
            }
            else
            {
                try
                {
                    if (chart1.ChartAreas[0].AxisX.ScaleView.Size>0.01)
                    {
                        chart1.ChartAreas[0].AxisX.ScaleView.Size -= 0.01;
                    }
                    else
                    {
                        MessageBox.Show("MIN");
                    }

                }
                catch (Exception)
                {
                    chart1.ChartAreas[0].AxisX.ScaleView.Size = 0;
                }
            }
        }
    }
}
