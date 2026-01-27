using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;

namespace _19___Project___DVLD
{
    public class clsCommonMethods
    {
        public static bool HasErrors(string errorMessage)
        {
            return errorMessage != string.Empty;
        }

        public static void MakeTextBoxFieldRequired(TextBox sender, ErrorProvider errorProvider)
        {
            if (sender.Text == string.Empty)
            {
                errorProvider.SetError(sender, "This field is required");
            }
            else
            {
                errorProvider.SetError(sender, "");
            }
        }


    }


}
