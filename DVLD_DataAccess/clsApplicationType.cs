using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsApplicationType
    {
        public static DataTable GetApplicationTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select * from ApplicationTypes";

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
            catch (Exception ex)
            {
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public static int GetFees(int ApplicationTypeID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT 
                                  [ApplicationFees]
                              FROM [DVLD].[dbo].[ApplicationTypes]
                              where ApplicationTypeID = @ApplicationTypeID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);

            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();
                if (result != null && double.TryParse(result.ToString(), out double value))
                    return (int)value;
            }
            catch (Exception) { }
            finally { connection.Close(); }
            return 0;
        }

        public static bool UpdateAppType(int ID, string title, float fees)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE [dbo].[ApplicationTypes]
                           SET [ApplicationTypeTitle] = @title
                              ,[ApplicationFees] = @fees
                         WHERE ApplicationTypeID = @ID;
                        ";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@title", title);
            command.Parameters.AddWithValue("@fees", fees);
            command.Parameters.AddWithValue("@ID", ID);

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

    }
}
