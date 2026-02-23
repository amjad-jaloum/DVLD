using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccess
{
    public class LocalDrivingLicensApplicationsData
    {
        public static double GetAppServiceFee(int ServiceID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
                            select ApplicationFees from ApplicationTypes
                            where ApplicationTypeID = @ServiceID
                            ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ServiceID", ServiceID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && double.TryParse(result.ToString(), out double value))
                {
                    connection.Close();
                    return value;
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
        public static DataTable GetLocalDrivingLicensApplications()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select * from LocalDrivingLicenseApplications_View";

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
        public static List<string> GetLocalLicensesClassNames()
        {
            List<string> list = new List<string>();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select ClassName from LicenseClasses";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add((string)reader["ClassName"]);
                }
                reader.Close();
            }
            catch (Exception)
            {
            }
            finally { connection.Close(); }

            return list;
        }
        public static int AddNewApplication(int ApplicantPersonID, DateTime ApplicationDate, int ApplicationTypeID, short ApplicationStatus, DateTime LastStatusDate, int PaidFees, int CreatedByUserID)
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
        public static int LocalDrivingLicenseApplications(int ApplicationID, int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
                            INSERT INTO [dbo].[LocalDrivingLicenseApplications]
                           ([ApplicationID]
                           ,[LicenseClassID])
                     VALUES
                           (@ApplicationID
                           ,@LicenseClassID)
                            ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

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
        public static bool IsClassNameAvialable(string nationalNo, string className)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"select top 1 Status
                            from LocalDrivingLicenseApplications_View
                            where NationalNo = @nationalNo and ClassName = @className
                            order by ApplicationDate desc";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@nationalNo", nationalNo);
            command.Parameters.AddWithValue("@className", className);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    if (reader["Status"].ToString().Contains("Cancelled"))
                        return true;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally { connection.Close(); }
            return false;
        }
        public static List<string> LocalDrivingColumns()
        {
            List<string> list = new List<string>();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'LocalDrivingLicenseApplications_View'";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if ((string)reader["COLUMN_NAME"] == "ClassName" || (string)reader["COLUMN_NAME"] == "ApplicationDate" | (string)reader["COLUMN_NAME"] == "PassedTestCount")
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
            string query = $"select * from LocalDrivingLicenseApplications_View where {ColumnName} like @value";
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
        public static bool UpdateLocalDrivingLicenseAppStatus(int LocalDrivingLicenseApplicationID, int ApplicationStatus)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"update Applications set ApplicationStatus = @ApplicationStatus
                            where ApplicationID = 
	                            (
		                            select ApplicationID 
		                            from LocalDrivingLicenseApplications 
		                            where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
	                            )
                        ";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

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
        public static string FindLicenceName(int LicenseClassID, string ClassName)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT [ClassName]   
                              FROM [DVLD].[dbo].[LicenseClasses]
                              where LicenseClassID = @LicenseClassID
                        ";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                ClassName = result != null ? result.ToString() : string.Empty;
            }
            catch (Exception)
            {
                ClassName = string.Empty;
            }
            finally { connection.Close(); }
            return ClassName;
        }
        public static bool FindLocalDrivingLicenseApplication(int ApplicationID, ref int ApplicantPersonID, ref DateTime ApplicationDate, ref int ApplicationTypeID, ref short ApplicationStatus, ref DateTime LastStatusDate, ref int PaidFees, ref int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
                            SELECT [ApplicationID]
                              ,[ApplicantPersonID]
                              ,[ApplicationDate]
                              ,[ApplicationTypeID]
                              ,[ApplicationStatus]
                              ,[LastStatusDate]
                              ,[PaidFees]
                              ,[CreatedByUserID]
                          FROM [DVLD].[dbo].[Applications]
                          where ApplicationID = @ApplicationID
                            ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

            bool isFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;

                    ApplicantPersonID = (int)reader["ApplicantPersonID"];
                    ApplicationDate = (DateTime)reader["ApplicationDate"];
                    ApplicationTypeID = (int)reader["ApplicationTypeID"];
                    ApplicationStatus = (byte)reader["ApplicationStatus"];
                    LastStatusDate = (DateTime)reader["LastStatusDate"];
                    PaidFees = (int)(decimal)reader["PaidFees"];
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
        public static int GetApplicationIDFromLocalDrivingLicenseApplications(int localDrivingLicenseAppID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
                            SELECT 
                              [ApplicationID]
                              FROM [DVLD].[dbo].[LocalDrivingLicenseApplications]
                              where LocalDrivingLicenseApplicationID = @localDrivingLicenseAppID
                            ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@localDrivingLicenseAppID", localDrivingLicenseAppID);

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
        public static string getAppTypeName(int ApplicationTypeID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT ApplicationTypeTitle
                            FROM   ApplicationTypes
                            WHERE ([ApplicationTypeID] = @ApplicationTypeID)
                        ";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            string AppTypeName = "";
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                AppTypeName = result != null ? result.ToString() : string.Empty;
            }
            catch (Exception)
            {
                AppTypeName = string.Empty;
            }
            finally { connection.Close(); }
            return AppTypeName;
        }
        public static string getUsername(int UserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT [UserName]
                              FROM [DVLD].[dbo].[Users]
                              where UserID = @UserID
                        ";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserID", UserID);
            string Username = "";
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                Username = result != null ? result.ToString() : string.Empty;
            }
            catch (Exception)
            {
                Username = string.Empty;
            }
            finally { connection.Close(); }
            return Username;
        }
        public static int GetTestFees(string TestTypeTitle)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
                            SELECT 
                                  [TestTypeFees]
                              FROM [DVLD].[dbo].[TestTypes]
                              where TestTypeTitle = @TestTypeTitle
                            ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeTitle", TestTypeTitle);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && double.TryParse(result.ToString(), out double value))
                {
                    connection.Close();
                    return (int)value;
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
        public static bool AddNewTestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID,
            DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string qeruy = @"USE [DVLD]
                                INSERT INTO [dbo].[TestAppointments]
                                           ([TestTypeID]
                                           ,[LocalDrivingLicenseApplicationID]
                                           ,[AppointmentDate]
                                           ,[PaidFees]
                                           ,[CreatedByUserID]
                                           ,[IsLocked])
                                     VALUES
                                           (@TestTypeID
                                           ,@LocalDrivingLicenseApplicationID
                                           ,@AppointmentDate
                                           ,@PaidFees
                                           ,@CreatedByUserID
                                           ,@IsLocked)
                                ";
            SqlCommand command = new SqlCommand(qeruy, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);

            bool isAdded = false;
            try
            {
                connection.Open();
                int rowsEffected = command.ExecuteNonQuery();
                if (rowsEffected > 0)
                    return true;
            }
            catch (Exception)
            {
                isAdded = false;
            }
            finally { connection.Close(); }
            return isAdded;
        }
        public static DataTable LoadTestAppointments(int LocalDrivingLicenseApplicationID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string qeruy = @"SELECT [TestAppointmentID] as 'Appointment ID'
                          ,[AppointmentDate] as 'Appointment Date'
                          ,[PaidFees] as 'Paid Fees'
                          ,[IsLocked] as 'Is Locked'
                          FROM [DVLD].[dbo].[TestAppointments]
                          where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                                ";
            SqlCommand command = new SqlCommand(qeruy, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

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
        public static bool UpdateTestAppointmentDate(int LocalDrivingLicenseApplicationID, DateTime AppointmentDate)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string qeruy = @"
                            UPDATE [dbo].[TestAppointments]
                               SET [AppointmentDate] = @AppointmentDate
      
                             WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                                ";
            SqlCommand command = new SqlCommand(qeruy, connection);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            bool isUpdated = false;
            try
            {
                connection.Open();
                int rowsEffected = command.ExecuteNonQuery();
                if (rowsEffected > 0)
                    return true;
            }
            catch (Exception)
            {
                isUpdated = false;
            }
            finally { connection.Close(); }
            return isUpdated;

        }
        public static DateTime GetTestAppDate(int LocalDrivingLicenseApplicationID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string qeruy = @"SELECT top 1
                                  [AppointmentDate]
    
                              FROM [DVLD].[dbo].[TestAppointments]
                              where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                              order by AppointmentDate desc
                                ";
            SqlCommand command = new SqlCommand(qeruy, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && DateTime.TryParse(result.ToString(), out DateTime value))
                {
                    connection.Close();
                    return value;
                }
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
            finally
            {
                connection.Close();
            }
            return DateTime.MinValue;
        }

        public static bool hasLockedAppointment(int localDrivingLicenseAppID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string qeruy = @"SELECT 
                                  [IsLocked]
                              FROM [DVLD].[dbo].[TestAppointments]
                              where LocalDrivingLicenseApplicationID = @localDrivingLicenseAppID
                              order by AppointmentDate desc
                                ";
            SqlCommand command = new SqlCommand(qeruy, connection);
            command.Parameters.AddWithValue("@localDrivingLicenseAppID", localDrivingLicenseAppID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && Boolean.TryParse(result.ToString(), out Boolean value))
                {
                    connection.Close();
                    return value;
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
    }
}
