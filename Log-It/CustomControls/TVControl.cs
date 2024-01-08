using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAL;
using Log_It.Forms;
using Log_It.CustomControls;
using System.Data.SqlClient;
using System.Globalization;

namespace Log_It.CustomControls
{
    public partial class TVControl : UserControl
    {

        public LogIt logitObj;
        public DateTime dt = DateTime.Now;

        DAL.Device_Config config;
        BAL.LogitInstance instance;
        public TVControl(LogitInstance instance)
        {

            this.instance = instance;
            InitializeComponent();
        }


        #region Properties

        public DAL.Device_Config ConfigItem { get; set; }

        public Color IntervalChangedColor
        {
            get { return this.chart.ColorChangeIntervalLine; }
            set
            {
                this.chart.ColorChangeIntervalLine = value;
                this.colorChangerStartLine.BackColor = value;
            }
        }

        public object OBJ
        {
            get;
            set;
        }

        public Color ImproperShutdownColor
        {
            get { return this.chart.ColorShutdownLine; }
            set
            {
                this.chart.ColorShutdownLine = value;
                this.colorChangerImproperShutdown.BackColor = value;
            }
        }
        public Color StopLineColor
        {
            get { return this.chart.ColorStopLine; }
            set
            {
                this.chart.ColorStopLine = value;
                this.colorChangerStopLine.BackColor = value;
            }
        }
        public Color StartLineColor
        {
            get { return this.chart.ColorStartLine; }
            set
            {
                this.chart.ColorStartLine = value;
                this.colorChangerStartLine.BackColor = value;
            }
        }
        public Color TLimitsColor
        {
            get { return this.chart.ColorTLimit; }
            set
            {
                this.chart.ColorTLimit = value;
                this.colorChangerTLimits.BackColor = value;
            }
        }
        public Color HLimitsColor
        {
            get { return this.chart.ColorHLimit; }
            set
            {
                this.chart.ColorHLimit = value;
                this.colorChangerHLimits.BackColor = value;
            }
        }
        public Color TLineColor
        {
            get { return this.chart.ColorTLine; }
            set
            {
                this.chart.ColorTLine = value;
                this.colorChangerTLine.BackColor = value;
            }
        }
        public Color HLineColor
        {
            get { return this.chart.ColorHLine; }
            set
            {
                this.chart.ColorHLine = value;
                this.colorChangerHLine.BackColor = value;
            }
        }
        public Color TLabelsColor
        {
            get { return this.chart.ColorTempFont; }
            set
            {
                this.chart.ColorTempFont = value;
                this.colorChangerTLabels.BackColor = value;
            }
        }
        public Color HLabelsColor
        {
            get { return this.chart.ColorHumidityFont; }
            set
            {
                this.chart.ColorHumidityFont = value;
                this.colorChangerHLabels.BackColor = value;
            }
        }
        public int NoOfPartitions
        {
            get
            {
                return this.chart.Partitions;
            }
            set
            {
                this.chart.Partitions = value;
                this.changerNoOfPartitions.Value = value;
            }
        }
        public Chart.Time NumTimeScale
        {
            get
            {
                return this.chart.NumTimeScale;
            }
            set
            {
                this.chart.NumTimeScale = value;
                this.comboTimeScale.SelectedValue = (int)value;
                this.comboGraphMode.SelectedIndex = (int)GraphMode;
            }

        }
        public PlottingMode GraphMode
        {
            get
            {
                return this.chart.Mode;
            }
            set
            {
                this.chart.Mode = value;
                this.comboGraphMode.SelectedValue = (int)value;
                this.comboTimeScale.SelectedIndex = (int)NumTimeScale;
            }
        }
        public bool AutoLimit
        {
            get
            {
                return this.chart.AutoLimit;
            }
            set
            {
                this.chart.AutoLimit = value;
                this.chkAutoLimit.Checked = value;
            }
        }
        public double TempUpperLimit
        {
            get
            {
                return this.chart.TempUpperLimitValue;
            }
            set
            {
                this.changerTULimit.Value = Convert.ToDecimal(value);
                this.chart.TempUpperLimitValue = value;
                this.tankT.ULimit = (float)value;
            }
        }
        public double TempLowerLimit
        {
            get
            {
                return this.chart.TempLowerLimitValue;
            }
            set
            {
                this.changerTLLimit.Value = Convert.ToDecimal(value);
                this.chart.TempLowerLimitValue = value;
                this.tankT.LLimit = (float)value;
            }

        }
        public double HumidityUpperLimit
        {
            get
            {
                return this.chart.HumidityUpperLimitValue;
            }
            set
            {
                this.chart.HumidityUpperLimitValue = value;
                this.changerHULimit.Value = Convert.ToDecimal(value);
                this.tankH.ULimit = (float)value;
            }
        }
        public double HumidityLowerLimit
        {
            get
            {
                return this.chart.HumidityLowerLimitValue;
            }
            set
            {
                this.chart.HumidityLowerLimitValue = value;
                this.changerHLLimit.Value = Convert.ToDecimal(value);
                this.tankH.LLimit = (float)value;
            }
        }
        public double TempLowerRange
        {
            get
            {
                return this.chart.TempInitialValue;
            }
            set
            {
                this.chart.TempInitialValue = value;
                this.changerTLRange.Value = Convert.ToDecimal(value);
                this.tankT.Min = (float)value;
            }

        }
        public double TempUpperRange
        {
            get
            {
                return this.chart.TempFinalValue;
            }
            set
            {
                this.chart.TempFinalValue = value;
                this.changerTURange.Value = Convert.ToDecimal(value);
                this.tankT.Max = (float)value;
            }
        }
        public double HumidityLowerRange
        {
            get
            {
                return this.chart.HumidityInitialValue;
            }
            set
            {
                this.chart.HumidityInitialValue = value;
                this.changerHLRange.Value = Convert.ToDecimal(value);
                this.tankH.Min = (float)value;
            }

        }
        public double HumidityUpperRange
        {
            get
            {
                return this.chart.HumidityFinalValue;
            }
            set
            {
                this.chart.HumidityFinalValue = value;
                this.changerHURange.Value = Convert.ToDecimal(value);
                this.tankH.Max = (float)value;
            }
        }
        public Chart Chart
        {
            get
            {
                return this.chart;
            }
        }
        public BarPack TankT
        {
            get
            {
                return this.tankT;
            }
        }
        public BarPack TankH
        {
            get
            {
                return this.tankH;
            }
        }
        #endregion


