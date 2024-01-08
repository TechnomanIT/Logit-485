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
    public delegate void Wizard(int i);
    public delegate void WizardCom();

    public partial class CWMain : Form
    {
        //public event Wizard NextPage;
        public event WizardCom Finish;

        private int iAllowedDevice = 0;
        private bool IsAllowed = true;
        public BAL.LogitInstance instance { get; set; }      
        RadioButton rbuttion;
        public CWMain()
        {
            InitializeComponent();
            
          
            //this.NextPage += CWMain_NextPage;
            if ( instance.Device_Configes.Count() > 0)
            {
                listBoxDevice.DisplayMember = "Instrument";
                listBoxDevice.DataSource = instance.Device_Configes.ToList();
            }
        }

        void CWMain_NextPage(int i)
        {
            //throw new NotImplementedException();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
            System.Windows.Forms.RadioButton rb = (sender as RadioButton);

            if (!rb.Checked)
            {
                foreach (var c in Controls)
                {
                    if (c is RadioButton && (c as RadioButton).Tag.ToString() == rb.Tag.ToString())
                    {
                        (c as RadioButton).Checked = false;
                    }
                }

                rb.Checked = true;
                rbuttion = rb;
            }
        }

        private void CWMain_Load(object sender, EventArgs e)
        {
   
        }

        private void buttoncancel_Click(object sender, EventArgs e)
        {
            if (Finish != null)
                Finish();
            this.Hide();
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            //if (userinstance.Role == 2)
            //{
            //    if (NextPage != null)
            //        NextPage(0);
              
            //}
            //else
            //    MessageBox.Show("You can not proceed." + "\r\n"
            //        + "Only Administrators are allowed to Configure the system.", "Access Violation", MessageBoxButtons.OK, MessageBoxIcon.Information);			
	
        }
    }
}
