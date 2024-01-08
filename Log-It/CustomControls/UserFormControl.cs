using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BAL;

namespace Log_It.CustomControls
{
    public partial class UserFormControl : UserControl
    {
        public IEnumerable<Role> Roles { get; set; }
        private BindingSource roleBinder = null;

        [Bindable(true)]
        public BindingSource RoleBinder
        {
            get { return roleBinder; }
            set
            {
                roleBinder = value;
                Roles = roleBinder.Cast<Role>();
            }
        }

        public UserFormControl()
        {
            InitializeComponent();
        }

        private void UserFormControl_Load(object sender, EventArgs e)
        {
            if (!DesignMode)
            {
                foreach (var item in Roles)
                {
                    comboBoxRole.Items.Add(item.RoleName);
                }
            }
        }



        
    }
}
