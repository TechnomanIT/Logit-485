using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log_It.Forms
{
    public partial class DeviceForm : Form
    {
        int id;
        bool isNew;
        BAL.LogitInstance Instance;
        BAL.Logit_Device devices;
        public DeviceForm(int Id, bool isNew, BAL.LogitInstance Instance, BAL.Logit_Device devices)
        {
            InitializeComponent();
            id = Id;
            this.isNew = isNew;
            labelID.Text = Id.ToString();
            this.Instance = Instance;
            this.devices = devices;
            for (int i = 1; i <= 60; i++)
            {
                comboBox.Items.Add(i.ToString());
            }
            comboBox.SelectedIndex = 14;

            if (!isNew && id > 0)
            {
                DAL.Device_Config config = Instance.Device_Configes.SingleOrDefault(x => x.Device_Id == id && x.IsRowActive == true);
                
                checkBoxActive.Checked = (bool)config.Active;
                labelID.Text = config.Device_Id.ToString();
                textBoxlocation.Text = config.Location.ToString();
                textBoxInstrument.Text = config.Instrument;
                checkBoxAlaram.Checked = (bool)config.Alaram;
                comboBox.Text = config.Interval.ToString();
                IQueryable<DAL.LimitTable> limits = config.LimitTables.Where(p => p.Device_id == config.ID).AsQueryable();
                if (limits.Count() > 0)
                {
                    DAL.LimitTable limitTemp = limits.SingleOrDefault(m => m.Device_type == 1);
                    textBoxTLL.Text = limitTemp.Lower_Limit.ToString();
                    textBoxTUL.Text = limitTemp.Upper_Limit.ToString();
                    textBoxTLR.Text = limitTemp.Lower_Range.ToString();
                    textBoxTUR.Text = limitTemp.Upper_Range.ToString();
                    checkBoxRh.Checked = (bool)config.Rh_Active;
                    if (config.Rh_Active == true)
                    {
                        DAL.LimitTable limitRH = limits.SingleOrDefault(m => m.Device_type == 2);
                        textBoxHLL.Text = limitRH.Lower_Limit.ToString();
                        textBoxHUL.Text = limitRH.Upper_Limit.ToString();
                        textBoxHLR.Text = limitRH.Lower_Range.ToString();
                        textBoxHUR.Text = limitRH.Upper_Range.ToString();

                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            #region IF
            if (isNew)
            {
                if (this.Validation())
                {
                    DAL.Device_Config newconfig = new DAL.Device_Config();
                    newconfig.ID = Guid.NewGuid();
                    newconfig.Active = true;
                    newconfig.Alaram = checkBoxAlaram.Checked;
                    newconfig.Channel_id = id.ToString();
                    newconfig.Device_Id = id;
                    newconfig.Instrument = textBoxInstrument.Text;
                    newconfig.Interval = Convert.ToInt16( comboBox.Text);
                    newconfig.Location = textBoxlocation.Text;
                    newconfig.CreateDateTime = DateTime.Now;
                    newconfig.Device_Type = 0;
                    newconfig.IsRowActive = true;
                    newconfig.ReportSendDate = DateTime.Today.Date;
                    newconfig.Rh_Active = checkBoxRh.Checked;
                    DAL.LimitTable limit = new DAL.LimitTable();
                    limit.Id = Guid.NewGuid();
                    limit.Device_type = 1;
                    limit.Lower_Limit = Convert.ToInt32(textBoxTLL.Text);
                    limit.Upper_Limit = Convert.ToInt32(textBoxTUL.Text);
                    limit.Lower_Range = Convert.ToInt32(textBoxTLR.Text);
                    limit.Upper_Range = Convert.ToInt32(textBoxTUR.Text);
                    limit.ofset = 0.0;
                    limit.dateofcalibrate = DateTime.Now;
                    limit.Device_id = newconfig.ID;
                    newconfig.LimitTables.Add(limit);
                    if (checkBoxRh.Checked)
                    {

                        DAL.LimitTable limitRH = new DAL.LimitTable();
                        limitRH.Id = Guid.NewGuid();
                        limitRH.Device_type = 2;
                        limitRH.Lower_Limit = Convert.ToInt32(textBoxHLL.Text);
                        limitRH.Upper_Limit = Convert.ToInt32(textBoxHUL.Text);
                        limitRH.Lower_Range = Convert.ToInt32(textBoxHLR.Text);
                        limitRH.Upper_Range = Convert.ToInt32(textBoxHUR.Text);
                        limitRH.ofset = 0.0;
                        limitRH.dateofcalibrate = DateTime.Now;
                        limit.Device_id = newconfig.ID;
                        newconfig.LimitTables.Add(limitRH);
                    }
                    devices.Add(newconfig);
                    Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Device Add ", Instance.UserInstance.Full_Name);
                }
            }
            else
            {
                DAL.Device_Config config = devices.GetbyDeviceID(id);                
                if (config.Active != (bool)checkBoxActive.Checked)
                {
                config.Active = (bool)checkBoxActive.Checked;
                if (checkBoxActive.Checked)
                {
                    Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Device No.# " + config.Device_Id.ToString() + " has enabled", Instance.UserInstance.Full_Name);
                    
                }
                else
                {
                    Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Device No.# " + config.Device_Id.ToString() + " has disabled", Instance.UserInstance.Full_Name);
               
                }
                          
                    
                }
                if (config.Alaram != checkBoxAlaram.Checked)
                {
                    config.Alaram = checkBoxAlaram.Checked;
                    Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Changed Properties: Device No.# " + config.Device_Id.ToString() + " alaram Disabled", Instance.UserInstance.Full_Name);
                }
                
                config.Channel_id = id.ToString();
                config.Device_Id = id;
                if (config.Instrument != textBoxInstrument.Text)
                {
                    Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Changed Properties: Device No.# " + config.Device_Id.ToString() + " Insturment name change from " + config.Instrument + " to " + textBoxInstrument.Text, Instance.UserInstance.Full_Name);
                    config.Instrument = textBoxInstrument.Text;
                    
                }

                if ( config.Interval.ToString() != comboBox.Text)
                {
                    Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Changed Properties: Device No.# " + config.Device_Id.ToString() + "interval change from " + config.Interval.ToString() + " to " + comboBox.SelectedIndex + 1, Instance.UserInstance.Full_Name);
                    config.Interval = Convert.ToInt16( comboBox.Text);
                    
                }

                if (config.Location != textBoxlocation.Text)
                {
                    Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Changed Properties: Device No.# " + config.Device_Id.ToString() + "Location change from " + config.Location + " to " + textBoxlocation.Text, Instance.UserInstance.Full_Name);
                    config.Location = textBoxlocation.Text;                   
                }
               
                config.ModifiedDateTime = DateTime.Now;
                config.IsRowActive = true;
                config.Last_Record = new DateTime(1899, 12, 31, 23, 59, 59);
                //config.Rh_Active = checkBoxRh.Checked;
                IQueryable<DAL.LimitTable> limits = config.LimitTables.Where(m => m.Device_id == config.ID).AsQueryable();
                if (limits.Count() > 0)
                {
                    DAL.LimitTable limitTemp = limits.SingleOrDefault(m => m.Device_type == 1);

                    if (limitTemp.Lower_Limit != Convert.ToInt32(textBoxTLL.Text))
                    {
                        Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Temperature Lower Limit Changed Properties: Device No.# " + config.Device_Id.ToString() + " from " + limitTemp.Lower_Limit.ToString() + " to " + textBoxTLL.Text, Instance.UserInstance.Full_Name);
                        limitTemp.Lower_Limit = Convert.ToInt32(textBoxTLL.Text);
                        
                    }
                    if (limitTemp.Upper_Limit != Convert.ToInt32(textBoxTUL.Text))
                    {
                        Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Temperature Upper Limit Changed Properties: Device No.# " + config.Device_Id.ToString() + " from " + limitTemp.Upper_Limit.ToString() + " to " + textBoxTUL.Text, Instance.UserInstance.Full_Name);
                        limitTemp.Upper_Limit = Convert.ToInt32(textBoxTUL.Text);
                        
                    }
                    if (limitTemp.Lower_Range != Convert.ToInt32(textBoxTLR.Text))
                    {
                        Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Temperature Lower Range Changed Properties: Device No.# " + config.Device_Id.ToString() + " from " + limitTemp.Lower_Range.ToString() + " to " + textBoxTLR.Text, Instance.UserInstance.Full_Name);
                        limitTemp.Lower_Range = Convert.ToInt32(textBoxTLR.Text);
                        
                    }
                    if (limitTemp.Upper_Range != Convert.ToInt32(textBoxTUR.Text))
                    {
                        Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Temperature Lower Range Changed Properties: Device No.# " + config.Device_Id.ToString() + " from " + limitTemp.Upper_Range.ToString() + " to " + textBoxTUR.Text, Instance.UserInstance.Full_Name);
                        limitTemp.Upper_Range = Convert.ToInt32(textBoxTUR.Text);
                        
                    }

                    if ( config.Rh_Active != checkBoxRh.Checked)
                    {
                        config.Rh_Active = checkBoxRh.Checked;
                        if (checkBoxRh.Checked)
                        {
                            Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Changed Properties: Device No.# " + config.Device_Id.ToString() + " Rh active", Instance.UserInstance.Full_Name);    
                        }
                        else
                        {
                            Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Changed Properties: Device No.# " + config.Device_Id.ToString() + " Rh inactive", Instance.UserInstance.Full_Name);    
                        }
                        
                    }
                  
                    if (checkBoxRh.Checked)
                    {
                        DAL.LimitTable limitRH = limits.SingleOrDefault(m => m.Device_type == 2);
                        if (limitRH == null)
                        {
                            DAL.LimitTable limitRH1 = new DAL.LimitTable();
                            limitRH1.Id = Guid.NewGuid();
                            limitRH1.Device_type = 2;
                        

                            if (limitRH1.Lower_Limit != Convert.ToInt32(textBoxHLL.Text))
                            {
                                Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Changed Properties: Device No.# " + config.Device_Id.ToString() + ", " + textBoxHLL.Text, Instance.UserInstance.Full_Name);
                                limitRH1.Lower_Limit = Convert.ToInt32(textBoxHLL.Text);
                                
                            }

                            if (limitRH1.Upper_Limit != Convert.ToInt32(textBoxHUL.Text))
                            {
                                Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Changed Properties: Device No.# " + config.Device_Id.ToString() + ", " + textBoxHUL.Text, Instance.UserInstance.Full_Name);
                                limitRH1.Upper_Limit = Convert.ToInt32(textBoxHUL.Text);
                                
                            }

                            if (limitRH1.Lower_Range != Convert.ToInt32(textBoxHLR.Text))
                            {
                                Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Changed Properties: Device No.# " + config.Device_Id.ToString() + ", " + textBoxHLR.Text, Instance.UserInstance.Full_Name);
                                limitRH1.Lower_Range = Convert.ToInt32(textBoxHLR.Text);
                                
                            }
                            if (limitRH1.Upper_Range != Convert.ToInt32(textBoxHUR.Text))
                            {
                                Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Changed Properties: Device No.# " + config.Device_Id.ToString() + ", " + textBoxHUR.Text, Instance.UserInstance.Full_Name);
                                limitRH1.Upper_Range = Convert.ToInt32(textBoxHUR.Text);
                                
                            }

                            limitRH1.Device_id = config.ID;
                            config.LimitTables.Add(limitRH1);
                        }
                        else
                        {

                            if (limitRH.Lower_Limit != Convert.ToInt32(textBoxHLL.Text))
                            {
                                Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Humidity Lower Limit Changed Properties: Device No.# " + config.Device_Id.ToString() + " from " + limitTemp.Upper_Range.ToString() + " to " + textBoxHLL.Text, Instance.UserInstance.Full_Name);
                                limitRH.Lower_Limit = Convert.ToInt32(textBoxHLL.Text);
                                
                            }

                            if (limitRH.Upper_Limit != Convert.ToInt32(textBoxHUL.Text))
                            {
                                Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Humidity Upper Limit Changed Properties: Device No.# " + config.Device_Id.ToString() + " from " + limitTemp.Upper_Range.ToString() + " to " + textBoxHUL.Text, Instance.UserInstance.Full_Name);
                                limitRH.Upper_Limit = Convert.ToInt32(textBoxHUL.Text);
                                
                            }

                            if (limitRH.Lower_Range != Convert.ToInt32(textBoxHLR.Text))
                            {
                                Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Humidity Lower Range Changed Properties: Device No.# " + config.Device_Id.ToString() + " from " + limitTemp.Upper_Range.ToString() + " to " + textBoxHLR.Text, Instance.UserInstance.Full_Name);
                                limitRH.Lower_Range = Convert.ToInt32(textBoxHLR.Text);
                                
                            }
                            if (limitRH.Upper_Range != Convert.ToInt32(textBoxHUR.Text))
                            {
                                Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Humidity Upper Range Changed Properties: Device No.# " + config.Device_Id.ToString() + " from " + limitTemp.Upper_Range.ToString() + " to " + textBoxHUR.Text, Instance.UserInstance.Full_Name);
                                limitRH.Upper_Range = Convert.ToInt32(textBoxHUR.Text);
                                
                            }
                        }
                    }
                    else
                    {
                        DAL.LimitTable limitRH = limits.SingleOrDefault(m => m.Device_type == 2);
                        if (limitRH == null)
                        {
                            
                        }
                        else
                        {
                            limitRH.Lower_Limit = 0;
                            limitRH.Upper_Limit = 0;
                            limitRH.Lower_Range = 0;
                            limitRH.Upper_Range = 0;
                        }
                    }
                }

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                devices.Update(config);
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Device Modified ", Instance.UserInstance.User_Name);
            }


            #endregion

            this.Close();
        }
        bool Validation()
        {

            if (textBoxlocation.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Location.");
                return false;
            }
            if (textBoxInstrument.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Instrument information.");
                return false;
            }

            if (textBoxTLL.Text == string.Empty || textBoxTUL.Text == string.Empty || textBoxTLR.Text == string.Empty || textBoxTUR.Text == string.Empty)
            {
                Log_It.Forms.DialogForm df = new Forms.DialogForm();
                df.ShowDialog();
                if (df.DialogResult == DialogResult.Cancel)
                {
                    return false;
                }
                else
                {
                    if (textBoxTLL.Text == string.Empty)
                    {
                        textBoxTLL.Text = "0";
                    }
                    if (textBoxTUL.Text == string.Empty)
                    {
                        textBoxTUL.Text = "100";
                    }
                    if (textBoxTLR.Text == string.Empty)
                    {
                        textBoxTLR.Text = "0";
                    }
                    if (textBoxTUR.Text == string.Empty)
                    {
                        textBoxTUR.Text = "100";
                    }
                }
            }
            if (checkBoxRh.Checked)
            {
                if (textBoxHLL.Text == string.Empty || textBoxHLR.Text == string.Empty || textBoxHUL.Text == string.Empty || textBoxHUR.Text == string.Empty)
                {
                    Log_It.Forms.DialogForm df = new Forms.DialogForm();
                    if (df.DialogResult == DialogResult.Cancel)
                    {
                        return false;
                    }
                    else
                    {
                        if (textBoxHLL.Text == string.Empty)
                        {
                            textBoxHLL.Text = "0";
                        }
                        if (textBoxHUL.Text == string.Empty)
                        {
                            textBoxHUL.Text = "100";
                        }
                        if (textBoxHLR.Text == string.Empty)
                        {
                            textBoxHLR.Text = "0";
                        }
                        if (textBoxHUR.Text == string.Empty)
                        {
                            textBoxHUR.Text = "100";
                        }
                    }
                }
            }

            return true;
        }

        private void checkBoxRh_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxHumadity.Enabled = checkBoxRh.Checked;
        }

        private void textBoxTLL_TextChanged(object sender, EventArgs e)
            {
            TextBox t = (TextBox)sender;
            if (System.Text.RegularExpressions.Regex.IsMatch(t.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                t.Text = t.Text.Remove(t.Text.Length - 1);
            }
        }

        private void DeviceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void DeviceForm_Load(object sender, EventArgs e)
        {

        }
    }
}
