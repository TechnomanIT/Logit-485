using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Log_It.Pages
{
    public partial class DeviceConfigPage : ControlPage
    {
        public delegate void SetDeviceID(int id);
        public event SetDeviceID IDSetDevice;
        BAL.LogitInstance instance;
        public DeviceConfigPage(BAL.LogitInstance instance)
        {
            this.instance = instance;
            InitializeComponent();
            RefreshPage();
        }
        public override void RefreshPage()
        {
            try
            {
                base.RefreshPage();
                if (instance.DataLink.Device_Configs.Count() > 0)
                {

                    bindingSource1.DataSource = instance.DataLink.AllDevices.OrderBy(c => c.Device_Id).ThenBy(n => n.Type);

                    dataGridView1.DataSource = bindingSource1;
                    dataGridView1.Columns[0].HeaderText = "Device ID";
                    dataGridView1.Columns[8].HeaderText = "Rh Active";
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Columns[6].Visible = false;
                    dataGridView1.Refresh();
                }
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");

            }
           
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (IDSetDevice != null)
                {
                    IDSetDevice((int)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                }
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");

            }
           
        }
    }
}
