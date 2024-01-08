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
    public partial class Shutdown : Form
    {
        public string comments { get; set; }
        public DAL.User User { get; set; }
        List<DAL.User> users;
        public Shutdown(List<DAL.User> users)
        {
            this.users = users;
            InitializeComponent();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            if (!comboBox1.Items.Contains( comboBox1.Text))
            {
                MessageBox.Show("Please select the drop down list");
                comboBox1.Text = string.Empty;
            }
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!comboBox1.Items.Contains(comboBox1.Text))
            {
                MessageBox.Show("Please select the drop down list");
                comboBox1.Text = string.Empty;
            }
            else
            {
                comments = comboBox1.Text;
                button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxUser.Text == string.Empty)
            {
                MessageBox.Show("Please enter the user name");
                return;
            }
            if (textBoxpassword.Text == string.Empty)
            {
                MessageBox.Show("Please enter the password");
                return;
            }
            
            DAL.User user = null;

            if (textBoxUser.Text != string.Empty && textBoxpassword.Text != string.Empty)
            {
               user = users.SingleOrDefault(x => x.User_Name == textBoxUser.Text && x.Password == BAL.Authentication.GetEc(textBoxpassword.Text) && x.Active == true && x.IsRowEnable == true);
                if (user == null)
                {
                    MessageBox.Show("Please enter the user which is loggin in currently");
                    textBoxUser.Text = string.Empty;
                    textBoxpassword.Text = string.Empty;

                    return;
                }
                else
                {
                    this.User = user;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
    }
}
