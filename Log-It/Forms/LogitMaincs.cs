using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAL;
using Log_It.CustomControls;
using System.Diagnostics;
using Log_It.Pages;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Configuration;
using Modbus_Poll_CS;
using System.Globalization;
using EasyModbus;
using System.Security.AccessControl;
using System.Security.Principal;
using System.IO;
using System.Data.SqlClient;
using System.Net.Sockets;
using ModbusTCP;
using System.Collections;
using PrimS.Telnet;
using Microsoft.Reporting.WinForms;
using DAL;

namespace Log_It.Forms
{


    public partial class LogitMaincs : Form
    {
        private Pages.TaskPanel.TaskControl[] taskPanel;
        private Pages.ControlPage[] Pages;

        private PageControlEnum displayMode;
        private Log_It.Pages.TankView tk;
        private Log_It.Pages.TVView tvv;
        private CustomControls.TVControl[] tvc;
        bool signal = false;
        BAL.LogitInstance instance;
        DAL.User userIntance;
        private LogIt[] channel;
        private BarPack[] bp;
        public bool isCalibratorOn;
        private Logit_Device logit_device;
        ConfigForm cf;
        private Thread t1;
        Task<string> task;
        CancellationTokenSource cancellationTokenSource; //Declare a cancellation token source
        CancellationToken cancellationToken;
        private bool isRun = false;
        private int UserID;
        private int Deviceid;
        private List<string> email;
        private List<string> SMSmail;
        SerialPort sp2;
        bool ExternalAlarm;
        modbus mb = null;

        ModbusClient modbusClient = null;
        System.Windows.Forms.Timer backuptimer = null;
        DateTime backuplast;

        
        private ModbusTCP.Master MBmaster;
        private byte[] data;


        static readonly object _object = new object();
        static readonly object _Alarmobject = new object();

        public LogitMaincs(BAL.LogitInstance instance, DAL.User userIntance, SerialPort sp)
        {
            try
            {
                //MessageBox.Show("Sucessfull 2");
                InitializeComponent();

                logit_device = new Logit_Device(instance);
                LogIt.Logging += LogIt_Logging;
                LogIt.LastRecord += LogIt_LastRecord;
                this.serialPort1 = sp;
                this.instance = instance;
                this.userIntance = userIntance;
                toolStripStatusUser.Text = "Login User: " + userIntance.User_Name;


                LogIt.Parameters.Output1 += new RealTimesS(Parameters_Output1);
                LogIt.Parameters.Nodata += Parameters_Nodata;
                LogIt.RealTime += new RealTimesChart(LogIt_RealTime);
                LogIt.Parameters.BarAlaram += Parameters_BarAlaram;

                LogIt.Parameters.outofLimits += Parameters_outofLimits;
                LogIt.SendAlarmCondition += LogIt_SendAlarmCondition;
                Control.CheckForIllegalCrossThreadCalls = false;
                //mb = new modbus();
                //modbusClient = new ModbusClient("169.254.1.1", 502);
                toolStripStatusComPort.Text = string.Empty;
                // Create new modbus master and add event functions

                //toolStripStatusComPort.Text = "Communication IP: " + modbusClient.IPAddress;
                if (instance.SystemProperties.ExtAlram == true)
                {
                    // MessageBox.Show("Sucessfull 4");
                    sp2 = new SerialPort();
                    sp2.BaudRate = Convert.ToInt32(instance.SystemProperties.Alarmbaud);
                    sp2.PortName = "COM" + instance.SystemProperties.Alarmport.ToString();
                    ExternalAlarm = true;
                }

                MBmaster = new Master("192.168.2.17", 503, true);
                MBmaster.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponseData);
                MBmaster.OnException += new ModbusTCP.Master.ExceptionData(MBmaster_OnException);
                // Show additional fields, enable watchdog
                //grpExchange.Visible = true;
                //grpData.Visible = true;	

                toolStripStatusComPort.Text = "192.168.2.17";

               
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
            }
            finally {
                if (MBmaster != null)
                {
                    if (MBmaster.connected)
                    {
                        MBmaster.disconnect();
                        MBmaster.Dispose();
                    }
                    MBmaster.Dispose();
                }
            }
        }

