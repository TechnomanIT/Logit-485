using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Log_It.Pages.TaskPanel
{
    public partial class UserTask : TaskControl
    {
        public delegate void UserAdd();
        public event UserAdd AddUser;

        public delegate void UserModfied();
        public event UserModfied ModifiedUser;

        public delegate void UserDelete();
        public event UserDelete DeleteUser;
        int user;
        BAL.LogitInstance instance;
        bool isNew;

        public UserTask(int id, BAL.LogitInstance instance)
        {
            this.user = id;
            this.instance = instance;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Log_It.Forms.UserForm form = new Forms.UserForm(0, instance, true);
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (AddUser != null)
                {
                    AddUser();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ModifiedUser != null)
            {
                ModifiedUser();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (DeleteUser != null)
            {
                DeleteUser();
            }
        }
    }
}
