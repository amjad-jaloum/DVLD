using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsApplicationTypeData
    {
        public static DataTable GetAllApplicationTypes()
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
                string sourceName = "DVLD";
                // find if already exists
                if (!EventLog.SourceExists(sourceName))
                {
                    // create the log event
                    EventLog.CreateEventSource(sourceName, "Application");
                }

                // logging
                EventLog.WriteEntry(sourceName, ex.Message, EventLogEntryType.Error);

            }
            finally
            {
                connection.Close();
            }
            return dt;
        }

        public static bool GetApplicationTypeInfoByID(int ApplicationTypeID,
            ref string ApplicationTypeTitle, ref float ApplicationFees)
        {
            bool isFound = false;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM ApplicationTypes WHERE ApplicationTypeID = @ApplicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    ApplicationTypeTitle = reader["ApplicationTypeTitle"].ToString();
                    ApplicationFees = reader["ApplicationFees"] != DBNull.Value ? Convert.ToSingle(reader["ApplicationFees"]) : 0;
                }
            }
            catch (Exception ex)
            {
                string sourceName = "DVLD";
                // find if already exists
                if (!EventLog.SourceExists(sourceName))
                {
                    // create the log event
                    EventLog.CreateEventSource(sourceName, "Application");
                }

                // logging
                EventLog.WriteEntry(sourceName, ex.Message, EventLogEntryType.Error);

            }
            finally { connection.Close(); }
            return isFound;
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
            catch (Exception ex)
            {
                string sourceName = "DVLD";
                // find if already exists
                if (!EventLog.SourceExists(sourceName))
                {
                    // create the log event
                    EventLog.CreateEventSource(sourceName, "Application");
                }

                // logging
                EventLog.WriteEntry(sourceName, ex.Message, EventLogEntryType.Error);
            }
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
            catch (Exception ex)
            {
                string sourceName = "DVLD";
                // find if already exists
                if (!EventLog.SourceExists(sourceName))
                {
                    // create the log event
                    EventLog.CreateEventSource(sourceName, "Application");
                }

                // logging
                EventLog.WriteEntry(sourceName, ex.Message, EventLogEntryType.Error);
            }
            finally
            {
                connection.Close();
            }
            return RowsEffected > 0;
        }
        public static int AddNewApplicationType(string Title, float Fees)
        {
            int ApplicationTypeID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Insert Into ApplicationTypes (ApplicationTypeTitle,ApplicationFees)
                            Values (@Title,@Fees)
                            
                            SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeTitle", Title);
            command.Parameters.AddWithValue("@ApplicationFees", Fees);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ApplicationTypeID = insertedID;
                }
            }

            catch (Exception ex)
            {
                string sourceName = "DVLD";
                // find if already exists
                if (!EventLog.SourceExists(sourceName))
                {
                    // create the log event
                    EventLog.CreateEventSource(sourceName, "Application");
                }

                // logging
                EventLog.WriteEntry(sourceName, ex.Message, EventLogEntryType.Error);

            }

            finally
            {
                connection.Close();
            }


            return ApplicationTypeID;

        }
        public static bool UpdateApplicationType(int ApplicationTypeID, string Title, float Fees)
        {

            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  ApplicationTypes  
                            set ApplicationTypeTitle = @Title,
                                ApplicationFees = @Fees
                                where ApplicationTypeID = @ApplicationTypeID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ApplicationTypeID", ApplicationTypeID);
            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@Fees", Fees);

            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                string sourceName = "DVLD";
                // find if already exists
                if (!EventLog.SourceExists(sourceName))
                {
                    // create the log event
                    EventLog.CreateEventSource(sourceName, "Application");
                }

                // logging
                EventLog.WriteEntry(sourceName, ex.Message, EventLogEntryType.Error);
                return false;
            }
            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);
        }

    }
}
