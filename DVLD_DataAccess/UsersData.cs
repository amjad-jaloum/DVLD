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
        public static bool FindUser(int ID, ref int PersonID, ref string username, ref string password, ref bool isActive)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select * from Users where UserID = @ID";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);

            bool isFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    PersonID = (int)reader["PersonID"];
                    username = (string)reader["Username"];
                    password = (string)reader["Password"];
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
        public static bool DoesUserExist(int PersonID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select R1 = 'found' from Users where PersonID = @PersonID;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            bool isFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    isFound = true;
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
                    if ((string)reader["COLUMN_NAME"] == "Password")
                        continue;

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
        public static DataTable GetDataTableWithQuery(string ColumnName, string value)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = $"select * from Users where {ColumnName} like @value";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@value", '%' + value + '%');

            DataTable dt = new DataTable();
            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.HasRows)
                {
                    dt.Load(reader); // loads all rows at once - read() uses sinbgle row at a time
                }
                reader.Close();
            }
            catch (Exception) { }
            finally { connection.Close(); }

            return dt;
        }
        public static int AddNewUser(int PersonID, string username, string Passwrod, bool IsActive)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
                            INSERT INTO Users
                            VALUES (
                                    @PersonID,
                                    @username,
                                    @Passwrod,
                                    @IsActive);
                            SELECT SCOPE_IDENTITY();
                            ";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@Passwrod", Passwrod);
            command.Parameters.AddWithValue("@IsActive", IsActive);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    connection.Close();
                    return insertedID;
                }
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                connection.Close();
            }
            return -1;
        }
        public static bool UpdateUser(int UserID, string Username, string Password, bool IsActive)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE [dbo].[Users]
                           SET [Username] = @Username
                              ,[Password] = @Password
                              ,[IsActive] = @IsActive
                         WHERE UserID = @UserID;
                        ";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Username", Username);
            command.Parameters.AddWithValue("@Password", Password);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@UserID", UserID);

            int RowsEffected = 0;
            try
            {
                connection.Open();
                RowsEffected = command.ExecuteNonQuery();
            }
            catch (Exception) { }
            finally
            {
                connection.Close();
            }
            return RowsEffected > 0;
        }
        public static bool DeleteUser(int UserID)
        {
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "delete from Users where UserID = @UserID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@UserID", UserID);

            int RowsEffected = -1;
            try
            {
                conn.Open();
                RowsEffected = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally { conn.Close(); }

            return RowsEffected > 0;
        }

    }
}
