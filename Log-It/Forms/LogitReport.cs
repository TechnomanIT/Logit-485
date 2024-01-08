
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Log_It.Reports;
using Microsoft.Reporting.WinForms;

namespace Log_It.Forms
{
     
    public partial class LogitReport : Form
    {
        private  DSLogit dt;


        public LogitReport(Reports.DSLogit dt)
        {
            InitializeComponent();
            this.dt = dt;
        }

        private void LogitReport_Load(object sender, EventArgs e)
        {
            ReportDataSource datasource2 = new ReportDataSource("DataSet1", dt.Tables["EventLog"]);
            ReportDataSource datasource1 = new ReportDataSource("DataSet2", dt.Tables["CompanyInfo"]);
            ReportDataSource datasource = new ReportDataSource("DataSet3", dt.Tables["UserInformation"]);           
            
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(datasource);
            reportViewer1.LocalReport.DataSources.Add(datasource1);
            reportViewer1.LocalReport.DataSources.Add(datasource2);
            this.reportViewer1.RefreshReport();           
        }
    }
}
