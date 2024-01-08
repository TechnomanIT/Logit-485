using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Log_It.Pages
{
    public enum PageControlEnum
    {
        Home = 0,
        Applicatio_Properties = 1,
        DB_Maintenance = 2,
        Event_Page = 3,
        User_Page = 4,
        DeviceConfigPage = 5,
        TankView = 6,
        TVView = 7
    }
    public partial class ControlPage : UserControl
    {


        public PageControlEnum Page_Controls
        {
            get;
            set;
        }

        public virtual void RefreshPage()
        { }

        public ControlPage()
        {
            InitializeComponent();
        }
    }
}
