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
    public partial class CWSearch : Form
    {
        public event WizardCom MainPage;
        public event WizardCom TimeOut;
        public event WizardCom NewDevice;


        private string[] sChannelIDs;

        public CWSearch()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.progressBarControl1.Value >= 100)
            {
                timer1.Enabled = false;
                if (TimeOut != null)
                    TimeOut();
            }
            else
                this.progressBarControl1.Value = this.progressBarControl1.Value + 1;
        }
        private void mp_NextPage(int i)
        {
            Console.WriteLine(i);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (MainPage != null)
                MainPage();	
        }

        private void CWSearch_Activated(object sender, EventArgs e)
        {

        }

        private bool Contain(string ID)
        {
            for (int i = 0; i < sChannelIDs.Length; i++)
                if (sChannelIDs[i] == ID)
                    return true;
            return false;
        }		

        public void SearchDevice()
        {
            //if (!Contain(CommAdapter.DeviceID))
            //{
            //    timer1.Enabled = false;
            //    if (NewDevice != null)
            //        NewDevice();
            //}
        }
    }
}