        #region Methods
        private void Picture(string path, Graphics g)
        {
            g.PageUnit = GraphicsUnit.Inch;
            g.DrawImage(Log_It.Properties.Resources.Untitled_1_copy, 0.5f, 0.5f);
           
        }

        private void CDName(string companyname, string deptname, Graphics g)
        {
            g.PageUnit = GraphicsUnit.Inch;
            float x = 8.0f, y = 1f;
            Font f = new Font("Arial", 16, System.Drawing.FontStyle.Bold);
            SizeF s1 = g.MeasureString(companyname, f);
            g.DrawString(companyname, f, Brushes.DarkBlue,
                x - s1.Width, y);
            f = new Font("Arial", 16);
            SizeF s2 = g.MeasureString(deptname, f);
            g.DrawString(deptname, f, Brushes.Black,
                x - s2.Width, s2.Height + y);
        }

        private void PrintDT(Graphics g)
        {
            g.PageUnit = GraphicsUnit.Inch;
            float x = 0.5f, y = 1.4f;
            string date = DateTime.Now.ToString("dd-MMMM-yyyy");
            string time = DateTime.Now.ToString("hh:mm:ss tt");
            Font f = new Font("Americana BT", 10);
            SizeF s1 = g.MeasureString(date, f);
            g.DrawString(date.ToUpper(), f, Brushes.DarkBlue,
                x, y);
            SizeF s2 = g.MeasureString(time, f);
            g.DrawString(time.ToUpper(), f, Brushes.Black,
                x, s2.Height + y);
        }

