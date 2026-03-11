using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class InternationalDrivingLicensesApplication
    {
        public static DataTable GetInternationalDrivingLicensApplications()
        {
            return InternationalDrivingLicenseApplicatioansData.GetInternationalDrivingLicensApplications();
        }
    }
}
