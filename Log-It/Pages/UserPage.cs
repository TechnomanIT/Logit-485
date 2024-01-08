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
    public partial class UserPage : ControlPage
    {
        public delegate void SetID(int id);
        public event SetID IDSet;
        int width;
        BAL.LogitInstance instance;
        public UserPage(BAL.LogitInstance instance)
        {
            InitializeComponent();
             width = dataGridView2.Width / 5;
          this.instance = instance;
            Refresh();
        }
        public override void RefreshPage()
        {
            try
            {
                base.RefreshPage();
                if (instance.DataLink.Users.Count() > 0)
                {
                    List<Use> users = new List<Use>();
                    bindingSource1.DataSource = instance.DataLink.Users.Where(x => x.Active == true && x.Role != 0);
                    bindingSource1.Sort = "Id ASC";
                    dataGridView2.DataSource = bindingSource1;



                    dataGridView2.Columns[1].Width = width;
                    dataGridView2.Columns[10].Width = width;
                    dataGridView2.Columns[11].Width = width;
                    dataGridView2.Columns[12].Width = width;
                    dataGridView2.Columns[0].Visible = false;
                    dataGridView2.Columns[2].Visible = false;
                    dataGridView2.Columns[3].Visible = false;
                    dataGridView2.Columns[4].Visible = false;
                    dataGridView2.Columns[5].Visible = false;
                    dataGridView2.Columns[6].Visible = false;
                    dataGridView2.Columns[7].Visible = false;
                    dataGridView2.Columns[8].Visible = false;
                    dataGridView2.Columns[9].Visible = false;
                    dataGridView2.Columns[13].Visible = true;
                    dataGridView2.Columns[14].Visible = true;
                    dataGridView2.Columns[15].Visible = false;
                    dataGridView2.Columns[17].Visible = false;
                  
                    //  dataGridView2.Sort(dataGridView2.Columns[0], ListSortDirection.Ascending);

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

       

        public class Use
        {
            public string Full_Name;
            public string Description;
            public string UserID;
            public string Authority;



        }

        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (IDSet != null)
                {
                    IDSet((int)dataGridView2.Rows[e.RowIndex].Cells[0].Value);
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
