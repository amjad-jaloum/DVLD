using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class InternationalDrivingLicenseApplicatioansData
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

    }
}
