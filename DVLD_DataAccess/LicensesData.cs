using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
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

        public static bool FindLicense(int licenseID, ref int applicationID, ref int driverID,
            ref int licenseClass, ref DateTime issueDate, ref DateTime expirationDate,
            ref string notes, ref decimal paidFees, ref bool isActive,
            ref short issueReason, ref int createdByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select * from Licenses where LicenseID = @licenseID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@licenseID", licenseID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    applicationID = (int)reader["applicationID"];
                    driverID = (int)reader["driverID"];
                    licenseClass = (int)reader["licenseClass"];
                    issueDate = (DateTime)reader["issueDate"];
                    expirationDate = (DateTime)reader["expirationDate"];
                    notes = reader["notes"] == DBNull.Value ? string.Empty : (string)reader["notes"]; // nullable
                    paidFees = (decimal)reader["paidFees"];
                    isActive = (bool)reader["isActive"];
                    issueReason = (byte)reader["issueReason"];
                    createdByUserID = (int)reader["createdByUserID"];

                    reader.Close();
                    return true;
                }
            }
            catch (Exception)
            { }
            finally { connection.Close(); }
            return false;

        }

        public static int GetLicenseID(int LocalDrivingLicenseApplicationID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"  select LicenseID from Licenses
                                  where [ApplicationID] = (
                                      SELECT  [ApplicationID]    
                                      FROM [DVLD].[dbo].[LocalDrivingLicenseApplications]
                                      where LocalDrivingLicenseApplicationID  = @LocalDrivingLicenseApplicationID
                                 )";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int licenseID))
                {
                    return licenseID;
                }
            }
            catch (Exception) { return -1; }
            finally
            {
                connection.Close();
            }
            return 0;
        }
    }
}
