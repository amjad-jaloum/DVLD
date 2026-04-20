using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsApplicationType
    {
        public int AppID { get; set; }
        public string AppTitle { get; set; }
        public float AppFees { get; set; }

        public enum enApplicationType
        {
            NewLocalDrivingLicenseService = 1,
            RenewDrivingLicenseService,
            ReplacementForLostDrivingLicense,
            ReplacementForDamagedDrivingLicense,
            ReleaseDetainedDrivingLicense,
            NewInternationalLicense
        }

        public clsApplicationType(int appID, string appTitle, float appFees)
        {
            AppID = appID;
            AppTitle = appTitle;
            AppFees = appFees;
        }

        public static bool UpdateAppType(clsApplicationType application)
        {
            return DVLD_DataAccess.clsApplicationType.UpdateAppType(application.AppID, application.AppTitle, application.AppFees);
        }

        public static DataTable GetApplicationTypes()
        {
            return DVLD_DataAccess.clsApplicationType.GetApplicationTypes();
        }

        public static int GetFees(enApplicationType ApplicationTypeID)
        {
            return DVLD_DataAccess.clsApplicationType.GetFees((int) ApplicationTypeID);
        }
    }
}
