using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Log_It.Forms;
using Microsoft.Win32;
using System.Diagnostics;
using System.Configuration;
using System.Xml;
using System.Reflection;
using System.Security.AccessControl;
using System.IO;
using System.Text;

namespace Log_It
{
    static class Program
    {
        static bool isOk;
        static System.IO.Ports.SerialPort spt;
        public static string fileName = Application.StartupPath + "\\Log.txt";
        /// <summary>
        /// 
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {

                Process current = Process.GetCurrentProcess();
                Process[] processes = Process.GetProcessesByName(current.ProcessName);
                foreach (Process process in processes)
                {
                    //// Ignore the current process 
                    if (process.Id != current.Id)
                    {
                        ////Make sure that the process is running from the exe file. 
                        if (Assembly.GetExecutingAssembly().Location.
                             Replace("/", "\\") == current.MainModule.FileName)
                        {
                            //// the other process instance.  
                            MessageBox.Show("App is already running");
                            return;
                        }
                    }
                }
                Thread t = new Thread(new ThreadStart(splashscreen));
                t.Start();
                t.Name = "T1";
                Thread.Sleep(1000);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
               

               

                if (!System.IO.File.Exists(Application.StartupPath + "\\LogitSetting.xml"))
                {
                    SystemSetting ss = new SystemSetting();
                    if (ss.ShowDialog() == DialogResult.OK)
                    {
                        XmlTextWriter textWriter = new XmlTextWriter(Application.StartupPath + "\\LogitSetting.xml", null);
                        // Opens the document  
                        textWriter.WriteStartDocument();

                        // Write next element  
                        textWriter.WriteStartElement("ConnectionStringDb");
                        textWriter.WriteString(ss.ConnectionStringDb);
                        textWriter.WriteEndElement();

                        textWriter.WriteEndDocument();
                        // close writer  
                        textWriter.Close();


                        //textWriter.WriteStartDocument();
                        ////textWriter.WriteComment("System Configuration has save");
                        ////textWriter.WriteComment("LogiitSetting.xml in root dir");
                        //// Write first element  
                        //textWriter.WriteStartElement("r", "RECORD", "urn:record");
                        //textWriter.WriteStartElement("ConnectionStringDb", ss.ConnectionStringDb);
                        ////textWriter.WriteString("CSDb");
                        //textWriter.WriteEndElement();
                        //textWriter.WriteStartElement("CS", "0");
                        //textWriter.WriteEndElement();
                        //textWriter.WriteStartElement("MTP", "169.254.1.1");
                        //textWriter.WriteEndElement();
                        //textWriter.WriteEndDocument();
                        //// close writer  3
                        //textWriter.Close();
                    }
                    else
                    {
                        if (ss.DialogResult == DialogResult.Cancel)
                        {
                            return;
                        }
                    }
                }

                while (t.IsAlive)
                {

                }

                if (isOk && System.IO.File.Exists(Application.StartupPath + "\\LogitSetting.xml"))
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(Application.StartupPath + "\\LogitSetting.xml");
                    string connection = xmlDocument.GetElementsByTagName("ConnectionStringDb").Item(0).InnerText;

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

                 


                    BAL.LogitInstance instance = new BAL.LogitInstance(BAL.Authentication.GetDec(connection));
                    Technoman.Utilities.EventClass.connectionstring = instance.DataLink.Connection.ConnectionString;
                    instance.COMType = 1;
                    Authentication authe = new Authentication(instance);
                    if (authe.ShowDialog() == DialogResult.OK)
                    {
                        instance.UserInstance = authe.UserInstance;
                        instance.SystemProperties = instance.DataLink.SYSProperties.FirstOrDefault();

                        Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Login, "User Login ", authe.UserInstance.Full_Name);

                         Application.Run(new LogitMaincs(instance, authe.UserInstance, SetCOMPort(instance)));
                        //Application.Run(new TimeForm());
                    }
                }
            }
            catch (Exception m)
            {
                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
                MessageBox.Show("Method Name: " + currentMethodName + " Message: " + m.Message);
            }
        }

        private static System.IO.Ports.SerialPort SetCOMPort(BAL.LogitInstance xml)
        {
            try
            {
                DAL.SYSProperty xmlDocument = xml.DataLink.SYSProperties.Single();
                System.IO.Ports.SerialPort spt = new System.IO.Ports.SerialPort();
                spt.PortName = "COM" + (xmlDocument.Port);
                spt.DtrEnable =  Convert.ToBoolean(xmlDocument.DTS);
                spt.RtsEnable = Convert.ToBoolean(xmlDocument.RTS);
                spt.BaudRate = Convert.ToInt16(xmlDocument.BaudRate);
                spt.DataBits = Convert.ToInt16(xmlDocument.DataBit);

                switch (xmlDocument.Parity)
                {
                    case "n":
                        spt.Parity = System.IO.Ports.Parity.None;
                        break;
                    case "N":
                        spt.Parity = System.IO.Ports.Parity.None;
                        break;

                    case "o":
                        spt.Parity = System.IO.Ports.Parity.Odd;
                        break;
                    case "O":
                        spt.Parity = System.IO.Ports.Parity.Odd;
                        break;

                    case "e":
                        spt.Parity = System.IO.Ports.Parity.Even;
                        break;
                    case "E":
                        spt.Parity = System.IO.Ports.Parity.Even;
                        break;

                    default:
                        spt.Parity = System.IO.Ports.Parity.None;
                        break;
                }

                switch (xmlDocument.StopBit)
                {
                    case "1":
                        spt.StopBits = System.IO.Ports.StopBits.One;
                        break;
                    case "2":
                        spt.StopBits = System.IO.Ports.StopBits.Two;
                        break;

                    default:
                        spt.StopBits = System.IO.Ports.StopBits.One;

                        break;
                }
                return spt;
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
                return null;
            }



        }

        public static void splashscreen()
        {
           // Application.Run(new Splash());
            Splash sp = new Splash();
            
            sp.ShowDialog();
            //spt = sp.SP;
            isOk = sp.isok;
            
        }
    }
}
