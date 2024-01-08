using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAL;
using DAL;
using Microsoft.Win32;
using System.Diagnostics;
using System.Configuration;
using System.Net.Mail;
using System.Threading;

namespace Log_It.Pages
{
    public enum D_Type
    {
        Aosong =1,
        Acquisition=2
    }

    public partial class ApplicationProperties : ControlPage
    {
        public BAL.LogitInstance instance { get; set; }
        public bool systemset = false;
        string username;
        public D_Type d_Type =  D_Type.Aosong;
        private object _object;

        public ApplicationProperties(BAL.LogitInstance instance,string username )
        {
            InitializeComponent( );
            d_Type = D_Type.Aosong;
            this.instance = instance;
            this.username = username;
            this.RefreshPage();
            labelLicensekey.Text = "License key: " + BAL.Authentication.GetDec(ConfigurationManager.AppSettings["license"]);
        }

        public ApplicationProperties()
        {
            InitializeComponent();
         
        }

        public override void RefreshPage()
        {
            try
            {
                base.RefreshPage();
                if (instance.DataLink.SYSProperties.Count() > 0)
                {
                    SYSProperty Sysproperties = instance.DataLink.SYSProperties.SingleOrDefault(x => x.ID == 0);

                    comboBoxUnit.Text = Sysproperties.Unit;
                    checkBoxSignLine.Checked = (bool)Sysproperties.Signature;
                    checkBoxSignLogged.Checked = (bool)Sysproperties.Automatic_Sign;
                    textBoxCom.Text = Sysproperties.Port.ToString();
                    textBoxBaudRate.Text = Sysproperties.BaudRate.ToString();
                    textBoxDataBit.Text = Sysproperties.DataBit.ToString();
                    comboBoxParity.Text = Sysproperties.Parity.ToString();
                    comboBoxStopBit.Text = Sysproperties.StopBit.ToString();
                    checkBoxRTS.Checked = (bool)Sysproperties.RTS;
                    checkBoxDTS.Checked = (bool)Sysproperties.DTS;
                    chbEmail.Checked = (bool)Sysproperties.Email;
                    if (chbEmail.Checked)
                    {
                        textBoxEmailID.Text = Sysproperties.EmailID;
                        textBoxEmailPassword.Text = Sysproperties.EmailPassword;
                        textBoxEmailPort.Text = Sysproperties.EmailPort;
                        textBoxEmailSMTP.Text = Sysproperties.EmailSMTP;
                    }

                    chbSMS.Checked = (bool)Sysproperties.SMS;
                    radioButtonGSM.Checked = (bool)Sysproperties.GSM;
                    groupBoxSerial.Enabled = radioButtonGSM.Checked;
                    radioButtonWeb.Checked = (bool)Sysproperties.WebLink;
                    groupBoxSMS.Enabled = radioButtonWeb.Checked;
                    if (chbSMS.Checked)
                    {
                        if (Sysproperties.WebLink == true)
                        {
                            // radioButtonWeb.Checked = (bool)Sysproperties.WebLink;
                            textBoxSMSID.Text = Sysproperties.SMSID;
                            textBoxSMSPassword.Text = Sysproperties.SMSPassword;
                            textBoxSMSSecret.Text = Sysproperties.SMSSecret;
                            textBoxSMSToken.Text = Sysproperties.SMSToken;
                        }
                        if (Sysproperties.GSM == true)
                        {
                            //radioButtonGSM.Checked = (bool)Sysproperties.GSM;
                            textBoxSerial.Text = Sysproperties.Port.ToString();
                        }

                    }
                    groupBoxEmail.Enabled = chbEmail.Checked;
                    if (Sysproperties.ExtAlram == true)
                    {
                        checkBoxAlarm.Checked = (bool)Sysproperties.ExtAlram;
                        textBoxAlarmBaud.Enabled = (bool)Sysproperties.ExtAlram;
                        textBoxAlarm.Enabled =  (bool)Sysproperties.ExtAlram;
                        if (Sysproperties.Alarm_Port != null)
                        {
                            textBoxAlarmBaud.Text = Sysproperties.Alarm_Port.ToString();
                        }
                        if (Sysproperties.Alarm_IP != null)
                        {
                            textBoxAlarm.Text = Sysproperties.Alarm_IP.ToString();
                        }
                    }

                    if (Sysproperties.D_Type == 1)
                    {
                        d_Type = D_Type.Aosong;
                        radioButton1.Checked = true;
                        numericUpDown1.Value = (decimal)Sysproperties.Number_Devices;
                        // radioButton1_CheckedChanged(radioButton1, null);
                    }
                    if (Sysproperties.D_Type == 2)
                    {
                        d_Type = D_Type.Acquisition;
                        radioButton2.Checked = true;
                        numericUpDown2.Value = (decimal)Sysproperties.Number_Devices;
                    }
                    DAL.Company company = instance.DataLink.Companies.SingleOrDefault();
                    if (company != null)
                    {
                        textBoxDepartment.Text = company.Department;
                        textBoxCompany.Text = company.Company_Name;
                    }
                    systemset = true;
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(t.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                t.Text = t.Text.Remove(t.Text.Length - 1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!systemset)
                {
                    SYSProperty Systproperties = new SYSProperty();

                    Systproperties.Unit = comboBoxUnit.Text;
                    Systproperties.Signature = checkBoxSignLine.Checked;
                    Systproperties.Automatic_Sign = checkBoxSignLogged.Checked;
                    Systproperties.Port = Convert.ToInt16(textBoxCom.Text);
                    Systproperties.BaudRate = textBoxBaudRate.Text;
                    Systproperties.DataBit = textBoxDataBit.Text;
                    Systproperties.Parity = comboBoxParity.Text;
                    Systproperties.StopBit = comboBoxStopBit.Text;
                    Systproperties.RTS = checkBoxRTS.Checked;
                    Systproperties.DTS = checkBoxDTS.Checked;
                    Systproperties.ExtAlram = checkBoxAlarm.Checked;
                    Systproperties.Email = chbEmail.Checked;
                    Systproperties.SMS = chbSMS.Checked;
                    if (checkBoxAlarm.Checked)
                    {                        
                           Systproperties.Alarm_IP=textBoxAlarmBaud.Text;
                           Systproperties.Alarm_Port =textBoxAlarm.Text;
                    }
                    switch (d_Type)
                    {
                        case D_Type.Aosong:
                            Systproperties.D_Type = 1;
                            Systproperties.D_Name = d_Type.ToString();
                            Systproperties.Number_Devices = (int)numericUpDown1.Value;

                            break;
                        case D_Type.Acquisition:
                            Systproperties.D_Type = 2;
                            Systproperties.D_Name = d_Type.ToString();
                            Systproperties.Number_Devices = (int)numericUpDown2.Value;

                            break;

                    }
                    if (chbEmail.Checked)
                    {
                        Systproperties.EmailID = textBoxEmailID.Text;
                        Systproperties.EmailPassword = textBoxEmailPassword.Text;
                        Systproperties.EmailPort = textBoxEmailPort.Text;
                        Systproperties.EmailSMTP = textBoxEmailSMTP.Text;
                    }
                    else
                    {
                        Systproperties.EmailID = string.Empty;
                        Systproperties.EmailPassword = string.Empty;
                        Systproperties.Port = null;
                        Systproperties.EmailSMTP = string.Empty;
                    }
                    if (chbSMS.Checked)
                    {
                        if (radioButtonGSM.Checked)
                        {
                            Systproperties.GSM = radioButtonGSM.Checked;
                            Systproperties.Port = Convert.ToInt32(textBoxSerial.Text);
                        }
                        else
                        {
                            Systproperties.GSM = false;
                            Systproperties.Port = Convert.ToInt32(textBoxSerial.Text);
                        }
                        if (radioButtonWeb.Checked)
                        {
                            Systproperties.WebLink = radioButtonWeb.Checked;
                            Systproperties.SMSID = textBoxSMSID.Text;
                            Systproperties.SMSPassword = textBoxSMSPassword.Text;
                            Systproperties.SMSSecret = textBoxSMSSecret.Text;
                            Systproperties.SMSToken = textBoxSMSToken.Text;
                        }
                        else
                        {
                            Systproperties.SMSID = textBoxSMSID.Text;
                            Systproperties.SMSPassword = textBoxSMSPassword.Text;
                            Systproperties.SMSSecret = textBoxSMSSecret.Text;
                            Systproperties.SMSToken = textBoxSMSToken.Text;
                        }
                    }
                    instance.DataLink.SYSProperties.InsertOnSubmit(Systproperties);

                    DAL.Company company = new Company();
                    company.Id = Guid.NewGuid();
                    company.Company_Name = textBoxCompany.Text;
                    company.Department = textBoxDepartment.Text;
                    if (instance.DataLink.Connection.State == System.Data.ConnectionState.Closed)
                    {
                        instance.DataLink.Connection.Open();
                    }
                    instance.DataLink.Companies.InsertOnSubmit(company);

                    instance.DataLink.SubmitChanges();
                   
                    RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\TLSSetting");
                    if (key == null)
                    {
                        key = Registry.LocalMachine.CreateSubKey(@"SOFTWARE\TLSSetting");
                        key.SetValue("A1", 1);
                    }

                    Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, " System properties has updated", username);

                }
                else
                {
                    SYSProperty Systproperties = instance.DataLink.SYSProperties.SingleOrDefault(x => x.ID == 0);


                    Systproperties.Unit = comboBoxUnit.Text;
                    Systproperties.Signature = checkBoxSignLine.Checked;
                    Systproperties.Automatic_Sign = checkBoxSignLogged.Checked;
                    Systproperties.Port = Convert.ToInt16(textBoxCom.Text);
                    Systproperties.BaudRate = textBoxBaudRate.Text;
                    Systproperties.DataBit = textBoxDataBit.Text;
                    Systproperties.Parity = comboBoxParity.Text;
                    Systproperties.StopBit = comboBoxStopBit.Text;
                    Systproperties.RTS = checkBoxRTS.Checked;
                    Systproperties.DTS = checkBoxDTS.Checked;
                    Systproperties.ExtAlram = checkBoxAlarm.Checked;
                    Systproperties.Email = chbEmail.Checked;
                    Systproperties.SMS = chbSMS.Checked;
                    if (checkBoxAlarm.Checked)
                    {

                        Systproperties.Alarm_IP= textBoxAlarmBaud.Text;

                        Systproperties.Alarm_Port = textBoxAlarm.Text;
                    }
                    switch (d_Type)
                    {
                        case D_Type.Aosong:
                            Systproperties.D_Type = 1;
                            Systproperties.D_Name = d_Type.ToString();
                            Systproperties.Number_Devices = (int)numericUpDown1.Value;

                            break;
                        case D_Type.Acquisition:
                            Systproperties.D_Type = 2;
                            Systproperties.D_Name = d_Type.ToString();
                            Systproperties.Number_Devices = (int)numericUpDown2.Value;

                            break;

                    }
                    if (chbEmail.Checked)
                    {
                        Systproperties.EmailID = textBoxEmailID.Text;
                        Systproperties.EmailPassword = textBoxEmailPassword.Text;
                        Systproperties.EmailPort = textBoxEmailPort.Text;
                        Systproperties.EmailSMTP = textBoxEmailSMTP.Text;
                    }
                    else
                    {
                        Systproperties.EmailID = string.Empty;
                        Systproperties.EmailPassword = string.Empty;
                        Systproperties.Port = null;
                        Systproperties.EmailSMTP = string.Empty;
                    }
                    if (chbSMS.Checked)
                    {
                        if (radioButtonGSM.Checked)
                        {
                            Systproperties.GSM = radioButtonGSM.Checked;
                            Systproperties.Port = Convert.ToInt32(textBoxSerial.Text);
                        }
                        else
                        {
                            Systproperties.GSM = false;
                            Systproperties.Port = Convert.ToInt32(textBoxSerial.Text);
                        }
                        if (radioButtonWeb.Checked)
                        {
                            Systproperties.WebLink = radioButtonWeb.Checked;
                            Systproperties.SMSID = textBoxSMSID.Text;
                            Systproperties.SMSPassword = textBoxSMSPassword.Text;
                            Systproperties.SMSSecret = textBoxSMSSecret.Text;
                            Systproperties.SMSToken = textBoxSMSToken.Text;
                        }
                        else
                        {
                            Systproperties.SMSID = textBoxSMSID.Text;
                            Systproperties.SMSPassword = textBoxSMSPassword.Text;
                            Systproperties.SMSSecret = textBoxSMSSecret.Text;
                            Systproperties.SMSToken = textBoxSMSToken.Text;
                        }
                    }
                    DAL.Company company = instance.DataLink.Companies.SingleOrDefault();
                    if (company != null)
                    {
                        company.Department = textBoxDepartment.Text;
                        company.Company_Name =textBoxCompany.Text ;

                        
                    }
                    if (instance.DataLink.Connection.State == System.Data.ConnectionState.Closed)
                    {
                        instance.DataLink.Connection.Open();
                    }
                    instance.DataLink.SubmitChanges();
                    
                    Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "System properties has updated", username);
                    MessageBox.Show("Setting has been update.");
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Tag == "Aosong")
            {
                d_Type = D_Type.Aosong;
                groupBox2.Enabled = false;
                groupBox1.Enabled = true;

            }
            if (rb.Tag == "Data Acquisition")
            {
                d_Type = D_Type.Acquisition;
                groupBox2.Enabled = true;
                groupBox1.Enabled = false;

            }
            
        }

        private void checkBoxAlarm_CheckedChanged(object sender, EventArgs e)
        {
            textBoxAlarm.Enabled = checkBoxAlarm.Checked;
            textBoxAlarmBaud.Enabled = checkBoxAlarm.Checked;
        }

        private void panelHome_Paint(object sender, PaintEventArgs e)
        {

        }

        async void buttontest_Click(object sender, EventArgs e)
        {
            if (chbEmail.Checked && textBoxEmailID.Text == string.Empty)
            {
                MessageBox.Show("Please provide User Name.");
                return;
            }
            if (chbEmail.Checked && textBoxEmailPassword.Text == string.Empty)
            {
                MessageBox.Show("Please provide Email Password.");
                return;
            }
            if (chbEmail.Checked && textBoxEmailSMTP.Text == string.Empty)
            {
                MessageBox.Show("Please provide SMTP.");
                return;
            }
            if (chbEmail.Checked && textBoxEmailPort.Text == string.Empty)
            {
                MessageBox.Show("Please provide SMTP Port.");
                return;
            }
            if (chbEmail.Checked && textBoxtestaddress.Text == string.Empty)
            {
                MessageBox.Show("Please provide Test Email Address.");
                textBoxtestaddress.Focus();
                return;
            }
            bool b = await SendMail();
        }
        async Task<bool> SendMail()
        {
            try
            {
                await Task.Run(() =>
                {


                    string smtpAddress = textBoxEmailSMTP.Text;// instance.SystemProperties.EmailSMTP; //ConfigurationManager.AppSettings["SMTP"].ToString();
                    int portNumber = Convert.ToInt32(textBoxEmailPort.Text);// ConfigurationManager.AppSettings["Port"].ToString());
                    //bool enableSSL = false;
                    string emailFromAddress = textBoxEmailID.Text;// instance.SystemProperties.EmailID;// ConfigurationManager.AppSettings["UserID"].ToString(); //Sender Email Address  
                    string password = textBoxEmailPassword.Text;// instance.SystemProperties.EmailPassword;// ConfigurationManager.AppSettings["Password"].ToString(); //Sender Password  
                    string subject = "Test Mail";
                    string body = @"<html><body> <h3> This is the Test Mail from Logit WiFi </h3><br/>Thanks & Regards, <br/>Logit System ";

                    instance.SystemProperties.EmailSMTP = smtpAddress;
                    instance.SystemProperties.EmailPort = portNumber.ToString();
                    instance.SystemProperties.EmailID = emailFromAddress;
                    instance.SystemProperties.EmailPassword = password;


                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress(emailFromAddress);
                        mail.To.Add(textBoxtestaddress.Text);



                        mail.Subject = subject;
                        mail.Body = body;
                        mail.IsBodyHtml = true;
                        try
                        {
                            mail.Subject = subject;
                            mail.Body = body;
                            mail.IsBodyHtml = true;
                            if (ConfigurationManager.AppSettings["SMTPEnable"].ToString() == "1")
                            {


                                if (Log_It.Classes.GmailAPI.Send_Mail(mail, null, smtpAddress, portNumber, emailFromAddress, password))
                                {
                                    MessageBox.Show("Email Successfully Sent.");
                                    Technoman.Utilities.EventClass.WriteLogException("Email has been Sent");
                                }
                                else
                                {
                                    MessageBox.Show("Email Send Fail");
                                    Technoman.Utilities.EventClass.WriteLogException("Email send fail, Internet issue");
                                }
                            }
                            if (ConfigurationManager.AppSettings["SMTPEnable"].ToString() == "0")
                            {
                                if (Log_It.Classes.GmailAPI.Send_Mail(mail, null))
                                {
                                    MessageBox.Show("Email Successfully Sent.");
                                    Technoman.Utilities.EventClass.WriteLogException("Email has been Sent");
                                }
                                else
                                {
                                    MessageBox.Show("Email Send Fail");
                                    Technoman.Utilities.EventClass.WriteLogException("Email send fail, Internet issue");
                                }
                            }
                        }
                        catch (Exception)
                        {
                            Technoman.Utilities.EventClass.WriteLogException("Email Sent Fail with Attachments");
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
            catch (Exception)
            {
                return false;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (chbSMS.Checked)
            {
                if (radioButtonGSM.Checked)
                {
                    System.IO.Ports.SerialPort sp = null;
                    bool isok = false;
                    Monitor.Enter(_object);
                    try
                    {

                        sp = new System.IO.Ports.SerialPort("COM" + textBoxSerial.Text, 19200, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);
                        sp.ReadTimeout = 3000;
                        string resutl = string.Empty;
                        try
                        {
                            if (!sp.IsOpen)
                            {
                                sp.Open();
                            }

                        }
                        catch (Exception m)
                        {

                            //toolStripStatusLabel4.Text = m.Message;
                            //return false;
                        }

                        //toolStripStatusLabel4.Text = "Serial Port connected.";
                        isok = false;
                        int count = 0;
                        do
                        {
                            count++;
                            sp.DiscardInBuffer();
                            sp.DiscardNull = true;
                            sp.WriteLine("" + (char)26 + '\r');
                            Task.Delay(4000);// Thread.Sleep(new TimeSpan(0, 0, 4));
                            resutl = sp.ReadExisting();

                            if (!resutl.Contains("ERROR"))
                            {

                            }
                            sp.DiscardInBuffer();
                            sp.DiscardNull = true;

                            sp.WriteLine("AT" + '\r');
                            Task.Delay(1000); //Thread.Sleep(new TimeSpan(0, 0, 1));
                            resutl = sp.ReadExisting();
                            if (count > 3)
                            {
                                isok = false;
                                //return isok;
                            }
                        } while (!resutl.Contains("OK"));
                        //toolStripStatusLabel4.Text = resutl;
                        count = 0;
                        //do
                        //{
                        //    count++;
                        //    sp.DiscardInBuffer();
                        //    sp.DiscardNull = true;
                        //    sp.WriteLine("AT+PSBEARER=0" + '\r');
                        //    Thread.Sleep(new TimeSpan(0, 0, 1));
                        //    resutl = sp.ReadExisting();
                        //    if (count > 3)
                        //    {
                        //        isok = false;
                        //        return isok;
                        //    }
                        //} while (!resutl.Contains("OK"));
                        //toolStripStatusLabel4.Text = resutl;
                        count = 0;
                        do
                        {
                            count++;
                            sp.DiscardInBuffer();
                            sp.DiscardNull = true;
                            sp.WriteLine("AT+CMGF=1" + '\r');
                            Task.Delay(1000); Thread.Sleep(new TimeSpan(0, 0, 1));
                            resutl = sp.ReadExisting();
                            if (count > 3)
                            {
                                isok = false;
                                //return isok;
                            }
                        } while (!resutl.Contains("OK"));

                        count = 0;
                        //toolStripStatusLabel4.Text = resutl;

                        //if (No.Count == 0)
                        //{
                        //    MessageBox.Show("No number found");
                        //}


                        //toolStripStatusLabel4.Text = item.ToString();
                        //if (item != "" || item != string.Empty || !item.Contains("+"))
                        //{
                        do
                        {
                            count++;
                            sp.DiscardInBuffer();
                            sp.DiscardNull = true;
                            string number = (char)34 + textBoxSMSTest.Text + (char)34;
                            sp.WriteLine("AT+CMGS=" + number + '\r');
                            //toolStripStatusLabel4.Text = "AT+CMGS=1";
                            Thread.Sleep(new TimeSpan(0, 0, 1));
                            resutl = sp.ReadExisting();
                            if (resutl.Contains(">"))
                            {
                                sp.DiscardOutBuffer();
                                sp.DiscardInBuffer();
                                sp.WriteLine("This is Test SMS from Logit Datalogger" + (char)26 + '\r');
                                System.Diagnostics.Debug.Print("This is Test SMS from Logit Datalogger");
                                Thread.Sleep(new TimeSpan(0, 0, 10));
                                //Task.Delay(10000);
                                //resutl = sp.ReadExisting();
                                do
                                {
                                    resutl = sp.ReadLine();
                                    System.Diagnostics.Debug.Print(resutl);
                                    if (resutl.Contains("ERROR:"))
                                    {
                                        isok = false;
                                        break;
                                    }
                                } while (!resutl.Contains("OK"));
                            }
                            if (count > 3)
                            {
                                isok = false;
                                break;
                            }
                            if (resutl.Contains("OK"))
                            {
                                isok = true;
                                break;
                            }
                        } while (!resutl.Contains("OK"));
                        //}

                        //toolStripStatusLabel4.Text = resutl;
                        sp.Close();
                        //return isok;
                    }
                    catch (Exception m)
                    {
                        if (sp.IsOpen)
                        {
                            sp.Close();
                        }
                        //toolStripStatusLabel4.Text = m.Message;
                        //return false;
                    }


                    finally
                    {
                        Monitor.Exit(_object);

                    }
                }
                if (radioButtonWeb.Checked)
                {
                    if (textBoxSMSID.Text == string.Empty)
                    {

                        MessageBox.Show("Please provide SMS User ID.");
                        return;
                    }
                    if (textBoxSMSPassword.Text == string.Empty)
                    {

                        MessageBox.Show("Please provide SMS Password.");
                        return;
                    }
                    if (textBoxSMSSecret.Text == string.Empty)
                    {

                        MessageBox.Show("Please provide SMS API Secret code.");
                        return;
                    }
                    if (textBoxSMSToken.Text == string.Empty)
                    {

                        MessageBox.Show("Please provide SMS API Token.");
                        return;
                    }
                    if (textBoxSMSTest.Text == string.Empty)
                    {
                        MessageBox.Show("Please provide SMS number.");
                        return;
                    }
                    CustomControls.SMSComponent sms = new CustomControls.SMSComponent(textBoxSMSToken.Text, textBoxSMSSecret.Text);
                    string smsresutl = sms.send(textBoxSMSTest.Text, "This is Test SMS from Logit Datalogger");
                    MessageBox.Show(smsresutl);
                    //CustomControls.SMSComponent sms = new CustomControls.SMSComponent(textBoxSMSToken.Text, );
                    //sms.send(textBoxSMSTest.Text,)

                }

            }
        }

        private void chbEmail_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxEmail.Enabled = chbEmail.Checked;
        }

        private void chbSMS_CheckedChanged(object sender, EventArgs e)
        {
            groupBox3.Enabled = chbSMS.Checked;
            groupBoxSMS.Enabled = chbSMS.Checked;
            textBoxSMSTest.Enabled = chbSMS.Checked;
            button2.Enabled = chbSMS.Checked;
            if (!chbSMS.Checked)
            {
                groupBoxSMS.Enabled = false;
                groupBoxSerial.Enabled = false;

            }
            if (chbSMS.Checked)
            {
                if (radioButtonWeb.Checked)
                {
                    groupBoxSMS.Enabled = radioButtonWeb.Checked;
                    groupBoxSerial.Enabled = !radioButtonWeb.Checked;
                }
                if (radioButtonGSM.Checked)
                {
                    groupBoxSMS.Enabled = !radioButtonGSM.Checked;
                    groupBoxSerial.Enabled = radioButtonGSM.Checked;
                }
            }
        }

        private void radioButtonGSM_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonGSM.Checked)
            {
                groupBoxSMS.Enabled = !radioButtonGSM.Checked;
                groupBoxSerial.Enabled = radioButtonGSM.Checked;
            }
        }

        private void radioButtonWeb_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonWeb.Checked)
            {
                groupBoxSMS.Enabled = radioButtonWeb.Checked;
                groupBoxSerial.Enabled = !radioButtonWeb.Checked;
            }
        }
    }
}
