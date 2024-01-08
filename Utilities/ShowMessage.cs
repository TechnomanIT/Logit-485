using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Technoman.Utilities
{
    [DebuggerNonUserCode]
    public static class ShowMessage
    {
        /// <summary>
        /// show message error
        /// </summary>
        /// <param name="owner">windows form</param>
        /// <param name="msg">show Message to the dialog box</param>
        public static void Message_Error(IWin32Window owner, string msg)
        {
            MessageBox.Show(owner, msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);        
        }
        /// <summary>
        /// show message Information
        /// </summary>
        /// <param name="owner">windows form</param>
        /// <param name="msg">show Message to the dialog box</param>
        public static void Message_Information(IWin32Window owner, string msg)
        {
            MessageBox.Show(owner, msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// show message warning
        /// </summary>
        /// <param name="owner">windows form</param>
        /// <param name="msg">show Message to the dialog box</param>
        public static void Message_Warning(IWin32Window owner, string msg)
        {
            MessageBox.Show(owner, msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        /// <summary>
        /// Show message Error
        /// </summary>
        /// <param name="msg">Show Message to the dialog box</param>
        public static void Message_Error(string msg)
        {
            MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }        
        /// <summary>
        /// show message Information
        /// </summary>
        /// <param name="msg">Show Message to the dialog box</param>
        public static void Message_Information(string msg)
        {
            MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// show message warning
        /// </summary>
        /// <param name="msg">Show Message to the dialog box</param>
        public static void Message_Warning(string msg)
        {
            MessageBox.Show(msg, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        /// <summary>
        /// asked the question through diaglog box
        /// </summary>
        /// <param name="owner">windows Form</param>
        /// <param name="msg">Show Message to the dialog Result</param>
        /// <returns>Dialog Result Yes/No</returns>
        public static DialogResult QuestionBox(IWin32Window owner, string msg)
        {
            return MessageBox.Show(owner, msg, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);        
        }
        /// <summary>
        /// asked the question through diaglog box
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static DialogResult QuestionBox(string msg)
        {
            return MessageBox.Show(msg, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
    }
}
