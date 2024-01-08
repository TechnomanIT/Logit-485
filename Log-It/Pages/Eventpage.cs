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
    public partial class Eventpage : ControlPage
    {
        BAL.LogitInstance instance;
        public Eventpage(BAL.LogitInstance instance )
        {
            InitializeComponent();
            this.instance = instance;
            RefreshPage();
            
        }
        public override void RefreshPage()
        {
            base.RefreshPage();
            int wi = dataGridView1.Size.Width;
            //if (instance.DataLink.EventLogs.Count() > 0)
            //{
                bindingSource1.DataSource = instance.DataLink.EventLogs.OrderByDescending(p => p.DateTime);

                dataGridView1.DataSource = bindingSource1;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].HeaderText = "Date Time";
                dataGridView1.Columns[1].Width = wi / 4;
                dataGridView1.Columns[2].HeaderText = "User";
                dataGridView1.Columns[3].HeaderText = "Event";
                dataGridView1.Columns[4].HeaderText = "Message";
                dataGridView1.Columns[4].Width = wi / 2;
                dataGridView1.Refresh();
            
                //this.dataGridView1.Sort(this.dataGridView1.Columns[1], ListSortDirection.Descending);
    
            //}
        }
      

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(this.dataGridView1.Width, this.dataGridView1.Height);
            dataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.dataGridView1.Width, this.dataGridView1.Height));
            e.Graphics.DrawImage(bm, 0, 0);
        }

        public void PrintDoc()
        {
            printDocument1.Print();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
