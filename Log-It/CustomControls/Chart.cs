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
using System.Drawing.Drawing2D;
using System.Globalization;

namespace Log_It.CustomControls
{
    public enum StartingStyle
    {
        New,
        Continuous
    }
    public enum PlottingMode
    {
        Realtime = 0,
        Logging = 1,
        LoggingView = 2
    }
    public enum RecordStatus
    {
        NoChange = 0,
        Start = 1,
        Stop = 2,
        Change_Interval = 3,
        Improper_Shutdown = 4
    }

    [DebuggerNonUserCode()]
    public partial class Chart : UserControl
    {

         private System.Data.DataTable ChartTable = new DataTable();
        private System.Data.DataRow[] ChartDataArray;

        #region Enums

        public enum NumberSquence
        {
            Temperature,
            Humidity,
            Both
        }

        public enum Time
        {
            Hours_1 = 3,
            Hours_24 = 2,
            OneWeek = 1,
            Days_32 = 0,
            UserDefined_Hours = 4,
            UserDefined_Days = 5
        }
        public enum Graph
        {
            XY,
            Circular
        }




        #endregion



        #region Fields

        private Color minorgrid = Color.LightGray;
        private Color majorgrid = Color.Silver;
        private Color partcolor = Color.Silver;
        private Color minipartcolor = Color.Gainsboro;
        private Color hfontcolor = Color.Blue;
        private Color tfontcolor = Color.Red;
        private Color tlimitcolor = Color.Red;
        private Color hlimitcolor = Color.RoyalBlue;
        private Color tlinecolor = Color.DarkRed;
        private Color hlinecolor = Color.MediumBlue;
        private Color scalecolor = Color.Gray;
        private Color startlinecolor = Color.DarkGreen;
        private Color stoplinecolor = Color.DarkBlue;
        private Color chintervallinecolor = Color.Green;
        private Color shutdownlinecolor = Color.Yellow;
        private int partitions = 30;
        private int numpartitions = 4;
        private int scalefactor = 60 * 60;
        private int[] points = new int[11];
        private int offsetXtemp = 10;
        private int offsetYtemp = 4;
        private int offsetXrh = 10;
        private int offsetYrh = 4;
        private int finalboundary = 0;
        private int beforefinalboundary = 0;
        private int majorblocksize = 5;
        private float dashlinelength = 10;
        private float dashlinespace = 5;
        private float rotation = 45;
        private float TScaleTimes = 0;
        private float HScaleTimes = 0;
        private double tupperlimit = 100;
        private double tlowerlimit = 0;
        private double hupperlimit = 100;
        private double hlowerlimit = 0;
        private double tempinitial = 0;
        private double tempfinal = 100;
        private double hinitial = 0;
        private double hfinal = 100;
        private double interval = 1;
        private bool tempfirst = true;
        private bool Isautolimit = false;
        private NumberSquence ns = NumberSquence.Both;
        private PlottingMode pm = PlottingMode.Realtime;
        private StartingStyle ss = StartingStyle.New;
        private Time timescale = Time.Hours_1;
        private Graph gh = Graph.Circular;
        private DateTime startDate = DateTime.Now;
      




        #endregion

        #region Properties

        public Color ColorMinorGrid
        {
            get { return minorgrid; }
            set
            {
                minorgrid = value;
                this.Refresh();
            }
        }
        public Color ColorMajorGrid
        {
            get { return majorgrid; }
            set
            {
                majorgrid = value;
                this.Refresh();
            }
        }
        public Color ColorPartition
        {
            get { return partcolor; }
            set
            {
                partcolor = value;
                this.Refresh();
            }
        }

        public Color ColorPartitionMini
        {
            get { return minipartcolor; }
            set
            {
                minipartcolor = value;
                this.Refresh();
            }
        }

        public Color ColorHumidityFont
        {
            get { return hfontcolor; }
            set
            {
                hfontcolor = value;
                this.Refresh();
            }
        }
        public Color ColorTempFont
        {
            get { return tfontcolor; }
            set
            {
                tfontcolor = value;
                this.Refresh();
            }
        }

        public Color ColorTLimit
        {
            get { return tlimitcolor; }
            set
            {
                tlimitcolor = value;
                this.Refresh();
            }
        }

        public Color ColorHLimit
        {
            get { return hlimitcolor; }
            set
            {
                hlimitcolor = value;
                this.Refresh();
            }
        }

        public Color ColorTLine
        {
            get { return tlinecolor; }
            set
            {
                tlinecolor = value;
                this.Refresh();
            }
        }

        public Color ColorHLine
        {
            get { return hlinecolor; }
            set
            {
                hlinecolor = value;
                this.Refresh();
            }
        }

        public Color ColorScale
        {
            get { return scalecolor; }
            set
            {
                scalecolor = value;
                this.Refresh();
            }
        }

