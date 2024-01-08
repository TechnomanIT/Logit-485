using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace LogitService
{
    public class Authentication
    {
   

        public static string GetDec(string s)
        {
            return Cryptography.Decrypt(s);
        }
        public static string GetEc(string s)
        {
            return Cryptography.Encrypt(s);
        }
    }
}
