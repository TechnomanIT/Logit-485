using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log_It.Forms
{
    public partial class DeviceOption : Form
    {
        public int option = 0;
        public DeviceOption()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                option = 0;
            }
            if (radioButton2.Checked)
            {
                option = 1;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
        
    }
}
