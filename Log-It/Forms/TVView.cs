using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BAL;
using DAL;
namespace Log_It.Forms
{
    public partial class TVView : Form
    {
        public delegate void FormClose();
        public event FormClose close;
        Log_It.CustomControls.TVControl tv;
        Logit_Device config;
        private static TVView instance = null;
        private Log_It.CustomControls.TVControl[] tvs = null;

        public TVView(object o, BAL.Logit_Device config)
        {
            InitializeComponent();
            this.config = config;
            this.CreateTVObjects(o);
           
        }
        public static TVView Instance(object o, BAL.Logit_Device config)
        {
            if (instance == null)
                instance = new TVView(o,config);
            return instance;
        }

        public Log_It.CustomControls.TVControl CreateTV(string caption)
        {
            tv = new Log_It.CustomControls.TVControl();
            System.Windows.Forms.TabPage page = new TabPage(caption);
            page.Controls.Add(tv);
            tab.TabPages.Add(page);
            page.BringToFront();
            tab.BringToFront();
            return tv;
        }
        public Log_It.CustomControls.TVControl[] TVs
        {
            get
            {
                return this.tvs;
            }

        }
        private void CreateTVObjects(object o)
        {
            LogIt[] channel = (LogIt[])o;
            if (channel != null)
            {
                tvs = new Log_It.CustomControls.TVControl[channel.Length];
                for (int i = 0; i < channel.Length; i++)
                {
                    tvs[i] = CreateTV(channel[i].Location);
                    tvs[i].logitObj = channel[i];
                }

                for (int i = 0; i < config.GetAllDevices().Count(); i++)
                {
                    tvs[i].TempLowerLimit = (float)channel[i].Parameter[0].LowerLimit;
                    tvs[i].TempUpperLimit = (float)channel[i].Parameter[0].UpperLimit;
                    tvs[i].TempLowerRange = (float)channel[i].Parameter[0].LowerRange;
                    tvs[i].TempUpperRange = (float)channel[i].Parameter[0].UpperRange;
                    tvs[i].TankT.Caption = channel[i].Location;
                    tvs[i].TankT.Tag = channel[i].DeviceID.ToString();



                    if (channel[i].RhActive)
                    {
                        tvs[i].HumidityLowerLimit = (float)channel[i].Parameter[1].LowerLimit;
                        tvs[i].HumidityUpperLimit = (float)channel[i].Parameter[1].UpperLimit;
                        tvs[i].HumidityLowerRange = (float)channel[i].Parameter[1].LowerRange;
                        tvs[i].HumidityUpperRange = (float)channel[i].Parameter[1].UpperRange;
                        tvs[i].TankH.Caption = channel[i].Location;
                    }
                    else
                    {
                        tvs[i].HideHumidity();
                    }
                }
            }
        }
        

        private System.Windows.Forms.TabControl.TabPageCollection  TabPages
		{
			get
			{
				return this.tab.TabPages;
			}

		}
        public void RealTimeData(LogIt logItObject)
		{			
			for(int i=0; i< tvs.Length; i++)
			{
				if(logItObject.DeviceID == tvs[i].logitObj.DeviceID)
				{
					tvs[i].RealTimeData(logItObject);
					Console.WriteLine(i);
				}	
				
			}
		}

        private void TVView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (close != null)
            {

                close();

            }
        }

        private void TVView_FormClosing(object sender, FormClosingEventArgs e)
        {
            instance = null;
            tv = null;

        }		
		
    }
}
