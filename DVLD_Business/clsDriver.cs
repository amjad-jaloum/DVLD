using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsDriver
    {
        public clsPerson PersonInfo;
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }

        public clsDriver(int personID, int createdByUserID, DateTime createdDate)
        {
            PersonID = personID;
            CreatedByUserID = createdByUserID;
            CreatedDate = createdDate;
        }

        public static int AddNewDriver(int PersonID, int CreatedByUserID)
        {
            return DVLD_DataAccess.clsDriver.AddNewDriver(PersonID, CreatedByUserID, DateTime.Now);
        }

        public static clsDriver FindDriver(int DriverID)
        {
            int PersonID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.MinValue;

            bool isFound = DVLD_DataAccess.clsDriver.FindDriver(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate);
            if (isFound)
                return new clsDriver(PersonID, CreatedByUserID, CreatedDate);
            else
                return null;
        }

        public static bool FindDriverID(int LocalDrivingLicenseAppID, ref int driverID)
        {
            int PersonID = clsApplication.GetApplicantPersonID(LocalDrivingLicenseAppID);
            driverID = DVLD_DataAccess.clsDriver.FindDriverID(PersonID);

            if (driverID == -1)
                return false;
            else
                return true;
        }

        public static DataTable GetDriversData()
        {
            return DVLD_DataAccess.clsDriver.GetDriversData();
        }

        public static List<string> GetDriversColumnNames()
        {
            return DVLD_DataAccess.clsDriver.GetDriversColumnNames();
        }

        public static object GetDataTableWithQuery(string ColumnName, string searchValue)
        {
            return DVLD_DataAccess.clsDriver.GetDataTableWithQuery(ColumnName, searchValue);
        }
    }
}