        private string Run(object id)
        {
            try
            {
                List<int> ids = new List<int>(logit_device.GetAllDevices().Count());
                foreach (var item in logit_device.GetAllDevices().OrderBy(x => x.Channel_id))
                {
                    ids.Add((int)item.Device_Id);
                }

                int index = 0;

                //For modbus communication
                switch (instance.COMType)
                {
                    case 0:
                        if (mb.Open(serialPort1.PortName, 9600, 8, Parity.None, StopBits.One))
                        // if (mb.Open("COM11", 9600, 8, Parity.None, StopBits.One))
                        {
                            while (isRun)
                            {
                                //Send2Channels(1, 255, 405);

                                //OpenComm();
                                if (cancellationToken.IsCancellationRequested)//Check if a cancellation request 
                                //is pending
                                {
                                    mb.Close();
                                    //Only Aosong devices
                                    //CloseComm();
                                    break;
                                }
                                ushort pollStart = Convert.ToUInt16(0);
                                ushort pollLength = Convert.ToUInt16(16);

                                float num2 = 0;
                                float num3 = 0;
                                short[] values = new short[Convert.ToInt32(16)];
                                int number = ids[index];

                                string hex = "10";
                                int value = Int32.Parse(hex, System.Globalization.NumberStyles.HexNumber);

                                try
                                {
                                    if (!mb.SendFc3(Convert.ToByte(number), pollStart, pollLength, ref values))
                                    {
                                        toolStripStatusLabel2.Text = logit_device.GetbyDeviceID(number).Location;
                                        //System.Diagnostics.Debug.Print(logit_device.GetbyDeviceID(number).Location + " Not responding Error: " + mb.modbusStatus);
                                        index++;
                                        if (index >= ids.Count)
                                        {
                                            index = 0;
                                        }
                                        continue;
                                    }
                                    toolStripStatusLabel2.Text = "";
                                }
                                catch (Exception)
                                {
                                    mb.Close();
                                }

                                if (values != null && values.Count() > 0)
                                {
                                    num2 = (float)values[0];
                                    num3 = (float)values[1];
                                    if (num3 != 0 && num2 != 0)
                                    {
                                        Send2Channels(number, num3, num2);
                                    }
                                }

                                index++;
                                if (index >= ids.Count)
                                {
                                    index = 0;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(mb.modbusStatus);
                            toolStripStatusLabel2.Text = mb.modbusStatus;
                        }
                        break;

                    case 1:
                        while (isRun)
                        {


                            if (cancellationToken.IsCancellationRequested)//Check if a cancellation request                             
                            {
                                if (MBmaster.connected)
                                {
                                    MBmaster.disconnect();
                                    MBmaster.Dispose();
                                }

                                break;
                            }


                            int number = ids[index];
                            //Monitor.Enter(_object);
                            try
                            {


                                while (!isDeviceConnected())
                                {
                                    Technoman.Utilities.EventClass.ErrorLog("Device Not Connected. " + DateTime.Now.ToString());
                                }
                                MBmaster = new Master("192.168.2.17", 503, true);
                                MBmaster.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponseData);
                                MBmaster.OnException += new ModbusTCP.Master.ExceptionData(MBmaster_OnException);

                                ushort ID = 3;
                                byte unit = Convert.ToByte(number);
                                ushort StartAddress = 0;
                                UInt16 Length = Convert.ToUInt16(2);
                                MBmaster.timeout = 3;
                                MBmaster.ReadHoldingRegister(ID, unit, StartAddress, Length);
                                Thread.Sleep(1000);
                                MBmaster.refresh = 3;

                                if (MBmaster.connected)
                                {

                                    MBmaster.disconnect();
                                    MBmaster.Dispose();
                                }


                                index++;
                                if (index >= ids.Count)
                                {
                                    index = 0;
                                }
                                // modbusClient.Disconnect();

                                //toolStripStatusLabel2.Text = "";
                            }
                            catch (Exception m)
                            {
                                //toolStripStatusLabel2.Text = "Device ID# " + number + "Response Timeout. Error: " + m.Message;
                                index++;
                                if (index >= ids.Count)
                                {
                                    index = 0;
                                }
                                //modbusClient.Disconnect();
                                //modbusClient = null;
                                //modbusClient  = new ModbusClient("169.254.1.1", 502);
                                Technoman.Utilities.EventClass.ErrorLog(m.Message);
                            }
                            finally
                            {
                                if (MBmaster.connected)
                                {

                                    MBmaster.disconnect();
                                    MBmaster.Dispose();
                                }
                               
                            }
                           // Monitor.Wait(_object,10000);
                        }
                        break;
                }
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
            }

            return string.Empty;
        }

        private async void RunTask()
        {
            try
            {
                int numericValue = 100;//Capture the user input
                object[] arrObjects = new object[] { numericValue };//Declare the array of objects

                //Because Cancellation tokens cannot be reused after they have been canceled,
                //we need to create a new cancellation token before each start
                cancellationTokenSource = new CancellationTokenSource();
                cancellationToken = cancellationTokenSource.Token;

                task = new Task<string>(new Func<object, string>(Run), arrObjects, cancellationToken);//Declare and initialize the task


                //lblStatus.Text = "Started Calculation...";//Set the status label to signal
                ////starting the operation
                //btnStart.Enabled = false; //Disable the Start button
                task.Start();//Start the execution of the task
                await task;// wait for the task to finish, without blocking the main thread
                
                if (!task.IsFaulted)
                {
                    //textBox1.Text = string.Empty;
                    //textBox1.Text = task.Result.ToString();//at this point,
                    ////the task has finished its background work, and we can take the result
                    //lblStatus.Text = "Completed.";//Signal the completion of the task
                }

                //btnStart.Enabled = true; //Re-enable the Start button
            }
            catch (Exception m)
            {
                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
            }
        }


        private static async Task NewMethod()
        {
            try
            {
                Client c = new Client("182.168.2.17", 23, new CancellationToken());
                bool b = await c.TryLoginAsync("admin", "admin", 100, ">", "\n");
                if (b)
                {
                    await c.WriteLine("Restart", "\n");
                    await c.WriteLine("Exit", "\n");

                    Technoman.Utilities.EventClass.ErrorLog("Device Restart on " + DateTime.Now.ToString());
                    Thread.Sleep(10000);
                }
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
            }

        }

        private void MBmaster_OnException(ushort id, byte unit, byte function, byte exception)
        {

            try
            {
                string exc = "Modbus says error: ";
                switch (exception)
                {
                    case Master.excIllegalFunction:
                    case Master.excIllegalDataAdr:
                    case Master.excIllegalDataVal:
                    case Master.excSlaveDeviceFailure:
                    case Master.excAck:
                    case Master.excGatePathUnavailable:
                    case Master.excExceptionTimeout:
                    case Master.excExceptionConnectionLost:
                    case Master.excExceptionNotConnected:
                        NewMethod();

                        break;
                }

                MessageBox.Show(exc, "Modbus slave exception");

            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
            }
        }

        private void MBmaster_OnResponseData(ushort ID, byte unit, byte function, byte[] values)
        {


            try
            {
                // ------------------------------------------------------------------
                // Seperate calling threads
                if (this.InvokeRequired)
                {
                    this.BeginInvoke(new Master.ResponseData(MBmaster_OnResponseData), new object[] { ID, unit, function, values });
                    return;
                }

                // ------------------------------------------------------------------------
                // Identify requested data
                switch (ID)
                {
                    case 1:
                        // grpData.Text = "Read coils";
                        data = values;
                        ShowAs(null, null);
                        break;
                    case 2:
                        //  grpData.Text = "Read discrete inputs";
                        data = values;
                        ShowAs(null, null);
                        break;
                    case 3:
                        //  grpData.Text = "Read holding register";
                        data = values;
                        ShowAs(null, null);
                        //System.Diagnostics.Debug.Print("Channel: " + unit.ToString() + "Temp: " + (word[1] / 10).ToString() + " Hum: " + (word[0] / 10).ToString());
                        if (word.Count() > 0)
                        {
                            Send2Channels(unit, word[1], word[0]);
                        }

                        break;
                    case 4:
                        //  grpData.Text = "Read input register";
                        data = values;
                        ShowAs(null, null);
                        break;
                    case 5:
                        //   grpData.Text = "Write single coil";
                        break;
                    case 6:
                        // grpData.Text = "Write multiple coils";
                        break;
                    case 7:
                        //      grpData.Text = "Write single register";
                        break;
                    case 8:
                        //  grpData.Text = "Write multiple register";
                        break;
                }
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
            }
        }
        int[] word;
        private void ShowAs(object sender, System.EventArgs e)
        {

            try
            {

                RadioButton rad;
                if (sender is RadioButton)
                {
                    rad = (RadioButton)sender;
                    if (rad.Checked == false) return;
                }

                bool[] bits = new bool[1];
                word = new int[1];

                //// Convert data to selected data type
                //if (radBits.Checked == true)
                //{
                //    BitArray bitArray = new BitArray(data);
                //    bits = new bool[bitArray.Count];
                //    bitArray.CopyTo(bits, 0);
                //}

                if (data.Length < 2) return;
                int length = data.Length / 2 + Convert.ToInt16(data.Length % 2 > 0);
                word = new int[length];
                for (int x = 0; x < length; x += 1)
                {
                    word[x] = data[x * 2] * 256 + data[x * 2 + 1];
                }


                // ------------------------------------------------------------------------
                // Put new data into text boxes
                //foreach (Control ctrl in grpData.Controls)
                //{
                //    if (ctrl is TextBox)
                //    {
                //        int x = Convert.ToInt16(ctrl.Tag);
                //        if (radBits.Checked)
                //        {
                //            if (x <= bits.GetUpperBound(0))
                //            {
                //                ctrl.Text = Convert.ToByte(bits[x]).ToString();
                //                ctrl.Visible = true;
                //            }
                //            else ctrl.Text = "";
                //        }
                //        if (radBytes.Checked)
                //        {
                //            if (x <= data.GetUpperBound(0))
                //            {
                //                ctrl.Text = data[x].ToString();
                //                ctrl.Visible = true;
                //            }
                //            else ctrl.Text = "";
                //        }
                //        if (radWord.Checked)
                //        {
                //            if (x <= word.GetUpperBound(0))
                //            {
                //                ctrl.Text = word[x].ToString();
                //                ctrl.Visible = true;
                //            }
                //            else ctrl.Text = "";
                //        }
                //    }
                //}
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
            }

        }

        void Parameters_BarAlaram(uint Index, double values, bool isactive)
        {


            try
            {
                if (bp != null)
                {
                    this.bp[Index].AlaramActive = isactive;

                }
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
            }
        }

        void LogIt_SendAlarmCondition(object sender, EventArgs e)
        {
            try
            {
                if (ExternalAlarm)
                {
                    Monitor.Enter(_Alarmobject);
                    try
                    {
                        if (!sp2.IsOpen)
                        {
                            sp2.Open();
                        }
                        for (int i = 0; i < 6; i++)
                        {
                            sp2.DiscardInBuffer();
                            sp2.DiscardOutBuffer();
                            sp2.WriteLine(sender.ToString());
                            Thread.Sleep(100);
                        }
                        //Thread.Sleep(500);
                        sp2.Close();
                    }
                    catch (Exception m)
                    {

                        var st = new StackTrace();
                        var sf = st.GetFrame(0);

                        var currentMethodName = sf.GetMethod();
                        //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
                        Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
                    }
                    finally
                    {
                        Monitor.Exit(_Alarmobject);
                    }
                }
            }
            catch (Exception m)
            {
                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
            }

        }

        void LogIt_LastRecord(Guid Id, DateTime dt)
        {


            try
            {
                DAL.Device_Config config = instance.Device_Configes.SingleOrDefault(x => x.ID == Id);
                config.Last_Record = dt;
                if (instance.DataLink.Connection.State == System.Data.ConnectionState.Closed)
                {
                    instance.DataLink.Connection.Open();
                }
                instance.DataLink.SubmitChanges();
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
            }
        }

        void Parameters_Nodata(uint Index, bool values)
        {

            try
            {
                if (bp != null)
                    this.bp[Index].picTimeOut.Visible = values;


            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
            }
        }

        async void Parameters_outofLimits(LogIt.Parameters p, string name, decimal values, bool isactive, uint Index, string read, string remakr)
        {
            try
            {
                string devicetype = string.Empty;
                string Description = string.Empty;
                DAL.Alaram_Log alaram = new DAL.Alaram_Log();
                alaram.ID = Guid.NewGuid();
                alaram.Device_ID = Convert.ToInt16(Index);
                if (p.Device_Type == 1)
                {
                    alaram.Description = "Temperature is " + remakr;
                    devicetype = "Temperature";
                }

                if (p.Device_Type == 2)
                {
                    alaram.Description = "Humidity is " + remakr;
                    devicetype = "Humidity";
                }
                alaram.Device_Type = devicetype;
                alaram._data = values;
                alaram.Time = DateTime.Now;
                //instance.DataLink.Alaram_Logs.InsertOnSubmit(alaram);

                DAL.Acknowledge ack = new Acknowledge();
                ack.ID = Guid.NewGuid();
                ack.Device_ID = alaram.Device_ID.ToString();
                ack.Instrument = p.Instrument;

                //"ALERT! Instrument: " + Instrument + " " + Event_Type + " is " + Event + " (" + Data.ToString() + ")"));

                ack.Event = "Instrument: " + p.Instrument + " " + devicetype +" is " + remakr + " ( " + values.ToString() +" )";
                ack.Event_DateTime = DateTime.Now;
                ack.Event_Type = devicetype;
                ack.Instrument = p.Instrument;
                ack.Location = p.Location;
                instance.DataLink.Acknowledges.InsertOnSubmit(ack);
                //instance.DataLink.Insert_Acknowladge(alaram.Device_ID.ToString(), name, name, devicetype, DateTime.Now, alaram.Description);
                if (instance.DataLink.Connection.State == ConnectionState.Closed)
                {
                    instance.DataLink.Connection.Open();
                }
                instance.DataLink.SubmitChanges();

                if (instance.SystemProperties.Email == true)
                {
                    bool isconnected = await isInternetConnected();
                    if (!isconnected)
                    {
                        toolStripStatusLabel4.Text = "No internet connect";
                    }
                    if (isactive)
                    {
                        if (isconnected)
                        {
                            bool b = await SendMail(name, p.Instrument, values.ToString(), remakr);
                            if (SMSmail.Count > 0)
                            {
                                string body = @"Time: " + DateTime.Now.ToString() + "\r\nDevice: " + p.Instrument + "\r\n" + p.Instrument+ "  = " + read + " \r\nDescription: \r\nALERT! " + p.Name + " is " + remakr;

                                foreach (var item in SMSmail.ToList())
                                {
                                    SMSComponent smscomponent = new SMSComponent(instance.SystemProperties);
                                    smscomponent.send(item, body);
                                    smscomponent.Dispose();

                                    //send(ConfigurationManager.AppSettings["SMSUserName"], ConfigurationManager.AppSettings["SMSPassword"], item, ConfigurationManager.AppSettings["SMSFrom"], body);
                                }
                            }

                        }
                    }

                    if (!isactive)
                    {
                        if (isconnected)
                        {
                            bool b = await SendMail(name, p.Name, values.ToString(), remakr);
                            if (SMSmail.Count > 0)
                            {
                                string body = @"Time: " + DateTime.Now.ToString() + "\r\nDevice: " + p.Instrument + "\r\n" + p.Name + "  = " + read + " \r\nDescription: \r\nALERT! " + p.Name + " is " + remakr;

                                foreach (var item in SMSmail.ToList())
                                {
                                    SMSComponent smscomponent = new SMSComponent(instance.SystemProperties);
                                    smscomponent.send(item, body);
                                    smscomponent.Dispose();
                                    //                                Time: 4/8/2019 12:5048 PM
                                    //Device: T1
                                    //Temperature: 34.1
                                    //ALERT! Temperature is High
                                    //send(ConfigurationManager.AppSettings["SMSUserName"], ConfigurationManager.AppSettings["SMSPassword"], item, ConfigurationManager.AppSettings["SMSFrom"], body);
                                }
                            }
                        }

                    }
                }
                //if (instance.SystemProperties.SMS == true)
                //{
                //    if (instance.SystemProperties.WebLink == true)
                //    {
                //        bool isconnected = true;// await isInternetConnected();
                //        if (!isconnected)
                //        {
                //            toolStripStatusLabel4.Text = "No internet connect";
                //        }
                //        if (isactive)
                //        {
                //            if (isconnected)
                //            {
                //                if (SMS != null)
                //                {
                //                    if (p.Name == "Temperature")
                //                    {
                //                        read = read + " C";
                //                    }
                //                    if (p.Name == "Humidity")
                //                    {
                //                        read = read + " %";
                //                    }
                //                    string status = (string)remakr.Clone();

                //                    string body = @"Date: " + p.dt_LastRecord.ToString() + "\r\n" + "Time: " + DateTime.Now.ToShortTimeString() + "\r\nInstrument: " + name + "\r\n" + p.Name + "  = " + read + " \r\nDescription: \r\nALERT! " + p.Name + " is " + status;

                //                    SMSComponent smscomponent = new SMSComponent(instance.SystemProperties);
                //                    smscomponent.send(SMS, body);
                //                    smscomponent.Dispose();
                //                }
                //            }
                //        }

                //        if (!isactive)
                //        {
                //            if (isconnected)
                //            {

                //                string status = (string)remakr.Clone();

                //                if (SMS != null)
                //                {
                //                    if (SMS.Count > 0)
                //                    {
                //                        if (p.Name == "Temperature")
                //                        {
                //                            read = read + " C";
                //                        }
                //                        if (p.Name == "Humidity")
                //                        {
                //                            read = read + " %";
                //                        }
                //                        //string status = (string)remakr.Clone();

                //                        string body = @"Date: " + p.dt_LastRecord.ToString() + "\r\n" + "Time: " + DateTime.Now.ToShortTimeString() + "\r\nInstrument: " + name + "\r\n" + p.Name + "  = " + read + " \r\nDescription: \r\nALERT! " + p.Name + " is " + status;

                //                        SMSComponent smscomponent = new SMSComponent(instance.SystemProperties);
                //                        smscomponent.send(SMS, body);
                //                        smscomponent.Dispose();
                //                    }
                //                }
                //            }
                //        }
                //    }
                   
                //}
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);

            }

        }

