using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class UsersData
    {
        private static string FilePath = @"E:\Amjad\Mohammed Abu-Hadhoud Courses\19 - Full Real Project\DVLD Project\DVLD_Presentaion\LoginData.txt";
        public static bool SaveUsernameAndPasswordToFile(string username, string password)
        {
            try
            {
                StreamWriter writer = new StreamWriter(FilePath, false);
                writer.Write(username + "," + password);
                writer.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool FindUserByUsername(ref int ID, ref int PersonID, string username, string password, ref bool isActive)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select * from Users where Username = @username and Password = @password";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@password", password);

            bool isFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    ID = (int)reader["UserID"];
                    PersonID = (int)reader["PersonID"];
                    isActive = (bool)reader["IsActive"];
                }
            }
            catch (Exception)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }
        public static void GetSavedLoginData(ref string UserName, ref string Password)
        {
            StreamReader reader = new StreamReader(FilePath);
            string line = reader.ReadToEnd();
            reader.Close();

            if (line != string.Empty)
            {
                string[] values = line.Split(',');
                UserName = values[0];
                Password = values[1];
            }
            else
            {
                UserName = string.Empty;
                Password = string.Empty;
            }
        }

        public static void ResetUsernameAndPasswrodFile()
        {
            StreamWriter writer = new StreamWriter(FilePath);
            writer.Write(string.Empty);
            writer.Close();
        }

        public static DataTable GetAllUsers()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select * from Users";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
                reader.Close();
            }
            catch (Exception)
            {

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public static List<string> GetUsersColumnNames()
        {
            List<string> list = new List<string>();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'Users'";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //if ((string)reader["COLUMN_NAME"] == "ImagePath" || (string)reader["COLUMN_NAME"] == "DateOfBirth")
                    //    continue;

                    list.Add((string)reader["COLUMN_NAME"]);
                }
                reader.Close();
            }
            catch (Exception)
            {
            }
            finally { connection.Close(); }

            return list;
        }

    }
}
