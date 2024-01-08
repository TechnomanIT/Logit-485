using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BAL
{
    public class Authentication
    {
        PlotterDataContext _dbcontaxt = null;

        public static string GetDec(string s)
        {
            return Cryptography.Decrypt(s);
        }
        public static string GetEc(string s)
        {
            return Cryptography.Encrypt(s);
        }
      
        string Password = null;
        User user = null;

        public Authentication(LogitInstance instance)
        {
           
           _dbcontaxt = instance.DataLink;
        }
        public bool IsUserValid(string username = "a", string password = "a")
        {

            Password = Cryptography.Encrypt(password);
            
            user = _dbcontaxt.Users.SingleOrDefault(x => x.User_Name == username && x.Password == Password && x.Active == true);
            if (user != null)
            {
                return true;
            }
            return false;
        }
        public User GetUser
        {
            get 
            {
                return user;
            }
        }
        public bool UserExists(string user)
        {
            int count = _dbcontaxt.Users.Count(x => x.User_Name == user);
            if (count > 0)
            {
                return true;
            }
            return false;
        }
    }
}
