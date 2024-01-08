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
    public partial class PressureDeviceForm : Form
    {
        int id;
        bool isNew;
        BAL.LogitInstance Instance;
        BAL.Logit_Device devices;

        public PressureDeviceForm(int Id, bool isNew, BAL.LogitInstance Instance, BAL.Logit_Device devices)
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
                    newconfig.Interval = Convert.ToInt16(comboBox.Text);
                    newconfig.Location = textBoxlocation.Text;
                    newconfig.CreateDateTime = DateTime.Now;
                    newconfig.Device_Type = 1;
                    newconfig.IsRowActive = true;
                   
                    DAL.LimitTable limit = new DAL.LimitTable();
                    limit.Id = Guid.NewGuid();
                    limit.Device_type = 3;
                    limit.Lower_Limit = Convert.ToInt32(textBoxTLL.Text);
                    limit.Upper_Limit = Convert.ToInt32(textBoxTUL.Text);
                    limit.Lower_Range = Convert.ToInt32(textBoxTLR.Text);
                    limit.Upper_Range = Convert.ToInt32(textBoxTUR.Text);
                    limit.ofset = 0.0;
                    limit.dateofcalibrate = DateTime.Now;
                    limit.Device_id = newconfig.ID;
                    newconfig.LimitTables.Add(limit);
                   
                    devices.Add(newconfig);
                    Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Device Add ", Instance.UserInstance.User_Name);
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
                    config.Instrument = textBoxInstrument.Text;
                    Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Changed Properties: Device No.# " + config.Device_Id.ToString() + " from " + config.Instrument + " to " + textBoxInstrument.Text, Instance.UserInstance.Full_Name);
                }

                if (config.Interval.ToString() != comboBox.Text)
                {
                    config.Interval = Convert.ToInt16(comboBox.Text);
                    Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Changed Properties: Device No.# " + config.Device_Id.ToString() + " from " + config.Interval.ToString() + " to " + comboBox.SelectedIndex + 1, Instance.UserInstance.Full_Name);
                }

                if (config.Location != textBoxlocation.Text)
                {
                    config.Location = textBoxlocation.Text;
                    Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Changed Properties: Device No.# " + config.Device_Id.ToString() + " from " + config.Location + " to " + textBoxlocation.Text, Instance.UserInstance.Full_Name);
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
                        limitTemp.Lower_Limit = Convert.ToInt32(textBoxTLL.Text);
                        Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Temperature Lower Limit Changed Properties: Device No.# " + config.Device_Id.ToString() + " from " + limitTemp.Lower_Limit.ToString() + " to " + textBoxTLL.Text, Instance.UserInstance.Full_Name);
                    }
                    if (limitTemp.Upper_Limit != Convert.ToInt32(textBoxTUL.Text))
                    {
                        limitTemp.Upper_Limit = Convert.ToInt32(textBoxTUL.Text);
                        Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Temperature Upper Limit Changed Properties: Device No.# " + config.Device_Id.ToString() + " from " + limitTemp.Upper_Limit.ToString() + " to " + textBoxTUL.Text, Instance.UserInstance.Full_Name);
                    }
                    if (limitTemp.Lower_Range != Convert.ToInt32(textBoxTLR.Text))
                    {
                        limitTemp.Lower_Range = Convert.ToInt32(textBoxTLR.Text);
                        Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Temperature Lower Range Changed Properties: Device No.# " + config.Device_Id.ToString() + " from " + limitTemp.Lower_Range.ToString() + " to " + textBoxTLR.Text, Instance.UserInstance.Full_Name);
                    }
                    if (limitTemp.Upper_Range != Convert.ToInt32(textBoxTUR.Text))
                    {
                        limitTemp.Upper_Range = Convert.ToInt32(textBoxTUR.Text);
                        Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Temperature Lower Range Changed Properties: Device No.# " + config.Device_Id.ToString() + " from " + limitTemp.Upper_Range.ToString() + " to " + textBoxTUR.Text, Instance.UserInstance.Full_Name);
                    }

                   

                   
                        DAL.LimitTable limitRH = limits.SingleOrDefault(m => m.Device_type == 3);
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

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                devices.Update(config);
                Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Device Modified ", Instance.UserInstance.User_Name);
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
            

            return true;
        }
    }
}
