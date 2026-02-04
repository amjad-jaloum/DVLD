using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class LocalDrivingLicenseApplication
    {
        private int ApplicantPersonID { get; set; }
        private DateTime ApplicationDate { get; set; }
        private int ApplicationTypeID { get; set; }
        private short ApplicationStatus { get; set; }
        private DateTime LastStatusDate { set; get; }
        private short PaidFees { get; set; }
        private int CreatedByUserID { get; set; }

        private enum enAppServiceFee
        {
            NewLocalDrivingLicenseService = 1,
            RenewDrivingLicenseService = 2,
            ReplacementforLostDrivingLicense = 3,
            ReplacementforDamagedDrivingLicense = 4,
            ReleaseDetainedDrivingLicsense = 5,
            NewInternationalLicense = 5,
        }
        public LocalDrivingLicenseApplication(int applicantPersonID, DateTime applicationDate, int applicationTypeID, short applicationStatus, DateTime lastStatusDate, short paidFees, int createdByUserID)
        {
            ApplicantPersonID = applicantPersonID;
            ApplicationDate = applicationDate;
            ApplicationTypeID = applicationTypeID;
            ApplicationStatus = applicationStatus;
            LastStatusDate = lastStatusDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
        }

        public static DataTable GetLocalLicenseApplications()
        {
            return LocalDrivingLicensApplicationsData.GetLocalDrivingLicensApplications();
        }

        public static List<string> GetUserColumnNames()
        {
            return LocalDrivingLicensApplicationsData.GetLocalLicensesClassNames();
        }

        public static string GetLocalDrivingLicenseAppFees()
        {
            return LocalDrivingLicensApplicationsData.GetAppServiceFee((int)enAppServiceFee.NewLocalDrivingLicenseService).ToString();
        }

        public int AddNewApplication()
        {
            return LocalDrivingLicensApplicationsData.AddNewApplication(ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
        }

        public static int AddNewLocalDrivingLicenseApplication(int AppID, int ClassID)
        {
            return LocalDrivingLicensApplicationsData.LocalDrivingLicenseApplications(AppID, ClassID);
        }

        public static bool IsClassNameAvialable(string nationalNo, object selectedItem)
        {
            return LocalDrivingLicensApplicationsData.IsClassNameAvialable(nationalNo, selectedItem.ToString());
        }

        public static List<string> GetLocalDrivingLincesesColumns()
        {
            return LocalDrivingLicensApplicationsData.LocalDrivingColumns();
        }

        public static DataTable GetDataTableWithQuery(string ColName, string searchValue)
        {
            return LocalDrivingLicensApplicationsData.GetDataTableWithQuery(ColName, searchValue);
        }
    }
}
