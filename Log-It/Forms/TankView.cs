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
    public partial class TankView : Form
    {

        public delegate void FormClose();
        public event FormClose close;

        private bool tanksCreated = false;
        private CustomControls.BarPack[] tanks = null;
        private const int PerLineControls = 8;
        private static TankView instance = null;
        public static TankView Instance()
        {
            if (instance == null)
                instance = new TankView();

            return instance;
        }

        public TankView()
        {
            InitializeComponent();
        }

        public void CreateTanks(int n)
        {
            if (this.tanksCreated) return;
            this.tanks = new CustomControls.BarPack[n];
            int index = 0;
            int noOfLines = (int)Math.Ceiling((float)n / PerLineControls);
            Panel[] panels = new Panel[noOfLines];
            Panel p;
            CustomControls.BarPack tank;
            for (int i = 0; i < noOfLines; i++)
            {
                p = new Panel();
                p.Height = 250;
                p.Dock = DockStyle.Top;
                panels[i] = p;
                for (int j = 0; j < PerLineControls; j++)
                {
                    tank = new CustomControls.BarPack();
                    tank.Dock = DockStyle.Left;
                    p.Controls.Add(tank);
                    tanks[index] = tank;
                    index++;
                    if (index >= n) break;
                }
            }
            for (int i = noOfLines - 1; i >= 0; i--)
                this.Controls.Add(panels[i]);
            this.tanksCreated = true;
        }

        public void ApplyFont(Font f)
        {
            foreach (System.Windows.Forms.Control c in this.tanks)
                c.Font = f;

        }

        public CustomControls.BarPack[] Tanks
        {
            get
            {
                return this.tanks;
            }

        }

        private void TankView_Load(object sender, EventArgs e)
        {
            this.Size = new Size(this.MdiParent.Size.Width, this.MdiParent.Size.Height);
        }

        private void TankView_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (close != null)
            {
                
                close();
                
            }
        }

    }
}