        private void ChartHeading(Graphics g, string Heading)
        {
            g.PageUnit = GraphicsUnit.Inch;
            float x = 4.25f, y = 1.75f;
            Font f = new Font("Americana BT", 20, FontStyle.Bold | FontStyle.Underline);
            SizeF s = g.MeasureString(Heading, f);
            g.DrawString(Heading, f, Brushes.Black, x - (s.Width / 2), y);
        }

        private void ChannelDetail(Graphics g, object[] details)
        {
            g.PageUnit = GraphicsUnit.Inch;
            float x = 0.5f, y = 8.75f;
            Font f = new Font("MS Reference Sans Serif", 11, FontStyle.Bold | FontStyle.Underline);
            g.DrawString("Channel Details", f, Brushes.Black, x, y);

            f = new Font("MS Reference Sans Serif", 10);
            g.DrawString("Channel type:", f, Brushes.Black, x + 0.2f, y + 0.3f);
            g.DrawString("Location:", f, Brushes.Black, x + 0.2f, y + 0.5f);
            g.DrawString("Instrument:", f, Brushes.Black, x + 0.2f, y + 0.7f);
            g.DrawString("Logging Interval:", f, Brushes.Black, x + 0.2f, y + 0.9f);
            g.DrawString("Logging On:", f, Brushes.Black, x + 0.2f, y + 1.1f);
            g.DrawString("Alarm On:", f, Brushes.Black, x + 0.2f, y + 1.3f);

            SizeF s = g.MeasureString("Logging Interval:i", f);

            f = new Font("MS Reference Sans Serif", 9);
            g.DrawString(details[0].ToString(), f, Brushes.Black, x + 0.2f + s.Width, y + 0.3f);
            g.DrawString(details[1].ToString(), f, Brushes.Black, x + 0.2f + s.Width, y + 0.5f);
            g.DrawString(details[2].ToString(), f, Brushes.Black, x + 0.2f + s.Width, y + 0.7f);
            g.DrawString(details[3].ToString(), f, Brushes.Black, x + 0.2f + s.Width, y + 0.9f);
            g.DrawString(details[4].ToString(), f, Brushes.Black, x + 0.2f + s.Width, y + 1.1f);
            g.DrawString(details[5].ToString(), f, Brushes.Black, x + 0.2f + s.Width, y + 1.3f);
        }

        private void ChartSummary(Graphics g, object[] summary)
        {
            g.PageUnit = GraphicsUnit.Inch;
            float x = 4.5f, y = 8.75f;
            Font f = new Font("MS Reference Sans Serif", 11, FontStyle.Bold | FontStyle.Underline);
            g.DrawString("Chart Summary", f, Brushes.Black, x, y);

            f = new Font("MS Reference Sans Serif", 10);
            g.DrawString("Start Date/Time:", f, Brushes.Black, x + 0.2f, y + 0.3f);
            g.DrawString("End Date/Time:", f, Brushes.Black, x + 0.2f, y + 0.5f);
            g.DrawString("No. of Records:", f, Brushes.Black, x + 0.2f, y + 0.7f);
            g.DrawString("Signature:", f, Brushes.Black, x + 0.2f, y + 0.9f);

            SizeF s = g.MeasureString("Start Date/Time:i", f);

            f = new Font("MS Reference Sans Serif", 9);
            g.DrawString(summary[0].ToString(), f, Brushes.Black, x + 0.2f + s.Width, y + 0.3f);
            g.DrawString(summary[1].ToString(), f, Brushes.Black, x + 0.2f + s.Width, y + 0.5f);
            g.DrawString(summary[2].ToString(), f, Brushes.Black, x + 0.2f + s.Width, y + 0.7f);
            g.DrawString(summary[3].ToString(), f, Brushes.Black, x + 0.2f + s.Width, y + 0.9f);
        }

