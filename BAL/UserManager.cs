using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{

    public class UserManager
    {
        LogitInstance _instance;
        public UserManager(LogitInstance instance)
        {

            _instance = instance;
        }

        public IQueryable<User> GetAll()
        {
            return _instance.DataLink.Users.Where(x => x.IsRowEnable == true);
        }
        public User GetByUserName(string name)
        {
            return _instance.DataLink.Users.SingleOrDefault(x => x.User_Name == name);

        }

        public int AddUser(User user)
        {
            try
            {
                if (_instance.DataLink.Connection.State == System.Data.ConnectionState.Closed)
                {
                    _instance.DataLink.Connection.Open();
                }
                _instance.DataLink.Users.InsertOnSubmit(user);
                _instance.DataLink.SubmitChanges();
                return 0;
            } 
            catch (Exception)
            {
                throw;
            }
        }

        public int UpdateUser(User newuser, User currentuser)
        {
             User user = _instance.DataLink.Users.SingleOrDefault(x => x.User_Name == currentuser.User_Name && currentuser.IsRowEnable == true);
            user.ModefiedBy = newuser.CreatedBy;
            user.ModifiedDateTime = DateTime.Now;
            user.IsRowEnable = false;
            this.AddUser(newuser);
            //_instance.DataLink.Device_Configs.InsertOnSubmit(_device);
            //this.Clone(current_device);
            return 0;
        }
    }
}
