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
    public partial class SMSConfigPage : ControlPage
    {
        BAL.LogitInstance instance;
        List<DAL.SM> listSMS;
        List<string> RemovelistEmail;
        List<string> AddlistEmail;

        public SMSConfigPage(BAL.LogitInstance instance)
        {
            InitializeComponent();
            listSMS = new List<DAL.SM>();
            RemovelistEmail = new List<string>();
            AddlistEmail = new List<string>();

            this.instance = instance;
            this.RefreshPage();
            //if (instance.SMSs.Count() > 0)
            //{
            //    foreach (var item in instance.SMSs.ToList())
            //    {
            //        listBoxAdded.Items.Add(item.ID);
            //        listSMS.Add(item);

            //    }
            //}
            //if (instance.Users.Count() > 0)
            //{
            //    foreach (var item in instance.Users.Where(e => e.Role != 0))
            //    {
            //        listBox4Add.Items.Add(item.SMS);
            //    }
            //}
        }

        public override void RefreshPage()
        {
            base.RefreshPage();
            if (listBoxAdded.Items.Count > 0)
            {
                listBoxAdded.Items.Clear();
                listSMS.Clear();
            }

            if (listBox4Add.Items.Count > 0)
            {
                listBox4Add.Items.Clear();
               
            }

            if (instance.SMSs.Count() > 0)
            {
                foreach (var item in instance.SMSs.ToList())
                {
                    listBoxAdded.Items.Add(item.SMS);
                    listSMS.Add(item);

                }
            }
            if (instance.Users.Count() > 0)
            {
                foreach (var item in instance.Users.Where(e => e.Role != 0))
                {
                    listBox4Add.Items.Add(item.SMS);
                }
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBoxAdded.SelectedIndex != -1)
            {
                RemovelistEmail.Add(listBoxAdded.SelectedItem.ToString());
                listBoxAdded.Items.Remove(listBoxAdded.SelectedItem);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (listSMS.Count > 0)
                {
                    if (instance.DataLink.Connection.State == System.Data.ConnectionState.Closed)
                    {
                        instance.DataLink.Connection.Open();
                    }
                    instance.DataLink.SMs.DeleteAllOnSubmit(listSMS);
                    instance.DataLink.SubmitChanges();
                }
                if (listBoxAdded.Items.Count > 0)
                {
                    for (int i = 0; i < listBoxAdded.Items.Count; i++)
                    {
                        DAL.SM email = new DAL.SM();
                        email.ID = Guid.NewGuid();
                        email.SMS = listBoxAdded.Items[i].ToString();
                        if (instance.DataLink.Connection.State == System.Data.ConnectionState.Closed)
                        {
                            instance.DataLink.Connection.Open();
                        }
                        instance.DataLink.SMs.InsertOnSubmit(email);
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
