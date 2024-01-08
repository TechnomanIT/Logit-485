using System;
using System.Collections.Generic;
using System.Text;

namespace Technoman.Utilities
{
    public struct WizardDescription
    {
        string header;
        string description;

        /// <summary>
        /// get or set wizard Header.
        /// </summary>
        public string Header
        {
            get { return header; }
            set { header = value; }
        }
        /// <summary>
        /// get or set wizard Description.
        /// </summary>
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
