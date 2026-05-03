using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;

namespace _19___Project___DVLD
{
    public class clsGlobal
    {
        public static clsUser CurrentUser;
        public static bool RemeberUsernameAndPassword(string Username, string Password)
        {
            try
            {
                string currentDirectory = Directory.GetCurrentDirectory();
                string filePath = currentDirectory + @"\data.txt";
                if (Username == string.Empty && File.Exists(filePath))
                {
                    File.Delete(filePath);
                    return true;
                }

                string SavedData = Username + "#//#" + Password;
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    sw.WriteLine(SavedData);
                    return true;
                }
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
                string currentDir = Directory.GetCurrentDirectory();
                string filePath = currentDir + @"\data.txt";
                if (File.Exists(filePath))
                {
                    using (StreamReader sr = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);
                            Username = result[0];
                            Password = result[1];
                        }
                        return true;
                    }
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
