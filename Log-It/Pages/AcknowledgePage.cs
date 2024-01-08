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
    public partial class AcknowledgePage : UserControl
    {
        int rowindex;
        BAL.LogitInstance Instance;
        public AcknowledgePage(BAL.LogitInstance Instance)
        {
            this.Instance = Instance;
            InitializeComponent();
            RefreshPage();
        }

        private void RefreshPage()
        {
            bindingSource1.DataSource = Instance.DataLink.Get_Acknowladge();
            //bindingSource1.DataSource = Instance.DataLink.EventLogs.Where(x => x.UserName != "System  ").OrderBy(p => p.DateTime);

            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[2].HeaderText = "Event";
            dataGridView1.Columns[3].Width = 110;
            dataGridView1.Columns[3].HeaderText = "Date Time";
            dataGridView1.Columns[6].Width = 260;
            dataGridView1.Columns[6].HeaderText = "Description";
            dataGridView1.Columns[7].Width = 360;
            dataGridView1.Columns[7].HeaderText = "Comments";
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void dataGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                var hti = dataGridView1.HitTest(e.X, e.Y);
                dataGridView1.ClearSelection();
                if (hti.RowIndex >= 0)
                {
                    dataGridView1.Rows[hti.RowIndex].Selected = true;
                    rowindex = hti.RowIndex;
                }
            }
        }

        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            string s = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        private void acknowladgeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rowindex < 0)
            {
                return;
            }
            DataGridViewRow row = dataGridView1.Rows[rowindex];
            Log_It.Forms.Ack_DialogBox dialogbox = new Forms.Ack_DialogBox((Guid)row.Cells[0].Value, row.Cells[2].Value.ToString(), (DateTime)row.Cells[3].Value, row.Cells[6].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString());
            if (dialogbox.ShowDialog() == DialogResult.OK)
            {
                DAL.Acknowledge ack = Instance.DataLink.Acknowledges.SingleOrDefault(x => x.ID == (Guid)row.Cells[0].Value);
                ack.Ack_Comments = dialogbox.comments;
                ack.Ack_DateTime = DateTime.Now;
                ack.Ack_User = Instance.UserInstance.Full_Name;
                Instance.DataLink.SubmitChanges();
                //Instance.DataLink.Update_Acknowladge(Instance.UserInstance.Full_Name, (Guid)row.Cells[0].Value, dialogbox.comments);
                RefreshPage();
            }
        }
    }
}
