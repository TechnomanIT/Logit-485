using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using System.Xml;
using System.Linq;



namespace BAL
{
    public delegate void LogIts(Guid Id, string DeviceID, string DeviceType, double Temperature, double Humidity, double Pressure);
    public delegate void LogItlastRecord(Guid Id, DateTime dt);
    public delegate void RealTimesS(uint Index, double values);
    public delegate void RealTimesN(uint Index, bool values);

    public delegate void RealTimesD(string DeviceID, uint Index, double values);
    public delegate void RealTimesChart(LogIt logItObject);
    //public delegate void AlarmConditions(bool isLimitExceed);
    public delegate void AlarmConditions(string[] parm);
    public delegate void IsAlaramCondition(LogIt.Parameters P, string name, decimal values, bool isactive, uint Index, string read, string remakr);
    public delegate void BarAlaramCondition(uint Index, double values, bool isactive);
    public delegate void ExtAlaramCondition();
    //[DebuggerNonUserCode()]
    public class LogIt : System.ComponentModel.Component
    {
        public static event LogIts Logging;
        public static event LogItlastRecord LastRecord;
        public static event RealTimesChart RealTime;

        public static uint index = 0;
        private bool rhActive = true;
        private string sDType = null;
        private string sDeviceID = null;
        private Guid Id;
        private string sLocation = null;
        private string sInstrument = null;
        private int iInterval = 0;
        private bool isLoggingEnable = false;
        private bool isDeviceEnable = true;
        private bool isAlarmEnable = true;
        public bool isLogged = true;
        private DateTime dtLastScan;
        private DateTime dtTimeOut = DateTime.Now;
        private Parameters[] parameter;
        private System.Windows.Forms.Timer LoggingTimer = new System.Windows.Forms.Timer();
        private static System.Windows.Forms.Timer AlarmTimer = new System.Windows.Forms.Timer();
        private static System.Windows.Forms.Timer SMS_Timer = new System.Windows.Forms.Timer();
        private static DateTime AlarmStartTiming = new DateTime();
       // private static TimeSpan AlarmDuration = new TimeSpan();
        private static List<LogIt> deviceCreated = new List<LogIt>();
        public static event EventHandler SendAlarmCondition;

        [DllImport("kernel32.dll", EntryPoint = "Beep", SetLastError = true)]
        static extern int Beep(uint dwFreq, uint dwDuration);
        //Clsmgt dm = new Clsmgt();

        #region Properties

        public int Channedl_ID
        { get; set; }

        public bool RhActive
        {
            get { return rhActive; }
            set { rhActive = value; }
        }

        public string DeviceType
        {
            get { return sDType; }
            set { sDType = value; }
        }
        public string DeviceID
        {
            get { return sDeviceID; }
            set { sDeviceID = value; }
        }
        public Guid ID
        {
            get { return Id; }
            set { Id = value; }
        }
        public string Location
        {
            get { return sLocation; }
            set { sLocation = value; }
        }
        public string Instrument
        {
            get { return sInstrument; }
            set { sInstrument = value; }
        }
        public int Type_of_Device { get; set; }
        public int Interval
        {
            get { return iInterval; }
            set
            {
                iInterval = value;
            }
        }

        public bool IsDeviceEnable
        {
            get { return isDeviceEnable; }
            set { isDeviceEnable = value; }
        }
        public bool IsLoggingEnable
        {
            get { return isLoggingEnable; }
            set { isLoggingEnable = value; }
        }
        public bool IsAlarmEnable
        {
            get { return isAlarmEnable; }
            set { isAlarmEnable = value; }
        }

        public DateTime LastScan
        {
            get { return dtLastScan; }
        }

        public Parameters[] Parameter
        {
            get
            {
                return parameter;
            }
            set
            {
                parameter = value;
            }
        }

        public static sbyte Time { get; set; }

        #endregion

        protected override void Dispose(bool disposing)
        {
            foreach (Parameters p in parameter)
            {
                if (p != null)
                {
                    p.Dispose();
                }

            }
            LoggingTimer.Stop();
            AlarmTimer.Stop();
            deviceCreated.Clear();
            base.Dispose(disposing);
        }

        static LogIt()
        {
            AlarmStartTiming = DateTime.Now;
            AlarmTimer.Interval = 5000;
            AlarmTimer.Tick += new EventHandler(AlarmTimer_Tick);
        }

