using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsTestAppointment
    {
        public object TestAppointmentID { get; set; }

        public static clsTestAppointment GetLastTestAppointment(int localDrivingLicenseApplicationID, clsTestType.enTestType visionTest)
        {
            throw new NotImplementedException();
        }

        public static decimal GetPaidFees(int localDrivingLicenseAppID)
        {
            return DVLD_DataAccess.clsTestAppointment.GetPaidFees(localDrivingLicenseAppID);
        }
    }
}
