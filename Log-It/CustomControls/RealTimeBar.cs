using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace Log_It.CustomControls
{
	/// <summary>
	/// Summary description for RealTimeBar.
	/// </summary>
    //[DebuggerNonUserCode()]
    public class RealTimeBar : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public enum Direction {Vertical=0,Horizontal};
		private bool verticalDisplay;
		private string numberFormat="+00.0;-00.0";
		private Color barColorDark=Color.Black,barColorLight=Color.White;
		private string suffix = " %";
		private LinearGradientMode gradientMode=LinearGradientMode.Horizontal;
		private float min=0,max=100;
		private float val=-90;
		private float lLimit=-90,uLimit=-50;
		Direction barDirection;
		private BarInfo[] barInfos=null;
		private System.Windows.Forms.PictureBox pictureBar; 
		private RectangleF userScale;




		public RealTimeBar()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		/// <summary>
		/// UserToSys
		/// </summary>
		public Point UserToSys(Rectangle sysScale,float x,float y)
		{

            x = (int)((sysScale.Width / this.userScale.Width) * (x - this.userScale.Left)) + sysScale.Left;
            y = (int)((sysScale.Height / this.userScale.Height) * (y - this.userScale.Top)) + sysScale.Top;
            return new Point((int)x, (int)y);
		}


		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.pictureBar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBar
            // 
            this.pictureBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBar.Location = new System.Drawing.Point(0, 0);
            this.pictureBar.Name = "pictureBar";
            this.pictureBar.Size = new System.Drawing.Size(150, 150);
            this.pictureBar.TabIndex = 0;
            this.pictureBar.TabStop = false;
            this.pictureBar.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBar_Paint);
            // 
            // RealTimeBar
            // 
            this.Controls.Add(this.pictureBar);
            this.Name = "RealTimeBar";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBar)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		/// <summary>
		/// NumberFormat
		/// </summary>
		public string NumberFormat
		{
			get
			{
				return numberFormat;
			}
			set
			{
				numberFormat=value;
				this.pictureBar.Refresh();
			}
		}

		/// <summary>
		/// VerticalDisplay
		/// </summary>
		public bool VerticalDisplay
		{
			get
			{
				return verticalDisplay;
			}
			set
			{
				verticalDisplay=value;
				this.pictureBar.Refresh();
			}
		}


		/// <summary>
		/// BarInfos
		/// </summary>
		public BarInfo[] BarInfos
		{
			get
			{
				return barInfos;
			}
			set
			{
				barInfos=value;
				this.SortBarInfos();				
				this.pictureBar.Refresh();
			}
		}

		/// <summary>
		/// Suffix
		/// </summary>
		public string Suffix
		{
			get
			{
				return suffix;
			}
			set
			{
				suffix=value;
				this.pictureBar.Refresh();
			}
		}

		/// <summary>
		/// GradientMode
		/// </summary>
		public LinearGradientMode GradientMode
		{
			get
			{
				return gradientMode;
			}
			set
			{
				gradientMode=value;
				this.pictureBar.Refresh();
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
				this.pictureBar.Refresh();
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
				this.pictureBar.Refresh();
			}
		}

		/// <summary>
		/// BarDirection
		/// </summary>
		public Direction BarDirection
		{
			get
			{
				return barDirection;
			}

			set
			{
				barDirection=value;
				this.pictureBar.Refresh();
			}
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
				this.pictureBar.Refresh();
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
				this.pictureBar.Refresh();
			}
		}

		/// <summary>
		/// Value
		/// </summary>
		public float Value
		{
			get
			{
				return val;
			}
			set
			{
				val=value;
				this.pictureBar.Refresh();
			}
		}

		/// <summary>
		/// BarColorDark
		/// </summary>
		public Color BarColorDark
		{
			get
			{
				return barColorDark;
			}
			set
			{
				barColorDark=value;
				this.pictureBar.Refresh();
			}
		}

		/// <summary>
		/// BarColorLight
		/// </summary>
		public Color BarColorLight
		{
			get
			{
				return barColorLight;
			}
			set
			{
				barColorLight=value;
				this.pictureBar.Refresh();
				
			}
		}

		/// <summary>
		/// DrawBar
		/// </summary>
		public void DrawBar(Graphics g,System.Windows.Forms.Control ctrl)
		{
			Rectangle sysScale=ctrl.ClientRectangle;
			RectangleF rectBar;
			userScale.X=min;userScale.Y=max; userScale.Width= max-min; userScale.Height=min-max;
			float a=val - (lLimit+uLimit)/2 ,b=(uLimit- lLimit)/2;
			float percent=(a/b)*100; 
			Point pt=this.UserToSys(sysScale,val,val);
			try
			{
				if(this.barDirection== Direction.Vertical)
					rectBar= new RectangleF(0,pt.Y ,sysScale.Width,sysScale.Height-pt.Y);
				else
					rectBar= new RectangleF(0,0,pt.X,sysScale.Height);
				Brush brush=this.ChoseGradient(percent,ctrl,rectBar);
				g.FillRectangle(brush,rectBar); 
			}
			catch(System.ArgumentException){}
			this.PrintDisplay(g,ctrl);		

		}

		private void pictureBar_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			this.DrawBar(e.Graphics,this.pictureBar);
		}

		/// <summary>
		/// ChoseGradient
		/// </summary>
		private Brush ChoseGradient(float p,System.Windows.Forms.Control ctrl,RectangleF rectBar)
		{
			float percent;
			BarInfo b;
			
			
			//-----For Gradient----
				LinearGradientBrush brush;
				brush= new LinearGradientBrush(rectBar,this.barColorDark,this.barColorLight,gradientMode);  
				//float[] factors = new float[]{0.0f, 0.5f, 1.0f};
				//float[] positions   = new float[] {0.0f, 0.5f, 1.0f};
				//Blend blend=new Blend(3);
				//blend.Factors=factors;
				//blend.Positions=positions;
				//brush.Blend=blend;


			if(this.barInfos== null || this.barInfos.Length==0) return brush;
			percent=Convert.ToSingle(Math.Abs(p));
			if(p>=0)
				for(int i = this.barInfos.Length-1; i>=0; i--)
				{
					b=BarInfos[i];
					if( b.Percent <= percent && (b.AppliedForSide== BarInfo.Side.Positive || b.AppliedForSide == BarInfo.Side.Both))
					{
						brush.LinearColors=new Color[]{b.DarkColor,b.LightColor};
						return brush;
					}
				}
			else
				for(int i = this.barInfos.Length-1; i>=0; i--)
				{
					b=BarInfos[i];
					if( b.Percent <= percent && (b.AppliedForSide== BarInfo.Side.Negative || b.AppliedForSide == BarInfo.Side.Both))
					{
						brush.LinearColors=new Color[]{b.DarkColor,b.LightColor};
						return brush;
					}
				}
			return brush;


		}

		/// <summary>
		/// SortBarInfos
		/// </summary>
		private void SortBarInfos()
		{
			if(this.barInfos==null)return;
			int n=barInfos.Length;
			BarInfo temp;
			for(int i=0; i<n-1; i++)
				for(int j=i+1; j<n; j++)
				{
					if(barInfos[i].Percent > barInfos[j].Percent) 
					{
						temp=barInfos[i];
						barInfos[i] = barInfos[j];
						barInfos[j]=temp;
					}
				}
		}

		/// <summary>
		/// PrintDisplay
		/// </summary>
		private void PrintDisplay(Graphics g,System.Windows.Forms.Control ctrl)
		{
			
			string str=val.ToString(this.numberFormat) ;
            string strsuffic = this.suffix;
			Rectangle sysScale=ctrl.ClientRectangle;
			SizeF stringSize;
			SolidBrush strBrush=new SolidBrush(Color.Black);
			System.Drawing.StringFormat stringFormat=new StringFormat();
			stringFormat.Alignment=System.Drawing.StringAlignment.Center;
			if(this.verticalDisplay)
			{
				stringFormat.FormatFlags= StringFormatFlags.DirectionVertical; 
				stringSize=g.MeasureString(str,this.Font,sysScale.Height,stringFormat);
				g.DrawString(str,this.Font,new SolidBrush(Color.Black),new RectangleF(0,0,sysScale.Width,sysScale.Height),stringFormat);

			}
			else
			{
                //stringSize = g.MeasureString(str, this.Font, sysScale.Width, stringFormat);
                //g.DrawString(str, this.Font, new SolidBrush(Color.Black), new RectangleF(0, sysScale.Height / 2 - stringSize.Height / 2, sysScale.Width, sysScale.Height), stringFormat);
                Font fnewdegit = new System.Drawing.Font(this.Font.FontFamily, 36.0f, FontStyle.Bold);
                stringSize = g.MeasureString(str, fnewdegit, sysScale.Width, stringFormat);
                g.DrawString(str, fnewdegit, new SolidBrush(Color.Black), new RectangleF(0, (sysScale.Height / 2 - stringSize.Height / 2) - 10, sysScale.Width, sysScale.Height), stringFormat);
                Font fnew = new System.Drawing.Font(this.Font.FontFamily, 28.0f, FontStyle.Regular);
                stringSize = g.MeasureString(strsuffic, fnew, sysScale.Width, stringFormat);
                g.DrawString(strsuffic, fnew, new SolidBrush(Color.Black), new RectangleF(0, 90, sysScale.Width, sysScale.Height), stringFormat);
			}
		}

	}


    public class BarInfo
    {

        public enum Side { Positive, Negative, Both };
        Color darkColor = Color.Black, lightColor = Color.White;
        float percent = 0;
        Side appliedForSide = Side.Both;
        public BarInfo() { }
        public BarInfo(Color darkColor, Color lightColor, float percent, Side appliedForSide)
        {
            this.darkColor = darkColor;
            this.lightColor = lightColor;
            this.percent = percent;
            this.appliedForSide = appliedForSide;
        }

        /// <summary>
        /// DarkColor
        /// </summary>
        public Color DarkColor
        {
            get
            {
                return darkColor;
            }
            set
            {
                darkColor = value;

            }
        }

        /// <summary>
        /// LightColor
        /// </summary>
        public Color LightColor
        {
            get
            {
                return lightColor;
            }
            set
            {
                lightColor = value;

            }
        }

        /// <summary>
        /// Percent
        /// </summary>
        public float Percent
        {
            get
            {
                return percent;
            }
            set
            {
                percent = value;

            }
        }

        /// <summary>
        /// AppliedForSide
        /// </summary>
        public Side AppliedForSide
        {
            get
            {
                return appliedForSide;
            }
            set
            {
                appliedForSide = value;

            }
        }
    }
}
