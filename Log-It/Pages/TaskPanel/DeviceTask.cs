using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log_It.Pages.TaskPanel
{
    public partial class DeviceTask : TaskControl
    {
        public delegate void DeviceAdd();
        public event DeviceAdd AddDevice;

        public delegate void DeviceAdded();
        public event DeviceAdded AddedDevice;


        public delegate void DeviceModfied();
        public event DeviceModfied ModifiedDevice;

        public delegate void DeviceDelete();
        public event DeviceDelete DeleteDevice;
        int user;
        BAL.LogitInstance instance;
        bool isNew;

        public DeviceTask(int id, BAL.LogitInstance instance)
        {
            this.user = id;
            this.instance = instance;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ModifiedDevice != null)
            {
                ModifiedDevice();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DeleteDevice != null)
            {
                DeleteDevice();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            DAL.SYSProperty properties = instance.DataLink.SYSProperties.SingleOrDefault(x => x.ID == 0);
            int count = instance.Device_Configes.Count(y => y.Active == true);
            if (count >= (int)properties.Number_Devices)
            {
                MessageBox.Show("Device already full as per configuration, Please coordinate with system provider", "System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (AddDevice != null)
            {
                AddDevice();
            }
        }

        void form_close()
        {
            if (AddedDevice != null)
            {
                AddedDevice();
            }
        }
    }
}
