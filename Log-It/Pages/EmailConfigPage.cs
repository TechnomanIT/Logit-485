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
    public partial class EmailConfigPage : ControlPage
    {
        BAL.LogitInstance instance;
        List<DAL.Email> listEmail;
        List<string> RemovelistEmail;
        List<string> AddlistEmail;
        public EmailConfigPage(BAL.LogitInstance instance)
        {
            InitializeComponent();
            listEmail = new List<DAL.Email>();
            RemovelistEmail = new List<string>();
            AddlistEmail = new List<string>();
            this.instance = instance;
            this.RefreshPage();
        }

        public override void RefreshPage()
        {
            base.RefreshPage();
            if (listBoxAdded.Items.Count > 0)
            {
                listBoxAdded.Items.Clear();
                listEmail.Clear();
            }

            if (listBox4Add.Items.Count > 0)
            {
                listBox4Add.Items.Clear();

            }

            if (instance.Emails.Count() > 0)
            {
                foreach (var item in instance.DataLink.Emails.ToList())
                {
                    listBoxAdded.Items.Add(item.EmailID);
                    listEmail.Add(item);

                }
            }
            if (instance.Users.Count() > 0)
            {
                foreach (var item in instance.Users.Where(e => e.Role != 0))
                {
                    listBox4Add.Items.Add(item.Email);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBoxAdded.SelectedIndex != -1)
            {
                RemovelistEmail.Add(listBoxAdded.SelectedItem.ToString());
                listBoxAdded.Items.Remove(listBoxAdded.SelectedItem) ;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox4Add.SelectedIndex != -1)
            {
                if (!listBoxAdded.Items.Contains(listBox4Add.SelectedItem))
                {
                    listBoxAdded.Items.Add(listBox4Add.SelectedItem);
                    AddlistEmail.Add(listBox4Add.SelectedItem.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (listEmail.Count > 0)
                {
                    if (instance.DataLink.Connection.State == System.Data.ConnectionState.Closed)
                    {
                        instance.DataLink.Connection.Open();
                    }
                    instance.DataLink.Emails.DeleteAllOnSubmit(listEmail);
                    instance.DataLink.SubmitChanges();
                }
                if (listBoxAdded.Items.Count > 0)
                {
                    for (int i = 0; i < listBoxAdded.Items.Count; i++)
                    {
                        DAL.Email email = new DAL.Email();
                        email.ID = Guid.NewGuid();
                        email.EmailID = listBoxAdded.Items[i].ToString();
                        if (instance.DataLink.Connection.State == System.Data.ConnectionState.Closed)
                        {
                            instance.DataLink.Connection.Open();
                        }
                        instance.DataLink.Emails.InsertOnSubmit(email);
                    }
                }

                instance.DataLink.SubmitChanges();
                MessageBox.Show("Configuration has been updated.");
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
