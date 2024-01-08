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

namespace Log_It.Forms
{
    public partial class DisplayAllForm : BaseForm
    {
      
        private bool tanksCreated = false;
        private BarPack[] tanks = null;
        private const int PerLineControls = 8;
 
       
        private static DisplayAllForm instance = null;

        public DisplayAllForm()
        {
            InitializeComponent();

        }

        public static DisplayAllForm Instance()
        {
            if (instance == null)
                instance = new DisplayAllForm();

            return instance;
        }

        public void CreateTanks(int n)
        {
            if (this.tanksCreated) return;
            this.tanks = new BarPack[n];
            int index = 0;
            int noOfLines = (int)Math.Ceiling((float)n / PerLineControls);
            Panel[] panels = new Panel[noOfLines];
            Panel p;
            BarPack tank;
            for (int i = 0; i < noOfLines; i++)
            {
                p = new Panel();
                p.Height = 188;
                p.Dock = DockStyle.Top;
                panels[i] = p;
                for (int j = 0; j < PerLineControls; j++)
                {
                    tank = new BarPack();
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

        /// Tanks
        /// </summary>
        public BarPack[] Tanks
        {
            get
            {
                return this.tanks;
            }

        }

        private void DisplayAllForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }
    }
}