        public Color ColorStartLine
        {
            get
            {
                return startlinecolor;
            }
            set
            {
                startlinecolor = value;
                this.Refresh();
            }
        }
        public Color ColorStopLine
        {
            get
            {
                return stoplinecolor;
            }
            set
            {
                stoplinecolor = value;
                this.Refresh();
            }
        }
        public Color ColorChangeIntervalLine
        {
            get
            {
                return chintervallinecolor;
            }
            set
            {
                chintervallinecolor = value;
                this.Refresh();
            }
        }
        public Color ColorShutdownLine
        {
            get
            {
                return shutdownlinecolor;
            }
            set
            {
                shutdownlinecolor = value;
                this.Refresh();
            }
        }
        public int Partitions
        {
            get { return partitions; }
            set
            {
                if (timescale == Time.UserDefined_Hours ||
                    timescale == Time.UserDefined_Days)
                {
                    if (value >= 2 && value <= 32)
                    {
                        partitions = value;
                        if (timescale == Time.UserDefined_Days)
                            scalefactor = partitions * 24 * 60;
                        else
                            scalefactor = partitions * 60;
                        this.Refresh();
                    }
                    else
                    {
                        partitions = 2;
                        timescale = Time.UserDefined_Hours;
                        scalefactor = 120;
                        this.Refresh();
                    }
                    //this.hsChart.Maximum = (((int)timescale)/partitions)-1;					
                }
            }
        }
        public int PartitionsNum
        {
            get { return numpartitions; }
            set
            {
                if (value >= 2)
                    numpartitions = value;
                else
                    numpartitions = 2;
                this.Refresh();
            }
        }
        public int OffSetTempRightLeft
        {
            get
            {
                return this.offsetXtemp;
            }
            set
            {
                this.offsetXtemp = value;
                this.Refresh();
            }
        }
        public int OffSetTempUpDown
        {
            get
            {
                return this.offsetYtemp;
            }
            set
            {
                this.offsetYtemp = value;
                this.Refresh();
            }
        }

        public int OffSetRHRightLeft
        {
            get
            {
                return this.offsetXrh;
            }
            set
            {
                this.offsetXrh = value;
                this.Refresh();
            }
        }
        public int OffSetRHUpDown
        {
            get
            {
                return this.offsetYrh;
            }
            set
            {
                this.offsetYrh = value;
                this.Refresh();
            }
        }

        public int MajorBlockSize
        {
            get
            {
                return majorblocksize;
            }
            set
            {
                if (value >= 1)
                    majorblocksize = value;
                else
                    majorblocksize = 1;
                this.Refresh();
            }
        }
        public float DashLineLength
        {
            get
            {
                return dashlinelength;
            }
            set
            {
                if (value > 0)
                    dashlinelength = value;
                else
                    dashlinelength = 1;
                this.Refresh();
            }
        }
        public float DashLineSpace
        {
            get
            {
                return dashlinespace;
            }
            set
            {
                if (value > 0)
                    dashlinespace = value;
                else
                    dashlinespace = 1;

                this.Refresh();
            }
        }
        public float Rotation
        {
            get
            {
                return rotation * -1;
            }
            set
            {
                rotation = -1 * value;
                this.Refresh();
            }

        }

        public double TempUpperLimitValue
        {
            get { return tupperlimit; }
            set
            {
                if (value <= tlowerlimit)
                    tupperlimit = tempfinal;
                else
                    tupperlimit = value;
                this.Refresh();
            }
        }
        public double TempLowerLimitValue
        {
            get { return tlowerlimit; }
            set
            {
                if (value >= tupperlimit)
                    tlowerlimit = tempinitial;
                else
                    tlowerlimit = value;
                this.Refresh();
            }
        }
        public double HumidityUpperLimitValue
        {
            get { return hupperlimit; }
            set
            {
                if (value < 0.999999 || value > 100 || value < hlowerlimit)

                    hupperlimit = 100;
                else
                    hupperlimit = value;
                this.Refresh();
            }
        }
        public double HumidityLowerLimitValue
        {
            get { return hlowerlimit; }
            set
            {
                if (value < 0 || value > 99.999999 || value > hupperlimit)
                    hlowerlimit = 0;
                else
                    hlowerlimit = value;
                this.Refresh();
            }
        }