        private void Legend(Graphics g, string parameter, Color color, int parano)
        {
            g.PageUnit = GraphicsUnit.Inch;
            float x = 4.5f, y = 8.94f;

            Font f = new Font("MS Reference Sans Serif", 10);
            g.DrawString(parameter + ":", f, Brushes.Black, x + 0.2f, y + 0.9f + ((float)parano / 5.0f));

            SizeF s = g.MeasureString("Start Date/Time:i", f);
            g.PageUnit = GraphicsUnit.Pixel;
            SolidBrush sb = new SolidBrush(color);
            g.FillRectangle(sb, (x + 0.2f + s.Width) * g.DpiX, (y + 0.965f + ((float)parano / 5.0f)) * g.DpiY, (0.5f) * g.DpiX, (0.1f) * g.DpiY);
        }

        private void Footer(Graphics g)
        {
            g.PageUnit = GraphicsUnit.Inch;
            float x = 5.5f, y = 10.5f;
            Font f = new Font("MS Reference Sans Serif", 12);
            g.DrawString("Logit Chart By TECHNOMAN", f, Brushes.Black, x, y);
        }

        private object[] GetChannelParameter()
        {
            object[] obj2 = new object[4];
            for (int i = 0; i < obj2.Length; i++)
            {
                obj2[i] = new object();
                obj2[i] = string.Empty;
            }

            if (this.logitObj.RhActive == true)
            {
                obj2[0] = this.custTable.Compute("MIN(DT)", "ID = '" + this.logitObj.ID + "'");
                obj2[1] = this.custTable.Compute("MAX(DT)", "ID = '" + this.logitObj.ID + "'");
                obj2[2] = this.custTable.Rows.Count;
                obj2[3] = this.instance.UserInstance.Full_Name;
            }
            else if (this.logitObj.RhActive == false)
            {
                obj2[0] = this.custTable.Compute("MIN(DT)", "Id = '" + this.logitObj.ID + "'");
                obj2[1] = this.custTable.Compute("MAX(DT)", "Id = '" + this.logitObj.ID + "'");
                obj2[2] = this.custTable.Rows.Count;
                obj2[3] = this.instance.UserInstance.Full_Name;
            }
            return obj2;
        }

        private void LogIt_Logging(string DeviceID, string DeviceType, double Temperature, double Humidity)
        {
            if (this.GraphMode == PlottingMode.Logging && DeviceID == this.logitObj.DeviceID)
            {
                DataRow dr;
                if (DeviceType == "01")
                {
                    dr = this.records1.RECODE1.NewRow();
                    dr["CHANNELID"] = DeviceID;
                    dr["DT"] = DateTime.Now;
                    dr["TEMP"] = Temperature;
                    dr["RH"] = Humidity;
                    dr["RECORDSTATUS"] = 0;
                    this.records1.RECODE1.Rows.Add(dr);
                    this.chart.Add(this.records1.RECODE1);
                }
                else if (DeviceType == "02")
                {
                    dr = this.records1.RECODE2.NewRow();
                    dr["CHANNELID"] = DeviceID;
                    dr["DT"] = DateTime.Now;
                    dr["TEMP"] = Temperature;
                    dr["RECORDSTATUS"] = 0;
                    this.records1.RECODE2.Rows.Add(dr);
                    this.chart.Add(this.records1.RECODE2);
                }
            }
        }

        public void HideHumidity()
        {
            this.tankH.Visible = false;
            this.chart.Parameters = Chart.NumberSquence.Temperature;
        }

