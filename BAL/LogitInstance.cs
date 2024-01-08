using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BAL
{
    public enum HardwareType
    {
        AO,
        DT,
        DA
    }
    public class LogitInstance
    {
        public PlotterDataContext DataLink { get; set; }

        public User UserInstance {get;set;}

        public int COMType { get; set; }

        public string IPAddress { get; set; }
        public SYSProperty SystemProperties { get; set; }

        public LogitInstance(string connectionstringDb)
        {

            DataLink = new PlotterDataContext();
            //string str = "Data Source=IT-PC\\SQLEXPRESS;Initial Catalog=Plotter;Persist Security Info=True;User ID=sa;Password=reloaded";
            string str = connectionstringDb;
            DataLink.Connection.ConnectionString = str;
            string s = DataLink.Connection.ConnectionString;
        }


        public IQueryable<AllDevice> AllDevice
        {
            get
            {
                DataLink.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, DataLink.AllDevices);
                return DataLink.AllDevices;
            }
        }

        public IQueryable<EventLog> Events
        {
            get
            {
                if (DataLink.Connection.State == System.Data.ConnectionState.Closed)
                {
                    DataLink.Connection.Open();
                }
                DataLink.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, DataLink.EventLogs);
                return DataLink.EventLogs;
            }
        }

        public IQueryable<Role> GetRols
        {
            get
            {
                DataLink.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, DataLink.Roles);
                return DataLink.Roles;
            }
        }

        public IQueryable<User> Users
        {
            get
            {
                if (DataLink.Connection.State == System.Data.ConnectionState.Closed)
                {
                    DataLink.Connection.Open();
                }
                DataLink.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, DataLink.Users);
                DataLink.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, DataLink.Emails);
                DataLink.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, DataLink.SMs);
                return DataLink.Users;
            }
        }

        public IQueryable<Email> Emails
        {
            get
            {

                if (DataLink.Connection.State == System.Data.ConnectionState.Open)
                {
                    DataLink.Connection.Close();
                }
                DataLink.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, DataLink.Emails);
                return DataLink.Emails;
            }
        }

        public IQueryable<SM> SMSs
        {
            get
            {
                if (DataLink.Connection.State == System.Data.ConnectionState.Open)
                {
                    DataLink.Connection.Close();
                }
                DataLink.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, DataLink.SMs);
                return DataLink.SMs;
            }
        }

        public IQueryable<Alaram_Log> Alaram_Logs
        {
            get
            {
                DataLink.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, DataLink.Alaram_Logs);
                return DataLink.Alaram_Logs;
            }
        }
        public IQueryable<Company> Companiess
        {
            get
            {
                DataLink.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, DataLink.Companies);
                return DataLink.Companies;
            }
        }
        public IQueryable<Device_Config> Device_Configes
        {
            get
            {
                DataLink.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, DataLink.Device_Configs);
                return DataLink.Device_Configs;
            }
        }
        public IQueryable<Group> Groups
        {
            get
            {
                DataLink.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, DataLink.Groups);
                return DataLink.Groups;
            }
        }
        public IQueryable<Group_Device> Groups_Devices
        {
            get
            {
                DataLink.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, DataLink.Group_Devices);
                return DataLink.Group_Devices;
            }
        }
        public IQueryable<Group_User> Groups_Users
        {
            get
            {
                DataLink.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, DataLink.Group_Users);
                return DataLink.Group_Users;
            }
        }
        public IQueryable<Log> Logs
        {
            get
            {
                DataLink.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, DataLink.Logs);
                return DataLink.Logs;
            }
        }
        public IQueryable<ofsetAuditRecord> ofsetAuditRecords
        {
            get
            {
                DataLink.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues, DataLink.ofsetAuditRecords);
                return DataLink.ofsetAuditRecords;
            }

        }


        public User UserReport { get; set; }
    }
}