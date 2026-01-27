using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class TestTypesData
    {
        public static DataTable GetTestTypesTypes()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select * from TestTypes";

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
        public static bool UpdateTestType(int TestTypeID, string TestTypeTitle, string TestTypeDescription, float TestTypeFees)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE [dbo].[TestTypes]
                           SET [TestTypeTitle] = @TestTypeTitle
                              ,[TestTypeDescription] = @TestTypeDescription
                              ,[TestTypeFees] = @TestTypeFees
                         WHERE TestTypeID = @TestTypeID;
                        ";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);
            command.Parameters.AddWithValue("@TestTypeDescription", TestTypeDescription);
            command.Parameters.AddWithValue("@TestTypeFees", TestTypeFees);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

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
