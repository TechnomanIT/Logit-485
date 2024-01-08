using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log_It.Forms
{
    public partial class EventFilterForm : Form
    {
        BAL.LogitInstance instance;
        public EventFilterForm(BAL.LogitInstance instance)
        {
            InitializeComponent();
            this.instance = instance;
            if (instance.DataLink.EventLogs.Count() > 0)
            {
                foreach (var item in instance.DataLink.EventLogs.Where(x => x.EventName != "Error" || x.UserName != "System"))
                {
                    if (!checkedListBoxUsers.Items.Contains(item.UserName))
                    {
                        checkedListBoxUsers.Items.Add(item.UserName);
                    }
                    if (!checkedListBoxEvents.Items.Contains(item.EventName))
                    {
                        checkedListBoxEvents.Items.Add(item.EventName);
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonFilterLogs_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxFilter.Enabled = true;
        }

        private void radioButtonAllLogs_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxFilter.Enabled = false;
        }

        private void radioButtonAllDate_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxDateTime.Enabled = false;
        }

        private void radioButtonFilterDate_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxDateTime.Enabled = true;
        }

        private void dateTimePickerEndDate_Leave(object sender, EventArgs e)
        {
            TimeSpan sp = dateTimePickerEndDate.Value.Subtract(dateTimePickerStartDate.Value);
            if (sp.Days < 0)
            {
                MessageBox.Show("Please Select correct End Date");
                dateTimePickerEndDate.Value = DateTime.Now;
            }

        }

        private void radioButtonAlluser_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxUser.Enabled = false;
        }

        private void radioButtonFilterUser_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxUser.Enabled = true;
        }

        private void radioButtonAllEvents_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxEvents.Enabled = false;
        }

        private void radioButtonFilterEvents_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxEvents.Enabled = true;
        }

        private void dateTimePickerEndTime_Leave(object sender, EventArgs e)
        {
            //TimeSpan sp = dateTimePickerEndTime.Value.Subtract(dateTimePickerStartTime.Value);
            //if (sp.Minutes < 0)
            //{
            //    MessageBox.Show("Please Select correct End Time");
            //    dateTimePickerEndDate.Value = DateTime.Now;
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string datestr = string.Empty;
            string userstr = string.Empty;
            string eventstr = string.Empty;
          
            string commnd = "select * from eventlog Where";


            if (radioButtonAllLogs.Enabled)
            {
                
                if (instance.DataLink.EventLogs.Count() == 0)
                {
                    return;
                    
                }
                Log_It.Reports.DSLogit dt = new Reports.DSLogit();
                
                if (radioButtonAllLogs.Checked)
                {
                    foreach (var item in instance.DataLink.EventLogs.Where( x => x.EventName != "Error" ).OrderByDescending(x => x.DateTime))
                    {
                        Reports.DSLogit.EventLogRow row = dt.EventLog.NewEventLogRow();

                        row.ID = item.ID.ToString();
                        row.DateTime = item.DateTime.ToString();
                        row.EventName = item.EventName;
                        row.UserName = item.UserName;
                        row.MessageLog = item.MessageLog;
                        dt.EventLog.AddEventLogRow(row);
                    }
                }

                if (radioButtonFilterLogs.Checked)
                {
                    List<DAL.EventLog> logs = instance.DataLink.EventLogs.ToList();    
                    if (radioButtonAllDate.Checked)
                    {
                        datestr = string.Empty;
                    }
                    if (radioButtonFilterDate.Checked)
                    {
                        datestr = "([DateTime] >= '"+ dateTimePickerStartDate.Value.ToString("MM/dd/yyyy 00:00:00") +"' AND [DateTime] <= '"+dateTimePickerEndDate.Value.ToString("MM/dd/yyyy 23:59:59") +"')";
                    }
                    
                     if (radioButtonAlluser.Checked)
                     {
                         userstr = string.Empty;
                     }
                     if (radioButtonFilterUser.Checked)
                     {
                         if (checkedListBoxUsers.Items.Count > 0)
                         {
                             List<string> userlist = new List<string>();
                             for (int i = 0; i < checkedListBoxUsers.Items.Count; i++)
                             {
                                 if (checkedListBoxUsers.GetItemChecked(i))
                                 {
                                     userlist.Add(checkedListBoxUsers.Items[i].ToString());
                                 }
                             }
                             if (userlist.Count > 1)
                             {
                                 string strUser = "(" ;
                                 for (int i = 0; i < userlist.Count; i++)
                                 {
                                     strUser = strUser + "UserName Like '" + userlist[i] + "' OR ";
                                 }
                                 strUser = strUser.Remove(strUser.Length - 3, 3);
                                 strUser = strUser + ")";
                                 userstr = strUser;
                             }
                             else
                             {
                                 userstr  = "( UserName Like '" + userlist[0] + "')";
                             }

                         }
                        
                     }
                     if (radioButtonAllEvents.Checked)
                     {
                         eventstr = string.Empty;
                     }
                     if (radioButtonFilterEvents.Checked)
                     {

                         if (checkedListBoxEvents.Items.Count > 0)
                         {
                             List<string> userEvent = new List<string>();
                             for (int i = 0; i < checkedListBoxEvents.Items.Count; i++)
                             {
                                 if (checkedListBoxEvents.GetItemChecked(i))
                                 {
                                     userEvent.Add(checkedListBoxEvents.Items[i].ToString());
                                 }
                             }
                             if (userEvent.Count > 1)
                             {
                                 string strEvent = "(";
                                 for (int i = 0; i < userEvent.Count; i++)
                                 {
                                     strEvent = strEvent + "EventName Like '" + userEvent[i] + "' OR ";
                                 }
                                 strEvent = strEvent.Remove(strEvent.Length - 3, 3);
                                 strEvent = strEvent + ")";
                                 eventstr = strEvent;
                             }
                             else
                             {
                                 eventstr = "( EventName Like '" + userEvent[0] + "')";
                             }

                         }
                     }

                    //0 0 0
                     if (datestr == string.Empty && userstr == string.Empty && eventstr == string.Empty)
                     {
                         commnd = "select * from eventlog";
                         if (instance.UserInstance.Authority != "Owner")
                         {
                             commnd = commnd + " Where UserName NOT like 'System'";
                         }
                     }
                     if (datestr != string.Empty && userstr == string.Empty && eventstr == string.Empty)
                     {
                         commnd =  commnd + datestr;
                         if (instance.UserInstance.Authority != "Owner")
                         {
                             commnd = commnd + "AND (UserName NOT like 'System' )";
                         }
                     }
                     //1 1 0
                     if (datestr != string.Empty && userstr != string.Empty && eventstr == string.Empty)
                     {
                         commnd = commnd + datestr + " AND " + userstr;
                         if (instance.UserInstance.Authority != "Owner")
                         {
                             commnd = commnd + "AND (UserName NOT like 'System' )";
                         }
                     }
                     //1 1 1
                     if (datestr != string.Empty && userstr != string.Empty && eventstr != string.Empty)
                     {
                         commnd = commnd + datestr + " AND " + userstr + " AND " + eventstr ;
                         if (instance.UserInstance.Authority != "Owner")
                         {
                             commnd = commnd + "AND (UserName NOT like 'System' )";
                         }
                     }
                     //1 0 1
                     if (datestr != string.Empty && userstr == string.Empty && eventstr != string.Empty)
                     {
                         commnd = commnd + datestr + " AND " + eventstr;
                         if (instance.UserInstance.Authority != "Owner")
                         {
                             commnd = commnd + "AND (UserName NOT like 'System' )";
                         }
                     }
                     //0 1 1
                     if (datestr == string.Empty && userstr != string.Empty && eventstr != string.Empty)
                     {
                         commnd = commnd + userstr + " AND " + eventstr;
                         if (instance.UserInstance.Authority != "Owner")
                         {
                             commnd = commnd + "AND (UserName NOT like 'System' )";
                         }
                     }
                     //0 0 1
                     if (datestr == string.Empty && userstr == string.Empty && eventstr != string.Empty)
                     {
                         commnd = commnd + eventstr;
                         if (instance.UserInstance.Authority != "Owner")
                         {
                             commnd = commnd + "AND (UserName NOT like 'System' )";
                         }
                     }
                     //0 1 0
                     if (datestr == string.Empty && userstr != string.Empty && eventstr == string.Empty)
                     {
                         commnd = commnd + userstr;
                         if (instance.UserInstance.Authority != "Owner")
                         {
                             commnd = commnd + "AND (UserName NOT like 'System' )";
                         }

                     }
                    

                     commnd = commnd + " Order by  [DateTime] DESC ";
                     SqlConnection Conn = new SqlConnection(instance.DataLink.Connection.ConnectionString);
                   
                     SqlCommand cmd = new SqlCommand(commnd, Conn);
                     cmd.CommandType = CommandType.Text;
                     Conn.Open();
                     SqlDataReader reader  = cmd.ExecuteReader();
                     while (reader.Read())
                     {
                         int i = 0;
                         Reports.DSLogit.EventLogRow row = dt.EventLog.NewEventLogRow();

                         row.ID = reader[0].ToString();
                         row.DateTime = reader[1].ToString();
                         row.EventName = reader[2].ToString();
                         row.UserName = reader[3].ToString();
                         row.MessageLog = reader[4].ToString();
                         dt.EventLog.AddEventLogRow(row);
                         i++;

                     }
                     Conn.Close();
                }

                Reports.DSLogit.CompanyInfoRow comrow = dt.CompanyInfo.NewCompanyInfoRow();
                comrow.CompanyName = instance.Companiess.SingleOrDefault().Company_Name;
                comrow.Department = instance.Companiess.SingleOrDefault().Department;
                dt.CompanyInfo.AddCompanyInfoRow(comrow);

                Reports.DSLogit.UserInformationRow userrow = dt.UserInformation.NewUserInformationRow();
                userrow.FullName = instance.UserInstance.Full_Name;
                dt.UserInformation.AddUserInformationRow(userrow);

                //Report.EventCrystalReport report = new Report.EventCrystalReport();
                ////Report.CrystalReport1 rp1 = new Report.CrystalReport1();
                ////rp1.SetParameterValue("Image url",@"C:\Users\Public\Pictures\Sample Pictures\Penguins.jpg");
                //report.SetDataSource(dt);
                Log_It.Forms.LogitReport rp = new LogitReport(dt);
                rp.ShowDialog();
                this.Close();
            }
        }
    }
}
