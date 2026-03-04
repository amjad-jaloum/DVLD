using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class LicensesData
    {
        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClass,
            DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees, 
            bool IsActive, short IssueReason, int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string qeruy = @"INSERT INTO [dbo].[Licenses]
                           ([ApplicationID]
                           ,[DriverID] 
                           ,[LicenseClass]
                           ,[IssueDate]
                           ,[ExpirationDate]
                           ,[Notes]
                           ,[PaidFees]
                           ,[IsActive]
                           ,[IssueReason]
                           ,[CreatedByUserID])
                     VALUES
                           (@ApplicationID
                           ,@DriverID
                           ,@LicenseClass
                           ,@IssueDate
                           ,@ExpirationDate
                           ,@Notes
                           ,@PaidFees
                           ,@IsActive
                           ,@IssueReason
                           ,@CreatedByUserID);


                                SELECT SCOPE_IDENTITY();
                                ";
            SqlCommand command = new SqlCommand(qeruy, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@DriverID", DriverID);
            command.Parameters.AddWithValue("@LicenseClass", LicenseClass);
            command.Parameters.AddWithValue("@IssueDate", IssueDate);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);

            if (Notes != string.Empty)
                command.Parameters.AddWithValue("@Notes", Notes);
            else
                command.Parameters.AddWithValue("@Notes", DBNull.Value);

            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@IsActive", IsActive);
            command.Parameters.AddWithValue("@IssueReason", IssueReason);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

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
