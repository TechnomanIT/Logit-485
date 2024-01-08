using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Technoman.Utilities
{
    public enum EventLog
    {
        Modfiy,
        Startup,
        Login,
        Logout,
        Shutdown,
        //Error,
        Warning,
        Timeout,
        Alaram,
        System,
        Information
    }

    public static  class EventClass
    {
        public static string connectionstring = string.Empty;
        public static string fileName =  Path.Combine(Path.GetTempPath(), "ErrorLog.txt");
               //Application.StartupPath + "\\LogError.txt";
        static readonly object _object = new object();
        static readonly object _objectError = new object();
        public static  void WriteLog(EventLog log, string Message, string username)
        {
            try

            {
                
                SqlConnection Conn = new SqlConnection(connectionstring);
                Message = Message.Replace("'", "!");
                SqlCommand cmd = new SqlCommand("InsertEventLog", Conn);//INSERT INTO Eventlog (ID, DateTime,UserName, EventName, MessageLog) VALUES ('" + Guid.NewGuid() + "'," + (DateTime)DateTime.Now + ",'" + username + "','" + log.ToString() + "','" + Message + "')", Conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (Conn.State == ConnectionState.Closed)
                {
                    Conn.Open();
                }
                cmd.Parameters.Add(new SqlParameter("@username", username));
                cmd.Parameters.Add(new SqlParameter("@log", log.ToString()));
                cmd.Parameters.Add(new SqlParameter("@message", Message));
                cmd.ExecuteNonQuery();
                Conn.Close();

                //SqlConnection Conn = new SqlConnection(connectionstring);
                //Message = Message.Replace("'", "!");
                //SqlCommand cmd = new SqlCommand("INSERT INTO Eventlog (ID, DateTime,UserName, EventName, MessageLog) VALUES ('" + Guid.NewGuid() + "','" + DateTime.Now + "','" + username + "','" + log.ToString() + "','" + Message + "')", Conn);
                //cmd.CommandType = CommandType.Text;
                //Conn.Open();
                //cmd.ExecuteNonQuery();
                //Conn.Close();
            }
            catch (Exception )
            {                
                throw;
            }
        }

         public static void WriteLog(string Message)
        {
            try
            {
                //string fileName = fileName;//Application.StartupPath + "\\ErrorLog.txt";
                if (!File.Exists(fileName))
                {
                    FileSecurity fSecurity = new FileSecurity();
                    fSecurity.AddAccessRule(new FileSystemAccessRule("EveryOne", FileSystemRights.FullControl, AccessControlType.Allow));

                    using (FileStream fs = File.Create(fileName, 1024, FileOptions.WriteThrough, fSecurity))
                    {
                        // Add some text to file    
                        Byte[] title = new UTF8Encoding(true).GetBytes("Error Log" + Environment.NewLine);
                        fs.Write(title, 0, title.Length);
                        fs.Close();
                        File.SetAttributes(fileName, FileAttributes.Archive | FileAttributes.Hidden);
                    }
                }

                Monitor.Enter(_objectError);
                try
                {
                    using (StreamWriter writer = File.AppendText(fileName))
                    {
                        writer.WriteLine(DateTime.Now.ToString() + " " + Message + '\n');
                        writer.Close();
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    Monitor.Exit(_objectError);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ErrorLog(string data)
        {
            Monitor.Enter(_objectError);
            try
            {
                using (StreamWriter writer = File.AppendText(fileName))
                {
                    writer.WriteLine(DateTime.Now.ToString() + " " + data + '\n');
                    writer.Close();
                }
            }
            catch (Exception)
            {

            }
            finally
            {
                Monitor.Exit(_objectError);
            }

        }

        public static void WriteLogException(string Message)
        {
            try
            {
                //string fileName = Path.Combine(Path.GetTempPath(), "ErrorLog.txt");
                //if (!File.Exists(fileName))
                //{
                //    FileSecurity fSecurity = new FileSecurity();
                //    fSecurity.AddAccessRule(new FileSystemAccessRule("EveryOne", FileSystemRights.FullControl, AccessControlType.Allow));

                //    using (FileStream fs = File.Create(fileName, 1024, FileOptions.WriteThrough, fSecurity))
                //    {
                //        // Add some text to file    
                //        Byte[] title = new UTF8Encoding(true).GetBytes("Error Log" + Environment.NewLine);
                //        fs.Write(title, 0, title.Length);
                //        fs.Close();
                //        File.SetAttributes(fileName, FileAttributes.Archive | FileAttributes.Hidden);
                //    }
                //}

                Monitor.Enter(_objectError);
                try
                {
                    using (StreamWriter sw = new StreamWriter(fileName, true))
                    {
                        sw.WriteLine(DateTime.Now.ToString() + " " + Message + '\n');
                    }
                }
                catch (Exception)
                {

                }
                finally
                {
                    Monitor.Exit(_objectError);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
