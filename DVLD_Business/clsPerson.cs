using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using DVLD_Buisness;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsPerson
    {
        public enum enMode { AddNew, Update };
        enMode Mode = enMode.AddNew;

        public int PersonID { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + SecondName + " " + ThirdName + " " + LastName; }
        }
        public string NationalNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public clsCountry CountryInfo;
        public string ImagePath { get; set; }

        public clsPerson()
        {
            PersonID = -1;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            LastName = string.Empty;
            DateOfBirth = DateTime.Now;
            Address = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            NationalityCountryID = -1;
            ImagePath = string.Empty;

            Mode = enMode.AddNew;
        }

        public clsPerson(
            int personID,
            string nationalNo,
            string firstName,
            string secondName,
            string thirdName,
            string lastName,
            DateTime dateOfBirth,
            int gender,
            string address,
            string phone,
            string email,
            int nationalityCountryID,
            string imagePath
            )
        {
            PersonID = personID;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            NationalNo = nationalNo;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Address = address;
            Phone = phone;
            Email = email;
            NationalityCountryID = nationalityCountryID;
            ImagePath = imagePath;
            CountryInfo = clsCountry.Find(nationalityCountryID);

            Mode = enMode.Update;
        }
        public string GenderString
        {
            get
            {
                return Gender == 1 ? "Female" : "Male";
            }
        }

        public static List<string> GetAllCountries()
        {
            return clsPersonData.GetAllCountries();
        }
        public static bool IsNationalNoFound(string nationalNo)
        {
            return clsPersonData.IsNationalNoFound(nationalNo);
        }
        private bool _AddNewPerson()
        {
            PersonID = clsPersonData.AddNewPerson(NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                Gender, Address, Phone, Email, NationalityCountryID, ImagePath);

            return PersonID != -1;
        }
        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(PersonID, NationalNo, FirstName, SecondName, ThirdName, LastName, DateOfBirth,
                Gender, Address, Phone, Email, NationalityCountryID, ImagePath);
        }
        public static clsPerson Find(int PersonID)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            int Gender = -1;
            string Address = "", Phone = "", Email = "", ImagePath = "";
            int NationalityCountryID = 0;
            string NationalNo = "";

            bool IsFound = clsPersonData.GetPersonInfoByID
                (
                    PersonID, ref NationalNo, ref FirstName,
                    ref SecondName, ref ThirdName, ref LastName,
                    ref DateOfBirth,
                    ref Gender, ref Address, ref Phone, ref Email,
                    ref NationalityCountryID, ref ImagePath
                );

            if (IsFound)
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName,
                    LastName, DateOfBirth, Gender,
                    Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }
        public static clsPerson Find(string NationalNo)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            short Gender = -1;
            string Address = "", Phone = "", Email = "", ImagePath = "";
            int NationalityCountryID = 0;
            int PersonID = -1;

            bool IsFound = clsPersonData.GetPersonInfoByNationalNo
                (
                    NationalNo, ref PersonID, ref FirstName,
                    ref SecondName, ref ThirdName, ref LastName,
                    ref DateOfBirth, ref Gender, ref Address, ref Phone, ref Email,
                    ref NationalityCountryID, ref ImagePath
                );

            if (IsFound)
            {
                return new clsPerson(PersonID, NationalNo, FirstName, SecondName, ThirdName,
                    LastName, DateOfBirth, Gender,
                    Address, Phone, Email, NationalityCountryID, ImagePath);
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
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                        return false;

                case enMode.Update:
                    return _UpdatePerson();

                default:
                    return false;
            }
        }
        public static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }
        public static clsPerson GetPersonInfoWithQueryFilter(string col, string value)
        {
            int ID = -1;
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            int Gender = -1;
            string Address = "", Phone = "", Email = "", ImagePath = "";
            int NationalityCountryID = 0;
            string NationalNo = "";

            bool Found = clsPersonData.GetPersonInfoWithQuery(col, value, ref ID, ref NationalNo, ref FirstName,
                ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth,
                ref Gender, ref Address, ref Phone, ref Email,
                ref NationalityCountryID, ref ImagePath);

            if (Found)
            {
                return new clsPerson(ID, NationalNo, FirstName, SecondName, ThirdName,
                    LastName, DateOfBirth, Gender,
                    Address, Phone, Email, NationalityCountryID, ImagePath);
            }
            else
            {
                return null;
            }
        }
        public static List<string> GetPeopleColumnNames()
        {
            return clsPersonData.GetPeopleColumnNames();
        }
        public static DataTable GetFilterdPeopleDataTable(string col, string value)
        {
            return clsPersonData.GetDataTableWithQuery(col, value);
        }
        public static bool DeletePerson(int PersonID)
        {
            return clsPersonData.DeletePerson(PersonID);
        }
        public static bool isPersonExist(int ID)
        {
            return clsPersonData.IsPersonExist(ID);
        }
        public static bool isPersonExist(string NationalNo)
        {
            return clsPersonData.IsPersonExist(NationalNo);
        }
        public static string GetCountryName(int CountryID)
        {
            return clsPersonData.GetCountryName(CountryID);
        }
    }
}
