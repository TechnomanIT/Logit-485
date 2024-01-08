using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Log_It.CustomControls
{
    public partial class LogitUC : UserControl
    {
        private float max, min, lLimit, uLimit;
        string unit = " °C";
      	

        public LogitUC()
        {
            InitializeComponent();
            this.realTimeBar1.BarInfos = new BarInfo[] 
             { new BarInfo(Color.Lime,Color.Yellow,0,BarInfo.Side.Negative),
                new BarInfo(Color.Yellow,Color.Lime,0,BarInfo.Side.Positive),
                new BarInfo(Color.Yellow,Color.Orange,75,BarInfo.Side.Negative),
                new BarInfo(Color.Orange ,Color.Yellow,75,BarInfo.Side.Positive),
                new BarInfo(Color.Orange,Color.Red,100,BarInfo.Side.Negative),
                new BarInfo(Color.Red ,Color.Orange,100,BarInfo.Side.Positive)};
            labelHeader.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void realTimeBarCurrentData_Resize(object sender, System.EventArgs e)
		{
			this.picTimeOut.Left = this.realTimeBar1.Left;
            this.picTimeOut.Top = this.realTimeBar1.Top;
            this.picTimeOut.Width = this.realTimeBar1.Width;
            this.picTimeOut.Height = this.realTimeBar1.Height;			
		}

		private void tmrTimeOut_Tick(object sender, System.EventArgs e)
		{			
			this.picTimeOut.Visible = true;			
			this.tmrTimeOut.Enabled = false;
		}

		/// <summary>
		/// LLimit
		/// </summary>
		public float LLimit
		{
			get
			{
				return lLimit;
			}
			set
			{
				lLimit=value;
				this.realTimeBar1.LLimit =value;

			}
		}

		/// <summary>
		/// Unit
		/// </summary>
		public string Unit
		{
			get
			{
				return unit;
			}
			set
			{
				unit=value;
				this.realTimeBar1.Suffix=value;
				
			}
		}

		/// <summary>
		/// NumericFormat
		/// </summary>
		public string NumericFormat
		{
			get
			{
				return this.realTimeBar1.NumberFormat;
			}
			set
			{
				
				this.realTimeBar1.NumberFormat=value;
				
			}
		}

		/// <summary>
		/// Caption
		/// </summary>
		public string Caption
		{
			get
			{
				return this.labelHeader.Text;
			}
			set
			{
                this.labelHeader.Text = value;
                string inputStr = value;
                //bool isDecreaseSize = false;
                //do
                //{
                //    SizeF size = lblCaption.CreateGraphics().MeasureString(inputStr, lblCaption.Font);
                //    if (size.Width >= lblCaption.Width)
                //    {
                //        isDecreaseSize = true;
                //        lblCaption.Font = new Font(lblCaption.Font.Name, lblCaption.Font.Size - 1);
                //    }
                //    else
                //    { isDecreaseSize = false; }

                //} while (isDecreaseSize);

                this.labelHeader.Text = inputStr;
                labelHeader.Enabled = true;
                labelHeader.Visible = true;
				
			}
		}


		/// <summary>
		/// ULimit
		/// </summary>
		public float ULimit
		{
			get
			{
				return uLimit;
			}
			set
			{
				uLimit=value;
				this.realTimeBar1.ULimit=value;
			}
		}

		/// <summary>
		/// Value
		/// </summary>
		public float Value
		{
			get
			{
				return this.realTimeBar1.Value;
			}
			set
			{
				this.realTimeBar1.Value=value;				
				this.picTimeOut.Visible = false;
				if(this.tmrTimeOut.Enabled)
					this.tmrTimeOut.Enabled = false;
				this.tmrTimeOut.Enabled = true;
			}
		}

		/// <summary>
		/// Min
		/// </summary>
		public float Min
		{
			get
			{
				return min;
			}
			set
			{
				min=value;
				this.realTimeBar1.Min=value;
                this.labelMin.Text = value.ToString();
			}
		}

		/// <summary>
		/// BackgroundColor
		/// </summary>
		public Color BackgroundColor
		{
			get
			{
				return this.labelHeader.BackColor;
			}
			set
			{
				this.labelHeader.BackColor=value;
			}
		}

		/// <summary>
		/// Font
		/// </summary>
		public override Font Font
		{
			get
			{
				return base.Font;
			}
			set
			{
				base.Font=value;
				this.realTimeBar1.Font=new Font(value.FontFamily,32,value.Style);
				this.labelHeader.Font=new Font(value.FontFamily,14,value.Style);

                //this.realTimeBarULimit.Font=new Font(value.FontFamily,14,value.Style);
                //this.realTimeBarLLimit.Font=new Font(value.FontFamily,14,value.Style);
			}
		}


		/// <summary>
		/// Max
		/// </summary>
		public float Max
		{
			get
			{
				return max;
			}
			set
			{
				max=value;
				this.realTimeBar1.Max=value;
                this.labelMax.Text = value.ToString();
                this.labelMax.Refresh();
			}
		}
    }
    }
