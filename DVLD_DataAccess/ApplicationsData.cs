using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class ApplicationsData
    {
        public static int AddNewApplication(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, short ApplicationStatus, DateTime LastStatusDate, decimal PaidFees, int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
                            INSERT INTO [dbo].[Applications]
                                       ([ApplicantPersonID]
                                       ,[ApplicationDate]
                                       ,[ApplicationTypeID]
                                       ,[ApplicationStatus]
                                       ,[LastStatusDate]
                                       ,[PaidFees]
                                       ,[CreatedByUserID])
                                 VALUES
                                       (@ApplicantPersonID
                                       ,@ApplicationDate
                                       ,@ApplicationTypeID
                                       ,@ApplicationStatus
                                       ,@LastStatusDate
                                       ,@PaidFees
                                       ,@CreatedByUserID);

                            SELECT SCOPE_IDENTITY();
                            ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicantPersonID", ApplicantPersonID);
            command.Parameters.AddWithValue("@ApplicationDate", ApplicationDate);
            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LastStatusDate", LastStatusDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
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

        public static bool Find(int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate, ref int ApplicationTypeID, ref short ApplicationStatus, ref DateTime LastStatusDate, ref decimal PaidFees, ref int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT    [ApplicationID]
                                      ,[ApplicantPersonID]
                                      ,[ApplicationDate]
                                      ,[ApplicationTypeID]
                                      ,[ApplicationStatus]
                                      ,[LastStatusDate]
                                      ,[PaidFees]
                                      ,[CreatedByUserID]
                              FROM [DVLD].[dbo].[Applications]
                              where ApplicationID = @applicationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@applicationID", ApplicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ApplicationID = (int)reader["ApplicationID"];
                    ApplicantPersonID = (int)reader["ApplicantPersonID"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationStatus = (byte)reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    PaidFees = (decimal)reader["paidFees"];
                    CreatedByUserID = (int)reader["createdByUserID"];

                    reader.Close();
                    return true;
                }
            }
            catch (Exception)
            { }
            finally { connection.Close(); }
            return false;
        }

        public static int GetApplicantPersonID(int LocalDrivingLicenseApplicationID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
                            SELECT   ApplicantPersonID
                            FROM         Applications
                            WHERE     (ApplicationID =
                                    (SELECT   ApplicationID
                                    FROM         LocalDrivingLicenseApplications
                                    WHERE     (LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)))
                            ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

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
            }
            finally
            {
                connection.Close();
            }
            return -1;
        }
    }
}
