using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;

namespace Log_It.CustomControls
{
    /// <summary>
    /// Summary description for BarPack.
    /// </summary>
    /// 
    //[DebuggerNonUserCode()]
    public class BarPack : System.Windows.Forms.UserControl
    {
        private float max, min, lLimit, uLimit;
        string unit = " °C";
        private RealTimeBar realTimeBarLLimit;
        private  RealTimeBar realTimeBarCurrentData;
        private System.Windows.Forms.Label lblCaption;
        public System.Windows.Forms.PictureBox picTimeOut;
        private Label labelHi;
        private Label labelLow;
        private Timer tmrTimeOut;
        private bool alaramActive;
        public bool isRed;
        private string tag;
        private TimeSpan lastRecord;
        public Timer timer1;
        private RealTimeBar realTimeBarULimit;

        public Stopwatch stopWatch = new Stopwatch();
        //public bool isSendMail = false;
        //public  bool isComeNormailCond = false;
        //public  DateTime dtLastScan;

        private System.ComponentModel.IContainer components;


        public BarPack()
        {
            // This call is required by the Windows.Forms Form Designer.
            InitializeComponent();
         
           
            this.realTimeBarCurrentData.BarInfos = new BarInfo[] 
            { new  BarInfo(Color.Yellow,Color.FromArgb(0, 176, 80),0, BarInfo.Side.Negative),
                new  BarInfo(Color.Yellow,Color.FromArgb(0, 176, 80),0, BarInfo.Side.Positive),
                new  BarInfo(Color.Yellow,Color.Orange,75, BarInfo.Side.Negative),
                new  BarInfo(Color.Orange ,Color.Yellow,75, BarInfo.Side.Positive),
                new  BarInfo(Color.Orange,Color.Red,100, BarInfo.Side.Negative),
                new BarInfo(Color.Red ,Color.Orange,100, BarInfo.Side.Positive)};
            lblCaption.TextAlign = ContentAlignment.MiddleCenter;
            //timer1.Enabled = true;
            // TODO: Add any initialization after the InitializeComponent call

        }

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }


        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BarPack));
            this.lblCaption = new System.Windows.Forms.Label();
            this.labelHi = new System.Windows.Forms.Label();
            this.labelLow = new System.Windows.Forms.Label();
            this.tmrTimeOut = new System.Windows.Forms.Timer(this.components);
            this.picTimeOut = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.realTimeBarCurrentData = new Log_It.CustomControls.RealTimeBar();
            this.realTimeBarLLimit = new Log_It.CustomControls.RealTimeBar();
            this.realTimeBarULimit = new Log_It.CustomControls.RealTimeBar();
            ((System.ComponentModel.ISupportInitialize)(this.picTimeOut)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCaption
            // 
            this.lblCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(155)))), ((int)(((byte)(213)))));
            this.lblCaption.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCaption.ForeColor = System.Drawing.Color.Black;
            this.lblCaption.Location = new System.Drawing.Point(4, 4);
            this.lblCaption.Name = "lblCaption";
            this.lblCaption.Size = new System.Drawing.Size(150, 25);
            this.lblCaption.TabIndex = 3;
            this.lblCaption.Text = "Temprature";
            this.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelHi
            // 
            this.labelHi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(155)))), ((int)(((byte)(213)))));
            this.labelHi.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHi.ForeColor = System.Drawing.Color.Black;
            this.labelHi.Location = new System.Drawing.Point(4, 179);
            this.labelHi.Name = "labelHi";
            this.labelHi.Size = new System.Drawing.Size(75, 25);
            this.labelHi.TabIndex = 6;
            this.labelHi.Text = "Hi ";
            this.labelHi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelLow
            // 
            this.labelLow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(155)))), ((int)(((byte)(213)))));
            this.labelLow.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLow.ForeColor = System.Drawing.Color.Black;
            this.labelLow.Location = new System.Drawing.Point(79, 179);
            this.labelLow.Name = "labelLow";
            this.labelLow.Size = new System.Drawing.Size(75, 25);
            this.labelLow.TabIndex = 7;
            this.labelLow.Text = "Hi ";
            this.labelLow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tmrTimeOut
            // 
            this.tmrTimeOut.Enabled = true;
            this.tmrTimeOut.Interval = 10000;
            this.tmrTimeOut.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // picTimeOut
            // 
            this.picTimeOut.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picTimeOut.Image = ((System.Drawing.Image)(resources.GetObject("picTimeOut.Image")));
            this.picTimeOut.Location = new System.Drawing.Point(4, 29);
            this.picTimeOut.Name = "picTimeOut";
            this.picTimeOut.Size = new System.Drawing.Size(150, 150);
            this.picTimeOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picTimeOut.TabIndex = 5;
            this.picTimeOut.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // realTimeBarCurrentData
            // 
            this.realTimeBarCurrentData.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.realTimeBarCurrentData.BackColor = System.Drawing.Color.White;
            this.realTimeBarCurrentData.BarColorDark = System.Drawing.Color.Black;
            this.realTimeBarCurrentData.BarColorLight = System.Drawing.Color.White;
            this.realTimeBarCurrentData.BarDirection = Log_It.CustomControls.RealTimeBar.Direction.Vertical;
            this.realTimeBarCurrentData.BarInfos = null;
            this.realTimeBarCurrentData.Font = new System.Drawing.Font("Microsoft Sans Serif", 32.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.realTimeBarCurrentData.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.realTimeBarCurrentData.LLimit = 0F;
            this.realTimeBarCurrentData.Location = new System.Drawing.Point(4, 29);
            this.realTimeBarCurrentData.Max = 100F;
            this.realTimeBarCurrentData.Min = 0F;
            this.realTimeBarCurrentData.Name = "realTimeBarCurrentData";
            this.realTimeBarCurrentData.NumberFormat = "00.0;-00.0";
            this.realTimeBarCurrentData.Size = new System.Drawing.Size(150, 150);
            this.realTimeBarCurrentData.Suffix = " °C";
            this.realTimeBarCurrentData.TabIndex = 2;
            this.realTimeBarCurrentData.ULimit = 100F;
            this.realTimeBarCurrentData.Value = 0F;
            this.realTimeBarCurrentData.VerticalDisplay = false;
            this.realTimeBarCurrentData.Resize += new System.EventHandler(this.realTimeBarCurrentData_Resize);
            // 
            // realTimeBarLLimit
            // 
            this.realTimeBarLLimit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.realTimeBarLLimit.BackColor = System.Drawing.Color.White;
            this.realTimeBarLLimit.BarColorDark = System.Drawing.Color.DarkOrange;
            this.realTimeBarLLimit.BarColorLight = System.Drawing.Color.Red;
            this.realTimeBarLLimit.BarDirection = Log_It.CustomControls.RealTimeBar.Direction.Vertical;
            this.realTimeBarLLimit.BarInfos = null;
            this.realTimeBarLLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.realTimeBarLLimit.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.realTimeBarLLimit.LLimit = 30F;
            this.realTimeBarLLimit.Location = new System.Drawing.Point(7, 109);
            this.realTimeBarLLimit.Max = 100F;
            this.realTimeBarLLimit.Min = 0F;
            this.realTimeBarLLimit.Name = "realTimeBarLLimit";
            this.realTimeBarLLimit.NumberFormat = "";
            this.realTimeBarLLimit.Size = new System.Drawing.Size(150, 25);
            this.realTimeBarLLimit.Suffix = " °C";
            this.realTimeBarLLimit.TabIndex = 0;
            this.realTimeBarLLimit.ULimit = 70F;
            this.realTimeBarLLimit.Value = 0F;
            this.realTimeBarLLimit.VerticalDisplay = false;
            this.realTimeBarLLimit.Visible = false;
            // 
            // realTimeBarULimit
            // 
            this.realTimeBarULimit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.realTimeBarULimit.BackColor = System.Drawing.Color.White;
            this.realTimeBarULimit.BarColorDark = System.Drawing.Color.Red;
            this.realTimeBarULimit.BarColorLight = System.Drawing.Color.DarkOrange;
            this.realTimeBarULimit.BarDirection = Log_It.CustomControls.RealTimeBar.Direction.Vertical;
            this.realTimeBarULimit.BarInfos = null;
            this.realTimeBarULimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.realTimeBarULimit.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.realTimeBarULimit.LLimit = 30F;
            this.realTimeBarULimit.Location = new System.Drawing.Point(4, 122);
            this.realTimeBarULimit.Max = 100F;
            this.realTimeBarULimit.Min = 0F;
            this.realTimeBarULimit.Name = "realTimeBarULimit";
            this.realTimeBarULimit.NumberFormat = "";
            this.realTimeBarULimit.Size = new System.Drawing.Size(150, 25);
            this.realTimeBarULimit.Suffix = " °C";
            this.realTimeBarULimit.TabIndex = 1;
            this.realTimeBarULimit.ULimit = 70F;
            this.realTimeBarULimit.Value = 100F;
            this.realTimeBarULimit.VerticalDisplay = false;
            this.realTimeBarULimit.Visible = false;
            // 
            // BarPack
            // 
            this.Controls.Add(this.picTimeOut);
            this.Controls.Add(this.realTimeBarCurrentData);
            this.Controls.Add(this.labelLow);
            this.Controls.Add(this.labelHi);
            this.Controls.Add(this.realTimeBarLLimit);
            this.Controls.Add(this.realTimeBarULimit);
            this.Controls.Add(this.lblCaption);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "BarPack";
            this.Padding = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.Size = new System.Drawing.Size(158, 220);
            ((System.ComponentModel.ISupportInitialize)(this.picTimeOut)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private void realTimeBarCurrentData_Resize(object sender, System.EventArgs e)
        {
            this.picTimeOut.Left = this.realTimeBarCurrentData.Left;
            this.picTimeOut.Top = this.realTimeBarCurrentData.Top;
            this.picTimeOut.Width = this.realTimeBarCurrentData.Width;
            this.picTimeOut.Height = this.realTimeBarCurrentData.Height;
        }

        private void tmrTimeOut_Tick(object sender, System.EventArgs e)
        {
            this.picTimeOut.Visible = true;
            this.tmrTimeOut.Enabled = false;
        }

        //public string Tag
        //{
        //    set
        //    {
        //        picTimeOut.Tag = (string)value;
        //    }
        //}

        public bool AlaramActive
        { get
        { return alaramActive; }

            set {
                alaramActive = value;
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
                lLimit = value;
                this.realTimeBarCurrentData.LLimit = this.realTimeBarLLimit.Value = value;
                this.labelLow.Text = "Min: " + value.ToString();

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
                unit = value;
                this.realTimeBarCurrentData.Suffix = this.realTimeBarLLimit.Suffix = this.realTimeBarULimit.Suffix = value;
               // this.labelunit.Text = value;
            }
        }

        /// <summary>
        /// NumericFormat
        /// </summary>
        public string NumericFormat
        {
            get
            {
                return this.realTimeBarCurrentData.NumberFormat;
            }
            set
            {

                this.realTimeBarCurrentData.NumberFormat = value;

            }
        }



        /// <summary>
        /// Caption
        /// </summary>
        public string Caption
        {
            get
            {
                return this.lblCaption.Text;
            }
            set
            {
                this.lblCaption.Text = value;
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

                this.lblCaption.Text = inputStr;
                lblCaption.Enabled = true;
                lblCaption.Visible = true;

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
                uLimit = value;
                this.realTimeBarCurrentData.ULimit = this.realTimeBarULimit.Value = value;
                this.labelHi.Text = "Max: " + value.ToString();
            }
        }

        /// <summary>
        /// Value
        /// </summary>
        public float Value
        {
            get
            {
                return this.realTimeBarCurrentData.Value;
            }
            set
            {
                this.realTimeBarCurrentData.Value = value;
                this.picTimeOut.Visible = false;
                //if (this.tmrTimeOut.Enabled)
                //    this.tmrTimeOut.Enabled = false;
                //this.tmrTimeOut.Enabled = true;
                stopWatch.Restart();
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
                min = value;
                this.realTimeBarCurrentData.Min = this.realTimeBarLLimit.Min = this.realTimeBarULimit.Min = min;
            }
        }

        /// <summary>
        /// BackgroundColor
        /// </summary>
        public Color BackgroundColor
        {
            get
            {
                return this.lblCaption.BackColor;
            }
            set
            {
                this.lblCaption.BackColor = value;
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
                base.Font = value;
                this.realTimeBarCurrentData.Font = new Font(value.FontFamily, 32, value.Style);
                this.lblCaption.Font = new Font(value.FontFamily, 14, value.Style);

                this.realTimeBarULimit.Font = new Font(value.FontFamily, 10, value.Style);
                this.realTimeBarLLimit.Font = new Font(value.FontFamily, 10, value.Style);
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
                max = value;
                this.realTimeBarCurrentData.Max = this.realTimeBarLLimit.Max = this.realTimeBarULimit.Max = max;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (alaramActive && picTimeOut.Visible != true)
            {
                if (!isRed)
                {
                    labelHi.BackColor = Color.Red;
                    lblCaption.BackColor = Color.Red;
                    labelLow.BackColor = Color.Red;
                    //labelunit.BackColor = Color.Red;
                    isRed = true;
                }
                else
                {
                    labelHi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(155)))), ((int)(((byte)(213)))));
                    lblCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(155)))), ((int)(((byte)(213)))));
                    labelLow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(155)))), ((int)(((byte)(213)))));
                    //labelunit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(155)))), ((int)(((byte)(213)))));
                    isRed = false;
                }
                
            }
            else
            {
                labelHi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(155)))), ((int)(((byte)(213)))));
                lblCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(155)))), ((int)(((byte)(213)))));
                labelLow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(155)))), ((int)(((byte)(213)))));
                //labelunit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(155)))), ((int)(((byte)(213)))));
            }
            TimeSpan ts = stopWatch.Elapsed;

            if (ts.Minutes >= 5)
            {
                alaramActive = false;
                picTimeOut.Visible = true;             

            }
        }

      
    }
}
