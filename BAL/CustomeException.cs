using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
    [Serializable]
    public class InvalidException : ApplicationException
    {
        public InvalidException(string name)
        : base(String.Format("Invalid Student Name: {0}", name))
    {

    }


    }
}
