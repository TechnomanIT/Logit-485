using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
namespace Log_It.CustomControls
{
    public partial class DeviceFormControl : UserControl
    {
        public bool isNewDevice { get; set; }
        public User currentUser { get; set; }
        public DeviceFormControl()
        {
            InitializeComponent();
        }

        public Device_Config GetDevice()
        {
            try
            {
                Device_Config device = new Device_Config()
                {
                    ID = Guid.NewGuid(),
                 
                    Alaram = checkBoxAlaram.Checked,
                    Channel_id = textBoxChannelID.Text,
                    Instrument = textBoxInstrument.Text,
                    Interval = Convert.ToInt16(numericInterval.Value),
                    Device_Id = Convert.ToInt16(textBoxDeviceID.Text),
                    Location = textBoxLocation.Text,
                    CreateDateTime = DateTime.Now,
                    IsRowActive = true,
                   
                     CreatedBy = currentUser.User_Name,
                };
                if (!isNewDevice)
                {
                    device.Last_Record = Convert.ToDateTime(label1lastRecord.Text);
                    LimitTable Templimit = new LimitTable()
                    {
                        Id = Guid.NewGuid(),
                        Device_id = device.ID,
                        Device_type = 1,
                        Lower_Limit = Convert.ToInt16(textBoxTLL.Text),
                        Lower_Range = Convert.ToInt16(textBoxTLR.Text),
                        Upper_Limit = Convert.ToInt16(textBoxTUL.Text),
                        Upper_Range = Convert.ToInt16(textBoxTUR.Text)
                    };
                    device.LimitTables.Add(Templimit);
                   
                }
                return device;
            }
            catch (Exception)
            {
                
                throw;
            }
            
        }

        
    }
}
