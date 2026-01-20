using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace DVLD_DataAccess
{
    public class PeopleData
    {
        public static DataTable GetAllPeople()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select * from People";

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
        public static List<string> GetAllCountries()
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string qeury = "select CountryName from Countries";
            SqlCommand command = new SqlCommand(qeury, connection);

            List<string> Countrieslist = new List<string>();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Countrieslist.Add((string)reader["CountryName"]);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
            }
            finally { connection.Close(); }
            return Countrieslist;
        }
        public static bool IsNationalNoFound(string nationalNo)
        {
            SqlConnection connection = new SqlConnection((clsDataAccessSettings.ConnectionString));
            string query = @"select Found = case when exists
                                (select top 1 R=1 from People where NationalNo = @nationalNo) 
                            then 'true' else 'false' end";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@nationalNo", nationalNo);

            bool isFound = false;
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    isFound = Convert.ToBoolean(reader["Found"]);
                    reader.Close();
                }
                else
                {
                    isFound = false;
                }
            }
            catch (Exception)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
        public static int AddNewPerson(string NationalNo, string FirstName, string SecondName,
            string ThirdName, string LastName, DateTime DateOfBirth,
            int Gender, string Address, string Phone, string Email,
            int NationalityCountryID, string ImagePath)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
                            INSERT INTO People
                            VALUES (@NationalNo,
                                    @FirstName,
                                    @SecondName,
                                    @ThirdName,
                                    @LastName,
                                    @DateOfBirth,
                                    @Gendor,
                                    @Address,
                                    @Phone,
                                    @Email,
                                    @NationalityCountryID,
                                    @ImagePath);
                            SELECT SCOPE_IDENTITY();
                            ";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            if (ThirdName != string.Empty)
                command.Parameters.AddWithValue("@ThirdName", ThirdName); // nullable
            else
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value); // nullable

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gendor", Gender);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);

            if (Email != string.Empty && Email != null)
                command.Parameters.AddWithValue("@Email", Email); // nullable
            else
                command.Parameters.AddWithValue("@Email", DBNull.Value); // nullable

            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (ImagePath != string.Empty)
                command.Parameters.AddWithValue("@ImagePath", ImagePath); // nullable
            else
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value); // nullable

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
        public static bool UpdatePerson(
            int ID,
             string NationalNo,
             string FirstName,
             string SecondName,
             string ThirdName,
             string LastName,
             DateTime DateOfBirth,
             int Gender,
             string Address,
             string Phone,
             string Email,
             int NationalityCountryID,
             string ImagePath)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"UPDATE [dbo].[People]
                           SET [NationalNo] = @NationalNo
                              ,[FirstName] = @FirstName
                              ,[SecondName] = @SecondName
                              ,[ThirdName] = @ThirdName
                              ,[LastName] = @LastName
                              ,[DateOfBirth] = @DateOfBirth
                              ,[Gendor] = @Gender
                              ,[Address] = @Address
                              ,[Phone] = @Phone
                              ,[Email] = @Email
                              ,[NationalityCountryID] =@NationalityCountryID
                              ,[ImagePath] = @ImagePath
                         WHERE PersonID = @ID;
                        ";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@NationalNo", NationalNo);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@SecondName", SecondName);

            if (ThirdName != string.Empty)
                command.Parameters.AddWithValue("@ThirdName", ThirdName); // nullable
            else
                command.Parameters.AddWithValue("@ThirdName", DBNull.Value); // nullable

            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Phone", Phone);

            if (Email != string.Empty && Email != null)
                command.Parameters.AddWithValue("@Email", Email); // nullable
            else
                command.Parameters.AddWithValue("@Email", DBNull.Value); // nullable

            command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);

            if (ImagePath != string.Empty)
                command.Parameters.AddWithValue("@ImagePath", ImagePath); // nullable
            else
                command.Parameters.AddWithValue("@ImagePath", DBNull.Value); // nullable

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
        public static bool GetPersonInfo(int ID,
            ref string NationalNo,
            ref string FirstName,
            ref string SecondName,
            ref string ThirdName,
            ref string LastName,
            ref DateTime DateOfBirth,
            ref int Gender,
            ref string Address,
            ref string Phone,
            ref string Email,
            ref int NationalityCountryID,
            ref string ImagePath)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select * from People where PersonID = @ID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ID", ID);
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    NationalNo = (string)reader["NationalNo"];
                    FirstName = (string)reader["FirstName"];
                    SecondName = (string)reader["SecondName"];
                    ThirdName = reader["ThirdName"] == DBNull.Value ? string.Empty : (string)reader["ThirdName"]; // nullable
                    LastName = (string)reader["LastName"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    Gender = Convert.ToInt32(reader["Gendor"]);
                    Address = (string)reader["Address"];
                    Phone = (string)reader["Phone"];
                    Email = reader["Email"] == DBNull.Value ? string.Empty : (string)reader["Email"]; // nullable
                    NationalityCountryID = (int)reader["NationalityCountryID"];
                    ImagePath = reader["ImagePath"] == DBNull.Value ? string.Empty : (string)reader["ImagePath"]; // nullable

                    reader.Close();
                    connection.Close();
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

        public static List<string> GetPeopleColumnNames()
        {
            List<string> list = new List<string>();

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select INFORMATION_SCHEMA.COLUMNS.COLUMN_NAME from INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'People'";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if ((string)reader["COLUMN_NAME"] == "ImagePath" || (string)reader["COLUMN_NAME"] == "DateOfBirth")
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
            string query = $"select * from People where {ColumnName} like @value"; ;
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

        public static bool DeletePerson(int PersonId)
        {
            SqlConnection conn = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "delete from People where PersonID = @PersonID";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@PersonID", PersonId);

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

        public static string GetCountryName(int CountryId)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select CountryName from Countries where CountryID = @CountryId";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CountryId", CountryId);

            string CountryName = "";
            try
            {
                connection.Open();
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    CountryName = (string)result;
                }
            }
            catch (Exception)
            {
            }
            finally { connection.Close(); }
            return CountryName;
        }

    }
}
