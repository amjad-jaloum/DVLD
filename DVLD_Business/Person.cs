using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class Person
    {
        public int PersonID { get; set; }
        public string NationalNo { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int NationalityCountryID { get; set; }
        public string ImagePath { get; set; }

        public Person(
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
            NationalNo = nationalNo;
            FirstName = firstName;
            SecondName = secondName;
            ThirdName = thirdName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Address = address;
            Phone = phone;
            Email = email;
            NationalityCountryID = nationalityCountryID;
            ImagePath = imagePath;
        }
        public static DataTable GetAllPeople()
        {
            return PeopleData.GetAllPeople();
        }

        public static List<string> GetAllCountries()
        {
            return PeopleData.GetAllCountries();
        }

        public static bool IsNationalNoFound(string nationalNo)
        {
            return PeopleData.IsNationalNoFound(nationalNo);
        }

        public static int AddNewPerson(Person person)
        {
            return PeopleData.AddNewPerson(person.NationalNo, person.FirstName, person.SecondName, person.ThirdName, person.LastName, person.DateOfBirth,
                person.Gender, person.Address, person.Phone, person.Email, person.NationalityCountryID, person.ImagePath);
        }

        public static bool UpdatePerson(Person person)
        {
            return PeopleData.UpdatePerson(person.PersonID, person.NationalNo, person.FirstName, person.SecondName, person.ThirdName, person.LastName, person.DateOfBirth,
                person.Gender, person.Address, person.Phone, person.Email, person.NationalityCountryID, person.ImagePath);
        }

        public static Person GetPersonInfo(int ID)
        {
            string FirstName = "", SecondName = "", ThirdName = "", LastName = "";
            DateTime DateOfBirth = DateTime.Now;
            int Gender = -1;
            string Address = "", Phone = "", Email = "", ImagePath = "";
            int NationalityCountryID = 0;
            string NationalNo = "";

            bool IsPersonFound = PeopleData.GetPersonInfo(ID, ref NationalNo, ref FirstName,
                ref SecondName, ref ThirdName, ref LastName, ref DateOfBirth,
                ref Gender, ref Address, ref Phone, ref Email,
                ref NationalityCountryID, ref ImagePath);

            if (IsPersonFound)
            {
                return new Person(ID, NationalNo, FirstName, SecondName, ThirdName,
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
            return PeopleData.GetPeopleColumnNames();
        }

        public static DataTable GetFilterdPeopleDataTable(string col, string value)
        {
            return PeopleData.GetDataTableWithQuery(col, value);
        }

        public static bool DeletePerson(int PersonID)
        {
            return PeopleData.DeletePerson(PersonID);
        }

        public static string GetCountryName(int  CountryID)
        {
            return PeopleData.GetCountryName(CountryID);
        }
    }
}
