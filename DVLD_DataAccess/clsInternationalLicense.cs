using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccess
{
    public class clsInternationalLicense
    {
        public static DataTable GetInternationalDrivingLicensApplications()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT 
                               [InternationalLicenseID] as 'Int.License ID'
                              ,[ApplicationID] as 'Application ID'
                              ,[DriverID] as 'Driver ID'
                              ,[IssuedUsingLocalLicenseID] as 'L.License ID'
                              ,[IssueDate] as 'Issue Date' 
                              ,[ExpirationDate] as 'Expiration Date'
                              ,[IsActive] as 'Is Acitve'
      
                            FROM [DVLD].[dbo].[InternationalLicenses]";

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
            catch (Exception) { }
            finally
            {
                connection.Close();
            }
            return dt;
        }
        public static List<string> InternationalDrivingColumns()
        {
            List<string> list = new List<string>();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'InternationalLicenses'";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    //if ((string)reader["COLUMN_NAME"] == "ClassName" || (string)reader["COLUMN_NAME"] == "ApplicationDate" | (string)reader["COLUMN_NAME"] == "PassedTestCount")
                    //    continue;

                    list.Add((string)reader["COLUMN_NAME"]);
                }
                reader.Close();
            }
            catch (Exception) { }
            finally { connection.Close(); }

            return list;

        }
        public static DataTable GetDataTableWithQuery(string ColumnName, string value)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = $"select * from InternationalLicenses where {ColumnName} like @value";
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
        public static bool DeleteInternationalDrivingLicenseApplication(int InternationalLicenseID)
        {
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "delete from InternationalLicenses where [InternationalLicenseID] = @InternationalLicenseID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

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
        public static int AddNewInternationalDrivingApplication(int applicationID, int driverID, int issuedUsingLocalLicenseID,
            DateTime issueDate, DateTime expirationDate, bool isActive, int createdByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
                            INSERT INTO [dbo].[InternationalLicenses]
                                       ([ApplicationID]
                                       ,[DriverID]
                                       ,[IssuedUsingLocalLicenseID]
                                       ,[IssueDate]
                                       ,[ExpirationDate]
                                       ,[IsActive]
                                       ,[CreatedByUserID])
                                 VALUES
                                       (@applicationID
                                       ,@driverID
                                       ,@issuedUsingLocalLicenseID
                                       ,@issueDate
                                       ,@expirationDate
                                       ,@isActive
                                       ,@createdByUserID)

                            SELECT SCOPE_IDENTITY();
                            ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@applicationID", applicationID);
            command.Parameters.AddWithValue("@driverID", driverID);
            command.Parameters.AddWithValue("@issuedUsingLocalLicenseID", issuedUsingLocalLicenseID);
            command.Parameters.AddWithValue("@issueDate", issueDate);
            command.Parameters.AddWithValue("@expirationDate", expirationDate);
            command.Parameters.AddWithValue("@isActive", isActive);
            command.Parameters.AddWithValue("@createdByUserID", createdByUserID);

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
            catch (Exception) { }
            finally
            {
                connection.Close();
            }
            return -1;

        }

        public static bool IsInternationalLicenseExists(int IssuedUsingLocalLicenseID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"  select R = 'found'
                                  from [InternationalLicenses]
                                  where exists
                                    (select top 1 InternationalLicenseID where IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
            }
            catch (Exception) { }
            {
                connection.Close();
            }
            return false;
        }

        public static bool FindLicenseByLocalLicenseID(ref int InternationalLicenseID, ref int ApplicationID, ref int DriverID, int IssuedUsingLocalLicenseID,
            ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
                            SELECT [InternationalLicenseID]
                                  ,[ApplicationID]
                                  ,[DriverID]
                                  ,[IssuedUsingLocalLicenseID]
                                  ,[IssueDate]
                                  ,[ExpirationDate]
                                  ,[IsActive]
                                  ,[CreatedByUserID]
                              FROM [DVLD].[dbo].[InternationalLicenses]
                              where IssuedUsingLocalLicenseID = @IssuedUsingLocalLicenseID
                            ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@IssuedUsingLocalLicenseID", IssuedUsingLocalLicenseID);

            bool isFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    InternationalLicenseID = (int)reader["InternationalLicenseID"];
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                reader.Close();
            }
            catch (Exception)
            {
                isFound = false;
            }
            finally { connection.Close(); }
            return isFound;
        }

        public static bool FindLicenseByInternationalLicenseID(int InternationalLicenseID, ref int ApplicationID, ref int DriverID,ref int IssuedUsingLocalLicenseID,
            ref DateTime IssueDate, ref DateTime ExpirationDate, ref bool IsActive, ref int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
                            SELECT [InternationalLicenseID]
                                  ,[ApplicationID]
                                  ,[DriverID]
                                  ,[IssuedUsingLocalLicenseID]
                                  ,[IssueDate]
                                  ,[ExpirationDate]
                                  ,[IsActive]
                                  ,[CreatedByUserID]
                              FROM [DVLD].[dbo].[InternationalLicenses]
                              where InternationalLicenseID = @InternationalLicenseID
                            ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@InternationalLicenseID", InternationalLicenseID);

            bool isFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    IssuedUsingLocalLicenseID = (int)reader["issuedUsingLocalLicenseID"];
                    ApplicationID = (int)reader["ApplicationID"];
                    DriverID = (int)reader["DriverID"];
                    IssueDate = (DateTime)reader["IssueDate"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    IsActive = (bool)reader["IsActive"];
                    CreatedByUserID = (int)reader["CreatedByUserID"];
                }
                reader.Close();
            }
            catch (Exception)
            {
                isFound = false;
            }
            finally { connection.Close(); }
            return isFound;
        }

        public static DataTable GetInternationalLicesnsHistory(int driverID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = $"select * from InternationalLicenses where driverID like @driverID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@driverID", driverID);

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
    }
}
