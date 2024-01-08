using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log_It.Forms
{
    public partial class UserForm : Form
    {
        bool isNew;
        int userid;
        DAL.User user;
        BAL.LogitInstance instace;
        DAL.User tempuser = null;
        public UserForm(int id, BAL.LogitInstance instace, bool isNew)
        {
            this.isNew = isNew;
            this.instace = instace;
            InitializeComponent();
            try
            {
                comboBoxRole.SelectedIndex = 0;
                if (id > 0)
                {
                    this.userid = id;
                    user = instace.Users.SingleOrDefault(x => x.Id == id);
                    
                }
                if (user != null)
                {
                   
                    this.Clone(user, out tempuser);
                    textBoxUserName.Text = user.User_Name;
                    textBoxUserName.Enabled = false;
                    textBoxFullName.Text = user.Full_Name;
                    textBoxDescription.Text = user.Description;
                    textBoxPassword.Text = BAL.Authentication.GetDec(user.Password);
                    if (user.Email_Notification != null)
                    {
                        checkBoxEmail.Checked = (bool)user.Email_Notification;
                    }
                    if (user.SMS_Notification!= null)
                    {
                        checkBoxSMS.Checked = (bool)user.SMS_Notification;
                    }
                    comboBoxRole.Text = user.Authority;
                    if (user.Email != null)
                    {
                        textBoxEmail.Text = user.Email;
                    }
                    if (user.SMS != null)
                    {
                         textBoxSMS.Text = user.SMS;
                    }
                 
                   comboBoxRole.SelectedIndex = (int)user.Role - 1;
                    checkBoxActive.Checked = (bool)user.Active;
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

           private bool CheckPassword(string password,string pattern)
        {
            string MatchEmailPattern = pattern;

            if (password != null) return Regex.IsMatch(password, MatchEmailPattern);
            else return false;
        }

           //"(?=^[^\\s]{6,}$)(?=.*\\d)(?=.*[a-zA-Z])"
           //^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}$


        private void Clone(DAL.User user, out DAL.User tempuser)
        {
            tempuser = new DAL.User();
            tempuser.Active = user.Active;
            tempuser.Authority = user.Authority;
            tempuser.CreateDateTime = user.CreateDateTime;
            tempuser.CreatedBy = user.CreatedBy;
            tempuser.Description = user.Description;
            tempuser.Full_Name = user.Full_Name;
            tempuser.Id = user.Id;
            tempuser.ModefiedBy = user.ModefiedBy;
            tempuser.ModifiedDateTime = user.ModifiedDateTime;
            tempuser.Password = user.Password;
            tempuser.Role = user.Role;
            tempuser.User_Name = user.User_Name;
            tempuser.Email = user.Email;
            tempuser.SMS = user.SMS;
            tempuser.SMS_Notification = user.SMS_Notification;
            tempuser.Email_Notification = user.Email_Notification;

        }

        private bool Validation(bool isnew)
        {
            try
            {
                if (textBoxFullName.Text == string.Empty)
                {
                    MessageBox.Show("Please Enter full name");
                    return false;
                }
                if (textBoxUserName.Text == string.Empty)
                {
                    MessageBox.Show("Please Enter user name");
                    return false;
                }
                if (instace.Users.SingleOrDefault( x => x.User_Name == textBoxUserName.Text && x.Active == true) != null && isnew)
                {
                     MessageBox.Show("User aready exists, please enter different user name.");
                    return false;
                }
                if (textBoxPassword.Text == string.Empty)
                {
                    MessageBox.Show("Please Enter password");
                    return false;

                }
                if (!CheckPassword(textBoxPassword.Text, "(?=^[^\\s]{6,}$)(?=.*\\d)(?=.*[a-zA-Z])"))
                {
                    MessageBox.Show("Password must be six characters including letter and number");
                    return false;
                }


                if (textBoxEmail.Text != string.Empty)
                {
                    if (!CheckPassword(textBoxEmail.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                    {
                        MessageBox.Show("Email Address not valid");
                        return false;
                    }
                }

                if (!comboBoxRole.Items.Contains(comboBoxRole.Text))
                {
                    MessageBox.Show("Please select correct role");
                    return false;
                }
                
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
               // Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");

            }
            return true;
            
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (isNew)
                {
                    if (this.Validation(true))
                    {

                        DAL.User user = new DAL.User();
                        user.Active = true;
                        user.Authority = comboBoxRole.Text;
                        user.CreateDateTime = DateTime.Now;
                        user.Description = textBoxDescription.Text;
                        user.Full_Name = textBoxFullName.Text;
                        user.IsRowEnable = true;
                        user.Password = BAL.Authentication.GetEc(textBoxPassword.Text);
                        user.User_Name = textBoxUserName.Text;
                        user.CreatedBy = instace.UserInstance.Full_Name;
                        user.Role = comboBoxRole.SelectedIndex + 1;
                        user.Email = textBoxEmail.Text;
                        user.SMS = textBoxSMS.Text;
                        user.Email_Notification = checkBoxEmail.Checked;
                        user.SMS_Notification = checkBoxEmail.Checked;
                        if (instace.DataLink.Connection.State == System.Data.ConnectionState.Closed)
                        {
                            instace.DataLink.Connection.Open();
                        }
                        instace.DataLink.Users.InsertOnSubmit(user);                        
                        instace.DataLink.SubmitChanges();
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Add new user ", instace.UserInstance.Full_Name);

                    }
                }
                else
                {
                    if (this.Validation(false))
                    {
                        bool ischange = false;  
                        if (user.Active != (bool)checkBoxActive.Checked)
                        {
                            ischange = true;
                            Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, user.Full_Name + "has disabled", instace.UserInstance.Full_Name);
                            user.Active = (bool)checkBoxActive.Checked;
                        }
                        if (user.Full_Name != textBoxFullName.Text)
                        {
                            Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Change Properties of Full Name : from "+ tempuser.Full_Name +" to "+ textBoxFullName.Text, instace.UserInstance.Full_Name);
                            user.Full_Name = textBoxFullName.Text;
                            ischange = true;
                        }
                        if (user.SMS != textBoxSMS.Text)
                        {
                            Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Change Properties of Phone : from " + tempuser.SMS + " to " + textBoxSMS.Text, instace.UserInstance.Full_Name);
                            user.SMS =textBoxSMS.Text;
                            ischange = true;
                        }

                        if (user.User_Name != textBoxUserName.Text)
                        {
                            Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Change Properties of User Name : from " + tempuser.User_Name + " to " + textBoxUserName.Text, instace.UserInstance.Full_Name);
                            user.User_Name = textBoxUserName.Text;
                            ischange = true;
                        }
                         if (user.Email != textBoxEmail.Text)
                        {
                            Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Change Properties of Email address : from " +  tempuser.Email + " to " + textBoxEmail.Text, instace.UserInstance.Full_Name);
                            user.Email = textBoxEmail.Text;
                            ischange = true;
                        }

                        if (user.Password != BAL.Authentication.GetEc(textBoxPassword.Text))
                        {
                            Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Change Properties ", instace.UserInstance.Full_Name);
                            user.Password = BAL.Authentication.GetEc( textBoxPassword.Text);
                            ischange = true;
                        }


                        if (user.Authority != comboBoxRole.Text)
                        {
                            Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Change Properties of Role : from " + tempuser.Authority + " to " + comboBoxRole.Text, instace.UserInstance.Full_Name);
                           
                            int index = comboBoxRole.SelectedIndex + 1;
                            user.Role1 = instace.GetRols.SingleOrDefault( x => x.Id == index);
                            user.Authority = comboBoxRole.Text;
                            ischange = true;
                        }

                        if (user.Description != textBoxDescription.Text)
                        {
                            Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Change Properties of Description: from " + tempuser.Description + " to " +textBoxDescription.Text, instace.UserInstance.Full_Name);
                            user.Description = textBoxDescription.Text;
                            ischange = true;
                        }
                        if (user.SMS_Notification != checkBoxSMS.Checked)
                        {
                            Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Change Properties of SMS Notication: from " + tempuser.SMS_Notification.ToString() + " to " + checkBoxSMS.Checked.ToString(), instace.UserInstance.Full_Name);
                            user.SMS_Notification = checkBoxSMS.Checked;
                            ischange = true;
                        }
                        if (user.Email_Notification != checkBoxEmail.Checked)
                        {
                            Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Change Properties of Email Notication: from " + tempuser.Email_Notification.ToString() + " to " + checkBoxEmail.Checked.ToString(), instace.UserInstance.Full_Name);
                            user.Email_Notification = checkBoxEmail.Checked;
                            ischange = true;
                        }
                        if (ischange )
                        {
                             user.IsRowEnable = true;
                        user.ModefiedBy = instace.UserInstance.Full_Name;
                        user.ModifiedDateTime = DateTime.Now;
                        if (instace.DataLink.Connection.State == System.Data.ConnectionState.Closed)
                        {
                            instace.DataLink.Connection.Open();
                        }
                        instace.DataLink.SubmitChanges();

                        //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "User Modifed ", instace.UserInstance.Full_Name);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        }
                    }
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

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {

        }

        private void checkBoxEmail_CheckedChanged(object sender, EventArgs e)
        {
            textBoxEmail.Enabled = checkBoxEmail.Checked;
        }

        private void checkBoxSMS_CheckedChanged(object sender, EventArgs e)
        {
            textBoxSMS.Enabled = checkBoxSMS.Checked;
        }
    }
}