using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsUser
    {
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public clsUser(int userID, int personID, string userName, string password, bool isActive)
        {
            UserID = userID;
            PersonID = personID;
            UserName = userName;
            Password = password;
            IsActive = isActive;
        }
        public static bool SaveUsernameAndPasswordToFile(string username, string password)
        {
            return clsUserData.SaveUsernameAndPasswordToFile(username, password);
        }
        public static clsUser FindUser(string username, string password, ref bool isFound)
        {
            int id = -1, personID = -1;
            bool isActive = false;

            if (clsUserData.FindUserByUsername(ref id, ref personID, username, password, ref isActive))
            {
                isFound = true;
                return new clsUser(id, personID, username, password, isActive);
            }
            else
            {
                isFound = false;
                return null;
            }
        }
        public static clsUser FindUser(int UserID)
        {
            int personID = -1;
            bool isActive = false;
            string username = "";
            string password = "";

            if (clsUserData.FindUser(UserID, ref personID, ref username, ref password, ref isActive))
            {
                return new clsUser(UserID,personID,username,password,isActive);
            }
            else
            {
                return null;
            }
        }
        public static bool IsUserFound(int PersonID)
        {
            return clsUserData.DoesUserExist(PersonID);
        }
        public static bool LoadSavedLoginData(ref string username, ref string password)
        {
            clsUserData.GetSavedLoginData(ref username, ref password);
            return username != string.Empty && password != string.Empty;
        }
        public static void ResetUsernameAndPasswrodFile()
        {
            clsUserData.ResetUsernameAndPasswrodFile();
        }
        public static DataTable GetAllUsers()
        {
            return clsUserData.GetAllUsers();
        }
        public static List<string> GetUserColumnNames()
        {
            return clsUserData.GetUsersColumnNames();
        }
        public static DataTable GetDataTableWithQuery(string colName, string value)
        {
            return clsUserData.GetDataTableWithQuery(colName, value);
        }
        public static int AddNewUser(clsUser user)
        {
            return clsUserData.AddNewUser(user.PersonID, user.UserName, user.Password, user.IsActive);
        }
        public static bool UpdateUser(clsUser user)
        {
            return clsUserData.UpdateUser(user.UserID, user.UserName, user.Password, user.IsActive);
        }
        public static bool UpdateUserPassword(int UserID, string newPassword)
        {
            return clsUserData.UpdateUserPassword(UserID, newPassword);
        }
        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }


    }
}