        public void RealTimeData(LogIt logItObject)
        {
            TimeSpan ts = dt.Subtract(DateTime.Now);
            if ((ts.TotalMilliseconds * -1) > 1000 && (this.chart.Mode == PlottingMode.Realtime))
            {
                DataRow dr;
               
                DataRow myDataRow;
                myDataRow = custTable.NewRow();
                myDataRow["Id"] = logItObject.DeviceID;
                myDataRow["DT"] = dt;
                myDataRow["RECORDSTATUS"] = 0;
                myDataRow["RH"] = logItObject.Parameter[0].ParameterValue;
                if (logItObject.RhActive)
                {
                     myDataRow["TEMP"]  = logItObject.Parameter[1].ParameterValue;


                }
                //myDataRow["TEMP"] = Convert.ToDouble(reader[3]);
                custTable.Rows.Add(myDataRow);

                //if (logItObject.DeviceType == "01")
                //{
                dr = this.records1.RECODE1.NewRow();
                
                dr["CHANNELID"] = logItObject.DeviceID;
                dr["DT"] = dt;
                dr["TEMP"] = logItObject.Parameter[0].ParameterValue;
                if (logItObject.RhActive)
                {
                    dr["RH"] = logItObject.Parameter[1].ParameterValue;
                   

                }
                dr["RECORDSTATUS"] = 0;
                this.tankT.Value = (float)logItObject.Parameter[0].ParameterValue;
                if (logItObject.RhActive)
                {
                    this.tankH.Value = (float)logItObject.Parameter[1].ParameterValue;

                }
                this.records1.RECODE1.Rows.Add(dr);

                this.chart.Add(this.records1.RECODE1);
                //}
                //else if (logItObject.DeviceType == "02")
                //{
                //    dr = this.records1.RECODE2.NewRow();
                //    dr["CHANNELID"] = logItObject.DeviceID;
                //    dr["DT"] = dt;
                //    dr["TEMP"] = logItObject.Parameter[0].ParameterValue;
                //    dr["RECORDSTATUS"] = 0;
                //    this.tankT.Value = (float)logItObject.Parameter[0].ParameterValue;
                //    this.records1.RECODE2.Rows.Add(dr);
                //    this.chart.Add(this.records1.RECODE2);
                //}
                dt = DateTime.Now;
            }
            //if (logItObject.DeviceType == "01")
            //{
            this.tankT.Value = (float)logItObject.Parameter[0].ParameterValue;
            if (logItObject.RhActive)
            {
                this.tankH.Value = (float)logItObject.Parameter[1].ParameterValue;
            }

            //}
            //else if (logItObject.DeviceType == "02")
            //{
            //    this.tankT.Value = (float)logItObject.Parameter[0].ParameterValue;
            //}
        }

        #endregion

        private void pDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.HasMorePages = false;
            this.PrintPageText(sender, e);
            e.Graphics.PageUnit = GraphicsUnit.Display;
            e.Graphics.TranslateTransform(110, 220);
            e.Graphics.ScaleTransform(1.15f, 1.15f);
            this.chart.Chart_Print(sender, e);
        }

