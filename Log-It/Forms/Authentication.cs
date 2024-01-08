using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAL;
using Technoman.Utilities;
using DAL;

namespace Log_It.Forms
{
    public partial class Authentication : BaseForm
    {

        BAL.LogitInstance Instance;
        BAL.Authentication aut;
        public DAL.User UserInstance { get; set; }
        public Authentication(BAL.LogitInstance instance )
        {
            this.Instance = instance;
            InitializeComponent();
            aut = new BAL.Authentication(Instance);
        }

        private bool FormValidation()
        {
            if (textBoxUsername.Text == string.Empty)
            {
                MessageBox.Show("Please enter the User Name.");
                textBoxUsername.Focus();
                return false;
            }
            if (textBoxpassword.Text == string.Empty)
            {
                MessageBox.Show("Please enter the Password.");
                textBoxpassword.Focus();
                return false;
            }
            return true;
        }

        private void buttonlogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!FormValidation())
                {
                    return;
                }
                if (aut.IsUserValid(textBoxUsername.Text, textBoxpassword.Text))
                {
                    //MessageBox.Show("successed");
                    UserInstance = aut.GetUser;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {

                    MessageBox.Show("Invalid User name and Password");
                    EventClass.WriteLog(Technoman.Utilities.EventLog.Warning, "User try to login failed", textBoxUsername.Text);
                    textBoxUsername.Text = string.Empty;
                    textBoxpassword.Text = string.Empty;
                    textBoxUsername.Focus();
                    
                }
            }
            catch (Exception m)
            {

                MessageBox.Show(m.Message);
            }
            
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
