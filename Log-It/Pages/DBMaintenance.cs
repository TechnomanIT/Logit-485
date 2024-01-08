using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Security.Principal;
using System.Security.AccessControl;
using System.Diagnostics;

namespace Log_It.Pages
{
    public partial class DBMaintenance : ControlPage
    {
        BAL.LogitInstance instance;
        public DBMaintenance(BAL.LogitInstance instance)
        {
            InitializeComponent();
            this.instance = instance;
            try
            {
                label7.Text = instance.SystemProperties.backuplocation;
                SqlConnection Conn = new SqlConnection(instance.DataLink.Connection.ConnectionString);
                SqlCommand testCMD = new SqlCommand("sp_spaceused", Conn);
                SqlCommand cmd = new SqlCommand("select @@version AS 'Server Name' ", Conn);
                testCMD.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.Text;
                Conn.Open();
                SqlDataReader reader = testCMD.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        labelDBName.Text = reader["database_name"].ToString();
                        labelFileSize.Text = reader["database_size"].ToString();

                    }
                }
                Conn.Close();
                Conn.Open();

                SqlDataReader r = cmd.ExecuteReader();
                if (r.HasRows)
                {
                    while (r.Read())
                    {
                        labelServerType.Text = r["Server Name"].ToString();
                    }
                }
                Conn.Close();
            }
            catch (Exception m)
            {

                MessageBox.Show(m.Message);
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fb = new FolderBrowserDialog();
                if (fb.ShowDialog() == DialogResult.OK)
                {
                    string files = fb.SelectedPath;
                    Directory.CreateDirectory(files);
                    var directoryInfo = new DirectoryInfo(files);
                    var directorySecurity = directoryInfo.GetAccessControl();
                    var currentUserIdentity = WindowsIdentity.GetCurrent();
                    var fileSystemRule = new FileSystemAccessRule("EveryOne",
                                                                  FileSystemRights.FullControl,
                                                                  InheritanceFlags.ObjectInherit |
                                                                  InheritanceFlags.ContainerInherit,
                                                                  PropagationFlags.None,
                                                                  AccessControlType.Allow);

                    directorySecurity.AddAccessRule(fileSystemRule);
                    directoryInfo.SetAccessControl(directorySecurity);
                     instance.SystemProperties.backuplocation = files + @"\";
                     label7.Text = instance.SystemProperties.backuplocation;
                     if (instance.DataLink.Connection.State == System.Data.ConnectionState.Closed)
                     {
                         instance.DataLink.Connection.Open();
                     }
                    instance.DataLink.SubmitChanges();
                }
            }
            catch (Exception m)
            {

                MessageBox.Show(m.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreateBackup();

        }


        private void CreateBackup()
        {
            try
            {


                string backuplocation = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Data\";
                if (!Directory.Exists(backuplocation))
                {
                    Directory.CreateDirectory(backuplocation);
                    var directoryInfo = new DirectoryInfo(backuplocation);
                    var directorySecurity = directoryInfo.GetAccessControl();
                    var currentUserIdentity = WindowsIdentity.GetCurrent();
                    var fileSystemRule = new FileSystemAccessRule("EveryOne",
                                                                  FileSystemRights.FullControl,
                                                                  InheritanceFlags.ObjectInherit |
                                                                  InheritanceFlags.ContainerInherit,
                                                                  PropagationFlags.None,
                                                                  AccessControlType.Allow);

                    directorySecurity.AddAccessRule(fileSystemRule);
                    directoryInfo.SetAccessControl(directorySecurity);
                }


                string DataBase = instance.DataLink.Connection.Database;
                //string userid = BAL.Authentication.GetDec(instance.SystemProperties.idlog);
                //string password = BAL.Authentication.GetDec(instance.SystemProperties.passlog);
                //string serverInstance = instance.SystemProperties.serverinstance;
                if (instance.SystemProperties.backuplocation != null)
                {
                    backuplocation = instance.SystemProperties.backuplocation;
                }
                try
                {
                    SqlConnection Conn = new SqlConnection(instance.DataLink.Connection.ConnectionString);
                    SqlCommand cmd = new SqlCommand("Create_dbBackup", Conn);//INSERT INTO Eventlog (ID, DateTime,UserName, EventName, MessageLog) VALUES ('" + Guid.NewGuid() + "'," + (DateTime)DateTime.Now + ",'" + username + "','" + log.ToString() + "','" + Message + "')", Conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (Conn.State == ConnectionState.Closed)
                    {
                        Conn.Open();
                    }
                    cmd.Parameters.Add(new SqlParameter("@dbName", "PlotterRS485"));
                    cmd.Parameters.Add(new SqlParameter("@location", backuplocation + @"\" + DataBase + DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + ".bak"));


                    cmd.ExecuteNonQuery();
                    Conn.Close();

                    MessageBox.Show("Backup has been created");

                }
                catch (Exception m)
                {
                    MessageBox.Show(m.Message);
                }

                Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Information, "Backup has been done", "System");
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);
                MessageBox.Show(m.InnerException.Message);
                var currentMethodName = sf.GetMethod();
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
            }
        }
    }
}
