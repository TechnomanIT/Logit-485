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
    public partial class SetupApp : Form
    {
        public SetupApp()
        {
            InitializeComponent();
            comboBox1.Items.Add(".");
            comboBox1.Items.Add("(local)");
            comboBox1.Items.Add(@"\SQLEXPRESS");
            comboBox1.Items.Add( string.Format(@"{0}\SQLEXPRESS",Environment.MachineName));
            comboBox1.SelectedIndex = 3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionstring = string.Format("Data Source={0};Initial Catalog=master;User ID={1};Password={2}", comboBox1.Text, textBox1.Text, textBox2.Text);
            try
            {
                SQLHelper helper = new SQLHelper(connectionstring);
                if (helper.isConnected)
                {
                    MessageBox.Show("Test Connection Succeeded.","Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            catch (Exception m)
            {

                MessageBox.Show(m.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    internal class SQLHelper
    {
        System.Data.SqlClient.SqlConnection cn;
        public SQLHelper(string connection)
        {
            cn = new System.Data.SqlClient.SqlConnection(connection);

        }
        public bool isConnected
        {
            get
            {
                if (cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }

}
