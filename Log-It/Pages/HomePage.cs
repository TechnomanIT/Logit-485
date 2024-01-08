using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Log_It.Pages
{
    public partial class HomePage : ControlPage
    {
        public delegate void IndexPage(int i);
        public event IndexPage PageIndex;


        public HomePage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (PageIndex != null)
                {
                    Button b = (Button)sender;
                    PageIndex(b.TabIndex);
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
    }
}