        async Task<bool> isInternetConnected()
        {
            PingReply reply = null;
            await Task.Run(() =>
            {
                try
                {
                    Ping myPing = new Ping();
                    String host = "google.com";
                    byte[] buffer = new byte[32];
                    int timeout = 1000;
                    PingOptions pingOptions = new PingOptions();
                    reply = myPing.Send(host, timeout, buffer, pingOptions);
                    if (reply.Status == IPStatus.Success)
                    {

                    }

                }
                catch (Exception)
                {


                }

                if (reply == null)
                {
                    return true;
                }
                if (reply.Status == IPStatus.TimedOut)
                {
                    return true;
                }
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
                return true;


                //return (reply.Status == IPStatus.Success);
            });
            //return (reply.Status == IPStatus.Success);
            if (reply == null)
            {
                return false;
            }
            if (reply.Status == IPStatus.TimedOut)
            {
                return false;
            }
            if (reply.Status == IPStatus.Success)
            {
                return true;
            }
            return false;
        }

        async Task<bool> SendMail(string device, string status, string read, string remakr)
        {

            try
            {
                await Task.Run(() =>
                {
                    string status1 = (string)remakr.Clone();

                    if (status == "Temperature")
                    {
                        read = read + " C";
                    }
                    if (status == "Humidity")
                    {
                        read = read + " %";
                    }


                    string emailFromAddress = "logitdatalogger@gmail.com";// ConfigurationManager.AppSettings["UserID"].ToString(); //Sender Email Address  
                    string subject = "Alram Alert device: " + device;
                    string body = @"<html><body> <p>Date & Time  : " + DateTime.Now.ToString() + "<br/>Device: <b>" + device + "</b><br/> " + status + "  = <b>" + read + "</b><br/><br/> Description: <br/> ALERT! " + status + " is <b>" + remakr + "</b><br/><br/>This is system notification email. Please don't reply <br/><br/>Thanks & Regards, <br/>Logit System ";

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(emailFromAddress);

                        if (email != null)
                        {
                            if (email.Count > 0)
                            {
                                foreach (var item in email)
                                {
                                    mail.To.Add(item);
                                }
                            }
                            else
                            {
                                mail.Dispose();
                                toolStripStatusLabel4.Text = "No any Email Address!";
                                return;
                            }

                        }
                        else
                        {
                            mail.Dispose();
                            toolStripStatusLabel4.Text = "No any Email Address!";
                            return;
                        }


                        mail.Subject = subject;
                        mail.Body = body;
                        mail.IsBodyHtml = true;

                        try
                        {
                            List<String> n = null;
                            toolStripStatusLabel4.Text = "Email is Sending";
                            if (Log_It.Classes.GmailAPI.Send_Mail(mail, n))
                            {
                                toolStripStatusLabel4.Text = "Email has been Sent";
                                Technoman.Utilities.EventClass.WriteLogException("Email has been Sent");
                            }
                            else
                            {
                                toolStripStatusLabel4.Text = "Email Send Fail";
                                Technoman.Utilities.EventClass.WriteLogException("Email send fail, Internet issue");
                            }
                        }
                        catch (Exception)
                        {
                            Technoman.Utilities.EventClass.WriteLogException("Email Sent Fail with Attachments");
                            toolStripStatusLabel4.Text = "Email Send Fail";
                            var st = new StackTrace();
                            var sf = st.GetFrame(0);

                            var currentMethodName = sf.GetMethod();
                            //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
                        }
                        finally
                        {
                            mail.Dispose();
                        }

                    }
                });
                return true;
            }
            catch (Exception m)
            {
                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                Technoman.Utilities.EventClass.WriteLogException("Error Log: " + m.Message + " Method Name: " + currentMethodName);
                return false;
            }


        }

        void cf_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                CreateLogItObjects();
                if (panelControl.Controls.Count > 0)
                {

                    panelControl.Controls.Clear();
                }
                panelControl.Controls.Add(Pages[5]);
                Log_It.Pages.ControlPage page = (Log_It.Pages.ControlPage)panelControl.Controls[0];
                page.RefreshPage();
                RunTask();
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);

            }

        }

        void Parameters_Output1(uint Index, double values)
        {
            try
            {
                if (bp != null)
                    this.bp[Index].Value = (float)values;
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
            }

        }

        void LogIt_Logging(Guid Id, string DeviceID, string DeviceType, double Temperature, double Humidity, double Pressure)
        {
            try
            {
                DAL.Log log = new DAL.Log();

                log.Channel_ID = DeviceID;
                log.Device_Id = Id;
                log.ID = Guid.NewGuid();
                log.date_ = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"));
                log.Pressure = Convert.ToDouble(Pressure.ToString("00.00"));
                log.Rh_Data = Convert.ToDouble(Humidity.ToString("00.00"));
                log.Temp_Data = Convert.ToDouble(Temperature.ToString("00.00"));
                if (instance.DataLink.Connection.State == ConnectionState.Closed)
                {
                    instance.DataLink.Connection.Open();
                }
                logit_device.InsertRecord(log);
                //instance.DataLink.SubmitChanges();
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
            }

        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form childForm in MdiChildren)
                {
                    childForm.Close();
                }
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
            }

        }

        private void wc_Closing(object sender, EventArgs e)
        {
            CreateLogItObjects();
            if (signal)
            {
                // smsTimer.Start();
            }
        }

        List<DateTime> dtm;
        DateTime expiredt = DateTime.Now;
        public void CreateLogItObjects()
        {
            try
            {
                if (logit_device.DeviceCount() > 0)
                {
                    isRun = true;
                }

                dtm = new List<DateTime>();

                channel = new LogIt[logit_device.GetAllDevices().Count()];
                tvc = new CustomControls.TVControl[channel.Length];
                int index = 0;
                foreach (DAL.Device_Config item in logit_device.GetAllDevices().OrderBy(x => x.Device_Id))
                {
                    dtm.Add((DateTime)item.LimitTables[0].dateofcalibrate);
                    channel[index] = new LogIt(item);

                    index++;
                }
                expiredt = dtm.Max();
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
            }

        }

        private void DestroyLogItObject()
        {
            try
            {
                foreach (LogIt logObj in channel)
                {
                    logObj.Dispose();
                }

                channel = null;
                LogIt.index = 0;
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
            }

        }

        void tk_close()
        {
            tk = null;
            //throw new NotImplementedException();
        }

        public void send(string username, string password, string no, string from, string message)
        {
            try
            {

                username =  ConfigurationManager.AppSettings["SMSUserName"].ToString();
                password = ConfigurationManager.AppSettings["SMSPassword"].ToString();
                System.Diagnostics.Debug.Print(" Message: " + message);

                //http://lifetimesms.com/plain?api_token=a54303719a573938f01282ca34717a55fa02f62330&api_secret=34334&to923242331164&from=SmartSMS&message=Date:%209/29/2019%209:56:42%20PM%0D%0ATime:%205:46%20PM%0D%0AInstrument:%20Ultra%20High%0D%0ATemperature%20%20=%2031.5%20C%20%0D%0ADescription:%20%0D%0AALERT!%20Temperature%20is%20High
                System.Net.HttpWebRequest myReq = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("http://Lifetimesms.com/plain?api_token="
                + username + "&api_secret=" + password + "&to=" + no + "&from=" + ConfigurationManager.AppSettings["SMSFrom"] + "&message=" + Uri.UnescapeDataString(message));

                System.Net.HttpWebResponse myResp = (System.Net.HttpWebResponse)myReq.GetResponse();
                System.IO.StreamReader respStreamReader = new System.IO.StreamReader(myResp.GetResponseStream());//.GET / POSTResponseStream());

                string responseString = respStreamReader.ReadToEnd();
                respStreamReader.Close();

                myResp.Close();
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
            }

        }

        private void LogitMaincs_Load(object sender, EventArgs e)
        {
            try
            {
                //string sysFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;

                sideNavItem2.Checked = true;

                taskPanel = new Log_It.Pages.TaskPanel.TaskControl[7];
                taskPanel[0] = new Log_It.Pages.TaskPanel.HomeTask(instance);
                taskPanel[1] = new Log_It.Pages.TaskPanel.AppTask();

                taskPanel[2] = new Log_It.Pages.TaskPanel.DatabaseTask();

                Log_It.Pages.TaskPanel.EventTask eventtask = new Log_It.Pages.TaskPanel.EventTask();
                eventtask.RefreshControl += eventtask_RefreshControl;
                eventtask.PrintP += eventtask_PrintP;
                taskPanel[3] = eventtask;

                Log_It.Pages.TaskPanel.UserTask usertask = new Log_It.Pages.TaskPanel.UserTask(0, instance);
                usertask.AddUser += usertask_AddUser;
                usertask.ModifiedUser += usertask_ModifiedUser;
                usertask.DeleteUser += usertask_DeleteUser;
                taskPanel[4] = usertask;

                Pages = new Log_It.Pages.ControlPage[8];
                Log_It.Pages.HomePage home = new Log_It.Pages.HomePage();
                home.PageIndex += home_PageIndex;
                Pages[0] = home;
                Pages[1] = new Log_It.Pages.ApplicationProperties(instance, userIntance.User_Name);
                if (userIntance.Role == 1)
                {
                    Log_It.Pages.ControlPage page = (Log_It.Pages.ApplicationProperties)Pages[1];
                    page.Enabled = false;
                }
                Pages[2] = new Log_It.Pages.DBMaintenance(instance);
                Pages[3] = new Log_It.Pages.Eventpage(instance);

                Log_It.Pages.UserPage userpage = new Log_It.Pages.UserPage(instance);
                userpage.IDSet += userpage_IDSet;
                Pages[4] = userpage;

                Log_It.Pages.EmailConfigPage emailpage = new EmailConfigPage(instance);
                Pages[5] = emailpage;
                Log_It.Pages.TaskPanel.EmailTask emailtask = new Log_It.Pages.TaskPanel.EmailTask();
                taskPanel[5] = emailtask;

                Log_It.Pages.SMSConfigPage SMSpage = new SMSConfigPage(instance);
                Pages[6] = SMSpage;
                Log_It.Pages.TaskPanel.SMSTask SMStask = new Log_It.Pages.TaskPanel.SMSTask();
                taskPanel[6] = SMStask;


                Log_It.Pages.DeviceConfigPage configpage = new DeviceConfigPage(instance);
                configpage.IDSetDevice += configpage_IDSetDevice;
                Pages[7] = configpage;

                email = new List<string>();
                foreach (var item in instance.Users.Where(x => x.Active == true && x.IsRowEnable == true && x.Email_Notification == true))
                {
                    if (item.Email != null)
                    {
                        email.Add(item.Email);
                    }
                }

                SMSmail = new List<string>();
                foreach (var item in instance.Users.Where(x => x.Active == true && x.IsRowEnable == true && x.SMS_Notification == true))
                {
                    if (item.SMS != null)
                    {
                        SMSmail.Add(item.SMS);

                    }
                }


                foreach (var item in Pages)
                {
                    item.Dock = DockStyle.Fill;
                }
                foreach (var item in taskPanel)
                {
                    item.Dock = DockStyle.Fill;
                }

                if (instance.SystemProperties.lastbakdate != null)
                {
                    backuplast = (DateTime)instance.SystemProperties.lastbakdate;
                }
                else
                {
                    backuplast = DateTime.Now;
                }



                backuptimer = new System.Windows.Forms.Timer();
                backuptimer.Interval = 600000;
                // backuptimer.Interval = 100000;
                backuptimer.Tick += backuptimer_Tick;
                backuptimer.Start();

                panelControl.Controls.Add(Pages[0]);
                paneltask.Controls.Add(taskPanel[0]);
                displayMode = PageControlEnum.Home;
                treeView1.ExpandAll();
                CreateLogItObjects();

                if (userIntance.Role == (int)DAL.RoleEnum.User)
                {
                    sideNavItem2.Visible = false;
                    buttonAddDevice.Visible = false;
                }

                if (userIntance.Role == 2)
                {
                    sideNavItem2.Visible = false;
                    sideNavItem2.Checked = false;

                    sideNavItem3.Checked = true;
                    if (panelControl.Controls.Count > 0)
                    {
                        panelControl.Controls.Clear();
                    }
                }

                if (isDeviceConnected())
                {
                    RunTask();
                }
                else
                {
                    MessageBox.Show("Device Not Connected, Please check network Adapter.");
                }

            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);

            }

        }

        bool isDeviceConnected()
        {

            PingReply reply = null;

            try
            {

                Ping myPing = new Ping();
                String host = "192.168.2.17";
                byte[] buffer = new byte[32];
                int timeout = 1000;
                PingOptions pingOptions = new PingOptions();
                reply = myPing.Send(host, timeout, buffer, pingOptions);
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }

            }
            catch (Exception)
            {
                return false;

            }
            if (reply == null)
            {
                return false;
            }

            switch (reply.Status)
            {
                case IPStatus.BadDestination:
                case IPStatus.BadHeader:
                case IPStatus.BadOption:
                case IPStatus.BadRoute:
                case IPStatus.DestinationHostUnreachable:
                case IPStatus.DestinationNetworkUnreachable:
                case IPStatus.DestinationPortUnreachable:
                case IPStatus.DestinationProhibited:
                case IPStatus.DestinationScopeMismatch:
                case IPStatus.DestinationUnreachable:
                case IPStatus.HardwareError:
                case IPStatus.IcmpError:
                case IPStatus.NoResources:
                case IPStatus.PacketTooBig:
                case IPStatus.ParameterProblem:
                case IPStatus.SourceQuench:
                case IPStatus.TimeExceeded:
                case IPStatus.TimedOut:
                case IPStatus.TtlExpired:
                case IPStatus.TtlReassemblyTimeExceeded:
                case IPStatus.Unknown:
                case IPStatus.UnrecognizedNextHeader:
                    return false;
                case IPStatus.Success:
                    return true;
                default:
                    return false;

            }
        }

        private void backuptimer_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime dt1 = backuplast.AddDays(7);

                DateTime dt2 = DateTime.Now;

                TimeSpan ts = dt1.Subtract(dt2);
                if (ts.TotalDays <= 0)
                {

                    CreateBackup();
                    backuplast = DateTime.Now;
                    instance.SystemProperties.lastbakdate = backuplast;
                    instance.DataLink.SubmitChanges();
                }
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
            }

        }

        void configpage_IDSetDevice(int id)
        {
            Deviceid = id;
        }

        void usertask_AddUser()
        {
            try
            {
                Log_It.Pages.UserPage userpage = (Log_It.Pages.UserPage)Pages[4];
                userpage.RefreshPage();
                email = new List<string>();
                foreach (var item in instance.Users.Where(x => x.Active == true && x.IsRowEnable == true && x.Email_Notification == true))
                {
                    if (item.Email != null)
                    {
                        email.Add(item.Email);
                    }
                }
                SMSmail = new List<string>();
                foreach (var item in instance.Users.Where(x => x.Active == true && x.IsRowEnable == true && x.SMS_Notification == true))
                {
                    if (item.SMS != null)
                    {
                        SMSmail.Add(item.SMS);

                    }

                }
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);

            }

        }

        void usertask_DeleteUser()
        {

            try
            {
                if (UserID > -1)
                {
                    DialogResult r = MessageBox.Show("Are your sure you want to delete select user", "Delete user", MessageBoxButtons.YesNo);
                    if (r == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                    instance.DataLink.Users.SingleOrDefault(x => x.Id == UserID).Active = false;
                    instance.DataLink.Users.SingleOrDefault(x => x.Id == UserID).IsRowEnable = false;
                    instance.DataLink.SubmitChanges();
                    int index = -1;
                    if (instance.Users.SingleOrDefault(x => x.Active == true && x.Authority != "Owner") != null)
                    {
                        DAL.User user = instance.Users.SingleOrDefault(x => x.Active == true && x.Authority != "Owner");
                        index = instance.Users.SingleOrDefault(x => x.Active == true && x.Authority != "Owner").Id;
                    }

                    userpage_IDSet(index);
                    Log_It.Pages.UserPage userpage = (Log_It.Pages.UserPage)Pages[4];
                    userpage.RefreshPage();
                    Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "User Delete by " + instance.UserInstance.Full_Name, instance.UserInstance.Full_Name);
                    email = new List<string>();
                    foreach (var item in instance.Users.Where(x => x.Active == true && x.IsRowEnable == true && x.Email_Notification == true))
                    {
                        if (item.Email != null)
                        {
                            email.Add(item.Email);
                        }
                    }
                    SMSmail = new List<string>();
                    foreach (var item in instance.Users.Where(x => x.Active == true && x.IsRowEnable == true && x.SMS_Notification == true))
                    {
                        if (item.SMS != null)
                        {
                            SMSmail.Add(item.SMS);
                        }
                    }
                }
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);

            }

        }

        void usertask_ModifiedUser()
        {

            try
            {
                if (UserID > -1)
                {


                    UserForm form = new UserForm(UserID, instance, false);
                    form.ShowDialog();
                    Log_It.Pages.UserPage userpage = (Log_It.Pages.UserPage)Pages[4];
                    userpage.RefreshPage();
                    email = new List<string>();
                    foreach (var item in instance.Users.Where(x => x.Active == true && x.IsRowEnable == true && x.Email_Notification == true))
                    {
                        if (item.Email != null)
                        {
                            email.Add(item.Email);
                        }
                    }
                    SMSmail = new List<string>();
                    foreach (var item in instance.Users.Where(x => x.Active == true && x.IsRowEnable == true && x.SMS_Notification == true))
                    {
                        if (item.SMS != null)
                        {
                            SMSmail.Add(item.SMS);

                        }

                    }
                }
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);

            }
        }

        void userpage_IDSet(int id)
        {
            UserID = id;
        }

        void eventtask_PrintP()
        {

            try
            {
                Log_It.Pages.Eventpage eventpage = (Log_It.Pages.Eventpage)Pages[3];
                //eventpage.PrintDoc();
                Log_It.Forms.EventFilterForm form = new EventFilterForm(this.instance);
                form.ShowDialog();
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);

            }
        }

        void eventtask_RefreshControl()
        {

            try
            {
                Log_It.Pages.Eventpage eventpage = (Log_It.Pages.Eventpage)Pages[3];
                eventpage.RefreshPage();
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);

            }
        }

        void home_PageIndex(int i)
        {

            try
            {
                if (panelControl.Controls.Count > 0)
                {
                    panelControl.Controls.Clear();
                    paneltask.Controls.Clear();
                }
                paneltask.Controls.Add(taskPanel[i]);

                panelControl.Controls.Add(Pages[i]);
                Log_It.Pages.ControlPage page = (Log_It.Pages.ControlPage)panelControl.Controls[0];
                page.RefreshPage();
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);

            }
        }

        private void tvv_Closed(object sender, EventArgs e)
        {
            tvv = null;
        }

        private void Send2Channels(int id, double temperature, double humidity)
        {
            try
            {
                if (channel != null)
                {
                    LogIt log = channel.SingleOrDefault(p => p.DeviceID == id.ToString());
                    switch (log.Type_of_Device)
                    {
                        case 0:
                            log.Parameter[0].ParameterValue = temperature / 10;
                            if (log.RhActive)
                            {
                                log.Parameter[1].ParameterValue = humidity / 10;
                            }
                            log.Parameter[0].SensorID = id.ToString();
                            break;
                        case 1:
                            if (temperature < 6553)
                            {
                                log.Parameter[0].ParameterValue = temperature / 10;
                                log.Parameter[0].SensorID = id.ToString();
                            }

                            break;

                    }
                    log.isLogged = false;
                    log.LaunchRealTime();

                }
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
            }

        }

        private void LogitMaincs_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Shutdown sd = new Shutdown(this.instance.DataLink.Users.Where(x => x.Active == true && x.IsRowEnable == true).ToList());
                sd.ShowDialog();
                if (sd.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    cancellationTokenSource.Cancel();
                    //backuptimer.Stop();
                    //backuptimer.Dispose();
                    //foreach (var item in channel)
                    //{
                    //    //foreach (var itempara in item.Parameter)
                    //    //{
                    //    //    if (itempara.AlarmLimit != Guid.Empty)
                    //    //    {
                    //    //        instance.DataLink.Update_AlarmStatus(itempara.AlarmLimit, itempara._DeviceID, itempara._SensiorID, itempara.combineID, DateTime.Now);
                    //    //    }
                    //    //    if (itempara.AlarmPower != Guid.Empty)
                    //    //    {
                    //    //        instance.DataLink.Update_AlarmStatus(itempara.AlarmLimit, itempara._DeviceID, itempara._SensiorID, itempara.combineID, DateTime.Now);
                    //    //    }
                    //    //}
                    //}
                    this.DestroyLogItObject();

                    Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Shutdown, sd.comments, sd.User.Full_Name);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
            }

        }

        private void AosongReadData(ref float num2, ref float num3, ref int number)
        {
            SendCommand(number);
            Thread.Sleep(1000);
            Random r = new Random();
            if (ReadData(out number, out num2, out num3) == 0)
            {
                System.Diagnostics.Debug.Print("ID: " + number.ToString() + " Temperature: " + num2.ToString() + " Humadity: " + num3.ToString());
                // Send2Channels(number, num2, num3);
            }
            else
            {

            }
        }

        private void NoDataSend2Channel(int number)
        {
            try
            {
                if (channel != null)
                {
                    LogIt log = channel.SingleOrDefault(p => p.DeviceID == number.ToString());

                    log.Parameter[0].ParameterNoData = true;
                    if (log.RhActive)
                    {
                        log.Parameter[1].ParameterNoData = true;
                    }

                    log.isLogged = true;

                }
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
            }
        }

        private void LogIt_RealTime(LogIt logItObject)
        {
            try
            {
                if (this.tvv != null)
                {
                    tvv.RealTimeData(logItObject);
                }
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);

            }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {

                if (panelControl.Controls.Count > 0)
                {
                    panelControl.Controls.Clear();
                    paneltask.Controls.Clear();
                }



                if (e.Node.Tag == "Option")
                {

                    panelControl.Controls.Add(Pages[0]);
                    paneltask.Controls.Add(taskPanel[0]);
                    displayMode = PageControlEnum.Home;
                }
                else
                {

                    int a = Convert.ToInt32(e.Node.ToolTipText) + 1;
                    panelControl.Controls.Add(Pages[a]);

                    Log_It.Pages.ControlPage page = (Log_It.Pages.ControlPage)panelControl.Controls[0];
                    page.RefreshPage();


                    paneltask.Controls.Add(taskPanel[a]);
                    displayMode = (PageControlEnum)a;
                }
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
            }

        }

        private void Tvv_close() => tvv = null;
        
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                tvv = Log_It.Pages.TVView.Instance(channel, logit_device, instance);
                tvv.ClientSize = new System.Drawing.Size(this.Size.Width - 50, 1000);
                tvv.close += Tvv_close;
                try
                {
                    tvc = tvv.TVs;

                    if (panelControl.Controls.Count > 0)
                    {
                        if (panelControl.Controls[0] is Log_It.Pages.TVView)
                        {

                        }
                        else
                        {
                            panelControl.Controls.Clear();
                        }

                        panelDevices.Controls.Clear();
                    }
                    displayMode = PageControlEnum.TVView;
                    panelControl.Controls.Add(tvv);
                }
                catch (Exception m)
                {
                    MessageBox.Show(m.Message);
                }
            }
            catch (Exception m)
            {
                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
            }
            //if (panelControl.Controls.Count >0)
            //{
            //    panelControl.Controls.Clear();
            //}
        }
        
        private void sideNavItem3_Click(object sender, EventArgs e)
        {
            try
            {
                DisposedPage();
                if (this.panelReport.Controls.Count > 0)
                {

                    if (panelReport.Controls[0] is Log_It.Pages.TaskPanel.ReportTask)
                    {
                        Log_It.Pages.TaskPanel.ReportTask tvView = (Log_It.Pages.TaskPanel.ReportTask)panelReport.Controls[0];
                        tvView.Dispose();
                        panelReport.Controls.Clear();
                    }
                }
                if (panelControl.Controls.Count > 0)
                {
                    if (panelControl.Controls[0] is Log_It.Pages.ReportPage)
                    {
                        Log_It.Pages.ReportPage tvView = (Log_It.Pages.ReportPage)panelControl.Controls[0];
                        tvView.Dispose();
                    }
                }

                panelControl.Controls.Clear();


                Log_It.Pages.DeviceConfigPage configpage = new DeviceConfigPage(instance);
                configpage.IDSetDevice += configpage_IDSetDevice;
                configpage.Dock = DockStyle.Fill;
                Pages[7] = configpage;
                panelControl.Controls.Add(Pages[7]);
                Log_It.Pages.DeviceConfigPage page = (Log_It.Pages.DeviceConfigPage)panelControl.Controls[0];
                page.RefreshPage();


                //Log_It.Pages.TaskPanel.DeviceTask deviceTask = new Log_It.Pages.TaskPanel.DeviceTask(0, instance);
                //deviceTask.AddDevice += deviceTask_AddDevice;
                //deviceTask.ModifiedDevice += deviceTask_ModifiedDevice;
                //deviceTask.DeleteDevice += deviceTask_DeleteDevice;
                //panelDevices.Controls.Add(deviceTask);
                //panelControl.Controls.Clear();
                //panelControl.Controls.Add(Pages[7]);
                //Log_It.Pages.ControlPage page = (Log_It.Pages.ControlPage)panelControl.Controls[0];
                //page.RefreshPage();
                displayMode = PageControlEnum.DeviceConfigPage;
                //if (instance.SystemProperties.Email == true)
                //{

                //}



            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
            }
        }

        private void sideNavItem2_Click(object sender, EventArgs e)
        {
            try
            {
                DisposedPage();
                if (panelControl.Controls.Count > 0)
                {
                    panelControl.Controls.Clear();
                    panelControl.Controls.Add(Pages[0]);
                }
                if (paneltask.Controls.Count > 0)
                {
                    paneltask.Controls.Clear();
                    paneltask.Controls.Add(taskPanel[0]);

                }

                displayMode = PageControlEnum.Home;
                panelControl.Controls.Add(Pages[0]);
                paneltask.Controls.Add(taskPanel[0]);
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DisplayChannel();

        }

        private void DisplayChannel()
        {
            try
            {
                tk = new Log_It.Pages.TankView();
                tk.close += tk_close;

                tk.Dock = DockStyle.Fill;
                int count = 0;

                foreach (var item in logit_device.GetAllDevices())
                {
                    if (item.Device_Type == 0)
                    {
                        if (item.Rh_Active == true)
                        {
                            count = count + 2;
                        }
                        else
                        {
                            count++;
                        }
                    }
                    else
                    {
                        count++;
                    }

                }

                tk.CreateTanks(count);
                tk.ApplyFont(new Font("Americana BT", 9));
                bp = tk.Tanks;

                int i = 0;
                IQueryable<DAL.Device_Config> config = logit_device.GetAllDevices();
                IOrderedQueryable<DAL.Device_Config> orderConfig = config.OrderBy(x => x.Device_Id);
                foreach (var item in orderConfig)
                {
                    switch (item.Device_Type)
                    {
                        case 0:

                            DAL.LimitTable templimit = item.LimitTables.SingleOrDefault(x => x.Device_type == 1);
                            bp[i].Caption = item.Instrument;
                            bp[i].Unit = "°C";
                            bp[i].LLimit = (float)templimit.Lower_Limit;
                            bp[i].ULimit = (float)templimit.Upper_Limit;
                            bp[i].Min = (float)templimit.Lower_Range;
                            bp[i].Max = (float)templimit.Upper_Range;
                            bp[i].picTimeOut.Tag = item.Device_Id.ToString();

                            if (item.Rh_Active == true)
                            {
                                i++;
                                DAL.LimitTable Rhlimit = item.LimitTables.SingleOrDefault(x => x.Device_type == 2);
                                bp[i].Caption = item.Instrument;// + "(RH)";
                                //bp[i].BackgroundColor = Color.LightYellow;
                                bp[i].Unit = " %";
                                bp[i].LLimit = (float)Rhlimit.Lower_Limit;
                                bp[i].ULimit = (float)Rhlimit.Upper_Limit;
                                bp[i].Min = (float)Rhlimit.Lower_Range;
                                bp[i].Max = (float)Rhlimit.Upper_Range;

                            }
                            i++;
                            break;
                        case 1:
                            bp[i].Caption = item.Instrument;
                            bp[i].Unit = "Pa";
                            DAL.LimitTable templimit1 = item.LimitTables.SingleOrDefault(x => x.Device_type == 3);
                            bp[i].LLimit = (float)templimit1.Lower_Limit;
                            bp[i].ULimit = (float)templimit1.Upper_Limit;
                            bp[i].Min = (float)templimit1.Lower_Range;
                            bp[i].Max = (float)templimit1.Upper_Range;
                            bp[i].picTimeOut.Tag = item.Device_Id.ToString();

                            i++;
                            break;
                        default:
                            break;
                    }


                }

                DisposedPage();

                //if (panelControl.Controls.Count > 0)
                //{
                //    if (panelControl.Controls[0] is Log_It.Pages.TVView)
                //    {
                //        Log_It.Pages.TVView tvView = (Log_It.Pages.TVView)panelControl.Controls[0];
                //        tvView.Dispose();
                //    }

                //}
                //if (panelControl.Controls.Count > 0)
                //{
                //    if (panelControl.Controls[0] is Log_It.Pages.AcknowledgePage)
                //    {
                //        Log_It.Pages.AcknowledgePage tvView = (Log_It.Pages.AcknowledgePage)panelControl.Controls[0];
                //        tvView.Dispose();
                //    }
                //}
                panelControl.Controls.Clear();
                displayMode = PageControlEnum.TankView;
                panelControl.Controls.Add(tk);

            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);

            }
        }

        private void DisposedPage()
        {

            if (panelControl.Controls.Count > 0)
            {
                if (panelControl.Controls[0] is Log_It.Pages.TankView)
                {
                    Log_It.Pages.TankView tvView = (Log_It.Pages.TankView)panelControl.Controls[0];
                    tvView.Dispose();
                }
            }
            if (panelControl.Controls.Count > 0)
            {
                if (panelControl.Controls[0] is Log_It.Pages.TVView)
                {
                    Log_It.Pages.TVView tvView = (Log_It.Pages.TVView)panelControl.Controls[0];
                    tvView.Dispose();
                }
            }


            if (panelControl.Controls.Count > 0)
            {
                if (panelControl.Controls[0] is Log_It.Pages.DeviceConfigPage)
                {
                    Log_It.Pages.DeviceConfigPage tvView = (Log_It.Pages.DeviceConfigPage)panelControl.Controls[0];
                    tvView.Dispose();
                    if (panelDevices.Controls.Count > 0)
                    {


                        if (panelDevices.Controls[0] is Log_It.Pages.TaskPanel.DeviceTask)
                        {
                            Log_It.Pages.TaskPanel.DeviceTask task = (Log_It.Pages.TaskPanel.DeviceTask)panelDevices.Controls[0];
                            task.Dispose();
                            panelDevices.Controls.Clear();
                        }
                    }
                }
            }


            if (panelControl.Controls.Count > 0)
            {
                if (panelControl.Controls[0] is Log_It.Pages.AcknowledgePage)
                {
                    Log_It.Pages.AcknowledgePage tvView = (Log_It.Pages.AcknowledgePage)panelControl.Controls[0];
                    tvView.Dispose();
                }
            }
            if (panelControl.Controls.Count > 0)
            {
                if (panelControl.Controls[0] is Log_It.Pages.Eventpage)
                {
                    Log_It.Pages.Eventpage tvView = (Log_It.Pages.Eventpage)panelControl.Controls[0];
                    tvView.Dispose();
                }
            }
        }

        void tvv_close()
        {
            tvv = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DisposedPage();
                panelControl.Controls.Clear();

                Log_It.Pages.TaskPanel.DeviceTask deviceTask = new Log_It.Pages.TaskPanel.DeviceTask(0, instance);
                deviceTask.AddDevice += deviceTask_AddDevice;
                deviceTask.ModifiedDevice += deviceTask_ModifiedDevice;
                deviceTask.DeleteDevice += deviceTask_DeleteDevice;
                panelDevices.Controls.Add(deviceTask);

                Log_It.Pages.DeviceConfigPage configpage = new DeviceConfigPage(instance);
                configpage.IDSetDevice += configpage_IDSetDevice;
                configpage.Dock = DockStyle.Fill;
                Pages[7] = configpage;
                panelControl.Controls.Add(Pages[7]);
                Log_It.Pages.ControlPage page = (Log_It.Pages.ControlPage)panelControl.Controls[0];
                page.RefreshPage();

            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);

            }

        }

        void deviceTask_DeleteDevice()
        {
            try
            {
                if (Deviceid > 0)
                {
                    if (userIntance.Role != (int)DAL.RoleEnum.Administrator)
                    {
                        MessageBox.Show("You can not proceed." + "\r\n"
                            + "Only Administrators are allowed to Configure the system.", "Access Violation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    cancellationTokenSource.Cancel();
                    this.DestroyLogItObject();
                    if (Deviceid > 0)
                    {
                        if (MessageBox.Show("Do you want to delete that select device?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                        {
                            DAL.Device_Config config = instance.Device_Configes.SingleOrDefault(x => x.Device_Id == Deviceid && x.IsRowActive == true);
                            config.IsRowActive = false;
                            config.Active = false;
                            config.ModifiedBy = instance.UserInstance.Full_Name;
                            config.ModifiedDateTime = DateTime.Now;
                            instance.DataLink.SubmitChanges();
                            Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Device Delete: ", userIntance.Full_Name);
                        }
                    }
                    CreateLogItObjects();
                    if (panelControl.Controls.Count > 0)
                    {

                        panelControl.Controls.Clear();
                    }
                    panelControl.Controls.Add(Pages[7]);
                    Log_It.Pages.ControlPage page = (Log_It.Pages.ControlPage)panelControl.Controls[0];
                    page.RefreshPage();
                    RunTask();
                    displayMode = PageControlEnum.DeviceConfigPage;
                }
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
            }

        }

        void deviceTask_ModifiedDevice()
        {
            try
            {

                if (Deviceid > 0)
                {
                    //if (userIntance.Role != (int)DAL.RoleEnum.Administrator)
                    //{
                    //    MessageBox.Show("You can not proceed." + "\r\n"
                    //        + "Only Administrators are allowed to Configure the system.", "Access Violation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    return;
                    //}
                    cancellationTokenSource.Cancel();
                    this.DestroyLogItObject();



                    DeviceForm from = new DeviceForm(Deviceid, false, instance, logit_device);
                    from.ShowDialog();

                    CreateLogItObjects();
                    if (panelControl.Controls.Count > 0)
                    {

                        panelControl.Controls.Clear();
                    }
                    panelControl.Controls.Add(Pages[7]);
                    Log_It.Pages.ControlPage page = (Log_It.Pages.ControlPage)panelControl.Controls[0];
                    page.RefreshPage();
                    RunTask();
                    displayMode = PageControlEnum.DeviceConfigPage;
                }
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
            }
        }

        void deviceTask_AddDevice()
        {

            try
            {

                //if (userIntance.Role != (int)DAL.RoleEnum.Administrator)
                //{
                //    MessageBox.Show("You can not proceed." + "\r\n"
                //        + "Only Administrators are allowed to Configure the system.", "Access Violation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                if (cancellationTokenSource != null)
                {
                    cancellationTokenSource.Cancel();
                }

                this.DestroyLogItObject();

                IQueryable<DAL.Device_Config> configs = instance.Device_Configes.Where(y => y.IsRowActive == true);
                var configuratioMax = configs.Max(x => x.Device_Id);
                DeviceForm from = null;
                PressureDeviceForm pform = null;

                if (configuratioMax != null)
                {
                    DeviceOption dp = new DeviceOption();
                    if (dp.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (dp.option == 0)
                        {
                            from = new DeviceForm(configuratioMax.Value + 1, true, instance, logit_device);
                            from.ShowDialog();
                        }
                        if (dp.option == 1)
                        {
                            pform = new PressureDeviceForm(configuratioMax.Value + 1, true, instance, logit_device);
                            pform.ShowDialog();
                        }
                    }

                }
                else
                {
                    DeviceOption dp = new DeviceOption();
                    if (dp.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (dp.option == 0)
                        {
                            from = new DeviceForm(1, true, instance, logit_device);
                            from.ShowDialog();
                        }
                        if (dp.option == 1)
                        {
                            pform = new PressureDeviceForm(1, true, instance, logit_device);
                            pform.ShowDialog();
                            
                        }
                    }

                }



                CreateLogItObjects();
                if (panelControl.Controls.Count > 0)
                {

                    panelControl.Controls.Clear();
                }
                panelControl.Controls.Add(Pages[7]);
                Log_It.Pages.ControlPage page = (Log_It.Pages.ControlPage)panelControl.Controls[0];
                page.RefreshPage();
                RunTask();
                displayMode = PageControlEnum.DeviceConfigPage;
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
            }
        }

        private void sideNavItem4_Click(object sender, EventArgs e)
        {
            try
            {

                DisposedPage();
                Log_It.Pages.TaskPanel.ReportTask t = new Pages.TaskPanel.ReportTask(instance);
                t.EventDevice += t_EventDevice;
                if (this.panelControl.Controls.Count > 0)
                {
                    panelControl.Controls.Clear();
                }
                t.Dock = DockStyle.Fill;
                this.panelReport.Controls.Add(t);
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
            }
        }

        void t_EventDevice(DAL.Device_Config Config, DateTime SD, DateTime ED)
        {
            try
            {
                if (this.panelControl.Controls.Count > 0)
                {
                    if (panelControl.Controls[0] is Log_It.Pages.ReportPage)
                    {


                        Log_It.Pages.ReportPage tvView = (Log_It.Pages.ReportPage)panelControl.Controls[0];
                        tvView.Dispose();
                    }
                    panelControl.Controls.Clear();
                }
                Cursor.Current = Cursors.WaitCursor;
                Log_It.Pages.ReportPage Rp = new ReportPage();
                Rp.RefreshPage(instance, Config, SD, ED);
                Rp.Dock = DockStyle.Fill;

                panelControl.Controls.Add(Rp);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception m)
            {

                Cursor.Current = Cursors.Default;
                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);

            }


        }

        private void treeView1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {


                try
                {
                    //tvc = tvv.TVs;



                    AcknowledgePage ackPage = new AcknowledgePage(instance);
                    DisposedPage();
                    panelDevices.Controls.Clear();
                    panelControl.Controls.Clear();
                    //displayMode = PageControlEnum.TVView;

                    panelControl.Controls.Add(ackPage);
                    ackPage.Dock = DockStyle.Fill;
                }
                catch (Exception m)
                {
                    var st = new StackTrace();
                    var sf = st.GetFrame(0);

                    var currentMethodName = sf.GetMethod();
                    //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
                    Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);

                    //Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);

                }
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
            }
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

                    //MessageBox.Show("Backup has been created");

                }
                catch (Exception m)
                {
                    var st = new StackTrace();
                    var sf = st.GetFrame(0);

                    var currentMethodName = sf.GetMethod();
                    //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
                    Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);

                }

                Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Information, "Backup has been done", "System");
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);
                MessageBox.Show(m.InnerException.Message);
                var currentMethodName = sf.GetMethod();
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
            }
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (instance.SystemProperties.Email == true)
                {
                    

                    bool internet = await isInternetConnected();
                    if (!internet)
                    {
                        return;
                    }


                    Dictionary<DAL.Device_Config, string> attached = new Dictionary<DAL.Device_Config, string>();

                    string subject = string.Empty;
                    foreach (var config in instance.Device_Configes.Where(x => x.Active == true && x.IsRowActive == true))
                    {
                        Reports.DSLogit dt = new Reports.DSLogit();
                        if (config.ReportSendDate.Value.Date.AddDays(1) == DateTime.Today)
                        {
                            continue;
                        }
                        DateTime SD = Convert.ToDateTime(config.ReportSendDate.Value.Date.Add(new TimeSpan(1, 0, 0, 0)).ToShortDateString() + " 00:00:00");
                        DateTime ED = Convert.ToDateTime(config.ReportSendDate.Value.Date.Add(new TimeSpan(1, 0, 0, 0)).ToShortDateString() + " 23:59:59");

                        string STARTDATETIME = SD.Month.ToString() + "-" + SD.Day.ToString() + "-" + SD.Year.ToString() + " " + SD.Hour.ToString() + ":" + SD.Minute.ToString() + ":" + "00" + " " + SD.ToString("tt", System.Globalization.CultureInfo.InvariantCulture);
                        string ENDDATETIME = ED.Month.ToString() + "-" + ED.Day.ToString() + "-" + ED.Year.ToString() + " " + ED.Hour.ToString() + ":" + ED.Minute.ToString() + ":" + "00" + " " + ED.ToString("tt", System.Globalization.CultureInfo.InvariantCulture);



                        subject = SD.ToString() + " " + ED.ToString();

                        string s = "SELECT * From Log Where Device_Id = '" + config.ID + "' AND ([date_] > '" + STARTDATETIME + "' AND [date_] < '" + ENDDATETIME + "') Order by date_";
                        string max = "SELECT MAX(Temp_Data) As Maximum, MIN(Temp_Data) As Minimumm, AVG(Temp_Data) As Average From Log Where Device_Id = '" + config.ID + "' AND ([date_] > '" + STARTDATETIME + "' AND [date_] < '" + ENDDATETIME + "')";
                        string Rhmax = "SELECT MAX(Rh_Data) As Maximum, MIN(Rh_Data) As Minimumm, AVG(Rh_Data) As Average From Log Where Device_Id = '" + config.ID + "' AND ([date_] > '" + STARTDATETIME + "' AND [date_] < '" + ENDDATETIME + "')";
                        string Pamax = "SELECT MAX( Pressure) As Maximum, MIN( Pressure) As Minimumm, AVG( Pressure) As Average From Log Where Device_Id = '" + config.ID + "' AND ([date_] > '" + STARTDATETIME + "' AND [date_] < '" + ENDDATETIME + "')";

                        SqlConnection Conn = new SqlConnection(instance.DataLink.Connection.ConnectionString);
                        Reports.DSLogit.StatisticsRow statiscticRow = dt.Statistics.NewStatisticsRow();


                        Reports.DSLogit.DeviceInformationRow drow = dt.DeviceInformation.NewDeviceInformationRow();
                        if (config.Device_Type == 0)
                        {
                            drow.Device_ID = config.Device_Id.ToString();
                            drow.Location = config.Location;
                            drow.Instrument = config.Instrument;
                            drow.Logging_Interval = config.Interval.ToString();
                            drow.Loggin_cycle = subject;
                            drow.Device_Type = "Temperature";

                            if (config.Rh_Active == true)
                            {
                                Reports.DSLogit.DeviceRhRow RhRow = dt.DeviceRh.NewDeviceRhRow();
                                drow.Device_Type = "Temperature/Humidity";

                                DAL.LimitTable limitT = config.LimitTables.SingleOrDefault(d => d.Device_type == 2);
                                RhRow.UpperLimit = limitT.Upper_Limit.ToString();
                                RhRow.LowerLimit = limitT.Lower_Limit.ToString();

                                dt.DeviceRh.AddDeviceRhRow(RhRow);
                            }
                            DAL.LimitTable limitT1 = config.LimitTables.SingleOrDefault(d => d.Device_type == 1);
                            drow.Max_Limit = (int)limitT1.Upper_Limit;
                            drow.Min_Limit = (int)limitT1.Lower_Limit;
                            dt.DeviceInformation.AddDeviceInformationRow(drow);
                        }

                        #region Rh
                        if (config.Device_Type == 0)
                        {


                            SqlCommand cmd = new SqlCommand(max, Conn);
                            cmd.CommandType = CommandType.Text;
                            if (Conn.State == ConnectionState.Closed)
                            {
                                Conn.Open();
                            }

                            SqlDataReader reader = cmd.ExecuteReader();

                            while (reader.Read())
                            {
                                double? Idmax = reader[0] as double? ?? default(double?);
                                double? Idmin = reader[1] as double? ?? default(double?);
                                double? Idavg = reader[2] as double? ?? default(double?);

                                if (Idmax != null)
                                {
                                    double data = Convert.ToDouble(Idmax);

                                    statiscticRow.Max = data.ToString();

                                }
                                if (Idmin != null)
                                {
                                    double data = Convert.ToDouble(Idmin);
                                    statiscticRow.Min = data.ToString();
                                }
                                if (Idavg != null)
                                {
                                    double data = Convert.ToDouble(Idavg);

                                    decimal stravg = Convert.ToDecimal(data);
                                    statiscticRow.Avg = Decimal.Round(stravg, 2, MidpointRounding.AwayFromZero).ToString();
                                }

                                //labelTmax.Text = reader[0].ToString();
                                //labelTmin.Text = reader[1].ToString();
                                //decimal stravg = Convert.ToDecimal(reader[2]);
                                //labelTavg.Text = Decimal.Round(stravg, 2, MidpointRounding.AwayFromZero).ToString();

                            }

                            statiscticRow.DateCalibration = config.LimitTables[0].dateofcalibrate.ToString();



                            Conn.Close();
                            dt.Statistics.AddStatisticsRow(statiscticRow);
                            if (config.Rh_Active == true)
                            {
                                Reports.DSLogit.StatisticsRhRow rhRow = dt.StatisticsRh.NewStatisticsRhRow();

                                cmd = new SqlCommand(Rhmax, Conn);
                                cmd.CommandType = CommandType.Text;
                                Conn.Open();
                                reader = cmd.ExecuteReader();
                                while (reader.Read())
                                {
                                    double? Idmax = reader[0] as double? ?? default(double?);
                                    double? Idmin = reader[1] as double? ?? default(double?);
                                    double? Idavg = reader[2] as double? ?? default(double?);

                                    if (Idmax != null)
                                    {

                                        rhRow.Maxi = Idmax.ToString();
                                    }
                                    if (Idmin != null)
                                    {
                                        rhRow.Mini = Idmin.ToString();

                                    }
                                    if (Idavg != null)
                                    {
                                        decimal stravg = Convert.ToDecimal(Idavg);
                                        rhRow.Avgr = Decimal.Round(stravg, 2, MidpointRounding.AwayFromZero).ToString();

                                    }


                                    dt.StatisticsRh.AddStatisticsRhRow(rhRow);

                                }

                                Conn.Close();

                            }
                            else
                            {

                            }


                            Reports.DSLogit.UserInformationRow userRow = dt.UserInformation.NewUserInformationRow();
                            userRow.FullName = "System Administrator";
                            dt.UserInformation.AddUserInformationRow(userRow);

                            cmd = new SqlCommand(s, Conn);
                            cmd.CommandType = CommandType.Text;
                            if (Conn.State == ConnectionState.Closed)
                            {
                                Conn.Open();
                            }
                            reader = cmd.ExecuteReader();

                            int i = 0;
                            List<MKT> mkt = new List<MKT>();

                            double sum = 0;
                            while (reader.Read())
                            {

                                Reports.DSLogit.LogsTableRow row = dt.LogsTable.NewLogsTableRow();
                                i++;
                                row.Point = i.ToString();
                                MKT mk = new MKT();
                                mk.Rhdata = Convert.ToDouble(reader[5]);
                                mk.data = Convert.ToDouble(reader[3]);
                                mk._date = Convert.ToDateTime(reader[4]);
                                mk.kvdata = Convert.ToDouble(mk.data + 273.15);
                                double d = (0.008314472 * mk.kvdata);
                                mk.expdata = Math.Exp(-83.14472 / d);
                                sum = sum + mk.expdata;
                                mkt.Add(mk);
                                row.Channel_ID = reader[2].ToString();
                                double data = Convert.ToDouble(reader[3]);
                                row.TempData = Math.Round(data, 2).ToString("##.0");
                                row.Date_Time = reader[4].ToString();
                                data = Convert.ToDouble(reader[5]);
                                row.RhData = Math.Round(data, 2).ToString("##.0"); //reader[5].ToString();
                                dt.LogsTable.AddLogsTableRow(row);
                            }
                            if (reader.HasRows)
                            {
                                sum = sum / mkt.Count;
                                sum = Math.Log(sum);
                                sum = sum / -1;
                                sum = 10000 / sum;
                                sum = sum - 273.15;
                                //labelTMKT.Text = sum.ToString("##.00");
                                statiscticRow.MKT = sum.ToString("##.00");
                            }










                            Conn.Close();

                            string ReportIDT = config.Instrument + " " + config.Instrument + "_TT";
                            string ReportIDRH = config.Instrument + " " + config.Instrument + "_TTRH";

                            string locationfile = string.Empty;
                            string filename = string.Empty;


                            switch (config.Device_Type)
                            {
                                case 0:
                                    filename = ReportIDRH;
                                    break;
                                case 2:
                                    filename = ReportIDT;
                                    break;
                                default:
                                    break;
                            }

                            if (File.Exists(Environment.CurrentDirectory + @"\" + filename + ".pdf"))
                            {
                                try
                                {
                                    File.Delete(Environment.CurrentDirectory + @"\" + filename + ".pdf");
                                    locationfile = Environment.CurrentDirectory + @"\" + filename + ".pdf";
                                }
                                catch (Exception)
                                {

                                    locationfile = Environment.CurrentDirectory + "\\" + filename + config.Last_Record.Value.Day.ToString() + config.Last_Record.Value.Month.ToString() + config.Last_Record.Value.Year.ToString() + ".pdf";
                                }
                            }
                            else
                            {
                                locationfile = Environment.CurrentDirectory + @"\" + filename + ".pdf";
                            }


                            ReportViewer reportViewer1 = new ReportViewer();
                            reportViewer1.ProcessingMode = ProcessingMode.Local;

                            reportViewer1.LocalReport.ReportEmbeddedResource = "Log_It.Reports.LogitReportRhEmail.rdlc";


                            ReportDataSource datasourcelog = new ReportDataSource("DataSet1", dt.Tables["UserInformation"]);
                            ReportDataSource datasourcelog2 = new ReportDataSource("DataSet2", dt.Tables["CompanyInfo"]);
                            ReportDataSource datasourcelog3 = new ReportDataSource("DataSet3", dt.Tables["DeviceInformation"]);
                            ReportDataSource datasourcelog4 = new ReportDataSource("DataSet4", dt.Tables["Statistics"]);
                            ReportDataSource datasourcelog5 = new ReportDataSource("DataSet5", dt.Tables["LogsTable"]);
                            ReportDataSource datasourcelog6 = new ReportDataSource("DataSet6", dt.Tables["DeviceRh"]);
                            ReportDataSource datasourcelog7 = new ReportDataSource("DataSet7", dt.Tables["StatisticsRh"]);

                            reportViewer1.LocalReport.DataSources.Clear();
                            reportViewer1.LocalReport.DataSources.Add(datasourcelog);
                            reportViewer1.LocalReport.DataSources.Add(datasourcelog2);
                            reportViewer1.LocalReport.DataSources.Add(datasourcelog3);
                            reportViewer1.LocalReport.DataSources.Add(datasourcelog4);
                            reportViewer1.LocalReport.DataSources.Add(datasourcelog5);
                            reportViewer1.LocalReport.DataSources.Add(datasourcelog6);
                            reportViewer1.LocalReport.DataSources.Add(datasourcelog7);

                            reportViewer1.RefreshReport();
                            

                            Warning[] warnings;
                            string[] streamIds;
                            string mimeType = string.Empty;
                            string encoding = string.Empty;
                            string extension = string.Empty;


                            byte[] bytes = reportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);

                            using (FileStream fs = File.Create(locationfile))
                            {
                                fs.Write(bytes, 0, bytes.Length);
                            }
                            dt.Dispose();
                            reportViewer1.Dispose();
                            attached.Add(config, locationfile);

                        }
                        else
                        {
                            MessageBox.Show("No record in selected dates");
                        }
                    }
                    #endregion

                    bool isconnected = true;///

                    if (isconnected && attached.Count > 0)
                    {
                        List<DAL.User> users = new List<DAL.User>();

                        List<DAL.User> userslist = instance.Users.Where(x => x.Active == true && x.IsRowEnable == true && x.Email_Notification == true && x.Role != 0).ToList();
                        foreach (var itemuser in userslist)
                        {
                            if (!users.Contains(itemuser))
                            {
                                users.Add(itemuser);
                            }
                        }


                        bool b = await SendMail(DateTime.Today.AddDays(-1).ToShortDateString(), users, attached, subject);

                        foreach (var itemmail in attached)
                        {
                            File.Delete(itemmail.Value);

                            // SendAttached.Add(itemmail.Key);
                            if (b)

                            {
                                DAL.Device_Config d = instance.Device_Configes.SingleOrDefault(x => x.ID == itemmail.Key.ID && x.Active == true && x.IsRowActive == true);
                                DateTime dtnow = d.ReportSendDate.Value.Date.Add(new TimeSpan(1, 0, 0, 0));
                                d.ReportSendDate = dtnow;
                                instance.DataLink.SubmitChanges(System.Data.Linq.ConflictMode.ContinueOnConflict);
                                //instance.DataLink.DailyReport_Status_Update(itemmail.Key.ID);
                                //DAL.Device_Config c= itemmail.Key;
                                //c.ReportSendDate.Value.AddDays(1);
                                //instance.DataLink.DailyReport_Status_Update(c.Channel_id);

                                //foreach (var itemconfig in configs)
                                //{

                                //    //itemconfig.ReportSendDate = c.ReportSendDate;
                                //    instance.DataLink.DailyReport_Status_Update(item.Key.Channel_id);
                                //}
                            }
                        }
                    }
                }
            }
            catch (Exception m)
            {
                var st = new StackTrace();
                var sf = st.GetFrame(0);
                MessageBox.Show(m.InnerException.Message);
                var currentMethodName = sf.GetMethod();
                Technoman.Utilities.EventClass.ErrorLog("Method Name: " + currentMethodName + " Message: " + m.Message);
            }
        }

        async Task<bool> SendMail(string v, List<User> users, Dictionary<Device_Config, string> attached,string Subject)
        {
            try
            {
                bool issendmail = false;
                await Task.Run(() =>
                {
                    string smtpAddress = ConfigurationManager.AppSettings["SMTP"].ToString();
                    int portNumber = Convert.ToInt32(587);// ConfigurationManager.AppSettings["Port"].ToString());

                    string emailFromAddress =ConfigurationManager.AppSettings["UserID"].ToString(); //Sender Email Address  
                  
                    string subject = "Daily Report : "+ Subject;
                    string body = @"<html><body> <p>Dear,</p>  <p>Please find the attached Daily Report.</b> @</p><p>This is system notification email. Please don't reply</br></p><p>Thanks & Regards</p> <p>Logit System</br></p></body> </html>";

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(emailFromAddress);
                        SqlConnection con = new SqlConnection(instance.DataLink.Connection.ConnectionString);
                      
                        List<string> email = new List<string>();


                        foreach (var item in users)
                        {
                            if (item.Email != string.Empty)
                            {
                                mail.To.Add(item.Email);
                            }
                        }

                        List<string> path = new List<string>();

                        foreach (var item in attached)
                        {
                            path.Add(item.Value);
                            //mail.Attachments.Add(new Attachment(item.Value));
                        }
                        mail.Subject = subject;
                        mail.Body = body;
                        mail.IsBodyHtml = true;

                        try
                        {
                            toolStripStatusLabel4.Text = "Email is Sending";
                            if (Log_It.Classes.GmailAPI.Send_Mail(mail, path))
                            {
                                toolStripStatusLabel4.Text = "Email has been Sent";
                                issendmail = true;
                                Technoman.Utilities.EventClass.WriteLogException("Email has been Sent");
                            }
                            else
                            {
                                toolStripStatusLabel4.Text = "Email Send Fail";
                                Technoman.Utilities.EventClass.WriteLogException("Email send fail, Internet issue");
                            }
                        }
                        catch (Exception)
                        {
                            Technoman.Utilities.EventClass.WriteLogException("Email Sent Fail with Attachments");
                            toolStripStatusLabel4.Text = "Email Send Fail";
                            var st = new StackTrace();
                            var sf = st.GetFrame(0);
                            issendmail = false;
                            var currentMethodName = sf.GetMethod();
                            //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");
                        }
                        finally
                        {
                            mail.Dispose();
                        }
                    }
                });
                return issendmail;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

