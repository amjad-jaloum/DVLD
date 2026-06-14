using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;
using Microsoft.Win32;

namespace _19___Project___DVLD
{
    public class clsGlobal
    {
        public static clsUser CurrentUser;
        private static string _keyPath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
        private static string _valueName = "DVLD";

        public static bool RemeberUsernameAndPassword(string Username, string Password)
        {
            try
            {
                string valueData = Username == string.Empty ? string.Empty : Username + "#//#" + Password;

                Registry.SetValue(_keyPath, _valueName, valueData, RegistryValueKind.String);
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                throw;
            }
        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            try
            {
                string value = Registry.GetValue(_keyPath, _valueName, null) as string;

                if (!string.IsNullOrEmpty(value))
                {
                    string[] result = value.Split(new string[] { "#//#" }, StringSplitOptions.None);
                    Username = result[0];
                    Password = result[1];
                    return true;
                }
                else
                    return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
                return false;
            }
        }
    }
}
