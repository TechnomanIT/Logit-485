using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Log_It.CustomControls;
using System.Diagnostics;

namespace Log_It.Forms
{
    public partial class ConfigForm : Form
    {
        public delegate void FormClose();
        public  event FormClose close;
        List<UserConfigControl> userconfigcontrols;
        List<BAL.LogIt> Logits = new List<BAL.LogIt>();
        BAL.LogitInstance instance;
        BAL.Logit_Device devices;
        int x = 10;
        int y = 5;
        public ConfigForm(Form f, BAL.Logit_Device devices, BAL.LogitInstance instance)
        {
            try
            {

                InitializeComponent();
                this.devices = devices;
                this.instance = instance;
                userconfigcontrols = new List<CustomControls.UserConfigControl>();
                int number = (int)instance.DataLink.SYSProperties.SingleOrDefault().Number_Devices;
                for (int i = 1; i <= number; i++)
                {
                    UserConfigControl us = new UserConfigControl();
                    us.Id = i;
                    us.Location = new Point(x, y);
                    panel1.Controls.Add(us);
                    y = y + us.Height + 5;
                    DAL.Device_Config config = devices.GetbyDeviceID(i);
                    if (config != null)
                    {
                        us.GUID = config.ID;
                        us.checkBoxActive.Checked = (bool)config.Active;
                        us.Id = (int)config.Device_Id;
                        us.textBoxlocation.Text = config.Location.ToString();
                        us.textBoxInstrument.Text = config.Instrument;
                        us.checkBoxAlaram.Checked = (bool)config.Alaram;
                        us.comboBox.SelectedIndex = (int)config.Interval - 1;
                        IQueryable<DAL.LimitTable> limits = config.LimitTables.Where(p => p.Device_id == config.ID).AsQueryable();
                        if (limits.Count() > 0)
                        {
                            DAL.LimitTable limitTemp = limits.SingleOrDefault(m => m.Device_type == 1);
                            us.textBoxTLL.Text = limitTemp.Lower_Limit.ToString();
                            us.textBoxTUL.Text = limitTemp.Upper_Limit.ToString();
                            us.textBoxTLR.Text = limitTemp.Lower_Range.ToString();
                            us.textBoxTUR.Text = limitTemp.Upper_Range.ToString();
                            us.checkBoxRh.Checked = (bool)config.Rh_Active;
                            if (config.Rh_Active == true)
                            {
                                DAL.LimitTable limitRH = limits.SingleOrDefault(m => m.Device_type == 2);
                                us.textBoxHLL.Text = limitRH.Lower_Limit.ToString();
                                us.textBoxHUL.Text = limitRH.Upper_Limit.ToString();
                                us.textBoxHLR.Text = limitRH.Lower_Range.ToString();
                                us.textBoxHUR.Text = limitRH.Upper_Range.ToString();

                            }
                        }
                    }
                    userconfigcontrols.Add(us);
                }
                //this.MdiParent = f;
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
                //Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");

            }

        }

