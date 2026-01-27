using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class User
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public User(int userID, int personID, string userName, string password, bool isActive)
        {
            UserID = userID;
            PersonID = personID;
            UserName = userName;
            Password = password;
            IsActive = isActive;
        }
        public static bool SaveUsernameAndPasswordToFile(string username, string password)
        {
            return UsersData.SaveUsernameAndPasswordToFile(username, password);
        }
        public static User FindUser(string username, string password, ref bool isFound)
        {
            int id = -1, personID = -1;
            bool isActive = false;

            if (UsersData.FindUserByUsername(ref id, ref personID, username, password, ref isActive))
            {
                isFound = true;
                return new User(id, personID, username, password, isActive);
            }
            else
            {
                isFound = false;
                return null;
            }
        }
        public static User FindUser(int UserID)
        {
            int personID = -1;
            bool isActive = false;
            string username = "";
            string password = "";

            if (UsersData.FindUser(UserID, ref personID, ref username, ref password, ref isActive))
            {
                return new User(UserID,personID,username,password,isActive);
            }
            else
            {
                return null;
            }
        }
        public static bool IsUserFound(int PersonID)
        {
            return UsersData.DoesUserExist(PersonID);
        }
        public static bool LoadSavedLoginData(ref string username, ref string password)
        {
            UsersData.GetSavedLoginData(ref username, ref password);
            return username != string.Empty && password != string.Empty;
        }
        public static void ResetUsernameAndPasswrodFile()
        {
            UsersData.ResetUsernameAndPasswrodFile();
        }
        public static DataTable GetAllUsers()
        {
            return UsersData.GetAllUsers();
        }
        public static List<string> GetUserColumnNames()
        {
            return UsersData.GetUsersColumnNames();
        }
        public static DataTable GetDataTableWithQuery(string colName, string value)
        {
            return UsersData.GetDataTableWithQuery(colName, value);
        }
        public static int AddNewUser(User user)
        {
            return UsersData.AddNewUser(user.PersonID, user.UserName, user.Password, user.IsActive);
        }
        public static bool UpdateUser(User user)
        {
            return UsersData.UpdateUser(user.UserID, user.UserName, user.Password, user.IsActive);
        }
        public static bool UpdateUserPassword(int UserID, string newPassword)
        {
            return UsersData.UpdateUserPassword(UserID, newPassword);
        }
        public static bool DeleteUser(int UserID)
        {
            return UsersData.DeleteUser(UserID);
        }


    }
}
