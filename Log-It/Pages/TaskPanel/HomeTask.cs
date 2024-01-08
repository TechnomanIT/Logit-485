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
    public partial class HomeTask : TaskControl
    {
        BAL.LogitInstance instance;
        public HomeTask(BAL.LogitInstance instance)
        {
            InitializeComponent();
            if (instance.UserInstance.Authority == "Owner")
            {
                button1.Visible = true;
            }
            //linkLabel1.Links.Add(24, 9, "http://www.technoman.biz");
            this.instance = instance;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;  
            System.Diagnostics.Process.Start("http://www.technoman.biz");  
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Log_It.Forms.Splash sp = new Forms.Splash();
            sp.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Log_It.Forms.Calibrator cl = new Forms.Calibrator(instance);
            cl.ShowDialog();
        }
    }
}
