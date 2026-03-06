using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class Driver
    {
        public int PersonID { get; set; }
        public int CreatedByUserID { get; set; }
        public DateTime CreatedDate { get; set; }

        public Driver(int personID, int createdByUserID, DateTime createdDate)
        {
            PersonID = personID;
            CreatedByUserID = createdByUserID;
            CreatedDate = createdDate;
        }

        public static int AddNewDriver(int PersonID, int CreatedByUserID)
        {
            return DriversData.AddNewDriver(PersonID, CreatedByUserID, DateTime.Now);
        }

        public static Driver FindDriver(int DriverID)
        {
            int PersonID = -1;
            int CreatedByUserID = -1;
            DateTime CreatedDate = DateTime.MinValue;

            bool isFound = DriversData.FindDriver(DriverID, ref PersonID, ref CreatedByUserID, ref CreatedDate);
            if (isFound)
                return new Driver(PersonID, CreatedByUserID, CreatedDate);
            else
                return null;
        }
    }
}
