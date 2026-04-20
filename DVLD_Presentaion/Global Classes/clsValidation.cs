using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _19___Project___DVLD.Global_Classes
{
    public class clsValidation
    {
        public static bool ValidateEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9.!#$%&'*+=/=?^_`{|}~]+
                                @[a-zA-Z0-9]+(?:\.[a-zA-Z0-9-]+)*$";

            var regex = new Regex(pattern);
            return regex.IsMatch(email);
        }

        public static bool ValidateIneger(string number)
        {
            string pattern = @"^[0-9]*$";
            var regex = new Regex(pattern);
            return regex.IsMatch(number);
        }

        public static bool ValidateFloat(string number)
        {
            string pattern = @"^[0-9]*(?:\.[0-9]*)?$";
            var regex = new Regex(pattern);
            return regex.IsMatch(number);
        }

        public static bool IsNumber(string number)
        {
            return ValidateIneger(number) || ValidateFloat(number);
        }
    }
}
