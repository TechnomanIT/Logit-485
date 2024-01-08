using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Drawing2D;
using BAL;
using Microsoft.Reporting.WinForms;
using System.IO;

namespace Log_It.Pages
{
    public partial class ReportPage : UserControl
    {

        LogIt logitObj;
        BAL.LogitInstance instance;
        DAL.Device_Config config;
        string depart = string.Empty;
        Reports.DSLogit dt = null;
        public ReportPage()
        {
            InitializeComponent();
        }

        public void RefreshPage(BAL.LogitInstance instance, DAL.Device_Config config, DateTime SD, DateTime ED)
        {
            try
            {
                this.instance = instance;
                this.config = config;
                labelid.Text = config.Device_Id.ToString();
                decimal tulimit, tllimit, hulimit = 0, hllimit = 0, charthigh, chartlow;
                labellocation.Text = config.Location;
                labelinstrument.Text = config.Instrument;
                label1interval.Text = config.Interval.ToString();
                labelstarttime.Text = SD.ToString();
                labelendtime.Text = ED.ToString();

                TimeSpan t = ED - SD;
                label1cycle.Text = t.Days + "d " + t.Hours + "h " + t.Minutes + "m";
                DAL.Company company = instance.Companiess.FirstOrDefault();
                labelCompany.Text = company.Company_Name;
                depart = company.Department;
                string scomp = company.Company_Name;

                IQueryable<DAL.Alaram_Log> alarams = instance.Alaram_Logs.Where(x => x.Device_ID == config.Device_Id).OrderBy(y => y.Time);

                alarams = alarams.Where(y => y.Time > SD && y.Time < ED);

                bindingSource1.DataSource = alarams;

                dataGridView2.DataSource = bindingSource1;
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.Columns[1].Width = 30;
                dataGridView2.Columns[1].HeaderText = "ID";
                dataGridView2.Columns[2].Visible = false;
                dataGridView2.Columns[3].HeaderText = "Description";
                dataGridView2.Columns[3].Width = 150;
                dataGridView2.Columns[4].HeaderText = "Date Time";
                dataGridView2.Columns[4].Width = 150;
                dataGridView2.Columns[5].HeaderText = "Data";
                dataGridView2.Refresh();

                dt = new Reports.DSLogit();




                Reports.DSLogit.DeviceInformationRow drow = dt.DeviceInformation.NewDeviceInformationRow();
                if (config.Device_Type == 0)
                {
                    drow.Device_ID = labelid.Text;
                    drow.Location = labellocation.Text;
                    drow.Instrument = labelinstrument.Text;
                    drow.Logging_Interval = label1interval.Text;
                    drow.Loggin_cycle = SD.ToString() + " " + ED.ToString(); //label1cycle.Text;
                    drow.Device_Type = "Temperature";
                    if (config.Rh_Active == true)
                    {
                        Reports.DSLogit.DeviceRhRow RhRow = dt.DeviceRh.NewDeviceRhRow();
                        drow.Device_Type = "Temperature/Humidity";
                        DAL.LimitTable limitT = config.LimitTables.SingleOrDefault(d => d.Device_type == 2);
                        labelhrcaldate.Text = limitT.dateofcalibrate.ToString();
                        RhRow.UpperLimit = limitT.Upper_Limit.ToString();
                        RhRow.LowerLimit = limitT.Lower_Limit.ToString();

                        dt.DeviceRh.AddDeviceRhRow(RhRow);
                    }
                    DAL.LimitTable limitT1 = config.LimitTables.SingleOrDefault(d => d.Device_type == 1);
                    labeltemcaldate.Text = limitT1.dateofcalibrate.ToString();
                    drow.Max_Limit = (int)limitT1.Upper_Limit;
                    drow.Min_Limit = (int)limitT1.Lower_Limit;
                    dt.DeviceInformation.AddDeviceInformationRow(drow);
                }
                if (config.Device_Type == 1)
                {
                    drow.Device_ID = labelid.Text;
                    drow.Location = labellocation.Text;
                    drow.Instrument = labelinstrument.Text;
                    drow.Logging_Interval = label1interval.Text;
                    drow.Loggin_cycle = label1cycle.Text;
                    drow.Device_Type = "Pressure";

                    DAL.LimitTable limitT1 = config.LimitTables.SingleOrDefault(d => d.Device_type == 3);
                    labeltemcaldate.Text = limitT1.dateofcalibrate.ToString();
                    drow.Max_Limit = (int)limitT1.Upper_Limit;
                    drow.Min_Limit = (int)limitT1.Lower_Limit;
                    dt.DeviceInformation.AddDeviceInformationRow(drow);
                }





                Reports.DSLogit.CompanyInfoRow companyrow = dt.CompanyInfo.NewCompanyInfoRow();
                companyrow.CompanyName = company.Company_Name;
                companyrow.Department = company.Department;
                dt.CompanyInfo.AddCompanyInfoRow(companyrow);

                Reports.DSLogit.UserInformationRow userrow = dt.UserInformation.NewUserInformationRow();
                userrow.FullName = instance.UserInstance.Full_Name;
                userrow.UserName = instance.UserInstance.User_Name;
                dt.UserInformation.AddUserInformationRow(userrow);

                string STARTDATETIME = SD.Month.ToString() + "-" + SD.Day.ToString() + "-" + SD.Year.ToString() + " " + SD.Hour.ToString() + ":" + SD.Minute.ToString() + ":" + "00" + " " + SD.ToString("tt", System.Globalization.CultureInfo.InvariantCulture);
                string ENDDATETIME = ED.Month.ToString() + "-" + ED.Day.ToString() + "-" + ED.Year.ToString() + " " + ED.Hour.ToString() + ":" + ED.Minute.ToString() + ":" + "00" + " " + ED.ToString("tt", System.Globalization.CultureInfo.InvariantCulture);


                string s = "SELECT * From Log Where Device_Id = '" + config.ID + "' AND ([date_] > '" + STARTDATETIME + "' AND [date_] < '" + ENDDATETIME + "') Order by date_";
                string max = "SELECT MAX(Temp_Data) As Maximum, MIN(Temp_Data) As Minimumm, AVG(Temp_Data) As Average From Log Where Device_Id = '" + config.ID + "' AND ([date_] > '" + STARTDATETIME + "' AND [date_] < '" + ENDDATETIME + "')";
                string Rhmax = "SELECT MAX(Rh_Data) As Maximum, MIN(Rh_Data) As Minimumm, AVG(Rh_Data) As Average From Log Where Device_Id = '" + config.ID + "' AND ([date_] > '" + STARTDATETIME + "' AND [date_] < '" + ENDDATETIME + "')";
                string Pamax = "SELECT MAX( Pressure) As Maximum, MIN( Pressure) As Minimumm, AVG( Pressure) As Average From Log Where Device_Id = '" + config.ID + "' AND ([date_] > '" + STARTDATETIME + "' AND [date_] < '" + ENDDATETIME + "')";

                SqlConnection Conn = new SqlConnection(instance.DataLink.Connection.ConnectionString);
                Reports.DSLogit.StatisticsRow statiscticRow = dt.Statistics.NewStatisticsRow();



                SqlCommand cmdAck = new SqlCommand("SELECT *  FROM [PlotterRS485].[dbo].[Acknowledge]  where Device_ID = '" + config.Channel_id + "' AND (Event_DateTime >=' " + STARTDATETIME + "'  AND Event_DateTime <= '" + ENDDATETIME + "' ) Order By Event_DateTime ASC", Conn); // Read user-> stored procedure name
                cmdAck.CommandType = CommandType.Text;
                Conn.Open();
                SqlDataReader readerAck = cmdAck.ExecuteReader();
                while (readerAck.Read())
                {
                    Reports.DSLogit.AcknowladgeRow arow = dt.Acknowladge.NewAcknowladgeRow();
                    arow.Device_ID = readerAck["ID"].ToString();
                    arow.Ack_DateTime = readerAck["Ack_DateTime"].ToString();
                    arow.Comment = readerAck["Ack_Comments"].ToString();
                    arow.Event = readerAck["Event"].ToString();
                    arow.Event_DateTime = readerAck["Event_DateTime"].ToString();
                    arow.Event_Type = readerAck["Event_Type"].ToString();
                    arow.User = readerAck["Ack_User"].ToString();
                    arow.Location = readerAck["Location"].ToString();
                    arow.Instrument = readerAck["Instrument"].ToString();
                    dt.Acknowladge.AddAcknowladgeRow(arow);
                }
                readerAck.Close();
                Conn.Close();


                #region Rh
                if (config.Device_Type == 0)
                {


                    SqlCommand cmd = new SqlCommand(max, Conn);
                    cmd.CommandType = CommandType.Text;
                    if (Conn.State == ConnectionState.Closed)
                    {
                        Conn.Open();
                    }

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        double? Idmax = reader[0] as double? ?? default(double?);
                        double? Idmin = reader[1] as double? ?? default(double?);
                        double? Idavg = reader[2] as double? ?? default(double?);

                        if (Idmax != null)
                        {
                            double data = Convert.ToDouble(Idmax);
                            if (label17.Text == "°F")
                            {

                                data = ((data * 9) / 5) + 32;
                            }
                            labelTmax.Text = data.ToString();

                        }
                        if (Idmin != null)
                        {
                            double data = Convert.ToDouble(Idmin);
                            if (label17.Text == "°F")
                            {

                                data = ((data * 9) / 5) + 32;
                            }
                            labelTmin.Text = data.ToString();
                        }
                        if (Idavg != null)
                        {
                            double data = Convert.ToDouble(Idavg);
                            if (label17.Text == "°F")
                            {

                                data = ((data * 9) / 5) + 32;
                            }

                            decimal stravg = Convert.ToDecimal(data);
                            labelTavg.Text = Decimal.Round(stravg, 2, MidpointRounding.AwayFromZero).ToString();
                        }

                        //labelTmax.Text = reader[0].ToString();
                        //labelTmin.Text = reader[1].ToString();
                        //decimal stravg = Convert.ToDecimal(reader[2]);
                        //labelTavg.Text = Decimal.Round(stravg, 2, MidpointRounding.AwayFromZero).ToString();

                    }
                    statiscticRow.Max = labelTmax.Text;
                    statiscticRow.Min = labelTmin.Text;
                    statiscticRow.Avg = labelTavg.Text;
                    statiscticRow.DateCalibration = labeltemcaldate.Text;
                    tulimit = Convert.ToDecimal(labelTmax.Text);
                    tllimit = Convert.ToDecimal(labelTmin.Text);
                    charthigh = tulimit;
                    chartlow = tllimit;


                    Conn.Close();
                    dt.Statistics.AddStatisticsRow(statiscticRow);
                    if (config.Rh_Active == true)
                    {
                        Reports.DSLogit.StatisticsRhRow rhRow = dt.StatisticsRh.NewStatisticsRhRow();
                        cmd = new SqlCommand(Rhmax, Conn);
                        cmd.CommandType = CommandType.Text;
                        Conn.Open();
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            double? Idmax = reader[0] as double? ?? default(double?);
                            double? Idmin = reader[1] as double? ?? default(double?);
                            double? Idavg = reader[2] as double? ?? default(double?);

                            if (Idmax != null)
                            {

                                labelHmax.Text = Idmax.ToString();
                                rhRow.Maxi = labelHmax.Text;
                                hulimit = Convert.ToDecimal(labelHmax.Text);
                            }
                            if (Idmin != null)
                            {
                                labelHmin.Text = Idmin.ToString();
                                rhRow.Mini = labelHmin.Text;
                                hllimit = Convert.ToDecimal(labelHmin.Text);
                            }
                            if (Idavg != null)
                            {
                                decimal stravg = Convert.ToDecimal(Idavg);
                                labelHavg.Text = Decimal.Round(stravg, 2, MidpointRounding.AwayFromZero).ToString();
                                rhRow.Avgr = labelHavg.Text;
                            }

                            rhRow.Avgr = labelHavg.Text;
                            rhRow.Maxi = labelHmax.Text;
                            rhRow.Mini = labelHmin.Text;
                            rhRow.DateCalibration = labelhrcaldate.Text;
                            dt.StatisticsRh.AddStatisticsRhRow(rhRow);

                            //labelHmax.Text = reader[0].ToString();
                            //labelHmin.Text = reader[1].ToString();
                            //decimal stravg = Convert.ToDecimal(reader[2]);
                            //labelHavg.Text = Decimal.Round(stravg, 2, MidpointRounding.AwayFromZero).ToString();

                            //rhRow.Avgr = labelHavg.Text;
                            //rhRow.Maxi = labelHmax.Text;
                            //rhRow.Mini = labelHmin.Text;
                            //rhRow.DateCalibration = labelhrcaldate.Text;
                            //dt.StatisticsRh.AddStatisticsRhRow(rhRow);

                            hulimit = Convert.ToDecimal(labelHmax.Text);
                            hllimit = Convert.ToDecimal(labelHmin.Text);
                            //chart1.ChartAreas[0].AxisY2.Minimum = Convert.ToInt32(labelHmin.Text);
                            //chart1.ChartAreas[0].AxisY2.Maximum = Convert.ToInt32(labelHmax.Text);
                            //chart1.ChartAreas[0].AxisY2.Interval = chart1.ChartAreas[0].AxisY2.Maximum/4;
                        }

                        Conn.Close();
                        if (hulimit > tulimit)
                        {
                            charthigh = hulimit;
                        }
                        if (hllimit < tllimit)
                        {
                            chartlow = hllimit;
                        }
                    }
                    else
                    {
                        label30.Visible = false;
                        label29.Visible = false;
                        line4.Visible = false;
                        label38.Visible = false;
                        label37.Visible = false;
                        label36.Visible = false;
                        labelHmax.Visible = false;
                        labelHmin.Visible = false;
                        labelHavg.Visible = false;
                    }

                    cmd = new SqlCommand(s, Conn);
                    cmd.CommandType = CommandType.Text;
                    if (Conn.State == ConnectionState.Closed)
                    {
                        Conn.Open();
                    }
                    reader = cmd.ExecuteReader();

                    int i = 0;
                    List<MKT> mkt = new List<MKT>();

                    double sum = 0;
                    while (reader.Read())
                    {

                        Reports.DSLogit.LogsTableRow row = dt.LogsTable.NewLogsTableRow();
                        i++;
                        row.Point = i.ToString();
                        MKT mk = new MKT();
                        mk.Rhdata = Convert.ToDouble(reader[5]);
                        mk.data = Convert.ToDouble(reader[3]);
                        mk._date = Convert.ToDateTime(reader[4]);
                        mk.kvdata = Convert.ToDouble(mk.data + 273.15);
                        double d = (0.008314472 * mk.kvdata);
                        mk.expdata = Math.Exp(-83.14472 / d);
                        sum = sum + mk.expdata;
                        mkt.Add(mk);
                        row.Channel_ID = reader[2].ToString();
                        double data = Convert.ToDouble(reader[3]);
                        row.TempData = Math.Round(data, 2).ToString("##.0");
                        row.Date_Time = reader[4].ToString();
                        data = Convert.ToDouble(reader[5]);
                        row.RhData = Math.Round(data, 2).ToString("##.0"); //reader[5].ToString();
                        dt.LogsTable.AddLogsTableRow(row);
                    }
                    if (reader.HasRows)
                    {
                        sum = sum / mkt.Count;
                        sum = Math.Log(sum);
                        sum = sum / -1;
                        sum = 10000 / sum;
                        sum = sum - 273.15;
                        labelTMKT.Text = sum.ToString("##.00");
                        statiscticRow.MKT = labelTMKT.Text;

                        dataGridView1.DataSource = dt;
                        dataGridView1.DataMember = "LogsTable";
                        dataGridView1.Columns[0].Width = 60;
                        dataGridView1.Columns[1].Visible = false;

                        dataGridView1.Columns[2].HeaderText = "°C";
                        dataGridView1.Columns[2].Width = 80;

                        dataGridView1.Columns[3].HeaderText = "Rh";
                        dataGridView1.Columns[3].Width = 80;
                        dataGridView1.Columns[4].HeaderText = "Date Time";
                        dataGridView1.Columns[4].Width = 200;


                        this.chart1.ChartAreas[0].AxisX.Title = "Date Time";
                        chart1.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM/yyyy hh:mm:ss tt";
                        chart1.Series[0].IsXValueIndexed = true;
                        chart1.Series[0].XValueType = ChartValueType.DateTime;


                        chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
                        chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

                        chart1.ChartAreas[0].AxisY.LabelStyle.IsEndLabelVisible = false;
                        chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
                        chart1.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

                        chart1.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(chartlow - 5);
                        chart1.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(charthigh + 5);
                        chart1.ChartAreas[0].AxisY.Interval = 5;



                        if (config.Rh_Active == true)
                        {
                            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();


                            series2.ChartArea = "ChartArea1";
                            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                            series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
                            //series2.IsValueShownAsLabel = true;
                            series2.Legend = "Legend1";
                            series2.MarkerImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                            series2.MarkerSize = 8;
                            series2.BorderWidth = 3;
                            // series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                            series2.Name = "Rh";
                            series2.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
                            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                            this.chart1.Series.Add(series2);
                            chart1.Series[1].IsXValueIndexed = true;
                            chart1.Series[1].XValueType = ChartValueType.DateTime;

                            chart1.ChartAreas[0].AxisY2.Minimum = Convert.ToDouble(chartlow - 5);
                            chart1.ChartAreas[0].AxisY2.Maximum = Convert.ToDouble(charthigh + 5);
                            chart1.ChartAreas[0].AxisY2.Interval = 5;
                            chart1.ChartAreas[0].AxisY2.MajorGrid.LineColor = Color.LightGray;
                            chart1.ChartAreas[0].AxisX2.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
                            chart1.ChartAreas[0].AxisY2.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

                        }
                        if (config.Rh_Active == true)
                        {
                            foreach (MKT item in mkt)
                            {
                                chart1.Series[0].Points.AddXY(item._date, item.data);
                                chart1.Series[1].Points.AddXY(item._date, item.Rhdata);
                            }
                        }
                        else
                        {
                            foreach (MKT item in mkt)
                            {
                                chart1.Series[0].Points.AddXY(item._date, item.data);
                            }
                        }



                        Conn.Close();



                        labeldatapoints.Text = i.ToString();
                        if (config.Rh_Active == true)
                        {
                            //Report.LogitReportRh rp = new Report.LogitReportRh();
                            //rp.SetDataSource(dt);
                            //crystalReportViewer1.ReportSource = rp;

                            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Log_It.Reports.LogitReportRh.rdlc";
                        }
                        else
                        {
                            //Report.LogitReport rp = new Report.LogitReport();
                            //rp.SetDataSource(dt);
                            //crystalReportViewer1.ReportSource = rp;

                            //LogitReport.rdlc
                            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Log_It.Reports.LogitReport.rdlc";
                        }
                        //ReportParameter rp = new ReportParameter("TLL", tllimit.ToString(),false);

                        //reportViewer1.LocalReport.SetParameters(rp);
                        //rp = new ReportParameter("THL", tulimit.ToString(), false);
                        //reportViewer1.LocalReport.SetParameters(rp);
                        reportViewer1.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;

                        ReportDataSource datasourcelog = new ReportDataSource("DataSet1", dt.Tables["UserInformation"]);
                        ReportDataSource datasourcelog2 = new ReportDataSource("DataSet2", dt.Tables["CompanyInfo"]);
                        ReportDataSource datasourcelog3 = new ReportDataSource("DataSet3", dt.Tables["DeviceInformation"]);
                        ReportDataSource datasourcelog4 = new ReportDataSource("DataSet4", dt.Tables["Statistics"]);
                        ReportDataSource datasourcelog5 = new ReportDataSource("DataSet5", dt.Tables["LogsTable"]);
                        ReportDataSource datasourcelog6 = new ReportDataSource("DataSet6", dt.Tables["DeviceRh"]);
                        ReportDataSource datasourcelog7 = new ReportDataSource("DataSet7", dt.Tables["StatisticsRh"]);

                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.DataSources.Add(datasourcelog);
                        reportViewer1.LocalReport.DataSources.Add(datasourcelog2);
                        reportViewer1.LocalReport.DataSources.Add(datasourcelog3);
                        reportViewer1.LocalReport.DataSources.Add(datasourcelog4);
                        reportViewer1.LocalReport.DataSources.Add(datasourcelog5);
                        reportViewer1.LocalReport.DataSources.Add(datasourcelog6);
                        reportViewer1.LocalReport.DataSources.Add(datasourcelog7);

                        this.reportViewer1.RefreshReport();

                    }
                    else
                    {
                        MessageBox.Show("No record in selected dates");
                    }
                }
                #endregion