        public LogIt(string DeviceType, string DeviceID, string Location,
            string Instrument, int Interval, DateTime LastScan,
            bool AlarmEnable, bool LoggingEnable, bool RhActive)
        {
            try
            {
                this.DeviceType = DeviceType;
                this.DeviceID = DeviceID;
                this.Location = Location;
                this.Instrument = Instrument;
                this.Interval = Interval;
                this.dtLastScan = LastScan;
                this.IsAlarmEnable = AlarmEnable;
                this.isLoggingEnable = LoggingEnable;
                this.rhActive = RhActive;

                if (this.sDType == "01")
                {
                    parameter = new Parameters[2];
                    parameter[0] = new Parameters("Temperature", sDeviceID, AlarmEnable);
                    parameter[1] = new Parameters("Humidity", sDeviceID, AlarmEnable);
                    parameter[0].Location = this.Location;
                    parameter[0].Instrument = this.Instrument;
                    parameter[0].Index = index++;
                    parameter[1].Index = index++;

                }
                else if (this.sDType == "02")
                {
                    parameter = new Parameters[1];
                    parameter[0] = new Parameters("Temperature", sDeviceID, AlarmEnable);
                    parameter[0].Index = index++;
                    parameter[0].Location = this.Location;
                    parameter[0].Instrument = this.Instrument;
                }
                LoggingTimer.Tick += new EventHandler(LoggingTimer_Tick);
                LoggingTimer_Tick(this, new EventArgs());
                LoggingTimer.Interval = 5000;
                LoggingTimer.Start();
                //Parameters.OutOfLimit += new AlarmConditions(Parameters_OutOfLimit);
                LogIt.deviceCreated.Add(this);
                if (!AlarmTimer.Enabled)
                {
                    AlarmTimer.Start();
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        public LogIt(DAL.Device_Config Device)
        {
            try
            {
                //this.DeviceType = Device.;
                this.ID = Device.ID;
                this.DeviceID = Device.Device_Id.ToString();
                this.Location = Device.Location;
                this.Type_of_Device = (int)Device.Device_Type;
                this.Instrument = Device.Instrument;
                this.Interval = (int)Device.Interval;
                this.Channedl_ID = Convert.ToInt32(Device.Channel_id);
                if (Device.Last_Record != null)
                {
                    this.dtLastScan = Device.Last_Record.Value;

                }
                this.IsAlarmEnable = (bool)Device.Alaram;
                this.isLoggingEnable = (bool)Device.Active;
                if (Device.Device_Type == 0)
                {
                    this.rhActive = (bool)Device.Rh_Active;
                }
                //this.DeviceType =  

                parameter = new Parameters[Device.LimitTables.Count];

                foreach (var item in Device.LimitTables.OrderBy(x => x.Device_type))
                {
                    switch (item.Device_type)
                    {
                        case 1:
                            parameter[0] = new Parameters("Temperature", Device.Device_Id.ToString(), (bool)Device.Alaram);
                            parameter[0].Index = index;
                            parameter[0].GUIDID = Device.ID;
                            parameter[0].Alarm_Interval = this.Interval;
                            parameter[0].Device_Type = (int)item.Device_type;
                            parameter[0].LowerLimit = (double)item.Lower_Limit;
                            parameter[0].UpperLimit = (double)item.Upper_Limit;
                            parameter[0].LowerRange = (double)item.Lower_Range;
                            parameter[0].UpperRange = (double)item.Upper_Range;
                            parameter[0].Location = this.Location;
                            parameter[0].Instrument = this.Instrument;

                            if (item.ofset != null)
                            {
                                parameter[0].Offset = (double)item.ofset;

                            }
                            index++;
                            break;
                        case 2:
                            if (Device.Rh_Active == true)
                            {
                                parameter[1] = new Parameters("Humidity", Device.Device_Id.ToString(), (bool)Device.Alaram);
                                parameter[1].Index = index;
                                parameter[1].Device_Type = (int)item.Device_type;
                                parameter[1].Alarm_Interval = this.Interval;
                                parameter[1].GUIDID = Device.ID;
                                parameter[1].LowerLimit = (double)item.Lower_Limit;
                                parameter[1].UpperLimit = (double)item.Upper_Limit;
                                parameter[1].LowerRange = (double)item.Lower_Range;
                                parameter[1].UpperRange = (double)item.Upper_Range;
                                parameter[1].Location = this.Location;
                                parameter[1].Instrument = this.Instrument;
                                if (item.ofset != null)
                                {
                                    parameter[1].Offset = (double)item.ofset;

                                }
                                index++;

                            }
                            break;
                        case 3:
                            parameter[0] = new Parameters("Pressure", Device.Device_Id.ToString(), (bool)Device.Alaram);
                            parameter[0].Index = index;
                            parameter[0].Device_Type = (int)item.Device_type;

                            parameter[0].GUIDID = Device.ID;
                            parameter[0].LowerLimit = (double)item.Lower_Limit;
                            parameter[0].UpperLimit = (double)item.Upper_Limit;
                            parameter[0].LowerRange = (double)item.Lower_Range;
                            parameter[0].UpperRange = (double)item.Upper_Range;
                            parameter[0].Alarm_Interval = this.Interval;
                            index++;

                            break;

                        default:
                            break;
                    }

                }
                LoggingTimer.Tick += new EventHandler(LoggingTimer_Tick);
                LoggingTimer_Tick(this, new EventArgs());
                LoggingTimer.Interval = 5000;
                LoggingTimer.Start();
                LogIt.deviceCreated.Add(this);
                if (!AlarmTimer.Enabled)
                {
                    AlarmTimer.Start();
                }
            }
            catch (Exception m)
            {
                
                throw;
            }
           

        }
        

        private static void AlarmTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                bool result = false;
                List<string> AlarmList = new List<string>();
                foreach (LogIt logitObject in LogIt.deviceCreated)
                {
                    foreach (Parameters p in logitObject.parameter)
                    {
                        if (p != null)
                        {
                            result = result | p.OutofLimit;
                            if (p.OutofLimit)
                            {
                                if (SendAlarmCondition != null)
                                {
                                    SendAlarmCondition("#0?", e);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                
                throw;
            }
            

        }



        //[DebuggerNonUserCode]
        private void LoggingTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime dt1 = dtLastScan.AddMinutes(iInterval);
                dt1 = dt1.AddSeconds(-dt1.Second);
                DateTime dt2 = DateTime.Now;
                TimeSpan ts = dt1.Subtract(dt2);
                if (ts.TotalMinutes <= 0)
                {
                    if (Logging != null && !(isLogged))
                    {
                        switch (this.Type_of_Device)
                        {
                            case 0:
                                if (rhActive)
                                    Logging(parameter[0].GUIDID, sDeviceID, sDType, parameter[0].ParameterValue, parameter[1].ParameterValue, -1);
                                else
                                    Logging(parameter[0].GUIDID, sDeviceID, sDType, parameter[0].ParameterValue, -1, -1);
                                break;
                            case 1:
                                Logging(parameter[0].GUIDID, sDeviceID, sDType, -1, -1, -parameter[0].ParameterValue);
                                break;
                            default:
                                break;
                        }


                        if (LastRecord != null)
                        {
                            dtLastScan = DateTime.Now;
                            LastRecord(this.ID, dtLastScan);
                        }

                        isLogged = true;
                    }
                }
            }
            catch (Exception m)
            {

                throw;
            }
            
        }
        public void ExplicitLogging()
        {
            switch (this.Type_of_Device)
            {
                case 0:
                    if (rhActive)
                      Logging(parameter[0].GUIDID, sDeviceID, sDType, parameter[0].ParameterValue, parameter[1].ParameterValue, -1);
                    else
                      Logging(parameter[0].GUIDID, sDeviceID, sDType, parameter[0].ParameterValue, -1, -1);
                    break;
                case 1:
                    Logging(parameter[0].GUIDID, sDeviceID, sDType, parameter[0].ParameterValue, -1, -1);
                    break;
                default:
                    break;
            }
           
                

            dtLastScan = DateTime.Now;
        }

        public void LaunchRealTime()
        {
            if (RealTime != null)
                RealTime(this);
        }

        //[DebuggerNonUserCode()]
        public class Parameters : System.ComponentModel.Component
        {
            public static event RealTimesS Output1;
            public static event RealTimesN Nodata;
            public static event AlarmConditions OutOfLimit;
            public static event ExtAlaramCondition ExtAlaram;
            public static event BarAlaramCondition BarAlaram;
            public static event IsAlaramCondition outofLimits;
            private DateTime alraminterval;
            private System.Windows.Forms.Timer AlaramLogTimer = new System.Windows.Forms.Timer();


            #region Fields
            private string name = "";
            private string sDeiveID = "";
            private double paravalue = 0;
            private double lowerlimit = 0;
            private double upperlimit = 0;
            private double lowerrange = 0;
            private double upperrange = 0;
            private double offset = 0;
            private bool isoutlimit = false;
            private bool isalarmenable = false;
            private uint index = 0;
            private DateTime newTime;
            private DateTime lastTime = DateTime.Now;
            public bool isSendMail;

            public bool isMailSend;
            public bool islogAlaram;
            #endregion

            #region Properties
            public string Name
            {
                get { return name; }
            }
            public int Device_Type
            { get; set; }
            public int Alarm_Interval
            { get; set; }
            public Guid GUIDID { get; set; }

            public string Limite { get; set; }

            public bool ParameterNoData
            {
                set
                {
                    Nodata(index, value);
                }

            }

          
            public double ParameterValue
            {
                get { return paravalue; }
                set
                {
                    // this.isoutlimit = false;
                    paravalue = value + offset;
                    Output1(index, paravalue);
                    newTime = DateTime.Now;
                    decimal dec = Convert.ToDecimal(paravalue);
                    dec = Decimal.Round(dec, 2);
                    double d = newTime.Subtract(lastTime).TotalSeconds;
                    if (d >= 1)
                    {
                        lastTime = DateTime.Now;
                    }
                    if (paravalue > upperlimit || paravalue < lowerlimit)
                    {
                        this.isoutlimit = true;

                        if (paravalue > upperlimit)
                        {
                            if (!isMailSend)
                            {
                                outofLimits(this, this.Location, dec, true, Convert.ToUInt32(sDeiveID), dec.ToString(), "High");
                                isMailSend = true;
                            }

                        }
                        if (paravalue < lowerlimit)
                        {
                            if (!isMailSend)
                            {
                                outofLimits(this, this.Location, dec, true, Convert.ToUInt32(sDeiveID), dec.ToString(), "Low");
                                isMailSend = true;
                            }

                        }
                        if (BarAlaram != null)
                        {
                            BarAlaram(index, paravalue, true);
                        }
                        if (ExtAlaram != null)
                        {
                            ExtAlaram();
                        }
                    }

                    else
                    {

                        this.isoutlimit = false;
                        if (paravalue >= lowerlimit && paravalue <= upperlimit)
                        {
                            this.Limite = "Normal";
                            if (islogAlaram)
                            {
                                string[] strArry = new string[] { this.SensorID, this.name + " is " + this.Limite, this.paravalue.ToString() };
                                OutOfLimit(strArry);
                                islogAlaram = false;
                            }
                            if (isMailSend)
                            {

                                outofLimits(this, this.Location, dec, true, Convert.ToUInt32(sDeiveID), dec.ToString(), "Normal");
                                isMailSend = false;

                            }
                            if (BarAlaram != null)
                            {
                                BarAlaram(index, paravalue, false);
                            }
                        }

                        this.Limite = string.Empty;
                    }
                }
            }
            public string SensorID { get; set; }
            public double LowerLimit
            {
                get { return lowerlimit; }
                set { lowerlimit = value; }
            }
            public double UpperLimit
            {
                get { return upperlimit; }
                set { upperlimit = value; }
            }
            public double LowerRange
            {
                get { return lowerrange; }
                set { lowerrange = value; }
            }
            public double UpperRange
            {
                get { return upperrange; }
                set { upperrange = value; }
            }
            public double Offset
            {
                get { return offset; }
                set { offset = value; }
            }
            public bool OutofLimit
            {
                get { return isoutlimit; }
            }
            public uint Index
            {
                get
                {
                    return index;
                }
                set
                {
                    index = value;
                }
            }
            #endregion

            #region Methods
            protected override void Dispose(bool disposing)
            {
                base.Dispose(disposing);
            }

            #endregion

            #region EventHandler

            #endregion

            #region Constructor

            public Parameters(string name, string sDeviceID, bool IsAlarmEnable)
            {
                this.name = name;
                this.sDeiveID = sDeviceID;
                this.isalarmenable = IsAlarmEnable;


            }
            #endregion


            public DateTime dtLastSend { get; set; }

            public bool isComeNormailCond { get; set; }

            public string Location { get; set; }
            public string Instrument { get; set; }
        }
    }
}