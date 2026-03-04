using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class TestAppointment
    {
        public static decimal GetPaidFees(int localDrivingLicenseAppID)
        {
            return TestAppointmentsData.GetPaidFees(localDrivingLicenseAppID);
        }
    }
}
