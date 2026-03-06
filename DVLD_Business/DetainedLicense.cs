using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class DetainedLicense
    {
        public static bool IsLicenseDetained(int LicenseID)
        {
            return DetainedLicensesData.IsLicenseDetained(LicenseID);
        }
    }
}