        private void ConfigForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
            if (close != null)
            {
                close();
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

            try
            {

                foreach (var item in userconfigcontrols)
                {
                    if (item.checkBoxActive.Checked)
                    {
                        if (!item.ValidateControl())
                        {
                            MessageBox.Show("Device# " + item.Id + " not properly configure");
                            return;
                        }
                    }

                    DAL.Device_Config config = devices.GetbyDeviceID(item.Id);
                    if (config != null)
                    {
                        config.Active = item.checkBoxActive.Checked;
                        config.Alaram = item.checkBoxAlaram.Checked;
                        config.Channel_id = item.Id.ToString();
                        config.Device_Id = item.Id;
                        config.Instrument = item.textBoxInstrument.Text;
                        config.Interval = item.comboBox.SelectedIndex + 1;
                        config.Location = item.textBoxlocation.Text;
                        config.ModifiedDateTime = DateTime.Now;
                        config.IsRowActive = true;
                        config.Last_Record = new DateTime(1899, 12, 31, 23, 59, 59);
                        config.Rh_Active = item.checkBoxRh.Checked;
                        IQueryable<DAL.LimitTable> limits = config.LimitTables.Where(m => m.Device_id == config.ID).AsQueryable();
                        if (limits.Count() > 0)
                        {
                            DAL.LimitTable limitTemp = limits.SingleOrDefault(m => m.Device_type == 1);
                            limitTemp.Lower_Limit = Convert.ToInt32(item.textBoxTLL.Text);
                            limitTemp.Upper_Limit = Convert.ToInt32(item.textBoxTUL.Text);
                            limitTemp.Lower_Range = Convert.ToInt32(item.textBoxTLR.Text);
                            limitTemp.Upper_Range = Convert.ToInt32(item.textBoxTUR.Text);
                            if (config.Rh_Active == true)
                            {
                                DAL.LimitTable limitRH = limits.SingleOrDefault(m => m.Device_type == 2);
                                if (limitRH == null)
                                {
                                    DAL.LimitTable limitRH1 = new DAL.LimitTable();
                                    limitRH1.Id = Guid.NewGuid();
                                    limitRH1.Device_type = 2;
                                    limitRH1.Lower_Limit = Convert.ToInt32(item.textBoxHLL.Text);
                                    limitRH1.Upper_Limit = Convert.ToInt32(item.textBoxHUL.Text);
                                    limitRH1.Lower_Range = Convert.ToInt32(item.textBoxHLR.Text);
                                    limitRH1.Upper_Range = Convert.ToInt32(item.textBoxHUR.Text);
                                    limitRH1.Device_id = config.ID;
                                    config.LimitTables.Add(limitRH1);
                                }
                                else
                                {
                                    limitRH.Lower_Limit = Convert.ToInt32(item.textBoxHLL.Text);
                                    limitRH.Upper_Limit = Convert.ToInt32(item.textBoxHUL.Text);
                                    limitRH.Lower_Range = Convert.ToInt32(item.textBoxHLR.Text);
                                    limitRH.Upper_Range = Convert.ToInt32(item.textBoxHUR.Text);
                                }

                            }
                        }
                        devices.Update(config);
                        Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Device Added by " + instance.UserInstance.User_Name, instance.UserInstance.User_Name);
                    }
                    else
                    {
                        if (item.checkBoxActive.Checked)
                        {
                            DAL.Device_Config newconfig = new DAL.Device_Config();
                            newconfig.ID = Guid.NewGuid();
                            newconfig.Active = item.checkBoxActive.Checked;
                            newconfig.Alaram = item.checkBoxAlaram.Checked;
                            newconfig.Channel_id = item.Id.ToString();
                            newconfig.Device_Id = item.Id;
                            newconfig.Instrument = item.textBoxInstrument.Text;
                            newconfig.Interval = item.comboBox.SelectedIndex + 1;
                            newconfig.Location = item.textBoxlocation.Text;
                            newconfig.CreateDateTime = DateTime.Now;
                            newconfig.IsRowActive = true;
                            newconfig.Rh_Active = item.checkBoxRh.Checked;
                            DAL.LimitTable limit = new DAL.LimitTable();
                            limit.Id = Guid.NewGuid();
                            limit.Device_type = 1;
                            limit.Lower_Limit = Convert.ToInt32(item.textBoxTLL.Text);
                            limit.Upper_Limit = Convert.ToInt32(item.textBoxTUL.Text);
                            limit.Lower_Range = Convert.ToInt32(item.textBoxTLR.Text);
                            limit.Upper_Range = Convert.ToInt32(item.textBoxTUR.Text);
                            limit.Device_id = newconfig.ID;
                            newconfig.LimitTables.Add(limit);
                            if (item.checkBoxRh.Checked)
                            {

                                DAL.LimitTable limitRH = new DAL.LimitTable();
                                limitRH.Id = Guid.NewGuid();
                                limitRH.Device_type = 2;
                                limitRH.Lower_Limit = Convert.ToInt32(item.textBoxHLL.Text);
                                limitRH.Upper_Limit = Convert.ToInt32(item.textBoxHUL.Text);
                                limitRH.Lower_Range = Convert.ToInt32(item.textBoxHLR.Text);
                                limitRH.Upper_Range = Convert.ToInt32(item.textBoxHUR.Text);
                                limit.Device_id = newconfig.ID;
                                newconfig.LimitTables.Add(limitRH);
                            }
                            devices.Add(newconfig);
                            Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Modfiy, "Device Modifed by " + instance.UserInstance.User_Name, instance.UserInstance.User_Name);
              
                        }
                    }

                }
                MessageBox.Show("Device has been saved");
                this.Close();
            }
            catch (Exception m)
            {

                var st = new StackTrace();
                var sf = st.GetFrame(0);

                var currentMethodName = sf.GetMethod();
               // Technoman.Utilities.EventClass.WriteLog(Technoman.Utilities.EventLog.Error, m.Message + " Method Name: " + currentMethodName, "System");

            }
        }

    }
}

