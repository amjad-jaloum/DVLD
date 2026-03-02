using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class LocalDrivingLicenseApplication
    {
        public int ApplicantPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public short ApplicationStatus { get; set; }
        public DateTime LastStatusDate { set; get; }
        public int PaidFees { get; set; }
        public int CreatedByUserID { get; set; }

        private enum enAppServiceFee
        {
            NewLocalDrivingLicenseService = 1,
            RenewDrivingLicenseService = 2,
            ReplacementforLostDrivingLicense = 3,
            ReplacementforDamagedDrivingLicense = 4,
            ReleaseDetainedDrivingLicsense = 5,
            NewInternationalLicense = 5,
        }
        public LocalDrivingLicenseApplication(int applicantPersonID, DateTime applicationDate, int applicationTypeID, short applicationStatus, DateTime lastStatusDate, int paidFees, int createdByUserID)
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

        public static bool UpdateLocalDrivingLicenseAppStatus(int appID, int Status)
        {
            return LocalDrivingLicensApplicationsData.UpdateLocalDrivingLicenseAppStatus(appID, Status);
        }
        public static string FindLicenceName(int LicenseClassID, string ClassName)
        {
            return LocalDrivingLicensApplicationsData.FindLicenceName(LicenseClassID, ClassName);
        }
        public static LocalDrivingLicenseApplication FindLocalDrivingLicenseApplication(int ApplicationID)
        {
            int ApplicantPersonID = 0;
            DateTime ApplicationDate = DateTime.MinValue;
            int ApplicationTypeID = 0;
            short ApplicationStatus = 0;
            DateTime LastStatusDate = DateTime.MinValue;
            int PaidFees = 0;
            int CreatedByUserID = 0;

            if (LocalDrivingLicensApplicationsData.FindLocalDrivingLicenseApplication(ApplicationID, ref ApplicantPersonID, 
                ref ApplicationDate, ref ApplicationTypeID, ref ApplicationStatus, 
                ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
            {
                return new LocalDrivingLicenseApplication(ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }

        public static int GetApplicationIDFromLocalDrivingLicenseApplications(int localDrivingLicenseAppID)
        {
            return LocalDrivingLicensApplicationsData.GetApplicationIDFromLocalDrivingLicenseApplications(localDrivingLicenseAppID);
        }

        public static string getAppTypeName(int applicationTypeID)
        {
            return LocalDrivingLicensApplicationsData.getAppTypeName(applicationTypeID);
        }

        public static string getUsername(int createdByUserID)
        {
            return LocalDrivingLicensApplicationsData.getUsername(createdByUserID);
        }

        public static int getTestFee(int TestTypeID)
        {
            return LocalDrivingLicensApplicationsData.GetTestFees(TestTypeID);
        }

        public static int AddNewTestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID,
            DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked)
        {
            return LocalDrivingLicensApplicationsData.AddNewTestAppointment
                (TestTypeID,LocalDrivingLicenseApplicationID,AppointmentDate,PaidFees,CreatedByUserID,IsLocked);
        }

        public static DataTable LoadTestAppointments(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return LocalDrivingLicensApplicationsData.LoadTestAppointments(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static bool UpdateTestAppointmentDate(int LocalDrivingLicenseApplicationID, int TestAppointmentID, DateTime AppointmentDate)
        {
            return LocalDrivingLicensApplicationsData.UpdateTestAppointmentDate(LocalDrivingLicenseApplicationID, TestAppointmentID, AppointmentDate);
        }

        public static DateTime GetTestAppointmentDate(int LocalDrivingLicenseApplicationID)
        {
            return LocalDrivingLicensApplicationsData.GetTestAppDate(LocalDrivingLicenseApplicationID);
        }

        public static bool hasUnlockedAppointment(int localDrivingLicenseAppID)
        {
            return LocalDrivingLicensApplicationsData.hasUnlockedAppointment(localDrivingLicenseAppID);
        }

        public static bool AddNewTestResult(int testAppointmentID, bool result, string notes, int userID)
        {
            return LocalDrivingLicensApplicationsData.AddNewTestResult(testAppointmentID, result, notes, userID);
        }

        public static bool LockTestAppointment(int testAppointmentID)
        {
            return LocalDrivingLicensApplicationsData.LockTestAppointment(testAppointmentID);
        }

        public static bool IsTestAppointmentLocked(int testAppointmentID)
        {
            return LocalDrivingLicensApplicationsData.isAppointmentLocked(testAppointmentID);
        }

        public static bool hasPassedTheTest(int testAppointmentID)
        {
            return LocalDrivingLicensApplicationsData.GetLastTestResult(testAppointmentID); // 0 fail // 1 pass
        }
    }
}
