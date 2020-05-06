namespace Get_BreakPoint
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbl_Value = new System.Windows.Forms.Label();
            this.panel_Tools = new System.Windows.Forms.Panel();
            this.btn_CaptureDIsplay = new System.Windows.Forms.Button();
            this.btn_BundlePlot = new System.Windows.Forms.Button();
            this.btn_Move = new System.Windows.Forms.Button();
            this.btn_Reduce = new System.Windows.Forms.Button();
            this.btn_Enlarge = new System.Windows.Forms.Button();
            this.btn_AutoZoom = new System.Windows.Forms.Button();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nUD_K = new System.Windows.Forms.NumericUpDown();
            this.nUD_Continuity = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nUD_MinX_Value = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel_Tools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_K)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Continuity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_MinX_Value)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.Font = new System.Drawing.Font("MetaPlusLF", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(538, 18);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 31);
            this.button1.TabIndex = 1;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("MetaPlusLF", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "WatchPath：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(13, 18, 13, 18);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(13, 18, 13, 18);
            this.panel1.Size = new System.Drawing.Size(652, 67);
            this.panel1.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("MetaPlusLF", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(129, 18);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(409, 28);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "C:\\Users\\CN0YLBBC\\Desktop\\YJKP Record";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseDoubleClick);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 258);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(652, 512);
            this.panel2.TabIndex = 4;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(650, 510);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lbl_Value);
            this.tabPage2.Controls.Add(this.panel_Tools);
            this.tabPage2.Controls.Add(this.chart1);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(642, 475);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Chart";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lbl_Value
            // 
            this.lbl_Value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_Value.AutoSize = true;
            this.lbl_Value.ForeColor = System.Drawing.Color.Orange;
            this.lbl_Value.Location = new System.Drawing.Point(462, 11);
            this.lbl_Value.Name = "lbl_Value";
            this.lbl_Value.Size = new System.Drawing.Size(0, 22);
            this.lbl_Value.TabIndex = 1;
            // 
            // panel_Tools
            // 
            this.panel_Tools.AutoScroll = true;
            this.panel_Tools.Controls.Add(this.btn_CaptureDIsplay);
            this.panel_Tools.Controls.Add(this.btn_BundlePlot);
            this.panel_Tools.Controls.Add(this.btn_Move);
            this.panel_Tools.Controls.Add(this.btn_Reduce);
            this.panel_Tools.Controls.Add(this.btn_Enlarge);
            this.panel_Tools.Controls.Add(this.btn_AutoZoom);
            this.panel_Tools.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel_Tools.Location = new System.Drawing.Point(588, 3);
            this.panel_Tools.Name = "panel_Tools";
            this.panel_Tools.Size = new System.Drawing.Size(51, 469);
            this.panel_Tools.TabIndex = 2;
            // 
            // btn_CaptureDIsplay
            // 
            this.btn_CaptureDIsplay.BackgroundImage = global::Get_BreakPoint.Properties.Resources.曲线对比__2_;
            this.btn_CaptureDIsplay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_CaptureDIsplay.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_CaptureDIsplay.Location = new System.Drawing.Point(0, 255);
            this.btn_CaptureDIsplay.Name = "btn_CaptureDIsplay";
            this.btn_CaptureDIsplay.Size = new System.Drawing.Size(51, 51);
            this.btn_CaptureDIsplay.TabIndex = 5;
            this.btn_CaptureDIsplay.UseVisualStyleBackColor = true;
            // 
            // btn_BundlePlot
            // 
            this.btn_BundlePlot.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_BundlePlot.BackgroundImage")));
            this.btn_BundlePlot.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_BundlePlot.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_BundlePlot.Location = new System.Drawing.Point(0, 204);
            this.btn_BundlePlot.Name = "btn_BundlePlot";
            this.btn_BundlePlot.Size = new System.Drawing.Size(51, 51);
            this.btn_BundlePlot.TabIndex = 4;
            this.btn_BundlePlot.UseVisualStyleBackColor = true;
            // 
            // btn_Move
            // 
            this.btn_Move.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Move.BackgroundImage")));
            this.btn_Move.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Move.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Move.Location = new System.Drawing.Point(0, 153);
            this.btn_Move.Name = "btn_Move";
            this.btn_Move.Size = new System.Drawing.Size(51, 51);
            this.btn_Move.TabIndex = 3;
            this.btn_Move.UseVisualStyleBackColor = true;
            // 
            // btn_Reduce
            // 
            this.btn_Reduce.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Reduce.BackgroundImage")));
            this.btn_Reduce.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Reduce.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Reduce.Location = new System.Drawing.Point(0, 102);
            this.btn_Reduce.Name = "btn_Reduce";
            this.btn_Reduce.Size = new System.Drawing.Size(51, 51);
            this.btn_Reduce.TabIndex = 2;
            this.btn_Reduce.UseVisualStyleBackColor = true;
            this.btn_Reduce.Click += new System.EventHandler(this.btn_Reduce_Click);
            // 
            // btn_Enlarge
            // 
            this.btn_Enlarge.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Enlarge.BackgroundImage")));
            this.btn_Enlarge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_Enlarge.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_Enlarge.Location = new System.Drawing.Point(0, 51);
            this.btn_Enlarge.Name = "btn_Enlarge";
            this.btn_Enlarge.Size = new System.Drawing.Size(51, 51);
            this.btn_Enlarge.TabIndex = 1;
            this.btn_Enlarge.UseVisualStyleBackColor = true;
            this.btn_Enlarge.Click += new System.EventHandler(this.btn_Enlarge_Click);
            // 
            // btn_AutoZoom
            // 
            this.btn_AutoZoom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_AutoZoom.BackgroundImage")));
            this.btn_AutoZoom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_AutoZoom.Dock = System.Windows.Forms.DockStyle.Top;
            this.btn_AutoZoom.Location = new System.Drawing.Point(0, 0);
            this.btn_AutoZoom.Name = "btn_AutoZoom";
            this.btn_AutoZoom.Size = new System.Drawing.Size(51, 51);
            this.btn_AutoZoom.TabIndex = 0;
            this.btn_AutoZoom.UseVisualStyleBackColor = true;
            this.btn_AutoZoom.Click += new System.EventHandler(this.btn_AutoZoom_Click);
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.IsVisibleInLegend = false;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            series4.IsVisibleInLegend = false;
            series4.Legend = "Legend1";
            series4.Name = "Series2";
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(636, 469);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.chart1_MouseMove);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(13, 17, 13, 18);
            this.tabPage1.Size = new System.Drawing.Size(642, 475);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "BreakPoint";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("MetaPlusLF", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 17);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "BreakPoint：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.listBox1.Font = new System.Drawing.Font("MetaPlusLF", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 22;
            this.listBox1.Location = new System.Drawing.Point(123, 17);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(506, 440);
            this.listBox1.TabIndex = 4;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 200);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(25, 18, 25, 18);
            this.panel3.Size = new System.Drawing.Size(652, 58);
            this.panel3.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("MetaPlusLF", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(25, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "FileName：";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 67);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(652, 133);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Params";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 231F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 251F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.nUD_K, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.nUD_Continuity, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.nUD_MinX_Value, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(646, 104);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 22);
            this.label4.TabIndex = 0;
            this.label4.Text = "K Threshold";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(86, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 22);
            this.label5.TabIndex = 1;
            this.label5.Text = "Continuity Condition";
            // 
            // nUD_K
            // 
            this.nUD_K.DecimalPlaces = 2;
            this.nUD_K.Location = new System.Drawing.Point(317, 3);
            this.nUD_K.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nUD_K.Name = "nUD_K";
            this.nUD_K.Size = new System.Drawing.Size(147, 28);
            this.nUD_K.TabIndex = 2;
            this.nUD_K.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // nUD_Continuity
            // 
            this.nUD_Continuity.Location = new System.Drawing.Point(317, 37);
            this.nUD_Continuity.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nUD_Continuity.Name = "nUD_Continuity";
            this.nUD_Continuity.Size = new System.Drawing.Size(147, 28);
            this.nUD_Continuity.TabIndex = 3;
            this.nUD_Continuity.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(86, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(153, 22);
            this.label6.TabIndex = 4;
            this.label6.Text = "Min. X_Axis Value";
            // 
            // nUD_MinX_Value
            // 
            this.nUD_MinX_Value.DecimalPlaces = 2;
            this.nUD_MinX_Value.Location = new System.Drawing.Point(317, 71);
            this.nUD_MinX_Value.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nUD_MinX_Value.Name = "nUD_MinX_Value";
            this.nUD_MinX_Value.Size = new System.Drawing.Size(147, 28);
            this.nUD_MinX_Value.TabIndex = 5;
            this.nUD_MinX_Value.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 770);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("MetaPlusLF", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel_Tools.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_K)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_Continuity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nUD_MinX_Value)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListBox listBox1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nUD_K;
        private System.Windows.Forms.NumericUpDown nUD_Continuity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nUD_MinX_Value;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lbl_Value;
        private System.Windows.Forms.Panel panel_Tools;
        private System.Windows.Forms.Button btn_CaptureDIsplay;
        private System.Windows.Forms.Button btn_BundlePlot;
        private System.Windows.Forms.Button btn_Move;
        private System.Windows.Forms.Button btn_Reduce;
        private System.Windows.Forms.Button btn_Enlarge;
        private System.Windows.Forms.Button btn_AutoZoom;
    }
}