        private void PrintPageText(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            object[] obj1 = new object[6];
            for (int i = 0; i < obj1.Length; i++)
                obj1[i] = new object();

            if (logitObj.RhActive == true)
                obj1[0] = "Temperature/Humidity";
            else if (logitObj.RhActive == false)
                obj1[0] = "Temperature only";

            obj1[1] = logitObj.Location;
            obj1[2] = logitObj.Instrument;
            obj1[3] = logitObj.Interval + " minute(s)";
            obj1[4] = logitObj.IsLoggingEnable;
            obj1[5] = logitObj.IsAlarmEnable;
            if (this.chart.Mode == PlottingMode.Realtime)
            {
              
            }
            
            object[] obj2 = this.GetChannelParameter();

            //Databases db = Databases.Instance();
            DAL.Company company =instance.Companiess.SingleOrDefault();
            this.Picture(Application.StartupPath + "\\Log-it_Chart.bmp", e.Graphics);
            this.CDName(company.Company_Name,company.Department, e.Graphics);
            this.PrintDT(e.Graphics);
            this.ChartHeading(e.Graphics, "Log-It Chart");
            this.ChannelDetail(e.Graphics, obj1);
            this.ChartSummary(e.Graphics, obj2);
            this.Legend(e.Graphics, "Temperature", this.chart.ColorTLine, 0);
            if (logitObj.RhActive  == true)
                this.Legend(e.Graphics, "Humidty", this.chart.ColorHLine, 1);
            this.Footer(e.Graphics);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                colorChangerStartLine.BackColor = colorDialog1.Color;
                this.StartLineColor = colorDialog1.Color;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                colorChangerStopLine.BackColor = colorDialog1.Color;
                this.StopLineColor = colorDialog1.Color;
            }
        }

        private void colorChangerInterval_Click(object sender, EventArgs e)
        {

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                colorChangerInterval.BackColor = colorDialog1.Color;
                this.IntervalChangedColor = colorDialog1.Color;
            }
        }

        private void colorChangerTLimits_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                colorChangerTLimits.BackColor = colorDialog1.Color;
                this.TLimitsColor = colorDialog1.Color;
            }
        }

        private void colorChangerTLine_Click(object sender, EventArgs e)
        {

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                colorChangerTLine.BackColor = colorDialog1.Color;
                this.TLineColor = colorDialog1.Color;
            }
        }

        private void colorChangerTLabels_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                colorChangerTLabels.BackColor = colorDialog1.Color;
                this.TLabelsColor = colorDialog1.Color;
            }
        }

        private void colorChangerHLimits_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                colorChangerHLimits.BackColor = colorDialog1.Color;
                this.HLimitsColor = colorDialog1.Color;
            }
        }

        private void colorChangerHLine_Click(object sender, EventArgs e)
        {

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                colorChangerHLine.BackColor = colorDialog1.Color;
                this.HLineColor = colorDialog1.Color;
            }
        }

        private void colorChangerHLabels_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                colorChangerHLabels.BackColor = colorDialog1.Color;
                this.HLabelsColor = colorDialog1.Color;
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void TVControl_Load(object sender, EventArgs e)
        {
            this.comboTimeScale.SelectedValue = (int)Chart.Time.Hours_1;
            this.comboGraphMode.SelectedValue = (int)PlottingMode.Realtime;
            CreateTable();
            if (logitObj.RhActive == false)
            {
                this.groupBox2.Enabled = false;

            }

        }

        private void comboTimeScale_SelectedIndexChanged(object sender, System.EventArgs e)
        {
                this.NumTimeScale = (Chart.Time)Convert.ToInt32(this.comboTimeScale.SelectedIndex);
            if (this.NumTimeScale == Chart.Time.UserDefined_Days || this.NumTimeScale == Chart.Time.UserDefined_Hours)
            {
                this.changerNoOfPartitions.Enabled = true;
                this.changerNoOfPartitions.Text = this.NoOfPartitions.ToString();
                this.lblPartitions.Enabled = true;
            }
            else
            {
                this.changerNoOfPartitions.Enabled = false;
                this.lblPartitions.Enabled = false;

            }
        }

        private void mnuPrintChart_Click(object sender, EventArgs e)
        {

        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            //Startup sp = new Startup();
            //if (DialogResult.OK == sp.ShowDialog())
            //{
            //    Startup.Admin = sp.IsAdmin;
            //    Startup.UName = sp.txtUserName.Text;
            //    frmComments fc = new frmComments(this.logitObj);
            //    fc.ShowDialog();
            //}
        }


        private void changerTLLimit_Leave(object sender, EventArgs e)
        {
            this.TempLowerLimit = Convert.ToDouble(changerTLLimit.Value);
        }

        private void changerTULimit_Leave(object sender, EventArgs e)
        {
            this.TempUpperLimit = Convert.ToDouble(changerTULimit.Value);
        }

        private void changerTLRange_Leave(object sender, EventArgs e)
        {
            this.TempLowerRange = Convert.ToDouble(changerTLRange.Value);
        }

        private void changerTURange_Leave(object sender, EventArgs e)
        {
            this.TempUpperRange = Convert.ToDouble(changerTURange.Value);
        }

        private void changerHLLimit_Leave(object sender, EventArgs e)
        {
            this.HumidityLowerLimit = Convert.ToDouble(changerHLLimit.Value);
        }

        private void changerHULimit_Leave(object sender, EventArgs e)
        {
            this.HumidityUpperLimit = Convert.ToDouble(changerHULimit.Value);
        }

        private void changerHLRange_Leave(object sender, EventArgs e)
        {
            this.HumidityLowerRange = Convert.ToDouble(changerHLRange.Value);
        }

        private void changerHURange_ValueChanged(object sender, EventArgs e)
        {

        }

        private void changerHURange_Leave(object sender, EventArgs e)
        {
            this.HumidityUpperRange = Convert.ToDouble(changerHURange.Value);
        }

        private void chkAutoLimit_CheckedChanged(object sender, EventArgs e)
        {
            this.AutoLimit = this.chkAutoLimit.Checked;
        }

        private void comboGraphMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboGraphMode_Click(object sender, EventArgs e)
        {
            this.comboGraphMode.SelectedIndex = 1;
        }

        System.Data.DataTable custTable;

        private void comboGraphMode_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            Reports.DSLogit dtobject = new Reports.DSLogit();
            this.GraphMode = (Log_It.CustomControls.PlottingMode)Convert.ToInt32(this.comboGraphMode.SelectedIndex);
            this.records1.RECODE1.Clear();
            this.records1.RECODE2.Clear();
            if (this.comboGraphMode.Text == "Logging [View]")
            {
                frmViewLogging fvl = new frmViewLogging();
                DialogResult dresult = fvl.ShowDialog();
                if (dresult == DialogResult.OK)
                {

                    if (logitObj.Parameter[0].Device_Type == 1)
                    {
                        string s = "SELECT * From Log Where Channel_ID = " + logitObj.DeviceID + fvl.SelectionFormula;

                        SqlConnection Conn = new SqlConnection(instance.DataLink.Connection.ConnectionString);

                        SqlCommand cmd = new SqlCommand(s, Conn);
                        cmd.CommandType = CommandType.Text;
                        Conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        DataRow myDataRow;
                        CreateTable();
                        while (reader.Read())
                        {
                            int i = 0;
                            if (logitObj.Parameter.Count() == 2)
                            {
                                myDataRow = custTable.NewRow();
                                myDataRow["id"] = reader["Device_Id"].ToString();
                                myDataRow["DT"] = Convert.ToDateTime(reader["date_"]);
                                myDataRow["RECORDSTATUS"] = 0;
                                myDataRow["RH"] = Convert.ToDouble(reader["Rh_Data"]);
                                myDataRow["TEMP"] = Convert.ToDouble(reader["Temp_Data"]);
                                custTable.Rows.Add(myDataRow);


                                Reports.DSLogit.RECODE1Row row = dtobject.RECODE1.NewRECODE1Row();
                                row.CHANNELID = reader["Channel_ID"].ToString();
                                string st = Convert.ToDateTime(reader["date_"]).ToString("dd/MM/yyy HH:mm:ss tt");
                                row.RECORDSTATUS = 0;
                                row.DT = DateTime.Parse(st);
                                row.TEMP = Convert.ToDouble(reader["Temp_Data"].ToString());
                                row.RH = Convert.ToDouble(reader["Rh_Data"].ToString());
                                dtobject.RECODE1.AddRECODE1Row(row);
                                i++;
                            }
                            else
                            {
                                Reports.DSLogit.RECODE2Row rowt = dtobject.RECODE2.NewRECODE2Row();

                                myDataRow = custTable.NewRow();
                                myDataRow["id"] = reader["Device_Id"].ToString();
                                myDataRow["DT"] = Convert.ToDateTime(reader["date_"]);
                                myDataRow["RECORDSTATUS"] = 0;
                               // myDataRow["RH"] = Convert.ToDouble(reader[5]);
                                myDataRow["TEMP"] = Convert.ToDouble(reader["Temp_Data"]);
                                custTable.Rows.Add(myDataRow);

                                rowt.CHANNELID = reader["Channel_ID"].ToString();
                                rowt.DT = Convert.ToDateTime(reader["date_"].ToString());
                                rowt.TEMP = Convert.ToDouble(reader["Temp_Data"].ToString());


                                dtobject.RECODE2.AddRECODE2Row(rowt);
                                i++;
                            }
                        }
                        Conn.Close();

                        
                        if (custTable.Rows.Count > 0)
                        {
                           //this.chart.Add(dtobject.RECODE1);
                            this.chart.Add(custTable);

                        }
                        else
                        {
                            //this.chart.Add(dtobject.RECODE2);
                            this.chart.Add(custTable);

                        }
                    }
                  
                }
            }
        }

        private void CreateTable()
        {
            custTable = new DataTable("Record");

            DataColumn dtColumn;

            // Create id Column
            dtColumn = new DataColumn();
            //System.DateTime
            //System.String

            dtColumn.DataType = System.Type.GetType("System.String");
            dtColumn.ColumnName = "id";
            dtColumn.Caption = "Channed ID";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            // Add id column to the DataColumnCollection.
            custTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            //System.DateTime
            //System.String
            dtColumn.DataType = System.Type.GetType("System.DateTime");
            dtColumn.ColumnName = "DT";
            dtColumn.Caption = "Date_Time";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = true;
            // Add id column to the DataColumnCollection.
            custTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            //System.DateTime
            //System.String
            dtColumn.DataType = System.Type.GetType("System.Byte");
            dtColumn.ColumnName = "RECORDSTATUS";
            dtColumn.Caption = "RECORDSTATUS";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            // Add id column to the DataColumnCollection.
            custTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            //System.DateTime
            //System.String
            dtColumn.DataType = System.Type.GetType("System.Double");
            dtColumn.ColumnName = "RH";
            dtColumn.Caption = "RH";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            // Add id column to the DataColumnCollection.
            custTable.Columns.Add(dtColumn);

            dtColumn = new DataColumn();
            //System.DateTime
            //System.String
            dtColumn.DataType = System.Type.GetType("System.Double");
            dtColumn.ColumnName = "TEMP";
            dtColumn.Caption = "TEMP";
            dtColumn.ReadOnly = false;
            dtColumn.Unique = false;
            // Add id column to the DataColumnCollection.
            custTable.Columns.Add(dtColumn);
        }

        private void changerNoOfPartitions_Leave(object sender, EventArgs e)
        {
            this.NoOfPartitions = (int)this.changerNoOfPartitions.Value;
        }

        private void mnuPrintChart_Click_1(object sender, EventArgs e)
        {

            DialogResult dr;
            try
            {
                dr = this.ppreview.ShowDialog();
            }
            catch (System.Exception winex)
            {
                MessageBox.Show(winex.Message, "Print Preview Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }     
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            DialogResult dr;
            try
            {
                dr = this.ppreview.ShowDialog();
            }
            catch (System.Exception winex)
            {
                MessageBox.Show(winex.Message, "Print Preview Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }     

        }

        private void colorChangerImproperShutdown_Click(object sender, EventArgs e)
        {

        }

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // TVControl
        //    // 
        //    this.Name = "TVControl";
        //    this.Size = new System.Drawing.Size(545, 427);
        //    this.ResumeLayout(false);

        //}

    }
}
