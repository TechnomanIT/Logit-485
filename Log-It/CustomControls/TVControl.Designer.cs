namespace Log_It.CustomControls
{
    partial class TVControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TVControl));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.tankT = new Log_It.CustomControls.BarPack();
            this.tankH = new Log_It.CustomControls.BarPack();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.colorChangerImproperShutdown = new System.Windows.Forms.Button();
            this.colorChangerInterval = new System.Windows.Forms.Button();
            this.colorChangerStopLine = new System.Windows.Forms.Button();
            this.colorChangerStartLine = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.colorChangerTLabels = new System.Windows.Forms.Button();
            this.colorChangerTLine = new System.Windows.Forms.Button();
            this.colorChangerTLimits = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.colorChangerHLabels = new System.Windows.Forms.Button();
            this.colorChangerHLine = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.colorChangerHLimits = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkAutoLimit = new System.Windows.Forms.CheckBox();
            this.comboGraphMode = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.comboTimeScale = new System.Windows.Forms.ComboBox();
            this.changerNoOfPartitions = new System.Windows.Forms.NumericUpDown();
            this.lblPartitions = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.changerHLRange = new System.Windows.Forms.NumericUpDown();
            this.changerHURange = new System.Windows.Forms.NumericUpDown();
            this.label22 = new System.Windows.Forms.Label();
            this.changerHLLimit = new System.Windows.Forms.NumericUpDown();
            this.label23 = new System.Windows.Forms.Label();
            this.changerHULimit = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.changerTLRange = new System.Windows.Forms.NumericUpDown();
            this.changerTURange = new System.Windows.Forms.NumericUpDown();
            this.changerTLLimit = new System.Windows.Forms.NumericUpDown();
            this.changerTULimit = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.pDoc = new System.Drawing.Printing.PrintDocument();
            this.ppreview = new System.Windows.Forms.PrintPreviewDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.ChartMenu = new System.Windows.Forms.ContextMenu();
            this.mnuPrintChart = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.records1 = new DAL.Records();
            this.chart = new Log_It.CustomControls.Chart();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changerNoOfPartitions)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changerHLRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.changerHURange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.changerHLLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.changerHULimit)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.changerTLRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.changerTURange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.changerTLLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.changerTULimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.records1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.tankT);
            this.panel1.Controls.Add(this.tankH);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Location = new System.Drawing.Point(632, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 586);
            this.panel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 555);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Print";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // tankT
            // 
            this.tankT.AlaramActive = false;
            //this.tankT.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(155)))), ((int)(((byte)(213)))));
            this.tankT.Caption = "Temprature";
            this.tankT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tankT.LLimit = 0F;
            this.tankT.Location = new System.Drawing.Point(8, 21);
            this.tankT.Max = 0F;
            this.tankT.Min = 0F;
            this.tankT.Name = "tankT";
            this.tankT.NumericFormat = "00.0;-00.0";
            this.tankT.Padding = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.tankT.Size = new System.Drawing.Size(158, 240);
            this.tankT.TabIndex = 4;
            this.tankT.ULimit = 0F;
            this.tankT.Unit = " °C";
            this.tankT.Value = 0F;
            // 
            // tankH
            // 
            this.tankH.AlaramActive = false;
            //this.tankH.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(155)))), ((int)(((byte)(213)))));
            this.tankH.Caption = "Temprature";
            this.tankH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tankH.LLimit = 0F;
            this.tankH.Location = new System.Drawing.Point(172, 21);
            this.tankH.Max = 0F;
            this.tankH.Min = 0F;
            this.tankH.Name = "tankH";
            this.tankH.NumericFormat = "00.0;-00.0";
            this.tankH.Padding = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.tankH.Size = new System.Drawing.Size(158, 240);
            this.tankH.TabIndex = 3;
            this.tankH.ULimit = 0F;
            this.tankH.Unit = " °C";
            this.tankH.Value = 0F;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(13, 305);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(334, 248);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.colorChangerImproperShutdown);
            this.tabPage1.Controls.Add(this.colorChangerInterval);
            this.tabPage1.Controls.Add(this.colorChangerStopLine);
            this.tabPage1.Controls.Add(this.colorChangerStartLine);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(326, 222);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Color";
            // 
            // colorChangerImproperShutdown
            // 
            this.colorChangerImproperShutdown.BackColor = System.Drawing.Color.Teal;
            this.colorChangerImproperShutdown.Location = new System.Drawing.Point(155, 80);
            this.colorChangerImproperShutdown.Name = "colorChangerImproperShutdown";
            this.colorChangerImproperShutdown.Size = new System.Drawing.Size(45, 23);
            this.colorChangerImproperShutdown.TabIndex = 13;
            this.colorChangerImproperShutdown.UseVisualStyleBackColor = false;
            this.colorChangerImproperShutdown.Click += new System.EventHandler(this.colorChangerImproperShutdown_Click);
            // 
            // colorChangerInterval
            // 
            this.colorChangerInterval.BackColor = System.Drawing.Color.Olive;
            this.colorChangerInterval.Location = new System.Drawing.Point(155, 54);
            this.colorChangerInterval.Name = "colorChangerInterval";
            this.colorChangerInterval.Size = new System.Drawing.Size(45, 23);
            this.colorChangerInterval.TabIndex = 12;
            this.colorChangerInterval.UseVisualStyleBackColor = false;
            this.colorChangerInterval.Click += new System.EventHandler(this.colorChangerInterval_Click);
            // 
            // colorChangerStopLine
            // 
            this.colorChangerStopLine.BackColor = System.Drawing.Color.Maroon;
            this.colorChangerStopLine.Location = new System.Drawing.Point(241, 22);
            this.colorChangerStopLine.Name = "colorChangerStopLine";
            this.colorChangerStopLine.Size = new System.Drawing.Size(45, 23);
            this.colorChangerStopLine.TabIndex = 11;
            this.colorChangerStopLine.UseVisualStyleBackColor = false;
            this.colorChangerStopLine.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // colorChangerStartLine
            // 
            this.colorChangerStartLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.colorChangerStartLine.Location = new System.Drawing.Point(81, 22);
            this.colorChangerStartLine.Name = "colorChangerStartLine";
            this.colorChangerStartLine.Size = new System.Drawing.Size(45, 23);
            this.colorChangerStartLine.TabIndex = 10;
            this.colorChangerStartLine.UseVisualStyleBackColor = false;
            this.colorChangerStartLine.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.colorChangerTLabels);
            this.groupBox1.Controls.Add(this.colorChangerTLine);
            this.groupBox1.Controls.Add(this.colorChangerTLimits);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Location = new System.Drawing.Point(19, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 88);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Temperature";
            // 
            // colorChangerTLabels
            // 
            this.colorChangerTLabels.BackColor = System.Drawing.Color.Maroon;
            this.colorChangerTLabels.Location = new System.Drawing.Point(62, 60);
            this.colorChangerTLabels.Name = "colorChangerTLabels";
            this.colorChangerTLabels.Size = new System.Drawing.Size(45, 23);
            this.colorChangerTLabels.TabIndex = 16;
            this.colorChangerTLabels.UseVisualStyleBackColor = false;
            this.colorChangerTLabels.Click += new System.EventHandler(this.colorChangerTLabels_Click);
            // 
            // colorChangerTLine
            // 
            this.colorChangerTLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.colorChangerTLine.Location = new System.Drawing.Point(62, 37);
            this.colorChangerTLine.Name = "colorChangerTLine";
            this.colorChangerTLine.Size = new System.Drawing.Size(45, 23);
            this.colorChangerTLine.TabIndex = 15;
            this.colorChangerTLine.UseVisualStyleBackColor = false;
            this.colorChangerTLine.Click += new System.EventHandler(this.colorChangerTLine_Click);
            // 
            // colorChangerTLimits
            // 
            this.colorChangerTLimits.BackColor = System.Drawing.Color.Red;
            this.colorChangerTLimits.Location = new System.Drawing.Point(62, 14);
            this.colorChangerTLimits.Name = "colorChangerTLimits";
            this.colorChangerTLimits.Size = new System.Drawing.Size(45, 23);
            this.colorChangerTLimits.TabIndex = 14;
            this.colorChangerTLimits.UseVisualStyleBackColor = false;
            this.colorChangerTLimits.Click += new System.EventHandler(this.colorChangerTLimits_Click);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 16);
            this.label10.TabIndex = 0;
            this.label10.Text = "Limits";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(8, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 16);
            this.label11.TabIndex = 0;
            this.label11.Text = "Line";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(8, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 16);
            this.label13.TabIndex = 0;
            this.label13.Text = "Labels";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.colorChangerHLabels);
            this.groupBox2.Controls.Add(this.colorChangerHLine);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.colorChangerHLimits);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Location = new System.Drawing.Point(187, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(120, 88);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Humidity";
            // 
            // colorChangerHLabels
            // 
            this.colorChangerHLabels.BackColor = System.Drawing.Color.Navy;
            this.colorChangerHLabels.Location = new System.Drawing.Point(59, 60);
            this.colorChangerHLabels.Name = "colorChangerHLabels";
            this.colorChangerHLabels.Size = new System.Drawing.Size(45, 23);
            this.colorChangerHLabels.TabIndex = 19;
            this.colorChangerHLabels.UseVisualStyleBackColor = false;
            this.colorChangerHLabels.Click += new System.EventHandler(this.colorChangerHLabels_Click);
            // 
            // colorChangerHLine
            // 
            this.colorChangerHLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.colorChangerHLine.Location = new System.Drawing.Point(59, 37);
            this.colorChangerHLine.Name = "colorChangerHLine";
            this.colorChangerHLine.Size = new System.Drawing.Size(45, 23);
            this.colorChangerHLine.TabIndex = 18;
            this.colorChangerHLine.UseVisualStyleBackColor = false;
            this.colorChangerHLine.Click += new System.EventHandler(this.colorChangerHLine_Click);
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(8, 64);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 16);
            this.label15.TabIndex = 0;
            this.label15.Text = "Labels";
            // 
            // colorChangerHLimits
            // 
            this.colorChangerHLimits.BackColor = System.Drawing.Color.Blue;
            this.colorChangerHLimits.Location = new System.Drawing.Point(59, 14);
            this.colorChangerHLimits.Name = "colorChangerHLimits";
            this.colorChangerHLimits.Size = new System.Drawing.Size(45, 23);
            this.colorChangerHLimits.TabIndex = 17;
            this.colorChangerHLimits.UseVisualStyleBackColor = false;
            this.colorChangerHLimits.Click += new System.EventHandler(this.colorChangerHLimits_Click);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(8, 40);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 16);
            this.label16.TabIndex = 0;
            this.label16.Text = "Line";
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(8, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 16);
            this.label17.TabIndex = 0;
            this.label17.Text = "Limits";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(27, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Interval Changed Line";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(27, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Improper Shutdown Line";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(27, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Start Line:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(187, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Stop Line:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.chkAutoLimit);
            this.tabPage2.Controls.Add(this.comboGraphMode);
            this.tabPage2.Controls.Add(this.label30);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(326, 222);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "General";
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // chkAutoLimit
            // 
            this.chkAutoLimit.AutoSize = true;
            this.chkAutoLimit.Location = new System.Drawing.Point(38, 137);
            this.chkAutoLimit.Name = "chkAutoLimit";
            this.chkAutoLimit.Size = new System.Drawing.Size(77, 17);
            this.chkAutoLimit.TabIndex = 6;
            this.chkAutoLimit.Text = "Auto Limits";
            this.chkAutoLimit.UseVisualStyleBackColor = true;
            this.chkAutoLimit.CheckedChanged += new System.EventHandler(this.chkAutoLimit_CheckedChanged);
            // 
            // comboGraphMode
            // 
            this.comboGraphMode.Items.AddRange(new object[] {
            "Real Time",
            "Loggin",
            "Logging [View]"});
            this.comboGraphMode.Location = new System.Drawing.Point(133, 103);
            this.comboGraphMode.Name = "comboGraphMode";
            this.comboGraphMode.Size = new System.Drawing.Size(146, 21);
            this.comboGraphMode.TabIndex = 2;
            this.comboGraphMode.SelectedIndexChanged += new System.EventHandler(this.comboGraphMode_SelectedIndexChanged_1);
            this.comboGraphMode.Click += new System.EventHandler(this.comboGraphMode_Click);
            // 
            // label30
            // 
            this.label30.Location = new System.Drawing.Point(35, 106);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(112, 16);
            this.label30.TabIndex = 3;
            this.label30.Text = "Graph Mode";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.comboTimeScale);
            this.groupBox5.Controls.Add(this.changerNoOfPartitions);
            this.groupBox5.Controls.Add(this.lblPartitions);
            this.groupBox5.Location = new System.Drawing.Point(27, 22);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(272, 75);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Page Length";
            // 
            // comboTimeScale
            // 
            this.comboTimeScale.FormattingEnabled = true;
            this.comboTimeScale.Items.AddRange(new object[] {
            "A Month [31 Days]",
            "A Week",
            "A Day",
            "An Hour",
            "User Defined [Days]",
            "User Defined [Hours]"});
            this.comboTimeScale.Location = new System.Drawing.Point(14, 19);
            this.comboTimeScale.Name = "comboTimeScale";
            this.comboTimeScale.Size = new System.Drawing.Size(238, 21);
            this.comboTimeScale.TabIndex = 3;
            this.comboTimeScale.SelectedIndexChanged += new System.EventHandler(this.comboTimeScale_SelectedIndexChanged);
            // 
            // changerNoOfPartitions
            // 
            this.changerNoOfPartitions.Location = new System.Drawing.Point(132, 46);
            this.changerNoOfPartitions.Name = "changerNoOfPartitions";
            this.changerNoOfPartitions.Size = new System.Drawing.Size(120, 20);
            this.changerNoOfPartitions.TabIndex = 2;
            this.changerNoOfPartitions.Leave += new System.EventHandler(this.changerNoOfPartitions_Leave);
            // 
            // lblPartitions
            // 
            this.lblPartitions.Location = new System.Drawing.Point(56, 50);
            this.lblPartitions.Name = "lblPartitions";
            this.lblPartitions.Size = new System.Drawing.Size(64, 16);
            this.lblPartitions.TabIndex = 1;
            this.lblPartitions.Text = "Partitions";
            this.lblPartitions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Controls.Add(this.groupBox3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(326, 222);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Limits/Ranges";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.changerHLRange);
            this.groupBox4.Controls.Add(this.changerHURange);
            this.groupBox4.Controls.Add(this.label22);
            this.groupBox4.Controls.Add(this.changerHLLimit);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.changerHULimit);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Location = new System.Drawing.Point(21, 120);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(264, 80);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Humidity";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(157, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "__";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // changerHLRange
            // 
            this.changerHLRange.Location = new System.Drawing.Point(85, 54);
            this.changerHLRange.Name = "changerHLRange";
            this.changerHLRange.Size = new System.Drawing.Size(66, 20);
            this.changerHLRange.TabIndex = 13;
            this.changerHLRange.Leave += new System.EventHandler(this.changerHLRange_Leave);
            // 
            // changerHURange
            // 
            this.changerHURange.Location = new System.Drawing.Point(187, 54);
            this.changerHURange.Name = "changerHURange";
            this.changerHURange.Size = new System.Drawing.Size(66, 20);
            this.changerHURange.TabIndex = 12;
            this.changerHURange.ValueChanged += new System.EventHandler(this.changerHURange_ValueChanged);
            this.changerHURange.Leave += new System.EventHandler(this.changerHURange_Leave);
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(8, 24);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(56, 16);
            this.label22.TabIndex = 0;
            this.label22.Text = "Limit";
            // 
            // changerHLLimit
            // 
            this.changerHLLimit.Location = new System.Drawing.Point(85, 25);
            this.changerHLLimit.Name = "changerHLLimit";
            this.changerHLLimit.Size = new System.Drawing.Size(66, 20);
            this.changerHLLimit.TabIndex = 11;
            this.changerHLLimit.Leave += new System.EventHandler(this.changerHLLimit_Leave);
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(8, 56);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(56, 16);
            this.label23.TabIndex = 0;
            this.label23.Text = "Range";
            // 
            // changerHULimit
            // 
            this.changerHULimit.Location = new System.Drawing.Point(187, 25);
            this.changerHULimit.Name = "changerHULimit";
            this.changerHULimit.Size = new System.Drawing.Size(66, 20);
            this.changerHULimit.TabIndex = 10;
            this.changerHULimit.Leave += new System.EventHandler(this.changerHULimit_Leave);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(157, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "__";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.changerTLRange);
            this.groupBox3.Controls.Add(this.changerTURange);
            this.groupBox3.Controls.Add(this.changerTLLimit);
            this.groupBox3.Controls.Add(this.changerTULimit);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Controls.Add(this.label21);
            this.groupBox3.Controls.Add(this.label24);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Location = new System.Drawing.Point(21, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(264, 80);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Temperature";
            // 
            // changerTLRange
            // 
            this.changerTLRange.Location = new System.Drawing.Point(85, 52);
            this.changerTLRange.Name = "changerTLRange";
            this.changerTLRange.Size = new System.Drawing.Size(66, 20);
            this.changerTLRange.TabIndex = 7;
            this.changerTLRange.Leave += new System.EventHandler(this.changerTLRange_Leave);
            // 
            // changerTURange
            // 
            this.changerTURange.Location = new System.Drawing.Point(187, 52);
            this.changerTURange.Name = "changerTURange";
            this.changerTURange.Size = new System.Drawing.Size(66, 20);
            this.changerTURange.TabIndex = 6;
            this.changerTURange.Leave += new System.EventHandler(this.changerTURange_Leave);
            // 
            // changerTLLimit
            // 
            this.changerTLLimit.Location = new System.Drawing.Point(85, 23);
            this.changerTLLimit.Name = "changerTLLimit";
            this.changerTLLimit.Size = new System.Drawing.Size(66, 20);
            this.changerTLLimit.TabIndex = 5;
            this.changerTLLimit.Leave += new System.EventHandler(this.changerTLLimit_Leave);
            // 
            // changerTULimit
            // 
            this.changerTULimit.Location = new System.Drawing.Point(187, 23);
            this.changerTULimit.Name = "changerTULimit";
            this.changerTULimit.Size = new System.Drawing.Size(66, 20);
            this.changerTULimit.TabIndex = 4;
            this.changerTULimit.Leave += new System.EventHandler(this.changerTULimit_Leave);
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(157, 25);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(24, 16);
            this.label25.TabIndex = 2;
            this.label25.Text = "__";
            this.label25.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(8, 27);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 16);
            this.label21.TabIndex = 0;
            this.label21.Text = "Limit";
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(8, 56);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(56, 16);
            this.label24.TabIndex = 0;
            this.label24.Text = "Range";
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(157, 54);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(24, 16);
            this.label26.TabIndex = 2;
            this.label26.Text = "__";
            this.label26.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pDoc
            // 
            this.pDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pDoc_PrintPage);
            // 
            // ppreview
            // 
            this.ppreview.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.ppreview.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.ppreview.ClientSize = new System.Drawing.Size(400, 300);
            this.ppreview.Document = this.pDoc;
            this.ppreview.Enabled = true;
            this.ppreview.Icon = ((System.Drawing.Icon)(resources.GetObject("ppreview.Icon")));
            this.ppreview.Name = "ppreview";
            this.ppreview.Visible = false;
            // 
            // ChartMenu
            // 
            this.ChartMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuPrintChart,
            this.menuItem1});
            // 
            // mnuPrintChart
            // 
            this.mnuPrintChart.Index = 0;
            this.mnuPrintChart.Text = "Print Chart";
            this.mnuPrintChart.Click += new System.EventHandler(this.mnuPrintChart_Click_1);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 1;
            this.menuItem1.Text = "Insert Comments";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // records1
            // 
            this.records1.DataSetName = "Records";
            this.records1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // chart
            // 
            this.chart.AutoLimit = false;
            this.chart.BackColor = System.Drawing.Color.White;
            this.chart.ChartType = Log_It.CustomControls.Chart.Graph.Circular;
            this.chart.ColorChangeIntervalLine = System.Drawing.Color.Green;
            this.chart.ColorHLimit = System.Drawing.Color.RoyalBlue;
            this.chart.ColorHLine = System.Drawing.Color.MediumBlue;
            this.chart.ColorHumidityFont = System.Drawing.Color.Blue;
            this.chart.ColorMajorGrid = System.Drawing.Color.Silver;
            this.chart.ColorMinorGrid = System.Drawing.Color.LightGray;
            this.chart.ColorPartition = System.Drawing.Color.Silver;
            this.chart.ColorPartitionMini = System.Drawing.Color.Gainsboro;
            this.chart.ColorScale = System.Drawing.Color.Gray;
            this.chart.ColorShutdownLine = System.Drawing.Color.Yellow;
            this.chart.ColorStartLine = System.Drawing.Color.DarkGreen;
            this.chart.ColorStopLine = System.Drawing.Color.DarkBlue;
            this.chart.ColorTempFont = System.Drawing.Color.Red;
            this.chart.ColorTLimit = System.Drawing.Color.Red;
            this.chart.ColorTLine = System.Drawing.Color.DarkRed;
            this.chart.DashLineLength = 10F;
            this.chart.DashLineSpace = 5F;
            this.chart.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chart.HumidityFinalValue = 100D;
            this.chart.HumidityInitialValue = 0D;
            this.chart.HumidityLowerLimitValue = 0D;
            this.chart.HumidityUpperLimitValue = 100D;
            this.chart.Interval = 1D;
            this.chart.Location = new System.Drawing.Point(19, 10);
            this.chart.MajorBlockSize = 5;
            this.chart.Mode = Log_It.CustomControls.PlottingMode.Realtime;
            this.chart.Name = "chart";
            this.chart.NumTimeScale = Log_It.CustomControls.Chart.Time.Hours_1;
            this.chart.OffSetRHRightLeft = 10;
            this.chart.OffSetRHUpDown = 4;
            this.chart.OffSetTempRightLeft = 10;
            this.chart.OffSetTempUpDown = 4;
            this.chart.Parameters = Log_It.CustomControls.Chart.NumberSquence.Both;
            this.chart.Partitions = 30;
            this.chart.PartitionsNum = 4;
            this.chart.Rotation = -45F;
            this.chart.Size = new System.Drawing.Size(552, 576);
            this.chart.StartWith = Log_It.CustomControls.StartingStyle.New;
            this.chart.TabIndex = 1;
            this.chart.TempFinalValue = 100D;
            this.chart.TempFirst = true;
            this.chart.TempInitialValue = 0D;
            this.chart.TempLowerLimitValue = 0D;
            this.chart.TempUpperLimitValue = 100D;
            // 
            // TVControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chart);
            this.Controls.Add(this.panel1);
            this.Name = "TVControl";
            this.Size = new System.Drawing.Size(984, 618);
            this.Load += new System.EventHandler(this.TVControl_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.changerNoOfPartitions)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.changerHLRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.changerHURange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.changerHLLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.changerHULimit)).EndInit();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.changerTLRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.changerTURange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.changerTLLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.changerTULimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.records1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Chart chart;
        private System.Drawing.Printing.PrintDocument pDoc;
        private System.Windows.Forms.PrintPreviewDialog ppreview;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button colorChangerStartLine;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button colorChangerStopLine;
        private System.Windows.Forms.Button colorChangerImproperShutdown;
        private System.Windows.Forms.Button colorChangerInterval;
        private System.Windows.Forms.Button colorChangerTLabels;
        private System.Windows.Forms.Button colorChangerTLine;
        private System.Windows.Forms.Button colorChangerTLimits;
        private System.Windows.Forms.Button colorChangerHLabels;
        private System.Windows.Forms.Button colorChangerHLine;
        private System.Windows.Forms.Button colorChangerHLimits;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblPartitions;
        private System.Windows.Forms.CheckBox chkAutoLimit;
        private System.Windows.Forms.ComboBox comboGraphMode;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.ComboBox comboTimeScale;
        private System.Windows.Forms.NumericUpDown changerNoOfPartitions;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown changerHLRange;
        private System.Windows.Forms.NumericUpDown changerHURange;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.NumericUpDown changerHLLimit;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.NumericUpDown changerHULimit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.NumericUpDown changerTLRange;
        private System.Windows.Forms.NumericUpDown changerTURange;
        private System.Windows.Forms.NumericUpDown changerTLLimit;
        private System.Windows.Forms.NumericUpDown changerTULimit;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.ContextMenu ChartMenu;
        private System.Windows.Forms.MenuItem mnuPrintChart;
        private System.Windows.Forms.MenuItem menuItem1;
        private DAL.Records records1;
        private BarPack tankT;
        private BarPack tankH;
        private System.Windows.Forms.Button button1;
    }
}
