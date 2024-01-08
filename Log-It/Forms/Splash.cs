using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Log_It.Forms
{
    public partial class Splash : Form
    {
        public bool isok;
        public System.IO.Ports.SerialPort SP { get; private set; }
        public Splash()
        {
            InitializeComponent();
            timer1.Start();
        }

        private bool PreparingFile()
        {
            try
            {
              
                //XmlDocument xmlDocument = new XmlDocument();
                //xmlDocument.Load(Application.StartupPath + "\\LogitSetting.xml");
              
                //this.SetCOMPort(xmlDocument);
                //SP = serialPort1;
                return true;

            }
            catch (Exception m)
            {
                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
                //MessageBox.Show(m.Message);
            }
            
            return false;
        }

        private void SetCOMPort(XmlDocument xmlDocument)
        {
            try
            {
                serialPort1.PortName = "COM" + (xmlDocument.GetElementsByTagName("PortName").Item(0).InnerText);
                serialPort1.DtrEnable = Convert.ToBoolean(xmlDocument.GetElementsByTagName("DtrEnable").Item(0).InnerText);
                serialPort1.RtsEnable = Convert.ToBoolean(xmlDocument.GetElementsByTagName("RtsEnable").Item(0).InnerText);
                serialPort1.BaudRate = Convert.ToInt16(xmlDocument.GetElementsByTagName("BaudRate").Item(0).InnerText);
                serialPort1.DataBits = Convert.ToInt16(xmlDocument.GetElementsByTagName("DataBits").Item(0).InnerText);

                switch (xmlDocument.GetElementsByTagName("Parity").Item(0).InnerText)
                {
                    case "n":
                        serialPort1.Parity = System.IO.Ports.Parity.None;
                        break;
                    case "N":
                        serialPort1.Parity = System.IO.Ports.Parity.None;
                        break;

                    case "o":
                        serialPort1.Parity = System.IO.Ports.Parity.Odd;
                        break;
                    case "O":
                        serialPort1.Parity = System.IO.Ports.Parity.Odd;
                        break;

                    case "e":
                        serialPort1.Parity = System.IO.Ports.Parity.Even;
                        break;
                    case "E":
                        serialPort1.Parity = System.IO.Ports.Parity.Even;
                        break;

                    default:
                        serialPort1.Parity = System.IO.Ports.Parity.None;
                        break;
                }

                switch (xmlDocument.GetElementsByTagName("StopBits").Item(0).InnerText)
                {
                    case "1":
                        serialPort1.StopBits = System.IO.Ports.StopBits.One;
                        break;
                    case "2":
                        serialPort1.StopBits = System.IO.Ports.StopBits.Two;
                        break;

                    default:
                        serialPort1.StopBits = System.IO.Ports.StopBits.One;

                        break;
                }
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
            }

            
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            
            if (progressBar1.Value == 100)
            {
                string s = Thread.CurrentThread.Name;
                timer1.Stop();
                isok = PreparingFile();
                this.Close();
            }
        }
    }
}
