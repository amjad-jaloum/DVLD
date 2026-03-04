using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class ApplicationsData
    {
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
