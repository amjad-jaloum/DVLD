using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_DataAccess
{
    public class clsLocalDrivingLicenseApplicationData
    {
        public static bool GetLocalDrivingLicenseApplicationInfoByID(
            int LocalDrivingLicenseApplicationID, ref int ApplicationID, ref int LicenseID)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string qeury = "select * from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand command = new SqlCommand(qeury, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = true;
                    ApplicationID = (int)reader["ApplicationID"];
                    LicenseID = (int)reader["LicenseClassID"];
                }
                reader.Close();
            }
            catch (Exception ex)
            {
            }
            finally { connection.Close(); }
            return isFound;
        }
        public static bool GetLocalDrivingLicenseApplicationInfoByApplicationID(
         int ApplicationID, ref int LocalDrivingLicenseApplicationID,
         ref int LicenseClassID)
                {
                    bool isFound = false;

                    SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

                    string query = "SELECT * FROM LocalDrivingLicenseApplications WHERE ApplicationID = @ApplicationID";

                    SqlCommand command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@ApplicationID", ApplicationID);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {

                            // The record was found
                            isFound = true;

                            LocalDrivingLicenseApplicationID = (int)reader["LocalDrivingLicenseApplicationID"];
                            LicenseClassID = (int)reader["LicenseClassID"];

                        }
                        else
                        {
                            // The record was not found
                            isFound = false;
                        }

                        reader.Close();


                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine("Error: " + ex.Message);
                        isFound = false;
                    }
                    finally
                    {
                        connection.Close();
                    }

                    return isFound;
                }

        public static DataTable GetAllLocalDrivingLicenseApplications()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *
                              FROM LocalDrivingLicenseApplications_View
                              order by ApplicationDate Desc";

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
                // Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }

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
        public static int AddNewLocalDrivingLicenseApplication(int ApplicationID, int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
                            INSERT INTO [dbo].[LocalDrivingLicenseApplications]
                           ([ApplicationID]
                           ,[LicenseClassID])
                     VALUES
                           (@ApplicationID
                           ,@LicenseClassID); SELECT SCOPE_IDENTITY();
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
        public static bool UpdateLocalDrivingLicenseApplication(
            int LocalDrivingLicenseApplicationID, int ApplicationID, int LicenseClassID)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  LocalDrivingLicenseApplications  
                            set ApplicationID = @ApplicationID,
                                LicenseClassID = @LicenseClassID
                            where LocalDrivingLicenseApplicationID=@LocalDrivingLicenseApplicationID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("ApplicationID", ApplicationID);
            command.Parameters.AddWithValue("LicenseClassID", LicenseClassID);


            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
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
                    {
                        reader.Close();
                        return true;
                    }
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
            finally
            {
                connection.Close();
            }
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
        public static string FindLicenceName(int LicenseClassID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT [ClassName]   
                              FROM [DVLD].[dbo].[LicenseClasses]
                              where LicenseClassID = @LicenseClassID
                        ";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LicenseClassID", LicenseClassID);
            string ClassName;
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
        public static int GetApplicationID(int localDrivingLicenseAppID)
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
        public static int GetTestFees(int TestTypeID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
                            SELECT 
                                  [TestTypeFees]
                              FROM [DVLD].[dbo].[TestTypes]
                              where TestTypeID = @TestTypeID
                            ";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

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
        public static int AddNewTestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID,
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
                                           ,@IsLocked);

                                SELECT SCOPE_IDENTITY();
                                ";
            SqlCommand command = new SqlCommand(qeruy, connection);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@PaidFees", PaidFees);
            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
            command.Parameters.AddWithValue("@IsLocked", IsLocked);

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
        public static DataTable LoadTestAppointments(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string qeruy = @"SELECT [TestAppointmentID] as 'Appointment ID'
                          ,[AppointmentDate] as 'Appointment Date'
                          ,[PaidFees] as 'Paid Fees'
                          ,[IsLocked] as 'Is Locked'
                          FROM [DVLD].[dbo].[TestAppointments]
                          where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                          and TestTypeID = @TestTypeID
                                ";
            SqlCommand command = new SqlCommand(qeruy, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

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
        public static bool UpdateTestAppointmentDate(int LocalDrivingLicenseApplicationID, int TestAppointmentID, DateTime AppointmentDate)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string qeruy = @"
                            UPDATE [dbo].[TestAppointments]
                               SET [AppointmentDate] = @AppointmentDate
      
                             WHERE LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID
                                and TestAppointmentID = @TestAppointmentID
                                ";
            SqlCommand command = new SqlCommand(qeruy, connection);
            command.Parameters.AddWithValue("@AppointmentDate", AppointmentDate);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
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
        public static bool hasUnlockedAppointment(int LocalDrivingLicenseApplicationID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string qeruy = @"select IsLocked from TestAppointments
                            where exists ( 
                                    select top 1 R = 1 where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID and IsLocked = 0 
                                         )
                                ";
            SqlCommand command = new SqlCommand(qeruy, connection);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    connection.Close();
                    return true;
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
        public static bool AddNewTestResult(int TestAppointmentID, bool TestResult, string Notes, int CreatedByUserID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string qeruy = @"USE [DVLD]
                            INSERT INTO [dbo].[Tests]
                                       ([TestAppointmentID]
                                       ,[TestResult]
                                       ,[Notes]
                                       ,[CreatedByUserID])
                                 VALUES
                                       (@TestAppointmentID
                                       ,@TestResult
                                       ,@Notes
                                       ,@CreatedByUserID)
                                ";
            SqlCommand command = new SqlCommand(qeruy, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            command.Parameters.AddWithValue("@TestResult", TestResult);
            if (Notes != string.Empty)
                command.Parameters.AddWithValue("@Notes", Notes);
            else
                command.Parameters.AddWithValue("@Notes", DBNull.Value);

            command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);

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
        public static bool LockTestAppointment(int TestAppointmentID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string qeruy = @"
                              update [TestAppointments] set IsLocked = 1
                                where TestAppointmentID = @TestAppointmentID
                                ";
            SqlCommand command = new SqlCommand(qeruy, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);

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
        public static bool isAppointmentLocked(int TestAppointmentID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string qeruy = @"SELECT        IsLocked
                                FROM            TestAppointments
                                WHERE        (TestAppointmentID = @TestAppointmentID) and IsLocked = 1
                                ";
            SqlCommand command = new SqlCommand(qeruy, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
        public static bool GetLastTestResult(int TestAppointmentID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string qeruy = @"select top 1 TestResult from Tests
                                  where TestAppointmentID = @TestAppointmentID
                                  order by TestID desc
                                ";
            SqlCommand command = new SqlCommand(qeruy, connection);
            command.Parameters.AddWithValue("@TestAppointmentID", TestAppointmentID);
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null && Boolean.TryParse(result.ToString(), out bool value))
                {
                    connection.Close();
                    return value;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
        public static bool IsStatusCompletedOrCancelled(int localDrivingLicenseApplicationID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string qeruy = @"SELECT Status
                            FROM         LocalDrivingLicenseApplications_View
                            where LocalDrivingLicenseApplicationID = @localDrivingLicenseApplicationID
                            and Status in ('Completed', 'Cancelled')
                                ";
            SqlCommand command = new SqlCommand(qeruy, connection);
            command.Parameters.AddWithValue("@localDrivingLicenseApplicationID", localDrivingLicenseApplicationID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Close();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
            return false;
        }
        public static bool UpdateApplicaitonStatus(int LocalDrivingLicenseApplicationID, int ApplicationStatus)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
                      update Applications 
                      set ApplicationStatus = @ApplicationStatus
                      where ApplicationID = 
                          (
                            SELECT   ApplicationID
                            FROM         LocalDrivingLicenseApplications
                            WHERE     (LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)
                          )        
                    ";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ApplicationStatus", ApplicationStatus);
            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            bool isUpdated = false;
            try
            {
                connection.Open();
                int effectedRows = command.ExecuteNonQuery();
                if (effectedRows > 0)
                {
                    isUpdated = true;
                }
            }
            catch (Exception)
            {
                isUpdated = false;
            }
            finally { connection.Close(); }
            return isUpdated;
        }
        public static int GetLicenseClassID(int localDrivingLicenseApplicationID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
                    SELECT   LicenseClassID
                    FROM         LocalDrivingLicenseApplications
                    WHERE     (LocalDrivingLicenseApplicationID = @localDrivingLicenseApplicationID)
                ";
            SqlCommand sqlCommand = new SqlCommand(query, connection);
            sqlCommand.Parameters.AddWithValue("@localDrivingLicenseApplicationID", localDrivingLicenseApplicationID);

            try
            {
                connection.Open();
                object result = sqlCommand.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int LicenseClassID))
                {
                    return LicenseClassID;
                }
            }
            catch (Exception) { }
            finally { connection.Close(); }
            return -1;
        }
        public static bool DeleteLocalDrivingLicenseApplication(int LocalDrivingLicenseApplicationID)
        {
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "delete from LocalDrivingLicenseApplications where LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);

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
        public static bool DoesPassTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool Result = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @" SELECT top 1 TestResult
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && bool.TryParse(result.ToString(), out bool returnedResult))
                {
                    Result = returnedResult;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return Result;

        }
        public static bool DoesAttendTestType(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    IsFound = true;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return IsFound;

        }
        public static byte TotalTrialsPerTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            byte TotalTrialsPerTest = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @" SELECT TotalTrialsPerTest = count(TestID)
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID INNER JOIN
                                 Tests ON TestAppointments.TestAppointmentID = Tests.TestAppointmentID
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID) 
                            AND(TestAppointments.TestTypeID = @TestTypeID)
                       ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && byte.TryParse(result.ToString(), out byte Trials))
                {
                    TotalTrialsPerTest = Trials;
                }
            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return TotalTrialsPerTest;

        }
        public static int GetLocalDrivingLicenseApplicationIDByNationalNo(string NationalNo)
        {
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT top 1 LocalDrivingLicenseApplicationID
                            FROM LocalDrivingLicenseApplications_View
                            where NationalNo = @NationalNo
                            ";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                conn.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int returnedID))
                    return returnedID;
            }
            catch (Exception) { }
            finally { conn.Close(); }
            return -1;
        }
        public static int GetLocalDrivingLicenseApplicationIDByApplicationID(int applicationID)
        {
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT top 1 LocalDrivingLicenseApplicationID
                            FROM LocalDrivingLicenseApplications
                            where applicationID = @applicationID
                            ";
            SqlCommand command = new SqlCommand(query, conn);
            command.Parameters.AddWithValue("@applicationID", applicationID);

            try
            {
                conn.Open();
                object result = command.ExecuteScalar();
                if (result != null && int.TryParse(result.ToString(), out int returnedID))
                    return returnedID;
            }
            catch (Exception) { }
            finally { conn.Close(); }
            return -1;
        }
        public static bool IsThereAnActiveScheduledTest(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {

            bool Result = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @" SELECT top 1 Found=1
                            FROM LocalDrivingLicenseApplications INNER JOIN
                                 TestAppointments ON LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = TestAppointments.LocalDrivingLicenseApplicationID 
                            WHERE
                            (LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LocalDrivingLicenseApplicationID)  
                            AND(TestAppointments.TestTypeID = @TestTypeID) and isLocked=0
                            ORDER BY TestAppointments.TestAppointmentID desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LocalDrivingLicenseApplicationID", LocalDrivingLicenseApplicationID);
            command.Parameters.AddWithValue("@TestTypeID", TestTypeID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();


                if (result != null)
                {
                    Result = true;
                }

            }

            catch (Exception ex)
            {
                //Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return Result;

        }

    }
}
