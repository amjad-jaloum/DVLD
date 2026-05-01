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
        public enum enMode { AddNew, Update };
        public enMode Mode = enMode.AddNew;
        clsPerson PersonInfo;
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public clsUser()
        {
            UserID = -1;
            UserName = string.Empty;
            Password = string.Empty;
            IsActive = false;
            Mode = enMode.AddNew;
        }
        public clsUser(int userID, int personID, string userName, string password, bool isActive)
        {
            UserID = userID;
            PersonID = personID;
            PersonInfo = clsPerson.Find(PersonID);
            UserName = userName;
            Password = password;
            IsActive = isActive;
            Mode = enMode.Update;
        }
        public static bool SaveUsernameAndPasswordToFile(string username, string password)
        {
            return clsUserData.SaveUsernameAndPasswordToFile(username, password);
        }
        public static clsUser FindByUsernameAndPassword(string username, string password)
        {
            int UserID = -1, personID = -1;
            bool isActive = false;
            bool isFound = clsUserData.GetUserInfoByUsernameAndPassword(username, password, ref UserID, ref personID, ref isActive);
            if (isFound)
            {
                return new clsUser(UserID, personID, username, password, isActive);
            }
            else
            {
                return null;
            }
        }
        public static clsUser FindByUserID(int UserID)
        {
            int personID = -1;
            bool isActive = false;
            string username = "";
            string password = "";

            if (clsUserData.GetUserInfoByUserID(UserID, ref personID, ref username, ref password, ref isActive))
            {
                return new clsUser(UserID, personID, username, password, isActive);
            }
            else
            {
                return null;
            }
        }
        public static clsUser FindByPersonID(int PersonID)
        {
            int userID = -1;
            bool isActive = false;
            string username = "";
            string password = "";

            if (clsUserData.GetUserInfoByPersonID(PersonID, ref userID, ref username, ref password, ref isActive))
            {
                return new clsUser(userID, PersonID, username, password, isActive);
            }
            else
            {
                return null;
            }
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (AddNewUser())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return UpdateUser();

                default:
                    return false;
            }
        }
        public static bool IsUserExist(int PersonID)
        {
            return clsUserData.IsUserExist(PersonID);
        }
        public static bool IsUserExist(string Username)
        {
            return clsUserData.IsUserExist(Username);
        }
        public static bool IsUserExistForPersonID(int PersonID)
        {
            return clsUserData.IsUserExistForPersonID(PersonID);
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
        public bool AddNewUser()
        {
            return clsUserData.AddNewUser(PersonID, UserName, Password, IsActive) != -1;
        }
        public bool UpdateUser()
        {
            return clsUserData.UpdateUser(UserID, UserName, Password, IsActive);
        }
        public static bool UpdateUserPassword(int UserID, string newPassword)
        {
            return clsUserData.ChangePassword(UserID, newPassword);
        }
        public static bool DeleteUser(int UserID)
        {
            return clsUserData.DeleteUser(UserID);
        }


    }
}
