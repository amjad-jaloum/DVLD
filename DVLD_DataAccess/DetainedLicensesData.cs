using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class DetainedLicensesData
    {
        public static bool IsLicenseDetained(int LicenseID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"  select Result = 'Found' from DetainedLicenses
                                  where exists (
                                    select LicenseID where LicenseID = @LicenseID
                                  )";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@LicenseID", LicenseID);

            bool isDetained = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                    isDetained= true;

                reader.Close();
            }
            catch (Exception)
            { isDetained = false; }
            finally { connection.Close(); }

            return isDetained;
        }
    }
}
