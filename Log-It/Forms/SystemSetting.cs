using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log_It.Forms
{
    public partial class SystemSetting : Form
    {
        bool DBverified;
        string servername;
        string userlogin;
        string password;
        public string ConnectionStringDb;
        string dbBackuplocation;
        public SystemSetting()
        {
            InitializeComponent();

            SqlDataSourceEnumerator obj = SqlDataSourceEnumerator.Instance;
            DataTable table = obj.GetDataSources();
            if (table != null)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    this.cmbServers.Items.Add(table.Rows[i][0].ToString() + @"\" + table.Rows[i][1].ToString());
                }
            }
        }

        private void applicationProperties1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection Conn = new SqlConnection("Data Source=" + cmbServers.Text + ";Initial Catalog=master;Persist Security Info=True;User ID=" + textBoxlogin.Text + ";Password=" + textBoxpassword.Text);
                SqlCommand testCMD = new SqlCommand("sp_spaceused", Conn);
                SqlCommand cmd = new SqlCommand("select @@version AS 'Server Name' ", Conn);
                testCMD.CommandType = CommandType.StoredProcedure;
                cmd.CommandType = CommandType.Text;
                Conn.Open();
                SqlDataReader reader = testCMD.ExecuteReader();
                if (reader.HasRows)
                {
                    MessageBox.Show("Test Connection Sucessfull");
                    DBverified = true;
                    servername = cmbServers.Text;
                    userlogin = textBoxlogin.Text;
                    password = textBoxpassword.Text;
                }
                Conn.Close();

                string key = System.Configuration.ConfigurationManager.AppSettings["license"];
                string license = textBox1.Text;
                bool ismacok = false;
                foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
                {
                    PhysicalAddress ad = nic.GetPhysicalAddress();
                    if (ad.ToString() == license)
                    {
                        ismacok = true;
                        MessageBox.Show("Verification of the license has been completed.");
                        break;
                    }

                }
                if (key != LogitService.Authentication.GetEc(license) || !ismacok)
                {
                    MessageBox.Show("Please enter the Physical Address");
                    return;
                }
                panel1.Enabled = true;
                panel13.Enabled = true;
                panel15.Enabled = true;
                panel10.Enabled = true;
                panel5.Enabled = true;
                panel7.Enabled = true;
                panel3.Enabled = true;
                button2.Enabled = true;
            }
            catch (Exception)
            {

                MessageBox.Show("Test Connection Fail");
                DBverified = false;
            }
        }

        private void SystemSetting_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if (!DBverified)
            {
                MessageBox.Show("Please verifiy the Database connection");
                return;
            }
            if (textBoxCompany.Text == string.Empty)
            {
                MessageBox.Show("Please Enter the company name");
                textBoxCompany.Focus();
                return;

            }
            if (textBoxDepartment.Text == string.Empty)
            {
                MessageBox.Show("Please Enter the department name");
                textBoxDepartment.Focus();
                return;
            }
            if (textBoxCom.Text == string.Empty)
            {
                MessageBox.Show("Please enter the port number");
                textBoxCom.Focus();
                return;
            }
            if (textBoxBaudRate.Text == string.Empty)
            {
                MessageBox.Show("Please enter the Baud Rate");
                textBoxBaudRate.Focus();
                return;
            }

            try
            {
                SqlConnection Conn = new SqlConnection("Data Source=" + servername + ";Initial Catalog=master;Persist Security Info=True;User ID=" + userlogin + ";Password=" + password);
                SqlCommand testCMD = new SqlCommand("create database PlotterRS485", Conn);


                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                int i = testCMD.ExecuteNonQuery();

                Conn.Close();
                Conn = new SqlConnection("Data Source=" + servername + ";Initial Catalog=PlotterRS485;Persist Security Info=True;User ID=" + userlogin + ";Password=" + password);
                ConnectionStringDb = BAL.Authentication.GetEc( Conn.ConnectionString);

                testCMD = new SqlCommand("CREATE TABLE  [dbo].[Alaram_Log](	[ID] [uniqueidentifier] NOT NULL,	[Device_ID] [int] NOT NULL,	[Device_Type] [nvarchar](50) NULL,	[Description] [nvarchar](50) NULL,	[Time] [datetime] NULL,	[_data] [decimal](18, 0) NULL, CONSTRAINT [PK_Alaram_Log] PRIMARY KEY CLUSTERED (	[ID] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();

                testCMD = new SqlCommand("CREATE TABLE [dbo].[Company](	[Id] [uniqueidentifier] NOT NULL,	[Company_Name] [nvarchar](50) NOT NULL,	[Department] [nvarchar](50) NULL, CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED (	[Id] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();

                testCMD = new SqlCommand("CREATE TABLE [dbo].[Device_Config](	[ID] [uniqueidentifier] NOT NULL,	[Channel_id] [nvarchar](50) NULL,	[Device_Id] [int] NULL,[Device_Type] [int] NULL,	[Location] [nvarchar](50) NULL,	[Instrument] [nvarchar](50) NULL,	[Interval] [int] NULL,	[Active] [bit] NULL,	[Alaram] [bit] NULL,	[Last_Record] [datetime] NULL,	[CreatedBy] [nvarchar](50) NULL,	[CreateDateTime] [datetime] NULL,	[ModifiedBy] [nvarchar](50) NULL,	[ModifiedDateTime] [datetime] NULL,	[IsRowActive] [bit] NULL,	[Rh_Active] [bit] NULL, CONSTRAINT [PK_Device_Config] PRIMARY KEY CLUSTERED (	[ID] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();

                testCMD = new SqlCommand("CREATE TABLE [dbo].[Device_Enum](	[ID] [int] NOT NULL,	[Type] [nchar](10) NULL, CONSTRAINT [PK_Device_Enum] PRIMARY KEY CLUSTERED (	[ID] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();

                testCMD = new SqlCommand("CREATE TABLE [dbo].[Email](	[ID] [uniqueidentifier] NOT NULL,	[EmailID] [nvarchar](100) NULL, CONSTRAINT [PK_Email] PRIMARY KEY CLUSTERED (	[ID] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();

                testCMD = new SqlCommand("CREATE TABLE [dbo].[SMS](	[ID] [uniqueidentifier] NOT NULL,	[SMS] [nvarchar](50) NULL, CONSTRAINT [PK_SMS] PRIMARY KEY CLUSTERED (	[ID] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();
                testCMD = new SqlCommand("CREATE TABLE [dbo].[EventLog](	[ID] [uniqueidentifier] NOT NULL,	[DateTime] [datetime] NULL,	[UserName] [nvarchar](50) NULL,	[EventName] [nvarchar](50) NULL,	[MessageLog] [nvarchar](max) NULL, CONSTRAINT [PK_EventLog] PRIMARY KEY CLUSTERED (	[ID] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();


                testCMD = new SqlCommand("CREATE TABLE [dbo].[LimitTable](	[Id] [uniqueidentifier] NOT NULL,	[Upper_Limit] [int] NULL,	[Lower_Limit] [int] NULL,	[Upper_Range] [int] NULL,	[Lower_Range] [int] NULL,	[Device_type] [int] NULL,	[Device_id] [uniqueidentifier] NULL,	[ofset] [float] NULL,	[dateofcalibrate] [datetime] NULL, CONSTRAINT [PK_LimitTable] PRIMARY KEY CLUSTERED (	[Id] ASC) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();

                //

                testCMD = new SqlCommand("ALTER TABLE [dbo].[LimitTable]  WITH CHECK ADD  CONSTRAINT [FK_LimitTable_Device_Config] FOREIGN KEY([Device_id]) REFERENCES [dbo].[Device_Config] ([ID]) ", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();

                testCMD = new SqlCommand("ALTER TABLE [dbo].[LimitTable] CHECK CONSTRAINT [FK_LimitTable_Device_Config] ", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();

                testCMD = new SqlCommand("ALTER TABLE [dbo].[LimitTable]  WITH CHECK ADD  CONSTRAINT [FK_LimitTable_Device_Enum] FOREIGN KEY([Device_type]) REFERENCES [dbo].[Device_Enum] ([ID]) ", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();

                testCMD = new SqlCommand("ALTER TABLE [dbo].[LimitTable] CHECK CONSTRAINT [FK_LimitTable_Device_Enum]", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();

                testCMD = new SqlCommand("CREATE TABLE [dbo].[Log](	[ID] [uniqueidentifier] NOT NULL,	[Device_Id] [uniqueidentifier] NOT NULL,	[Channel_ID] [nvarchar](50) NULL,	[Temp_Data] [float] NULL,	[date_] [datetime] NULL,	[Rh_Data] [float] NULL,	[Pressure] [float] NULL, CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED (	[ID] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();

                testCMD = new SqlCommand("CREATE TABLE [dbo].[ofsetAuditRecord](	[Id] [int] IDENTITY(1,1) NOT NULL,	[Device_Id] [int] NULL,	[ofset] [float] NOT NULL,	[createdby] [nvarchar](50) NULL,	[createddatetime] [datetime] NULL, CONSTRAINT [PK_ofsetAuditRecord_1] PRIMARY KEY CLUSTERED (	[Id] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();


                testCMD = new SqlCommand("CREATE TABLE [dbo].[Roles](	[Id] [int] NOT NULL,	[RoleName] [nvarchar](50) NULL, CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED (	[Id] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();

                testCMD = new SqlCommand("CREATE TABLE [dbo].[SYSProperties](	[ID] [int] NOT NULL,	[Unit] [nvarchar](50) NULL,	[Signature] [bit] NULL,	[Automatic_Sign] [bit] NULL,	[Port] [int] NULL,	[BaudRate] [nvarchar](50) NULL,	[DataBit] [nvarchar](50) NULL,	[Parity] [nvarchar](50) NULL,	[StopBit] [nvarchar](50) NULL,	[RTS] [bit] NULL,	[DTS] [bit] NULL,	[D_Type] [int] NULL,	[D_Name] [nvarchar](50) NULL,	[Number_Devices] [int] NULL,	[Email] [bit] NULL,	[SMS] [bit] NULL,	[ExtAlram] [bit] NULL,	[Alarmport] [int] NULL,	[Alarmbaud] [nvarchar](50) NULL,	[backuplocation] [nvarchar](max) NULL,	[lastbakdate] [datetime] NULL, CONSTRAINT [PK_SYSProperties] PRIMARY KEY CLUSTERED (	[ID] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();

                testCMD = new SqlCommand("CREATE TABLE [dbo].[User](	[Id] [int] IDENTITY(1,1) NOT NULL,	[User_Name] [nvarchar](50) NOT NULL,	[Password] [nvarchar](2000) NULL,	[Role] [int] NULL,	[CreatedBy] [nvarchar](50) NULL,	[CreateDateTime] [datetime] NULL,	[Active] [bit] NULL,	[ModefiedBy] [nvarchar](50) NULL,	[ModifiedDateTime] [datetime] NULL,	[IsRowEnable] [bit] NULL,	[Full_Name] [nvarchar](max) NULL,	[Authority] [nvarchar](50) NULL,	[Description] [nvarchar](max) NULL,	[Email] [nvarchar](50) NULL,	[SMS] [nvarchar](50) NULL,	[Email_Notification] [bit] NULL,	[SMS_Notification] [bit] NULL, CONSTRAINT [PK_User_1] PRIMARY KEY CLUSTERED (	[Id] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();

                //

                testCMD = new SqlCommand("ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Roles] FOREIGN KEY([Role]) REFERENCES [dbo].[Roles] ([Id]) ", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();

                testCMD = new SqlCommand("ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Roles] CREATE TABLE [dbo].[Group]( [ID] [int] IDENTITY(1,1) NOT NULL,	[Group_Name] [nvarchar](50) NULL, CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED (	[ID] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();




                testCMD = new SqlCommand("CREATE TABLE [dbo].[Group_Devices](	[Id] [int] IDENTITY(1,1) NOT NULL,	[Group_Id] [int] NOT NULL,	[Device_Id] [int] NOT NULL, CONSTRAINT [PK_Group_Devices] PRIMARY KEY CLUSTERED (	[Id] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY]", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();

                testCMD = new SqlCommand("CREATE TABLE [dbo].[Group_User](	[Id] [int] IDENTITY(1,1) NOT NULL,	[User_Id] [int] NOT NULL,	[Group_ID] [int] NOT NULL, CONSTRAINT [PK_Group_User] PRIMARY KEY CLUSTERED (	[Id] ASC)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]) ON [PRIMARY] ", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();

                //GO 

                testCMD = new SqlCommand("ALTER TABLE [dbo].[Group_User]  WITH CHECK ADD  CONSTRAINT [FK_Group_User_Group] FOREIGN KEY([Group_ID]) REFERENCES [dbo].[Group] ([ID])", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();

                testCMD = new SqlCommand("ALTER TABLE [dbo].[Group_User] CHECK CONSTRAINT [FK_Group_User_Group]", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();

                testCMD = new SqlCommand("ALTER TABLE [dbo].[Group_User]  WITH CHECK ADD  CONSTRAINT [FK_Group_User_User] FOREIGN KEY([User_Id])REFERENCES [dbo].[User] ([Id])", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();

                testCMD = new SqlCommand("ALTER TABLE [dbo].[Group_User] CHECK CONSTRAINT [FK_Group_User_User] ", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();


                testCMD = new SqlCommand("CREATE VIEW [dbo].[AllDevices] AS SELECT     TOP (100) PERCENT dbo.Device_Config.Device_Id, dbo.Device_Enum.Type, dbo.Device_Config.Channel_id, dbo.Device_Config.Location, dbo.Device_Config.Instrument, dbo.Device_Config.Interval, dbo.Device_Config.Active, dbo.Device_Config.Alaram, dbo.Device_Config.Rh_Active, dbo.LimitTable.Upper_Limit, dbo.LimitTable.Lower_Limit, dbo.LimitTable.Upper_Range, dbo.LimitTable.Lower_Range FROM         dbo.Device_Config INNER JOIN dbo.LimitTable ON dbo.Device_Config.ID = dbo.LimitTable.Device_id INNER JOIN dbo.Device_Enum ON dbo.LimitTable.Device_type = dbo.Device_Enum.ID WHERE     (dbo.Device_Config.Active = 1) ORDER BY dbo.Device_Config.Device_Id, dbo.Device_Enum.Type", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();

                testCMD = new SqlCommand("CREATE VIEW [dbo].[TotalDevices] AS SELECT     TOP (100) PERCENT dbo.Device_Config.ID, dbo.Device_Config.Channel_id, dbo.Device_Config.Device_Id, dbo.Device_Config.Location, dbo.Device_Config.Instrument, dbo.Device_Config.Interval, dbo.Device_Config.Active, dbo.Device_Config.Alaram, dbo.Device_Config.Last_Record, dbo.Device_Config.CreatedBy,                       dbo.Device_Config.CreateDateTime, dbo.Device_Config.ModifiedBy, dbo.Device_Config.ModifiedDateTime, dbo.Device_Config.IsRowActive,                       dbo.Device_Config.Rh_Active, dbo.LimitTable.Upper_Limit, dbo.LimitTable.Lower_Limit, dbo.LimitTable.Upper_Range, dbo.LimitTable.Lower_Range,                       dbo.LimitTable.Device_type FROM         dbo.Device_Config INNER JOIN                       dbo.LimitTable ON dbo.Device_Config.ID = dbo.LimitTable.Device_id WHERE     (dbo.Device_Config.Active = 1) AND (dbo.Device_Config.IsRowActive = 1) ORDER BY dbo.Device_Config.Device_Id ", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();

                testCMD = new SqlCommand("INSERT INto Device_Enum(ID,Type) Values(1,'Temp')", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();

                testCMD = new SqlCommand("INSERT INto Device_Enum(ID,Type) Values(2,'Rh')", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();

                testCMD = new SqlCommand("INSERT INto Device_Enum(ID,Type) Values(3,'Pressure')", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();

                testCMD = new SqlCommand("INSERT INTO Roles(Id,RoleName) Values(0,'Owner')", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();

                testCMD = new SqlCommand("INSERT INTO Roles(Id,RoleName) Values(1,'Administrator')", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();
                testCMD = new SqlCommand("INSERT INTO Roles(Id,RoleName) Values(2,'User')", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();

                Conn.Close();
                int s1 = 0;
                int s2 = 0;
                int s3 = 0;
                int s4 = 0;
                int s5 = 0;
                int s6 = 0;
                if (checkBoxSignLine.Checked)
                {
                    s1 = 1;
                }
                else
                {
                    s1 = 0;
                }
                if (checkBoxSignLogged.Checked)
                {
                    s2 = 1;
                }
                else
                {
                    s2 = 0;
                }
                if (checkBoxRTS.Checked)
                {
                    s3 = 1;
                }
                else
                {
                    s3 = 0;
                }
                if (checkBoxDTS.Checked)
                {
                    s4 = 1;
                }
                else
                {
                    s4 = 0;
                }
                if (chbEmail.Checked)
                {
                    s5 = 1;
                }
                else
                {
                    s5 = 0;
                }
                //chbSMS
                if (chbSMS.Checked)
                {
                    s6 = 1;
                }
                else
                {
                    s6 = 0;
                }
                testCMD = new SqlCommand("INSERT INTO SYSProperties([ID],[Unit],[Signature],[Automatic_Sign],[Port],[BaudRate],[DataBit],[Parity],[StopBit],[RTS],[DTS],[D_Type],[D_Name],[Number_Devices],[Email],[SMS], [ExtAlram],[Alarmport],[Alarmbaud],[backuplocation])VALUES ("
                    + 0 + ",'" + comboBoxUnit.Text + "'," + s1 + "," + s2 + "," + Convert.ToInt32(textBoxCom.Text) + ",'" + textBoxBaudRate.Text + "','" + textBoxDataBit.Text + "','" + comboBoxParity.Text + "','" + comboBoxStopBit.Text + "'," + s3 + "," + s4 + "," + 1 + ",'Aosong'," + Convert.ToInt32(numericUpDown1.Value) + "," + s5 + "," + s6 + "," + 0 + "," + "'1'" + ",'" + "9600" + "','" + label26.Text + "')", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();

                testCMD = new SqlCommand("INSERT INTO Company ([ID],[Company_Name],[Department]) VALUES ('" + Guid.NewGuid() + "','" + textBoxCompany.Text + "','" + textBoxDepartment.Text + "')", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();

                Conn.Close();

                testCMD = new SqlCommand("INSERT INTO [User] ([User_Name],[Password],[Role],[CreatedBy],[CreateDateTime],[Active],[ModefiedBy],[ModifiedDateTime],[IsRowEnable],[Full_Name],[Authority],[Description],[Email],[SMS]) VALUES ('" +
                    textBoxuserName.Text + "','" + BAL.Authentication.GetEc(textBoxloginpassword.Text) + "','" + 0 + "','System Admin',GETDATE(),1,'NULL',NULL," + 1 + ",'System Administrator','Owner','NULL','NULL','NULL')", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();
                Conn.Close();

               //// Conn = new SqlConnection(Conn);
               // testCMD = new SqlCommand("CREATE PROC [dbo].[InsertEventLog]	(@username as nvarchar(50),	@log as nvarchar(max),	@message as nvarchar(max)) AS BEGIN 	SET NOCOUNT ON; INSERT INTO [PlotterIP].[dbo].[EventLog]           ([ID]           ,[DateTime]           ,[UserName]           ,[EventName]           ,[MessageLog])     VALUES           (NEWID()           ,GETDATE()           ,@username           ,@log           ,@message) END", Conn);
               // testCMD.CommandType = CommandType.Text;
               // Conn.Open();
               // i = testCMD.ExecuteNonQuery();
               // Conn.Close();

                testCMD = new SqlCommand("CREATE PROC [dbo].[InsertEventLog]	(@username as nvarchar(50),	@log as nvarchar(max),	@message as nvarchar(max)) AS BEGIN 	SET NOCOUNT ON; INSERT INTO [PlotterRS485].[dbo].[EventLog]           ([ID]           ,[DateTime]           ,[UserName]           ,[EventName]           ,[MessageLog])     VALUES           (NEWID()           ,GETDATE()           ,@username           ,@log           ,@message) END", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();
                Conn.Close();

                testCMD = new SqlCommand("CREATE PROCEDURE [dbo].[Create_dbBackup]               @dbName  as VARCHAR(50) =NULL,        @location as nvarchar(MAX)       AS            BEGIN       begin try        backup database @dbName to disk = @location  with init      UPDATE [PlotterRS485].[dbo].[SYSProperties]   SET       [lastbakdate] = GETDATE()      WHERE [ID] =  1     end try     begin catch               Select ERROR_MESSAGE() AS ErrorMessage;           end catch      END ", Conn);
                testCMD.CommandType = CommandType.Text;
                Conn.Open();
                i = testCMD.ExecuteNonQuery();
                Conn.Close();

                //RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\TMSSetting");
                //if (key == null)
                //{
                //    key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\TMSSetting");
                //    key.SetValue("A1", 1);
                //}

                MessageBox.Show("Configuration has been saved");
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();

            }
            catch (Exception m)
            {

                labelstatus.Text = m.Message;
                MessageBox.Show(m.Message);
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
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
                    dbBackuplocation = files + @"\";
                    label26.Text = dbBackuplocation;
                }
            }
            catch (Exception m)
            {
                MessageBox.Show(m.Message);
            }
        }
    }
}
