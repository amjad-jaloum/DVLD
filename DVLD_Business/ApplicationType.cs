using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class ApplicationType
    {
        public int AppID { get; set; }
        public string AppTitle { get; set; }
        public float AppFees { get; set; }

        public ApplicationType(int appID, string appTitle, float appFees)
        {
            AppID = appID;
            AppTitle = appTitle;
            AppFees = appFees;
        }

        public static bool UpdateAppType(ApplicationType application)
        {
            return ApplicationTypesData.UpdateAppType(application.AppID, application.AppTitle, application.AppFees);
        }

        public static DataTable GetApplicationTypes()
        {
            return ApplicationTypesData.GetApplicationTypes();
        }
    }
}