                #region Pa
                if (config.Device_Type == 1)
                {


                    SqlCommand cmd = new SqlCommand(Pamax, Conn);
                    cmd.CommandType = CommandType.Text;
                    Conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        double? Idmax = reader[0] as double? ?? default(double?);
                        double? Idmin = reader[1] as double? ?? default(double?);
                        double? Idavg = reader[2] as double? ?? default(double?);

                        if (Idmax != null)
                        {
                            labelTmax.Text = Idmax.ToString();
                        }
                        if (Idmin != null)
                        {
                            labelTmin.Text = Idmin.ToString();
                        }
                        if (Idavg != null)
                        {
                            decimal stravg = Convert.ToDecimal(Idavg);
                            labelTavg.Text = Decimal.Round(stravg, 2, MidpointRounding.AwayFromZero).ToString();
                        }


                    }
                    statiscticRow.Max = labelTmax.Text;
                    statiscticRow.Min = labelTmin.Text;
                    statiscticRow.Avg = labelTavg.Text;
                    statiscticRow.DateCalibration = labeltemcaldate.Text;
                    tulimit = Convert.ToDecimal(labelTmax.Text);
                    tllimit = Convert.ToDecimal(labelTmin.Text);
                    charthigh = tulimit;
                    chartlow = tllimit;


