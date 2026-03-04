using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class DriversData
    {
        public static int AddNewDriver(int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string qeruy = @"INSERT INTO [dbo].[Drivers]
                               ([PersonID]
                               ,[CreatedByUserID]
                               ,[CreatedDate])
                            VALUES
                               (@PersonID
                               ,@CreatedByUserID
                               ,@CreatedDate);

                                SELECT SCOPE_IDENTITY();
                                ";
            SqlCommand command = new SqlCommand(qeruy, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@CreatedDate", CreatedDate);

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

    }
}