        public double TempInitialValue
        {
            get { return tempinitial; }
            set
            {
                if (value < tempfinal)
                    tempinitial = value;
                else
                    tempinitial = tempfinal - 100;
                this.Refresh();
            }
        }
        public double TempFinalValue
        {
            get { return tempfinal; }
            set
            {
                if (value > tempinitial)
                    tempfinal = value;
                else
                    tempfinal = tempinitial + 100;
                this.Refresh();
            }
        }
        public double HumidityInitialValue
        {
            get { return hinitial; }
            set
            {
                if (value < 0 || value > 99.999999 || value > hfinal)
                    hinitial = 0;
                else
                    hinitial = value;
                this.Refresh();
            }
        }
        public double HumidityFinalValue
        {
            get { return hfinal; }
            set
            {
                if (value < 0.999999 || value > 100 || value < hinitial)
                    hfinal = 100;
                else
                    hfinal = value;
                this.Refresh();
            }
        }

        public double Interval
        {
            get
            {
                return interval;
            }
            set
            {
                //interval = IntervalValidity(value);
            }
        }
        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                this.Refresh();
            }
        }
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
        }
        public bool TempFirst
        {
            get
            {
                return tempfirst;
            }
            set
            {
                tempfirst = value;
                this.Refresh();
            }

        }
        public bool AutoLimit
        {
            get
            {
                return Isautolimit;
            }
            set
            {
                Isautolimit = value;
                this.Refresh();
            }
        }

        public NumberSquence Parameters
        {
            get
            {
                return ns;
            }
            set
            {
                ns = value;
                this.Refresh();
            }
        }
        public PlottingMode Mode
        {
            get
            {
                return pm;
            }
            set
            {
                pm = value;
                this.ChartTable.Clear();
                if (pm == PlottingMode.Logging || pm == PlottingMode.LoggingView)
                {
                    if (this.NumTimeScale == Time.Hours_1)
                        this.NumTimeScale = Time.UserDefined_Hours;
                }
                else if (pm == PlottingMode.Realtime)
                {
                    if (this.NumTimeScale != Time.Hours_1)
                        this.NumTimeScale = Time.Hours_1;
                }
                this.Refresh();
            }
        }
        public StartingStyle StartWith
        {
            get
            {
                return ss;
            }
            set
            {
                ss = value;
                this.Refresh();
            }
        }
        public Time NumTimeScale
        {
            get
            {
                return timescale;
            }
            set
            {
                timescale = value;
                if (value == Time.Hours_24)
                {
                    partitions = 24;
                    scalefactor = 24 * 60;
                }
                else if (value == Time.OneWeek)
                {
                    partitions = 7;
                    scalefactor = 7 * 24 * 60;
                }
                else if (value == Time.Days_32)
                {
                    partitions = 32;
                    scalefactor = 32 * 24 * 60;
                }
                else if (value == Time.Hours_1)
                {
                    this.Mode = PlottingMode.Realtime;
                    partitions = 30;
                    scalefactor = 60 * 60;
                    this.hsChart.Maximum = 0;
                    this.Refresh();
                    return;
                }
                else
                    Partitions = partitions;

                if (this.Mode == PlottingMode.Realtime)
                    this.Mode = PlottingMode.Logging;
                this.hsChart.Maximum = (int)timescale;
                this.Refresh();
            }
        }
        public Graph ChartType
        {
            get
            {
                return gh;
            }
            set
            {
                gh = value;
            }
        }

        #endregion

        public Chart()
        {
            InitializeComponent();
        }

        #region Methods

      


        private void DrawAllCircle(Graphics g, Pen p)
        {
            int a = 0;
            int b = 0;
            int i = 0;
            int j = 100;
            int count = 0;
            /*a = this.picChart.ClientSize.Height;
            if (this.picChart.ClientSize.Height > this.picChart.ClientSize.Width)
                a = this.picChart.ClientSize.Width;*/
            a = 600;
            b = 8;//Convert.ToInt32(Math.Round((double)(a-50)/68.75,0));			
            for (; j <= (a - 50); j += b)
            {
                if (((j - 100) % (b * 5)) == 0)
                {
                    p.Color = majorgrid;
                    try
                    {
                        points[i] = j;
                    }
                    catch
                    { }
                    i++;
                }
                else
                    p.Color = minorgrid;
                g.DrawEllipse(p, -j / 2, -j / 2, j, j);
                count++;
                if (count == 51)
                    break;
            }
            j = a - 55;
            this.beforefinalboundary = j - 45;
            g.DrawEllipse(p, -j / 2, -j / 2, j, j);
            finalboundary = j;
        }

        private void DrawAllPartitions(Graphics g, Pen p)
        {
            p.Color = partcolor;
            Point[] p1 = new Point[partitions];
            Point[] p2 = new Point[partitions];
            int j = 0;
            for (float i = 0; i < 359.9; i = i + 360 / (float)partitions, j++)
            {
                p1[j].X = Convert.ToInt32(100 * Math.Cos((Math.PI / 180) * i) / 2);
                p1[j].Y = Convert.ToInt32(100 * Math.Sin((Math.PI / 180) * i) / 2);
                p2[j].X = Convert.ToInt32((finalboundary) * Math.Cos((Math.PI / 180) * i) / 2);
                p2[j].Y = Convert.ToInt32((finalboundary) * Math.Sin((Math.PI / 180) * i) / 2);

                g.DrawLine(p, p1[j], p2[j]);
            }
            j = 0;
            p.Color = minipartcolor;
            for (float i = (360 / (float)partitions) / 2; i < 359.9; i = i + 360 / (float)partitions, j++)
            {
                p1[j].X = Convert.ToInt32(100 * Math.Cos((Math.PI / 180) * i) / 2);
                p1[j].Y = Convert.ToInt32(100 * Math.Sin((Math.PI / 180) * i) / 2);
                p2[j].X = Convert.ToInt32((finalboundary - 45) * Math.Cos((Math.PI / 180) * i) / 2);
                p2[j].Y = Convert.ToInt32((finalboundary - 45) * Math.Sin((Math.PI / 180) * i) / 2);

                g.DrawLine(p, p1[j], p2[j]);
            }
        }

        private float Scale(double final, double initial)
        {
            return ((finalboundary - 145) / (float)(final - initial));
        }

        private void DrawOutText(Graphics g, Pen p)
        {
            SolidBrush mybrush1 = new SolidBrush(scalecolor);

            Point p3 = new Point();
            float m = 360 / (float)partitions;
            Font fonts = new Font("Times New Roman", 9);
            string times; float rot;
            int t = 1;
            float r = 180f;
            if (timescale == Time.Hours_24 || timescale == Time.UserDefined_Hours)
            {
                times = "Hr";
                rot = 2f;
            }
            else if (timescale == Time.Hours_1)
            {
                times = "Min";
                rot = 2f;
                r = 181.5f;
            }
            else
            {
                times = "Day";
                rot = 3.5f;
            }

            for (float i = r + (m / 2) + rot; i <= r + 359.9f + (m / 2) + rot; )
            {

                p3.X = Convert.ToInt32((finalboundary - 9) * 1 / 2);
                p3.Y = Convert.ToInt32((finalboundary - 9));

                g.RotateTransform(270 - i, MatrixOrder.Prepend);
                g.TranslateTransform(-p3.X, -p3.X * 3, MatrixOrder.Prepend);

                g.DrawString(times + " " + t.ToString(), fonts, mybrush1, p3);

                g.TranslateTransform(p3.X, p3.X * 3, MatrixOrder.Prepend);
                g.RotateTransform(-(270 - i), MatrixOrder.Prepend);

                i += m;
                if (timescale == Time.Hours_1)
                    t += 2;
                else
                    t += 1;
            }
        }

        private void DrawImage(Graphics g)
        {
            Bitmap b = new Bitmap(Log_It.Properties.Resources.Logit);
            //Bitmap b = new Bitmap("");
            b.MakeTransparent(Color.White);
            b.SetResolution(225, 225);
            g.DrawImage(b, new Point(-43, -42));
        }

        private void DrawAllTNum(Graphics g, Pen p, Font myfont, bool Continuous, bool first)
        {
            SolidBrush mybrush1 = new SolidBrush(tfontcolor);
            Point p3 = new Point();
            double c = tempinitial;
            double e1 = (tempfinal - c) / 10;


            for (float i = 0 - rotation; i < 359.9 - rotation; )
            {
                if (!first)
                {
                    i = i + 360 / (float)numpartitions;
                    first = true;
                }
                c = Math.Round(tempinitial, 2);
                for (int j = 0; j <= 10; j++)
                {
                    p3.X = Convert.ToInt32(points[j] * Math.Cos((Math.PI / 180) * 0) / 2);
                    p3.Y = Convert.ToInt32(points[j] * Math.Sin((Math.PI / 180) * 0) / 2);

                    g.RotateTransform(450 - i, MatrixOrder.Prepend);
                    g.TranslateTransform(-p3.X - this.offsetXtemp, -p3.X - this.offsetYtemp, MatrixOrder.Prepend);
                    g.DrawString(c.ToString() + "ºC", myfont, mybrush1, p3);
                    g.TranslateTransform(p3.X + this.offsetXtemp, p3.X + this.offsetYtemp, MatrixOrder.Prepend);
                    g.RotateTransform(-(450 - i), MatrixOrder.Prepend);

                    c += e1;
                    c = Math.Round(c, 2);
                }

                i = i + 360 / (float)numpartitions;
                if (!(i < 359.9 - rotation))
                    break;
                if (!Continuous)
                    i = i + 360 / (float)numpartitions;
            }
        }

        private void DrawAllHNum(Graphics g, Pen p, Font myfont, bool Continuous, bool first)
        {

            SolidBrush mybrush2 = new SolidBrush(hfontcolor);
            Point p4 = new Point();
            double d = hinitial;
            double f = (hfinal - d) / 10;

            for (float i = 0 - rotation; i < 359.9 - rotation; )
            {
                if (!first)
                {
                    i = i + 360 / (float)numpartitions;
                    first = true;
                }
                d = Math.Round(hinitial, 2);
                for (int j = 0; j <= 10; j++)
                {
                    p4.X = Convert.ToInt32(points[j] * Math.Cos((Math.PI / 180) * 0) / 2);
                    p4.Y = Convert.ToInt32(points[j] * Math.Sin((Math.PI / 180) * 0) / 2);

                    g.RotateTransform(450 - i, MatrixOrder.Prepend);
                    g.TranslateTransform(-p4.X - this.offsetXrh, -p4.X - this.offsetYrh, MatrixOrder.Prepend);
                    g.DrawString(d.ToString() + "%", myfont, mybrush2, p4);
                    g.TranslateTransform(p4.X + this.offsetXrh, p4.X + this.offsetYrh, MatrixOrder.Prepend);
                    g.RotateTransform(-(450 - i), MatrixOrder.Prepend);

                    d += f;
                    d = Math.Round(d, 2);
                }

                i = i + 360 / (float)numpartitions;
                if (!(i < 359.9 - rotation))
                    break;

                if (!Continuous)
                    i = i + 360 / (float)numpartitions;
            }
        }

        private void DrawAllNumbers_Lines(Graphics g, Pen p, Font myfont, NumberSquence ns, bool Tfirst)
        {
            if (ns == NumberSquence.Temperature)
            {
                this.DrawLimitLine(g, p, tlimitcolor, tupperlimit, tlowerlimit,
                    tempinitial, tempfinal, TScaleTimes);
                if (this.ChartTable.Rows.Count != 0)
                    if (!DrawLines(g, p, tlinecolor, "TEMP", tempinitial, TScaleTimes))
                    {
                        g.Clear(BackColor);
                        AllDrawingMethods(g, p);
                    }
                this.DrawAllTNum(g, p, myfont, true, true);
                this.tempfirst = true;
            }
            else if (ns == NumberSquence.Humidity)
            {
                this.DrawLimitLine(g, p, hlimitcolor, hupperlimit, hlowerlimit,
                    hinitial, hfinal, HScaleTimes);
                if (this.ChartTable.Rows.Count != 0)
                    if (!DrawLines(g, p, hlinecolor, "RH", hinitial, HScaleTimes))
                    {
                        g.Clear(BackColor);
                        AllDrawingMethods(g, p);
                    }
                this.DrawAllHNum(g, p, myfont, true, true);
                this.tempfirst = false;
            }
            else
            {
                this.DrawLimitLine(g, p, tlimitcolor, tupperlimit, tlowerlimit,
                    tempinitial, tempfinal, TScaleTimes);
                this.DrawLimitLine(g, p, hlimitcolor, hupperlimit, hlowerlimit,
                    hinitial, hfinal, HScaleTimes);
                if (this.ChartTable.Rows.Count != 0)
                {
                    if (!DrawLines(g, p, tlinecolor, "TEMP", tempinitial, TScaleTimes))
                    {
                        g.Clear(BackColor);
                        AllDrawingMethods(g, p);
                    }
                    if (!DrawLines(g, p, hlinecolor, "RH", hinitial, HScaleTimes))
                    {
                        g.Clear(BackColor);
                        AllDrawingMethods(g, p);
                    }
                }
                this.DrawAllTNum(g, p, myfont, false, Tfirst);
                this.DrawAllHNum(g, p, myfont, false, !Tfirst);
            }
        }

        private void DrawLimitLine(Graphics g, Pen p, Color LineColor,
            double ul, double ll, double init, double final, float scaletimes)
        {
            p.Color = LineColor;
            float[] dash = new float[2];
            dash[0] = dashlinelength;
            dash[1] = dashlinespace;
            p.DashPattern = dash;
            p.DashStyle = DashStyle.Custom;
            float du = (float)(ul - final);
            float dl = (float)(ul - init);
            float d = du;
            if (du > 0 || dl < 0)
                d = 0;
            else
                d = d * scaletimes + 500;
            g.DrawEllipse(p, -d / 2, -d / 2, d, d);
            du = (float)(ll - final);
            dl = (float)(ll - init);
            d = dl;
            if (du > 0 || dl < 0)
                d = 0;
            else
                d = d * scaletimes + 100;

            g.DrawEllipse(p, -d / 2, -d / 2, d, d);
            p.DashStyle = DashStyle.Solid;
        }


        private PointF NormalLine(Graphics g, Pen p, Color LineColor, PointF prePoint,
            double RangePoint, ref float j, float angle, int index)
        {
            PointF currentPoint = new PointF();
            p.Color = LineColor;

            if (RangePoint > beforefinalboundary)
            {
                RangePoint = beforefinalboundary;
                p.Color = Color.Transparent;
            }
            else if (RangePoint < 100)
            {
                RangePoint = 100;
                p.Color = Color.Transparent;
            }

            if (index != 0)
            {
                interval = TotalInterval(index);
                j -= angle * (float)interval;

            }
            else
            {
                interval = InitialInterval(0);
                j -= angle * (float)interval;
            }

            if (j < 0)
                return currentPoint;

            currentPoint.X = (float)(RangePoint * Math.Cos((Math.PI / 180) * j) / 2);
            currentPoint.Y = (float)(RangePoint * Math.Sin((Math.PI / 180) * j) / 2);

            if (index != 0)
                g.DrawLine(p, prePoint, currentPoint);

            return currentPoint;
        }

        private PointF StartLine(Graphics g, Pen p, ref float j, float angle,
            double RangePoint, int index)
        {
            PointF prePoint = new PointF();
            PointF currentPoint = new PointF();
            p.Color = startlinecolor;

            if (this.ChartTable.Rows.Count > 0 && index != 0)
            {
                interval = TotalInterval(index);
                j -= angle * (float)interval;
            }
            else if (this.ChartTable.Rows.Count > 0 && index == 0)
            {
                interval = InitialInterval(index);
                j -= angle * (float)interval;
            }

            if (j < 0)
                return currentPoint;

            prePoint.X = (float)(100 * Math.Cos((Math.PI / 180) * j) / 2);
            prePoint.Y = (float)(100 * Math.Sin((Math.PI / 180) * j) / 2);
            currentPoint.X = (float)(beforefinalboundary * Math.Cos((Math.PI / 180) * j) / 2); //600
            currentPoint.Y = (float)(beforefinalboundary * Math.Sin((Math.PI / 180) * j) / 2); //600
            g.DrawLine(p, prePoint, currentPoint);

            currentPoint.X = (float)(RangePoint * Math.Cos((Math.PI / 180) * j) / 2);
            currentPoint.Y = (float)(RangePoint * Math.Sin((Math.PI / 180) * j) / 2);

            interval = TotalInterval(index + 1);


            return currentPoint;
        }
        private PointF StopLine(Graphics g, Pen p, Color LineColor, ref float j, float angle, PointF prePoint, double RangePoint, int index)
        {
            PointF pPoint = new PointF();
            PointF currentPoint = new PointF();
            p.Color = stoplinecolor;

            interval = TotalInterval(index);
            j -= angle * (float)interval;

            if (j < 0)
                return currentPoint;


            pPoint.X = (float)(100 * Math.Cos((Math.PI / 180) * j) / 2);
            pPoint.Y = (float)(100 * Math.Sin((Math.PI / 180) * j) / 2);
            currentPoint.X = (float)(beforefinalboundary * Math.Cos((Math.PI / 180) * j) / 2);
            currentPoint.Y = (float)(beforefinalboundary * Math.Sin((Math.PI / 180) * j) / 2);
            g.DrawLine(p, pPoint, currentPoint);

            p.Color = LineColor;
            if (RangePoint > beforefinalboundary)
            {
                RangePoint = beforefinalboundary;
                p.Color = Color.Transparent;
            }
            else if (RangePoint < 100)
            {
                RangePoint = 100;
                p.Color = Color.Transparent;
            }

            currentPoint.X = (float)(RangePoint * Math.Cos((Math.PI / 180) * j) / 2);
            currentPoint.Y = (float)(RangePoint * Math.Sin((Math.PI / 180) * j) / 2);
            g.DrawLine(p, prePoint, currentPoint);

            return currentPoint;
        }

        private PointF ChangeIntervalLine(Graphics g, Pen p,
            double RangePoint, ref float j, float angle, int index)
        {
            PointF prePoint = new PointF();
            PointF currentPoint = new PointF();
            p.Color = chintervallinecolor;

            interval = TotalInterval(index);

            j -= angle * ((float)interval);

            if (j < 0)
                return currentPoint;

            prePoint.X = (float)(100 * Math.Cos((Math.PI / 180) * j) / 2);
            prePoint.Y = (float)(100 * Math.Sin((Math.PI / 180) * j) / 2);
            currentPoint.X = (float)(beforefinalboundary * Math.Cos((Math.PI / 180) * j) / 2);
            currentPoint.Y = (float)(beforefinalboundary * Math.Sin((Math.PI / 180) * j) / 2);
            g.DrawLine(p, prePoint, currentPoint);

            currentPoint.X = (float)(RangePoint * Math.Cos((Math.PI / 180) * j) / 2);
            currentPoint.Y = (float)(RangePoint * Math.Sin((Math.PI / 180) * j) / 2);



            return currentPoint;
        }

        private PointF ShutdownLine(Graphics g, Pen p, Color LineColor, ref float j, float angle, PointF prePoint, double RangePoint, int index)
        {
            PointF pPoint = new PointF();
            PointF currentPoint = new PointF();
            p.Color = shutdownlinecolor;

            interval = TotalInterval(index);
            j -= angle * (float)interval;

            if (j < 0)
                return currentPoint;

            pPoint.X = (float)(100 * Math.Cos((Math.PI / 180) * j) / 2);
            pPoint.Y = (float)(100 * Math.Sin((Math.PI / 180) * j) / 2);
            currentPoint.X = (float)(beforefinalboundary * Math.Cos((Math.PI / 180) * j) / 2);
            currentPoint.Y = (float)(beforefinalboundary * Math.Sin((Math.PI / 180) * j) / 2);
            g.DrawLine(p, pPoint, currentPoint);

            p.Color = LineColor;
            if (RangePoint > finalboundary)
            {
                RangePoint = finalboundary;
                p.Color = Color.Transparent;
            }
            else if (RangePoint < 100)
            {
                RangePoint = 100;
                p.Color = Color.Transparent;
            }


            currentPoint.X = (float)(RangePoint * Math.Cos((Math.PI / 180) * j) / 2);
            currentPoint.Y = (float)(RangePoint * Math.Sin((Math.PI / 180) * j) / 2);
            g.DrawLine(p, prePoint, currentPoint);
            return currentPoint;
        }


        private bool DrawLines(Graphics g, Pen p, Color color, string Columnname,
                double init, float scaletimes)
        {
            PointF point = new PointF();
            float angle = 360 / ((float)scalefactor);
            double n, val;
            ChartDataArray = ChartTable.Select("");
            try
            {
                string str = this.DataRow4Page();
//                 ChartDataArray = ChartTable.Select(this.DataRow4Page());
                ChartDataArray = ChartTable.Select(str);

                if (ChartDataArray.Length <= 0)
                    return true;
                float j = 360;

                int i = 0;
                RecordStatus rs;
                byte by = 0;

                point.X = 50; point.Y = 0;
                for (; i >= 0 && i < ChartDataArray.Length && j >= 0; i++)
                {
                    val = (double)ChartDataArray[i][Columnname];
                    by = (byte)ChartDataArray[i]["RECORDSTATUS"];
                    rs = (RecordStatus)by;

                    if (Isautolimit && SetAutoLimit(val, Columnname))
                        return false;

                    n = 100 - (init * scaletimes) + (val * scaletimes);

                    if (rs == RecordStatus.NoChange)
                    {
                        point = NormalLine(g, p, color, point, n, ref j, angle, i);
                    }
                    else if (rs == RecordStatus.Start)
                    {
                        point = StartLine(g, p, ref j, angle, n, i);
                    }
                    else if (rs == RecordStatus.Stop)
                    {
                        point = StopLine(g, p, color, ref j, angle, point, n, i);
                    }
                    else if (rs == RecordStatus.Change_Interval)
                    {
                        point = ChangeIntervalLine(g, p, n, ref j, angle, i);
                    }
                    else if (rs == RecordStatus.Improper_Shutdown)
                    {
                        point = ShutdownLine(g, p, color, ref j, angle, point, n, i);
                    }
                }
                if (pm == PlottingMode.Realtime && j < 0)
                    this.ChartTable.Clear();

            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message, "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ChartTable.Clear();
            }
            return true;
        }


        private void GetStartTime()
        {
            if (ChartTable.Rows.Count != 0)
            {
                startDate = Convert.ToDateTime(ChartTable.Rows[0]["DT"]);
                DataRow4Page();
            }
        }

        private string DataRow4Page()
        {
            string selectstring = string.Empty;
            DateTime d, dtm;

            if (pm == PlottingMode.Realtime)
            {
                return selectstring;
                /*d = startDate.AddSeconds(hsChart.Value*scalefactor);	
                dtm = startDate.AddSeconds((hsChart.Value+1)*scalefactor);				*/
            }
            else
            {
                d = startDate.AddMinutes(hsChart.Value * scalefactor);
                dtm = startDate.AddMinutes((hsChart.Value + 1) * scalefactor);
            }
            selectstring = "DT >= #" + d.ToString("MM/dd/yyyy hh:00:00 tt") + "# AND DT <= #" + dtm.ToString("MM/dd/yyyy hh:00:00 tt") + "#";
            return selectstring;
        }

        private double TotalInterval(int index)
        {
            DateTime d1, d2;
            double d = 0;
            try
            {
                if (index < ChartDataArray.Length)
                {
                    d1 = Convert.ToDateTime(ChartDataArray[index]["DT"]);
                    d2 = Convert.ToDateTime(ChartDataArray[index - 1]["DT"]);

                    if (pm == PlottingMode.Realtime)
                        d = d1.Subtract(d2).TotalSeconds;
                    else
                        d = d1.Subtract(d2).TotalMinutes;
                }

                return d;
            }
            catch (Exception)
            {
                throw new Exception("Data points have different interval period.");
            }

        }
        private double InitialInterval(int index)
        {
            DateTime d1;
            d1 = Convert.ToDateTime(ChartDataArray[index]["DT"]);
            double d;
            if (pm == PlottingMode.Realtime)
                d = d1.Minute * 60 + d1.Second;
            else
                d = d1.Minute;
            return d;
        }

        private bool SetAutoLimit(double values, string Columnname)
        {
            if (Columnname == "TEMP")
            {
                if (values > tempfinal)
                {
                    TempFinalValue = values;
                    return true;
                }
                else if (values < tempinitial)
                {
                    TempInitialValue = values;
                    return true;
                }

            }
            else if (Columnname == "RH")
            {
                if (values > hfinal)
                {
                    HumidityFinalValue = values;
                    return true;
                }
                else if (values < hinitial)
                {
                    HumidityInitialValue = values;
                    return true;
                }

            }
            return false;
        }

        private void AllDrawingMethods(Graphics g, Pen p)
        {
            Font myfont = base.Font;
            this.DrawAllCircle(g, p);
            this.DrawAllPartitions(g, p);
            this.DrawOutText(g, p);
            this.DrawImage(g);

            TScaleTimes = Scale(tempfinal, tempinitial);
            HScaleTimes = Scale(hfinal, hinitial);

            this.DrawAllNumbers_Lines(g, p, myfont, ns, tempfirst);
            this.GetStartTime();
            this.DisplayTimeOnPage(g);
        }

        private void DisplayTimeOnPage(Graphics g)
        {
            int index;
            string starttime;
            index = hsChart.Value * scalefactor;
            if (pm == PlottingMode.Realtime)
                starttime = startDate.AddSeconds(index).ToString("dd/MM/yyyy hh:00:00 tt");
            else
                starttime = startDate.AddMinutes(index).ToString("dd/MM/yyyy hh:00:00 tt");
            g.DrawString("Start " + starttime, new Font("Times New Roman", 8), new SolidBrush(Color.Black), 60, -15);
        }

        private void Drawing(Graphics g)
        {
            Pen p = new Pen(Color.Transparent, 1);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.TranslateTransform(this.picChart.Size.Width / 2, this.picChart.Size.Height / 2);
            //g.TranslateTransform(0, this.picChart.Size.Height);						

            g.DrawEllipse(p, -5, -5, 10, 10);

            AllDrawingMethods(g, p);

            //this.DrawAllRectangle(g, p);
            //this.DrawTimeScale(g, p);

        }
        private double IntervalValidity(double val)
        {
            if (timescale == Time.Hours_1)
            {
                if (val >= 1 && val <= 59)
                    return val;
                else
                    return 1;
            }
            else
            {
                if (val >= 1 && val <= 120)
                    return val;
                else
                    return 1;
            }
        }

        public void Chart_Print(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            this.Drawing(e.Graphics);
        }

        public void Chart_Print(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            this.Drawing(e.Graphics);
        }



        public void Add(DataTable dt)
        {
            ChartTable = dt;
            this.Refresh();//picChart.Refresh();
            if (this.Mode == Log_It.CustomControls.PlottingMode.LoggingView)
            {
                this.hsChart.Value = this.hsChart.Maximum - 1;
                this.hsChart.Value = 0;
            }
        }


        #endregion

        #region EventHandler

        private void picChart_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            this.Chart_Print(sender, e);
        }
        private void Chart_Resize(object sender, System.EventArgs e)
        {
            this.Refresh();
        }

        private void Chart_Load(object sender, System.EventArgs e)
        {
            //wdf = new DevExpress.Utils.WaitDialogForm("","",new Size(200, 50));
            //this.oleDbDataAdapter1.Fill(this.dataSet11);
            /*foreach(DataRow r in this.dataSet11.test.Rows)
                Console.WriteLine(r["DT"].ToString());*/
            //this.ChartTable = this.dataSet11.test;
            //wdf.Show();

            //wdf.Close();
        }

        private void picChart_Resize(object sender, System.EventArgs e)
        {
            this.Refresh();
        }


        private void hsChart_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
        {
            //wdf = new DevExpress.Utils.WaitDialogForm("","",new Size(200, 50));			
            //wdf.Show();						
            this.Refresh();
            //wdf.Close();
        }

        private void hsChart_ValueChanged(object sender, System.EventArgs e)
        {
            this.Refresh();
        }


        #endregion
    }
}