                    Conn.Close();
                    dt.Statistics.AddStatisticsRow(statiscticRow);

                    label30.Visible = false;
                    label29.Visible = false;
                    line4.Visible = false;
                    label38.Visible = false;
                    label37.Visible = false;
                    label36.Visible = false;
                    labelHmax.Visible = false;
                    labelHmin.Visible = false;
                    labelHavg.Visible = false;


                    cmd = new SqlCommand(s, Conn);
                    cmd.CommandType = CommandType.Text;
                    Conn.Open();
                    reader = cmd.ExecuteReader();

                    int i = 0;
                    List<MKT> mkt = new List<MKT>();

                    double sum = 0;
                    while (reader.Read())
                    {

                        Reports.DSLogit.LogsTableRow row = dt.LogsTable.NewLogsTableRow();
                        i++;
                        row.Point = i.ToString();
                        MKT mk = new MKT();
                        mk.Rhdata = Convert.ToDouble(reader[5]);
                        mk.data = Convert.ToDouble(reader[3]);
                        mk._date = Convert.ToDateTime(reader[4]);
                        mk.kvdata = Convert.ToDouble(mk.data + 273.15);
                        double d = (0.008314472 * mk.kvdata);
                        mk.expdata = Math.Exp(-83.14472 / d);
                        sum = sum + mk.expdata;
                        mkt.Add(mk);
                        row.Channel_ID = reader[2].ToString();
                        row.TempData = reader[3].ToString();
                        row.Date_Time = reader[4].ToString();
                        row.RhData = reader[5].ToString();
                        dt.LogsTable.AddLogsTableRow(row);
                    }
                    if (reader.HasRows)
                    {
                        sum = sum / mkt.Count;
                        sum = Math.Log(sum);
                        sum = sum / -1;
                        sum = 10000 / sum;
                        sum = sum - 273.15;
                        labelTMKT.Text = sum.ToString("##.00");
                        statiscticRow.MKT = labelTMKT.Text;

                        dataGridView1.DataSource = dt;
                        dataGridView1.DataMember = "LogsTable";
                        dataGridView1.Columns[0].Width = 60;
                        dataGridView1.Columns[1].Visible = false;

                        dataGridView1.Columns[2].HeaderText = "Pa";
                        dataGridView1.Columns[2].Width = 80;

                        dataGridView1.Columns[4].HeaderText = "Date Time";
                        dataGridView1.Columns[4].Width = 200;


                        this.chart1.ChartAreas[0].AxisX.Title = "Date Time";
                        chart1.ChartAreas[0].AxisX.LabelStyle.Format = "MM/dd/yyyy hh:mm:ss tt";
                        chart1.Series[0].IsXValueIndexed = true;
                        chart1.Series[0].XValueType = ChartValueType.DateTime;


                        chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
                        chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

                        chart1.ChartAreas[0].AxisY.LabelStyle.IsEndLabelVisible = false;
                        chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
                        chart1.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

                        chart1.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(chartlow - 5);
                        chart1.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(charthigh + 5);
                        chart1.ChartAreas[0].AxisY.Interval = 5;





                        foreach (MKT item in mkt)
                        {
                            chart1.Series[0].Points.AddXY(item._date, item.data);
                        }




                        Conn.Close();



                        labeldatapoints.Text = i.ToString();

                        //Report.LogitReport rp = new Report.LogitReport();
                        //rp.SetDataSource(dt);
                        //crystalReportViewer1.ReportSource = rp;

                    }
                    else
                    {
                        MessageBox.Show("No record in selected dates");
                    }
                }
                #endregion
            }
            catch (Exception m)
            {

                MessageBox.Show(m.Message);
            }

        }


        //public void RefreshPage(BAL.LogitInstance instance, DAL.Device_Config config, DateTime SD, DateTime ED)
        //{
        //    try
        //    {
        //        this.instance = instance;
        //        this.config = config;
        //        labelid.Text = config.Device_Id.ToString();
        //        decimal tulimit, tllimit, hulimit = 0, hllimit = 0, charthigh, chartlow;
        //        labellocation.Text = config.Location;
        //        labelinstrument.Text = config.Instrument;
        //        label1interval.Text = config.Interval.ToString();
        //        labelstarttime.Text = SD.ToString();
        //        labelendtime.Text = ED.ToString();

        //        TimeSpan t = ED - SD;
        //        label1cycle.Text = t.Days + "d " + t.Hours + "h " + t.Minutes + "m";
        //        DAL.Company company = instance.Companiess.FirstOrDefault();
        //        labelCompany.Text = company.Company_Name;
        //        depart = company.Department;
        //        string scomp = company.Company_Name;

        //        IQueryable<DAL.Alaram_Log> alarams = instance.Alaram_Logs.Where(x => x.Device_ID == config.Device_Id).OrderBy(y => y.Time);

        //        alarams = alarams.Where(y => y.Time > SD && y.Time < ED);

        //        bindingSource1.DataSource = alarams;

        //        dataGridView2.DataSource = bindingSource1;
        //        dataGridView2.Columns[0].Visible = false;
        //        dataGridView2.Columns[1].Width = 30;
        //        dataGridView2.Columns[1].HeaderText = "ID";
        //        dataGridView2.Columns[2].Visible = false;
        //        dataGridView2.Columns[3].HeaderText = "Description";
        //        dataGridView2.Columns[3].Width = 150;
        //        dataGridView2.Columns[4].HeaderText = "Date Time";
        //        dataGridView2.Columns[4].Width = 150;
        //        dataGridView2.Columns[5].HeaderText = "Data";
        //        dataGridView2.Refresh();

        //        dt = new Reports.DSLogit();




        //        Reports.DSLogit.DeviceInformationRow drow = dt.DeviceInformation.NewDeviceInformationRow();
        //        if (config.Device_Type == 0)
        //        {
        //            drow.Device_ID = labelid.Text;
        //            drow.Location = labellocation.Text;
        //            drow.Instrument = labelinstrument.Text;
        //            drow.Logging_Interval = label1interval.Text;
        //            drow.Loggin_cycle = label1cycle.Text;
        //            drow.Device_Type = "Temperature";
        //            if (config.Rh_Active == true)
        //            {
        //                Reports.DSLogit.DeviceRhRow RhRow = dt.DeviceRh.NewDeviceRhRow();
        //                drow.Device_Type = "Temperature/Humidity";
        //                DAL.LimitTable limitT = config.LimitTables.SingleOrDefault(d => d.Device_type == 2);
        //                labelhrcaldate.Text = limitT.dateofcalibrate.ToString();
        //                RhRow.UpperLimit = limitT.Upper_Limit.ToString();
        //                RhRow.LowerLimit = limitT.Lower_Limit.ToString();

        //                dt.DeviceRh.AddDeviceRhRow(RhRow);
        //            }
        //            DAL.LimitTable limitT1 = config.LimitTables.SingleOrDefault(d => d.Device_type == 1);
        //            labeltemcaldate.Text = limitT1.dateofcalibrate.ToString();
        //            drow.Max_Limit = (int)limitT1.Upper_Limit;
        //            drow.Min_Limit = (int)limitT1.Lower_Limit;
        //            dt.DeviceInformation.AddDeviceInformationRow(drow);
        //        }
        //        if (config.Device_Type ==1)
        //        {
        //            drow.Device_ID = labelid.Text;
        //            drow.Location = labellocation.Text;
        //            drow.Instrument = labelinstrument.Text;
        //            drow.Logging_Interval = label1interval.Text;
        //            drow.Loggin_cycle = label1cycle.Text;
        //            drow.Device_Type = "Pressure";

        //            DAL.LimitTable limitT1 = config.LimitTables.SingleOrDefault(d => d.Device_type == 3);
        //            labeltemcaldate.Text = limitT1.dateofcalibrate.ToString();
        //            drow.Max_Limit = (int)limitT1.Upper_Limit;
        //            drow.Min_Limit = (int)limitT1.Lower_Limit;
        //            dt.DeviceInformation.AddDeviceInformationRow(drow);
        //        }





        //        Reports.DSLogit.CompanyInfoRow companyrow = dt.CompanyInfo.NewCompanyInfoRow();
        //        companyrow.CompanyName = company.Company_Name;
        //        companyrow.Department = company.Department;
        //        dt.CompanyInfo.AddCompanyInfoRow(companyrow);

        //        Reports.DSLogit.UserInformationRow userrow = dt.UserInformation.NewUserInformationRow();
        //        userrow.FullName = instance.UserInstance.Full_Name;
        //        userrow.UserName = instance.UserInstance.User_Name;
        //        dt.UserInformation.AddUserInformationRow(userrow);

        //        string STARTDATETIME = SD.Month.ToString() + "-" + SD.Day.ToString() + "-" + SD.Year.ToString() + " " + SD.Hour.ToString() + ":" + SD.Minute.ToString() + ":" + "00" + " " + SD.ToString("tt", System.Globalization.CultureInfo.InvariantCulture);
        //        string ENDDATETIME = ED.Month.ToString() + "-" + ED.Day.ToString() + "-" + ED.Year.ToString() + " " + ED.Hour.ToString() + ":" + ED.Minute.ToString() + ":" + "00" + " " + ED.ToString("tt", System.Globalization.CultureInfo.InvariantCulture);


        //        string s = "SELECT * From Log Where Device_Id = '" + config.ID + "' AND ([date_] > '" + STARTDATETIME + "' AND [date_] < '" + ENDDATETIME + "') Order by date_";
        //        string max = "SELECT MAX(Temp_Data) As Maximum, MIN(Temp_Data) As Minimumm, AVG(Temp_Data) As Average From Log Where Device_Id = '" + config.ID + "' AND ([date_] > '" + STARTDATETIME + "' AND [date_] < '" + ENDDATETIME + "')";
        //        string Rhmax = "SELECT MAX(Rh_Data) As Maximum, MIN(Rh_Data) As Minimumm, AVG(Rh_Data) As Average From Log Where Device_Id = '" + config.ID + "' AND ([date_] > '" + STARTDATETIME + "' AND [date_] < '" + ENDDATETIME + "')";
        //        string Pamax = "SELECT MAX( Pressure) As Maximum, MIN( Pressure) As Minimumm, AVG( Pressure) As Average From Log Where Device_Id = '" + config.ID + "' AND ([date_] > '" + STARTDATETIME + "' AND [date_] < '" + ENDDATETIME + "')";

        //        SqlConnection Conn = new SqlConnection(instance.DataLink.Connection.ConnectionString);
        //        Reports.DSLogit.StatisticsRow statiscticRow = dt.Statistics.NewStatisticsRow();



        //            SqlCommand cmdAck = new SqlCommand("SELECT *  FROM [PlotterRS485].[dbo].[Acknowledge]  where Device_ID = '" + config.Channel_id + "' AND (Event_DateTime >=' " + STARTDATETIME + "'  AND Event_DateTime <= '" + ENDDATETIME + "' ) Order By Event_DateTime ASC", Conn); // Read user-> stored procedure name
        //            cmdAck.CommandType = CommandType.Text;
        //            Conn.Open();
        //            SqlDataReader readerAck = cmdAck.ExecuteReader();
        //            while (readerAck.Read())
        //            {
        //                Reports.DSLogit.AcknowladgeRow arow = dt.Acknowladge.NewAcknowladgeRow();
        //                arow.Device_ID = readerAck["ID"].ToString();
        //                arow.Ack_DateTime = readerAck["Ack_DateTime"].ToString();
        //                arow.Comment = readerAck["Ack_Comments"].ToString();
        //                arow.Event = readerAck["Event"].ToString();
        //                arow.Event_DateTime = readerAck["Event_DateTime"].ToString();
        //                arow.Event_Type = readerAck["Event_Type"].ToString();
        //                arow.User = readerAck["Ack_User"].ToString();
        //                arow.Location = readerAck["Location"].ToString();
        //                arow.Instrument = readerAck["Instrument"].ToString();
        //                dt.Acknowladge.AddAcknowladgeRow(arow);
        //            }
        //            readerAck.Close();
        //            Conn.Close();


        //        #region Rh
        //        if (config.Device_Type == 0)
        //        {


        //            SqlCommand cmd = new SqlCommand(max, Conn);
        //            cmd.CommandType = CommandType.Text;
        //            if (Conn.State == ConnectionState.Closed)
        //            {
        //                Conn.Open();    
        //            }

        //            SqlDataReader reader = cmd.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                double? Idmax = reader[0] as double? ?? default(double?);
        //                double? Idmin = reader[1] as double? ?? default(double?);
        //                double? Idavg = reader[2] as double? ?? default(double?);

        //                if (Idmax != null)
        //                {
        //                    double data = Convert.ToDouble(Idmax);
        //                    if (label17.Text == "°F")
        //                    {

        //                        data = ((data * 9) / 5) + 32;
        //                    }
        //                    labelTmax.Text = data.ToString();

        //                }
        //                if (Idmin != null)
        //                {
        //                    double data = Convert.ToDouble(Idmin);
        //                    if (label17.Text == "°F")
        //                    {

        //                        data = ((data * 9) / 5) + 32;
        //                    }
        //                    labelTmin.Text = data.ToString();
        //                }
        //                if (Idavg != null)
        //                {
        //                    double data = Convert.ToDouble(Idavg);
        //                    if (label17.Text == "°F")
        //                    {

        //                        data = ((data * 9) / 5) + 32;
        //                    }

        //                    decimal stravg = Convert.ToDecimal(data);
        //                    labelTavg.Text = Decimal.Round(stravg, 2, MidpointRounding.AwayFromZero).ToString();
        //                }

        //                //labelTmax.Text = reader[0].ToString();
        //                //labelTmin.Text = reader[1].ToString();
        //                //decimal stravg = Convert.ToDecimal(reader[2]);
        //                //labelTavg.Text = Decimal.Round(stravg, 2, MidpointRounding.AwayFromZero).ToString();

        //            }
        //            statiscticRow.Max = labelTmax.Text;
        //            statiscticRow.Min = labelTmin.Text;
        //            statiscticRow.Avg = labelTavg.Text;
        //            statiscticRow.DateCalibration = labeltemcaldate.Text;
        //            tulimit = Convert.ToDecimal(labelTmax.Text);
        //            tllimit = Convert.ToDecimal(labelTmin.Text);
        //            charthigh = tulimit;
        //            chartlow = tllimit;


        //            Conn.Close();
        //            dt.Statistics.AddStatisticsRow(statiscticRow);
        //            if (config.Rh_Active == true)
        //            {
        //                Reports.DSLogit.StatisticsRhRow rhRow = dt.StatisticsRh.NewStatisticsRhRow();
        //                cmd = new SqlCommand(Rhmax, Conn);
        //                cmd.CommandType = CommandType.Text;
        //                Conn.Open();
        //                reader = cmd.ExecuteReader();
        //                while (reader.Read())
        //                {
        //                    double? Idmax = reader[0] as double? ?? default(double?);
        //                    double? Idmin = reader[1] as double? ?? default(double?);
        //                    double? Idavg = reader[2] as double? ?? default(double?);

        //                    if (Idmax != null)
        //                    {

        //                        labelHmax.Text = Idmax.ToString();
        //                        rhRow.Maxi = labelHmax.Text;
        //                        hulimit = Convert.ToDecimal(labelHmax.Text);
        //                    }
        //                    if (Idmin != null)
        //                    {
        //                        labelHmin.Text = Idmin.ToString();
        //                        rhRow.Mini = labelHmin.Text;
        //                        hllimit = Convert.ToDecimal(labelHmin.Text);
        //                    }
        //                    if (Idavg != null)
        //                    {
        //                        decimal stravg = Convert.ToDecimal(Idavg);
        //                        labelHavg.Text = Decimal.Round(stravg, 2, MidpointRounding.AwayFromZero).ToString();
        //                        rhRow.Avgr = labelHavg.Text;
        //                    }

        //                    rhRow.Avgr = labelHavg.Text;
        //                    rhRow.Maxi = labelHmax.Text;
        //                    rhRow.Mini = labelHmin.Text;
        //                    rhRow.DateCalibration = labelhrcaldate.Text;
        //                    dt.StatisticsRh.AddStatisticsRhRow(rhRow);

        //                    //labelHmax.Text = reader[0].ToString();
        //                    //labelHmin.Text = reader[1].ToString();
        //                    //decimal stravg = Convert.ToDecimal(reader[2]);
        //                    //labelHavg.Text = Decimal.Round(stravg, 2, MidpointRounding.AwayFromZero).ToString();

        //                    //rhRow.Avgr = labelHavg.Text;
        //                    //rhRow.Maxi = labelHmax.Text;
        //                    //rhRow.Mini = labelHmin.Text;
        //                    //rhRow.DateCalibration = labelhrcaldate.Text;
        //                    //dt.StatisticsRh.AddStatisticsRhRow(rhRow);

        //                    hulimit = Convert.ToDecimal(labelHmax.Text);
        //                    hllimit = Convert.ToDecimal(labelHmin.Text);
        //                    //chart1.ChartAreas[0].AxisY2.Minimum = Convert.ToInt32(labelHmin.Text);
        //                    //chart1.ChartAreas[0].AxisY2.Maximum = Convert.ToInt32(labelHmax.Text);
        //                    //chart1.ChartAreas[0].AxisY2.Interval = chart1.ChartAreas[0].AxisY2.Maximum/4;
        //                }

        //                Conn.Close();
        //                if (hulimit > tulimit)
        //                {
        //                    charthigh = hulimit;
        //                }
        //                if (hllimit < tllimit)
        //                {
        //                    chartlow = hllimit;
        //                }
        //            }
        //            else
        //            {
        //                label30.Visible = false;
        //                label29.Visible = false;
        //                line4.Visible = false;
        //                label38.Visible = false;
        //                label37.Visible = false;
        //                label36.Visible = false;
        //                labelHmax.Visible = false;
        //                labelHmin.Visible = false;
        //                labelHavg.Visible = false;
        //            }

        //            cmd = new SqlCommand(s, Conn);
        //            cmd.CommandType = CommandType.Text;
        //            if (Conn.State == ConnectionState.Closed)
        //            {
        //                Conn.Open();
        //            }
        //            reader = cmd.ExecuteReader();

        //            int i = 0;
        //            List<MKT> mkt = new List<MKT>();

        //            double sum = 0;
        //            while (reader.Read())
        //            {

        //                Reports.DSLogit.LogsTableRow row = dt.LogsTable.NewLogsTableRow();
        //                i++;
        //                row.Point = i.ToString();
        //                MKT mk = new MKT();
        //                mk.Rhdata = Convert.ToDouble(reader[5]);
        //                mk.data = Convert.ToDouble(reader[3]);
        //                mk._date = Convert.ToDateTime(reader[4]);
        //                mk.kvdata = Convert.ToDouble(mk.data + 273.15);
        //                double d = (0.008314472 * mk.kvdata);
        //                mk.expdata = Math.Exp(-83.14472 / d);
        //                sum = sum + mk.expdata;
        //                mkt.Add(mk);
        //                row.Channel_ID = reader[2].ToString();
        //                double data = Convert.ToDouble(reader[3]);
        //                row.TempData = Math.Round(data, 2).ToString("##.0");
        //                row.Date_Time = reader[4].ToString();
        //                data = Convert.ToDouble(reader[5]);
        //                row.RhData = Math.Round(data, 2).ToString("##.0"); //reader[5].ToString();
        //                dt.LogsTable.AddLogsTableRow(row);
        //            }
        //            if (reader.HasRows)
        //            {
        //                sum = sum / mkt.Count;
        //                sum = Math.Log(sum);
        //                sum = sum / -1;
        //                sum = 10000 / sum;
        //                sum = sum - 273.15;
        //                labelTMKT.Text = sum.ToString("##.00");
        //                statiscticRow.MKT = labelTMKT.Text;

        //                dataGridView1.DataSource = dt;
        //                dataGridView1.DataMember = "LogsTable";
        //                dataGridView1.Columns[0].Width = 60;
        //                dataGridView1.Columns[1].Visible = false;

        //                dataGridView1.Columns[2].HeaderText = "°C";
        //                dataGridView1.Columns[2].Width = 80;

        //                dataGridView1.Columns[3].HeaderText = "Rh";
        //                dataGridView1.Columns[3].Width = 80;
        //                dataGridView1.Columns[4].HeaderText = "Date Time";
        //                dataGridView1.Columns[4].Width = 200;


        //                this.chart1.ChartAreas[0].AxisX.Title = "Date Time";
        //                chart1.ChartAreas[0].AxisX.LabelStyle.Format = "dd/MM/yyyy hh:mm:ss tt";
        //                chart1.Series[0].IsXValueIndexed = true;
        //                chart1.Series[0].XValueType = ChartValueType.DateTime;


        //                chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
        //                chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

        //                chart1.ChartAreas[0].AxisY.LabelStyle.IsEndLabelVisible = false;
        //                chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
        //                chart1.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

        //                chart1.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(chartlow - 5);
        //                chart1.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(charthigh + 5);
        //                chart1.ChartAreas[0].AxisY.Interval = 5;



        //                if (config.Rh_Active == true)
        //                {
        //                    System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();


        //                    series2.ChartArea = "ChartArea1";
        //                    series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        //                    series2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
        //                    //series2.IsValueShownAsLabel = true;
        //                    series2.Legend = "Legend1";
        //                    series2.MarkerImageTransparentColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
        //                    series2.MarkerSize = 8;
        //                    series2.BorderWidth = 3;
        //                    // series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
        //                    series2.Name = "Rh";
        //                    series2.YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
        //                    series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
        //                    this.chart1.Series.Add(series2);
        //                    chart1.Series[1].IsXValueIndexed = true;
        //                    chart1.Series[1].XValueType = ChartValueType.DateTime;

        //                    chart1.ChartAreas[0].AxisY2.Minimum = Convert.ToDouble(chartlow - 5);
        //                    chart1.ChartAreas[0].AxisY2.Maximum = Convert.ToDouble(charthigh + 5);
        //                    chart1.ChartAreas[0].AxisY2.Interval = 5;
        //                    chart1.ChartAreas[0].AxisY2.MajorGrid.LineColor = Color.LightGray;
        //                    chart1.ChartAreas[0].AxisX2.MajorGrid.LineDashStyle = ChartDashStyle.Dash;
        //                    chart1.ChartAreas[0].AxisY2.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

        //                }
        //                if (config.Rh_Active == true)
        //                {
        //                    foreach (MKT item in mkt)
        //                    {
        //                        chart1.Series[0].Points.AddXY(item._date, item.data);
        //                        chart1.Series[1].Points.AddXY(item._date, item.Rhdata);
        //                    }
        //                }
        //                else
        //                {
        //                    foreach (MKT item in mkt)
        //                    {
        //                        chart1.Series[0].Points.AddXY(item._date, item.data);
        //                    }
        //                }



        //                Conn.Close();

        //                ReportViewer reportViewer1 = new ReportViewer();
        //                //reportViewer1.ProcessingMode = ProcessingMode.Local;
        //                //this.reportViewer1.LocalReport.ReportEmbeddedResource = "Log_It.Reports.LogitReportRh.rdlc";
        //                //labeldatapoints.Text = i.ToString();
        //                if (config.Rh_Active == true)
        //                {
        //                    //Report.LogitReportRh rp = new Report.LogitReportRh();
        //                    //rp.SetDataSource(dt);
        //                    //crystalReportViewer1.ReportSource = rp;
        //                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "Log_It.Reports.LogitReportRh.rdlc";

        //                }
        //                else
        //                {
        //                    //Report.LogitReport rp = new Report.LogitReport();
        //                    //rp.SetDataSource(dt);
        //                    //crystalReportViewer1.ReportSource = rp;

        //                    //LogitReport.rdlc
        //                    this.reportViewer1.LocalReport.ReportEmbeddedResource = "Log_It.Reports.LogitReport.rdlc";
        //                }
        //                //ReportParameter rp = new ReportParameter("TLL", tllimit.ToString(),false);

        //                //reportViewer1.LocalReport.SetParameters(rp);
        //                //rp = new ReportParameter("THL", tulimit.ToString(), false);
        //                //reportViewer1.LocalReport.SetParameters(rp);
        //                reportViewer1.LocalReport.SubreportProcessing += LocalReport_SubreportProcessing;

        //                ReportDataSource datasourcelog = new ReportDataSource("DataSet1",dt.Tables["UserInformation"]);
        //                ReportDataSource datasourcelog2 = new ReportDataSource("DataSet2", dt.Tables["CompanyInfo"]);
        //                ReportDataSource datasourcelog3 = new ReportDataSource("DataSet3", dt.Tables["DeviceInformation"]);
        //                ReportDataSource datasourcelog4 = new ReportDataSource("DataSet4", dt.Tables["Statistics"]);
        //                ReportDataSource datasourcelog5 = new ReportDataSource("DataSet5", dt.Tables["LogsTable"]);
        //                ReportDataSource datasourcelog6 = new ReportDataSource("DataSet6", dt.Tables["DeviceRh"]);
        //                ReportDataSource datasourcelog7 = new ReportDataSource("DataSet7", dt.Tables["StatisticsRh"]);

        //                reportViewer1.LocalReport.DataSources.Clear();
        //                reportViewer1.LocalReport.DataSources.Add(datasourcelog);
        //                reportViewer1.LocalReport.DataSources.Add(datasourcelog2);
        //                reportViewer1.LocalReport.DataSources.Add(datasourcelog3);
        //                reportViewer1.LocalReport.DataSources.Add(datasourcelog4);
        //                reportViewer1.LocalReport.DataSources.Add(datasourcelog5);
        //                reportViewer1.LocalReport.DataSources.Add(datasourcelog6);
        //                reportViewer1.LocalReport.DataSources.Add(datasourcelog7);

        //                this.reportViewer1.RefreshReport();
        //                //this.reportViewer1.Dispose();



        //            }
        //            else
        //            {
        //                MessageBox.Show("No record in selected dates");
        //            }
        //        }
        //        #endregion

        //        #region Pa
        //        if (config.Device_Type == 1)
        //        {


        //            SqlCommand cmd = new SqlCommand(Pamax, Conn);
        //            cmd.CommandType = CommandType.Text;
        //            Conn.Open();
        //            SqlDataReader reader = cmd.ExecuteReader();

        //            while (reader.Read())
        //            {
        //                double? Idmax = reader[0] as double? ?? default(double?);
        //                double? Idmin = reader[1] as double? ?? default(double?);
        //                double? Idavg = reader[2] as double? ?? default(double?);

        //                if (Idmax != null)
        //                {
        //                    labelTmax.Text = Idmax.ToString();
        //                }
        //                if (Idmin != null)
        //                {
        //                    labelTmin.Text = Idmin.ToString();
        //                }
        //                if (Idavg != null)
        //                {
        //                    decimal stravg = Convert.ToDecimal(Idavg);
        //                    labelTavg.Text = Decimal.Round(stravg, 2, MidpointRounding.AwayFromZero).ToString();
        //                }


        //            }
        //            statiscticRow.Max = labelTmax.Text;
        //            statiscticRow.Min = labelTmin.Text;
        //            statiscticRow.Avg = labelTavg.Text;
        //            statiscticRow.DateCalibration = labeltemcaldate.Text;
        //            tulimit = Convert.ToDecimal(labelTmax.Text);
        //            tllimit = Convert.ToDecimal(labelTmin.Text);
        //            charthigh = tulimit;
        //            chartlow = tllimit;


        //            Conn.Close();
        //            dt.Statistics.AddStatisticsRow(statiscticRow);

        //                label30.Visible = false;
        //                label29.Visible = false;
        //                line4.Visible = false;
        //                label38.Visible = false;
        //                label37.Visible = false;
        //                label36.Visible = false;
        //                labelHmax.Visible = false;
        //                labelHmin.Visible = false;
        //                labelHavg.Visible = false;


        //            cmd = new SqlCommand(s, Conn);
        //            cmd.CommandType = CommandType.Text;
        //            Conn.Open();
        //            reader = cmd.ExecuteReader();

        //            int i = 0;
        //            List<MKT> mkt = new List<MKT>();

        //            double sum = 0;
        //            while (reader.Read())
        //            {

        //                Reports.DSLogit.LogsTableRow row = dt.LogsTable.NewLogsTableRow();
        //                i++;
        //                row.Point = i.ToString();
        //                MKT mk = new MKT();
        //                mk.Rhdata = Convert.ToDouble(reader[5]);
        //                mk.data = Convert.ToDouble(reader[3]);
        //                mk._date = Convert.ToDateTime(reader[4]);
        //                mk.kvdata = Convert.ToDouble(mk.data + 273.15);
        //                double d = (0.008314472 * mk.kvdata);
        //                mk.expdata = Math.Exp(-83.14472 / d);
        //                sum = sum + mk.expdata;
        //                mkt.Add(mk);
        //                row.Channel_ID = reader[2].ToString();
        //                row.TempData = reader[3].ToString();
        //                row.Date_Time = reader[4].ToString();
        //                row.RhData = reader[5].ToString();
        //                dt.LogsTable.AddLogsTableRow(row);
        //            }
        //            if (reader.HasRows)
        //            {
        //                sum = sum / mkt.Count;
        //                sum = Math.Log(sum);
        //                sum = sum / -1;
        //                sum = 10000 / sum;
        //                sum = sum - 273.15;
        //                labelTMKT.Text = sum.ToString("##.00");
        //                statiscticRow.MKT = labelTMKT.Text;

        //                dataGridView1.DataSource = dt;
        //                dataGridView1.DataMember = "LogsTable";
        //                dataGridView1.Columns[0].Width = 60;
        //                dataGridView1.Columns[1].Visible = false;

        //                dataGridView1.Columns[2].HeaderText = "Pa";
        //                dataGridView1.Columns[2].Width = 80;

        //                dataGridView1.Columns[4].HeaderText = "Date Time";
        //                dataGridView1.Columns[4].Width = 200;


        //                this.chart1.ChartAreas[0].AxisX.Title = "Date Time";
        //                chart1.ChartAreas[0].AxisX.LabelStyle.Format = "MM/dd/yyyy hh:mm:ss tt";
        //                chart1.Series[0].IsXValueIndexed = true;
        //                chart1.Series[0].XValueType = ChartValueType.DateTime;


        //                chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
        //                chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

        //                chart1.ChartAreas[0].AxisY.LabelStyle.IsEndLabelVisible = false;
        //                chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.LightGray;
        //                chart1.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

        //                chart1.ChartAreas[0].AxisY.Minimum = Convert.ToDouble(chartlow - 5);
        //                chart1.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(charthigh + 5);
        //                chart1.ChartAreas[0].AxisY.Interval = 5;





        //                    foreach (MKT item in mkt)
        //                    {
        //                        chart1.Series[0].Points.AddXY(item._date, item.data);
        //                    }




        //                Conn.Close();



        //                labeldatapoints.Text = i.ToString();

        //                    //Report.LogitReport rp = new Report.LogitReport();
        //                    //rp.SetDataSource(dt);
        //                    //crystalReportViewer1.ReportSource = rp;

        //            }
        //            else
        //            {
        //                MessageBox.Show("No record in selected dates");
        //            }
        //        }
        //        #endregion


        //    }
        //    catch (Exception m)
        //    {

        //        MessageBox.Show(m.Message);
        //    }

        //}

        void LocalReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            ReportDataSource datasource = new ReportDataSource("DataSet2", dt.Tables["Acknowladge"]);


            e.DataSources.Add(datasource);

        }

        private void chart1_GetToolTipText(object sender, System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs e)
        {
            if (e.HitTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                int i = e.HitTestResult.PointIndex;
                DataPoint dp = e.HitTestResult.Series.Points[i];
                DateTime dt = DateTime.FromOADate(dp.XValue);
                e.Text = string.Format("TimeStamp: {0:F1}, Value: {1:F1}", dt.ToString(), dp.YValues[0]);

            }
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {

            //Point mousePoint = new Point(e.X, e.Y);

            //chart1.ChartAreas[0].CursorX.SetCursorPixelPosition(mousePoint, true);
            //chart1.ChartAreas[0].CursorY.SetCursorPixelPosition(mousePoint, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr;
            try
            {
                this.chart1.Printing.PrintDocument.DefaultPageSettings.Landscape = true;
                this.pDoc.DefaultPageSettings.Landscape = true;
                dr = this.ppreview.ShowDialog();


            }
            catch (System.Exception winex)
            {
                MessageBox.Show(winex.Message, "Print Preview Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void Footer(Graphics g)
        {
            g.PageUnit = GraphicsUnit.Inch;
            float x = 8.0f, y = 8.0f;
            Font f = new Font("MS Reference Sans Serif", 9);
            g.DrawString("Logit Chart By TECHNOMAN", f, Brushes.Black, x, y);
        }

        private void ChartHeading(Graphics g, string Heading)
        {
            g.PageUnit = GraphicsUnit.Inch;
            float x = 5.25f, y = 1.75f;
            Font f = new Font("Americana BT", 20, FontStyle.Bold | FontStyle.Underline);
            SizeF s = g.MeasureString(Heading, f);
            g.DrawString(Heading, f, Brushes.Black, x - (s.Width / 2), y);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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

        private void pDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            pDoc.DefaultPageSettings.Landscape = true;
            this.PrintPageText(sender, e);
            e.Graphics.PageUnit = GraphicsUnit.Display;
            e.Graphics.TranslateTransform(-25, 145);
            e.Graphics.ScaleTransform(1.0f, 0.7f);
            this.chart1.Printing.PrintPaint(e.Graphics, new Rectangle(0, 0, this.chart1.Width, this.chart1.Height));
        }

        private object[] GetHumditiyParameter()
        {
            object[] obj2 = new object[6];
            for (int i = 0; i < obj2.Length; i++)
            {
                obj2[i] = new object();
                obj2[i] = string.Empty;
            }

            obj2[0] = this.labelstarttime.Text;
            obj2[1] = this.labelendtime.Text;
            obj2[2] = this.labeldatapoints.Text;
            obj2[3] = this.labelHavg.Text;
            obj2[4] = this.labelHmax.Text;
            obj2[5] = this.labelHmin.Text;
            //if (config.Rh_Active == true)
            //{
            //    //obj2[0] = this.labelstarttime.Text;
            //    //obj2[1] = this.labelendtime.Text;
            //    //obj2[2] = this.labeldatapoints.Text;
            //}
            //else if (config.Rh_Active == false)
            //{
            //    //obj2[0] = this.records1.RECODE2.Compute("MIN(DT)", "CHANNELID = '" + this.logitObj.DeviceID + "'");
            //    //obj2[1] = this.records1.RECODE2.Compute("MAX(DT)", "CHANNELID = '" + this.logitObj.DeviceID + "'");
            //    //obj2[2] = this.records1.RECODE2.Count;
            //}
            return obj2;
        }

        private void PrintPageText(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            object[] obj1 = new object[6];
            for (int i = 0; i < obj1.Length; i++)
                obj1[i] = new object();

            if (config.Rh_Active == true)
            {
                obj1[0] = "Temperature/Humidity";
                object[] obj3 = this.GetHumditiyParameter();
                this.HumiditySummary(e.Graphics, obj3);
            }
            else if (config.Rh_Active == false)
                obj1[0] = "Temperature only";

            obj1[1] = config.Location;
            obj1[2] = config.Instrument;
            obj1[3] = config.Interval + " minute(s)";
            obj1[4] = true;
            obj1[5] = instance.UserInstance.Full_Name;

            object[] obj2 = this.GetChannelParameter();


            //DAL.Company company = instance.DataLink.Companies.SingleOrDefault();// Companies.ToArray();
            this.Picture(Application.StartupPath + "\\Log-it_Chart.bmp", e.Graphics);
            this.CDName(labelCompany.Text, depart, e.Graphics);
            this.PrintDT(e.Graphics);
            // this.ChartHeading(e.Graphics, "Log-It Chart");
            this.ChannelDetail(e.Graphics, obj1);
            this.ChartSummary(e.Graphics, obj2);
            //this.Legend(e.Graphics, "Temperature", this.chart1.Series[0].Color, 0);
            //if (logitObj.DeviceType == "01")
            //    this.Legend(e.Graphics, "Humidty", this.chart.ColorHLine, 1);
            this.Footer(e.Graphics);
        }

        private void Legend(Graphics g, string parameter, Color color, int parano)
        {
            g.PageUnit = GraphicsUnit.Inch;
            float x = 6.5f, y = 6.8f;

            Font f = new Font("MS Reference Sans Serif", 10);
            g.DrawString(parameter + ":", f, Brushes.Black, x + 0.2f, y + 0.9f + ((float)parano / 5.0f));

            SizeF s = g.MeasureString("Start Date/Time:i", f);
            g.PageUnit = GraphicsUnit.Pixel;
            SolidBrush sb = new SolidBrush(color);
            g.FillRectangle(sb, (x + 0.2f + s.Width) * g.DpiX, (y + 0.965f + ((float)parano / 5.0f)) * g.DpiY, (0.5f) * g.DpiX, (0.1f) * g.DpiY);
        }

        private void ChartSummary(Graphics g, object[] summary)
        {
            g.PageUnit = GraphicsUnit.Inch;
            float x = 3.5f, y = 6.4f;

            Font f = new Font("MS Reference Sans Serif", 11, FontStyle.Bold | FontStyle.Underline);
            g.DrawString("Temperature", f, Brushes.Black, x + 0.2f, y);
            //g.DrawLine(new Pen(Brushes.Black, 0.01f), 0.5f, 6.78f, 10, 6.78f);

            f = new Font("MS Reference Sans Serif", 10);
            g.DrawString("Start Date/Time:", f, Brushes.Black, x + 0.2f, y + 0.3f);
            g.DrawString("End Date/Time:", f, Brushes.Black, x + 0.2f, y + 0.5f);
            g.DrawString("No. of Records:", f, Brushes.Black, x + 0.2f, y + 0.7f);

            g.DrawString("T-Max:", f, Brushes.Black, x + 0.2f, y + 0.9f);
            g.DrawString("T-Min:", f, Brushes.Black, x + 0.2f, y + 1.1f);


            g.DrawString("Average :", f, Brushes.Black, x + 0.2f, y + 1.3f);

            SizeF s = g.MeasureString("Start Date/Time:i", f);

            f = new Font("MS Reference Sans Serif", 9);
            g.DrawString(summary[0].ToString(), f, Brushes.Black, x + 0.2f + s.Width, y + 0.32f);
            g.DrawString(summary[1].ToString(), f, Brushes.Black, x + 0.2f + s.Width, y + 0.52f);
            g.DrawString(summary[2].ToString(), f, Brushes.Black, x + 0.2f + s.Width, y + 0.73f);
            g.DrawString(summary[4].ToString(), f, Brushes.Black, x + 0.2f + s.Width, y + 0.93f);
            g.DrawString(summary[5].ToString(), f, Brushes.Black, x + 0.2f + s.Width, y + 1.13f);
            if (summary[3] != null)
            {
                g.DrawString(summary[3].ToString(), f, Brushes.Black, x + 0.2f + s.Width, y + 1.34f);
            }
            g.DrawLine(new Pen(Brushes.Black, 0.01f), 3.6f, 6.6f, 3.6f, 8.0f);

        }

        private void ChannelDetail(Graphics g, object[] details)
        {
            g.PageUnit = GraphicsUnit.Inch;
            float x = 0.5f, y = 6.4f;
            Font f = new Font("MS Reference Sans Serif", 11, FontStyle.Bold | FontStyle.Underline);
            g.DrawString("Channel Details", f, Brushes.Black, x, y);
            g.DrawLine(new Pen(Brushes.Black, 0.01f), 0.5f, 6.6f, 10, 6.6f);
            f = new Font("MS Reference Sans Serif", 10);
            g.DrawString("Channel type:", f, Brushes.Black, x + 0.2f, y + 0.3f);
            g.DrawString("Location:", f, Brushes.Black, x + 0.2f, y + 0.5f);
            g.DrawString("Instrument:", f, Brushes.Black, x + 0.2f, y + 0.7f);
            g.DrawString("Logging Interval:", f, Brushes.Black, x + 0.2f, y + 0.9f);
            g.DrawString("Logging On:", f, Brushes.Black, x + 0.2f, y + 1.1f);
            g.DrawString("Signature :", f, Brushes.Black, x + 0.2f, y + 1.3f);

            SizeF s = g.MeasureString("Logging Interval:i", f);

            f = new Font("MS Reference Sans Serif", 9);
            g.DrawString(details[0].ToString(), f, Brushes.Black, x + 0.2f + s.Width, y + 0.32f);
            g.DrawString(details[1].ToString(), f, Brushes.Black, x + 0.2f + s.Width, y + 0.52f);
            g.DrawString(details[2].ToString(), f, Brushes.Black, x + 0.2f + s.Width, y + 0.72f);
            g.DrawString(details[3].ToString(), f, Brushes.Black, x + 0.2f + s.Width, y + 0.92f);
            g.DrawString(details[4].ToString(), f, Brushes.Black, x + 0.2f + s.Width, y + 1.12f);
            g.DrawString(details[5].ToString(), f, Brushes.Black, x + 0.2f + s.Width, y + 1.32f);
            g.DrawLine(new Pen(Brushes.Black, 0.01f), 0.5f, 6.6f, 0.5f, 8.0f);
            g.DrawLine(new Pen(Brushes.Black, 0.01f), 10f, 6.6f, 10f, 8.0f);
            g.DrawLine(new Pen(Brushes.Black, 0.01f), 0.5f, 8.0f, 10, 8.0f);
        }

        private void PrintDT(Graphics g)
        {
            g.PageUnit = GraphicsUnit.Inch;
            float x = 0.5f, y = 1.1f;
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

        private void CDName(string companyname, string deptname, Graphics g)
        {
            g.PageUnit = GraphicsUnit.Inch;
            float x = 10.0f, y = 0.9f;
            Font f = new Font("Arial", 16, System.Drawing.FontStyle.Bold);
            SizeF s1 = g.MeasureString(companyname, f);
            g.DrawString(companyname, f, Brushes.DarkBlue,
                x - s1.Width, y);
            f = new Font("Arial", 16);
            SizeF s2 = g.MeasureString(deptname, f);
            g.DrawString(deptname, f, Brushes.Black,
                x - s2.Width, s2.Height + y);
        }

        private void Picture(string path, Graphics g)
        {
            g.PageUnit = GraphicsUnit.Inch;
            g.DrawImage(Log_It.Properties.Resources.Untitled_1_copy, 0.5f, 0.5f);
        }

        private object[] GetChannelParameter()
        {
            object[] obj2 = new object[6];
            for (int i = 0; i < obj2.Length; i++)
            {
                obj2[i] = new object();
                obj2[i] = string.Empty;
            }

            obj2[0] = this.labelstarttime.Text;
            obj2[1] = this.labelendtime.Text;
            obj2[2] = this.labeldatapoints.Text;
            obj2[3] = this.labelTavg.Text;
            obj2[4] = this.labelTmax.Text;
            obj2[5] = this.labelTmin.Text;
            if (config.Rh_Active == true)
            {
                //obj2[0] = this.labelstarttime.Text;
                //obj2[1] = this.labelendtime.Text;
                //obj2[2] = this.labeldatapoints.Text;
            }
            else if (config.Rh_Active == false)
            {
                //obj2[0] = this.records1.RECODE2.Compute("MIN(DT)", "CHANNELID = '" + this.logitObj.DeviceID + "'");
                //obj2[1] = this.records1.RECODE2.Compute("MAX(DT)", "CHANNELID = '" + this.logitObj.DeviceID + "'");
                //obj2[2] = this.records1.RECODE2.Count;
            }
            return obj2;
        }

        private void HumiditySummary(Graphics g, object[] summary)
        {
            g.PageUnit = GraphicsUnit.Inch;
            float x = 6.5f, y = 6.4f;

            Font f = new Font("MS Reference Sans Serif", 11, FontStyle.Bold | FontStyle.Underline);
            g.DrawString("Humidity", f, Brushes.Black, x + 0.2f, y);
            // g.DrawLine(new Pen(Brushes.Black, 0.01f), 1, 6.78f, 10, 6.78f);

            f = new Font("MS Reference Sans Serif", 10);
            g.DrawString("Start Date/Time:", f, Brushes.Black, x + 0.2f, y + 0.3f);
            g.DrawString("End Date/Time:", f, Brushes.Black, x + 0.2f, y + 0.5f);
            g.DrawString("No. of Records:", f, Brushes.Black, x + 0.2f, y + 0.7f);

            g.DrawString("H-Max:", f, Brushes.Black, x + 0.2f, y + 0.9f);
            g.DrawString("H-Min:", f, Brushes.Black, x + 0.2f, y + 1.1f);


            g.DrawString("Average :", f, Brushes.Black, x + 0.2f, y + 1.3f);

            SizeF s = g.MeasureString("Start Date/Time:i", f);

            f = new Font("MS Reference Sans Serif", 9);
            g.DrawString(summary[0].ToString(), f, Brushes.Black, x + 0.2f + s.Width, y + 0.32f);
            g.DrawString(summary[1].ToString(), f, Brushes.Black, x + 0.2f + s.Width, y + 0.52f);
            g.DrawString(summary[2].ToString(), f, Brushes.Black, x + 0.2f + s.Width, y + 0.73f);
            g.DrawString(summary[4].ToString(), f, Brushes.Black, x + 0.2f + s.Width, y + 0.93f);
            g.DrawString(summary[5].ToString(), f, Brushes.Black, x + 0.2f + s.Width, y + 1.13f);
            if (summary[3] != null)
            {
                g.DrawString(summary[3].ToString(), f, Brushes.Black, x + 0.2f + s.Width, y + 1.34f);
            }
            g.DrawLine(new Pen(Brushes.Black, 0.01f), 6.65f, 6.6f, 6.65f, 8.0f);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            //this.comboTimeScale.EditValue = (int)D2PC.Chart.Time.Hours_1;
            //this.comboGraphMode.EditValue = (int)D2PC.PlottingMode.Realtime;

            //colorChangerInterval_EditValueChanged(this, e);
            //colorChangerImproperShutdown_EditValueChanged(this, e);
            //colorChangerStopLine_EditValueChanged(this, e);
            //colorChangerStartLine_EditValueChanged(this, e);
            //colorChangerTLimits_EditValueChanged(this, e);
            //colorChangerHLimits_EditValueChanged(this, e);
            //colorChangerTLine_EditValueChanged(this, e);
            //colorChangerHLine_EditValueChanged(this, e);
            //colorChangerTLabels_EditValueChanged(this, e);
            //colorChangerHLabels_EditValueChanged(this, e);
            //if (logitObj.DeviceType == "02")
            //    this.groupBox2.Enabled = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog savedialog = new SaveFileDialog();
                savedialog.Filter = "PDF Files|*.pdf";
                string ReportIDT = config.Location + "_T" + labelCompany.Text.Substring(0, 1) + DateTime.Now.Day.ToString("0#") + DateTime.Now.Month.ToString("0#") + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + "T";
                string ReportIDRH = config.Location+ "_T" + labelCompany.Text.Substring(0, 1) + DateTime.Now.Day.ToString("0#") + DateTime.Now.Month.ToString("0#") + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + "TRH";

                string filename = string.Empty;
                switch (config.Device_Type)
                {
                    case 0:
                        filename = ReportIDRH;
                        break;
                    case 1:
                        filename = ReportIDT;
                        break;
                    default:
                        break;
                }
                savedialog.FileName = filename;
                if (savedialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = savedialog.FileName;
                    System.IO.FileInfo fi = new System.IO.FileInfo(fileName);
                    if (fi.Exists)
                    {
                        fi.Delete();
                    }
                    //Warning[] warnings;
                    //string[] streaminds;
                    //string mimetype, ecoding, filenameExtension;
                    byte[] bytes = reportViewer1.LocalReport.Render("PDF");
                    using (FileStream fs = File.Create(fileName))
                    {
                        fs.Write(bytes, 0, bytes.Length);
                        fs.Close();
                        fs.Dispose();
                    }
                    MessageBox.Show("File has been export successfully.");
                    //ackReport.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, fileName);

                }
            }
            catch (Exception m)
            {

                MessageBox.Show(m.Message);
            }
        }
    }
    public class MKT
    {
        public double Rhdata;
        public double data;
        public double kvdata;
        public double expdata;
        public DateTime _date;
    }
}
