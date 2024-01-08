using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log_It.CustomControls
{
    public partial class UserConfigControl : UserControl
    {
        public bool RhActive;
        private int id;
        public int Id
        {
            get
            {

                return id;
            }
            set
            {
                id = value;
                labelID.Text = value.ToString();
            }
        }
        public Guid GUID
        { get; set; }
        public UserConfigControl()
        {
            InitializeComponent();
            if (!checkBoxRh.Checked)
            {
                groupBoxHumadity.Enabled = false;
            }
            if (!checkBoxActive.Checked)
            {
                groupBoxDevice.Enabled = false;
            }
            for (int i = 1; i <= 60; i++)
            {
                comboBox.Items.Add(i.ToString());
            }
            comboBox.SelectedIndex = 14;

        }

        public bool ValidateControl()
        {
            if (textBoxlocation.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Location.");
                return false;
            }

            if (textBoxTLL.Text == string.Empty || textBoxTUL.Text == string.Empty || textBoxTLR.Text == string.Empty || textBoxTUR.Text == string.Empty)
            {
                Log_It.Forms.DialogForm df = new Forms.DialogForm();
                df.ShowDialog();
                if (df.DialogResult == DialogResult.Cancel)
                {
                    return false;
                }
                else
                {
                    if (textBoxTLL.Text == string.Empty)
                    {
                        textBoxTLL.Text = "0";
                    }
                    if (textBoxTUL.Text == string.Empty)
                    {
                        textBoxTUL.Text = "100";
                    }
                    if (textBoxTLR.Text == string.Empty)
                    {
                        textBoxTLR.Text = "0";
                    }
                    if (textBoxTUR.Text == string.Empty)
                    {
                        textBoxTUR.Text = "100";
                    }
                }
            } 
            if (checkBoxRh.Checked)
            {
                if (textBoxHLL.Text == string.Empty || textBoxHLR.Text == string.Empty || textBoxHUL.Text == string.Empty || textBoxHUR.Text == string.Empty)
                {
                    Log_It.Forms.DialogForm df = new Forms.DialogForm();
                    if (df.DialogResult == DialogResult.Cancel)
                    {
                        return false;
                    }
                    else
                    {
                        if (textBoxHLL.Text == string.Empty)
                        {
                            textBoxHLL.Text = "0";
                        }
                        if (textBoxHUL.Text == string.Empty)
                        {
                            textBoxHUL.Text = "100";
                        }
                        if (textBoxHLR.Text == string.Empty)
                        {
                            textBoxHLR.Text = "0";
                        }
                        if (textBoxHUR.Text == string.Empty)
                        {
                            textBoxHUR.Text = "100";
                        }
                    }
                } 
            }
            
            return true;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxHumadity.Enabled = checkBoxRh.Checked;
        }

        private void checkBoxActive_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxDevice.Enabled = checkBoxActive.Checked;
        }

        private void textBoxTLL_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch( t.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                t.Text = t.Text.Remove(t.Text.Length - 1);
            }
        }

        private void checkBoxAlaram_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
