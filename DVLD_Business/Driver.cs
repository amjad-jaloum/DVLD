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
        int PersonID { get; set; }
        int CreatedByUserID { get; set; }
        DateTime CreatedDate { get; set; }

        public Driver(int personID, int createdByUserID, DateTime createdDate)
        {
            PersonID = personID;
            CreatedByUserID = createdByUserID;
            CreatedDate = createdDate;
        }

        public static int AddNewDriver(int PersonID, int CreatedByUserID, DateTime CreatedDate)
        {
            return DriversData.AddNewDriver(PersonID, CreatedByUserID, CreatedDate);
        }
    }
}
