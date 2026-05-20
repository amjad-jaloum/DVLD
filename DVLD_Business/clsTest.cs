using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsTest
    {
        public bool TestResult { get; set; }
        public clsTestAppointment TestAppointmentInfo { get; set; }

        internal static clsTest FindLastTestPerPersonAndLicenseClass(int applicantPersonID, int licenseClassID, clsTestType.enTestType testTypeID)
        {
            throw new NotImplementedException();
        }

        internal static byte GetPassedTestCount(int localDrivingLicenseApplicationID)
        {
            throw new NotImplementedException();
        }

        internal static bool PassedAllTests(int localDrivingLicenseApplicationID)
        {
            throw new NotImplementedException();
        }
    }
}
