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
    public class clsLocalDrivingLicenseApplication
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

        public enum enApplicationStatus
        {
            New = 1, Cancelled = 2 , Completed = 3
        }
        enApplicationStatus AppStatus;
        public clsLocalDrivingLicenseApplication(int applicantPersonID, DateTime applicationDate, int applicationTypeID, short applicationStatus, DateTime lastStatusDate, int paidFees, int createdByUserID)
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
            return clsLocalDrivingLicensApplicationData.GetLocalDrivingLicensApplications();
        }

        public static List<string> GetUserColumnNames()
        {
            return clsLocalDrivingLicensApplicationData.GetLocalLicensesClassNames();
        }

        public static string GetNewLocalDrivingLicenseAppFees()
        {
            return clsLocalDrivingLicensApplicationData.GetAppServiceFee((int)enAppServiceFee.NewLocalDrivingLicenseService).ToString();
        }

        public int AddNewApplication()
        {
            return clsLocalDrivingLicensApplicationData.AddNewApplication(ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
        }

        public static int AddNewLocalDrivingLicenseApplication(int AppID, int ClassID)
        {
            return clsLocalDrivingLicensApplicationData.LocalDrivingLicenseApplications(AppID, ClassID);
        }

        public static bool IsClassNameAvialable(string nationalNo, object selectedItem)
        {
            return clsLocalDrivingLicensApplicationData.IsClassNameAvialable(nationalNo, selectedItem.ToString());
        }

        public static List<string> GetLocalDrivingLincesesColumns()
        {
            return clsLocalDrivingLicensApplicationData.LocalDrivingColumns();
        }

        public static DataTable GetDataTableWithQuery(string ColName, string searchValue)
        {
            return clsLocalDrivingLicensApplicationData.GetDataTableWithQuery(ColName, searchValue);
        }

        public static bool UpdateLocalDrivingLicenseAppStatus(int appID, int Status)
        {
            return clsLocalDrivingLicensApplicationData.UpdateLocalDrivingLicenseAppStatus(appID, Status);
        }
        public static string GetLicenceName(int LicenseClassID)
        {
            return clsLocalDrivingLicensApplicationData.FindLicenceName(LicenseClassID);
        }
        public static clsLocalDrivingLicenseApplication FindApplication(int ApplicationID)
        {
            int ApplicantPersonID = 0;
            DateTime ApplicationDate = DateTime.MinValue;
            int ApplicationTypeID = 0;
            short ApplicationStatus = 0;
            DateTime LastStatusDate = DateTime.MinValue;
            int PaidFees = 0;
            int CreatedByUserID = 0;

            if (clsLocalDrivingLicensApplicationData.FindLocalDrivingLicenseApplication(ApplicationID, ref ApplicantPersonID, 
                ref ApplicationDate, ref ApplicationTypeID, ref ApplicationStatus, 
                ref LastStatusDate, ref PaidFees, ref CreatedByUserID))
            {
                return new clsLocalDrivingLicenseApplication(ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
            }
            else
            {
                return null;
            }
        }

        public static int GetApplicationID(int localDrivingLicenseAppID)
        {
            return clsLocalDrivingLicensApplicationData.GetApplicationID(localDrivingLicenseAppID);
        }

        public static string getAppTypeName(int applicationTypeID)
        {
            return clsLocalDrivingLicensApplicationData.getAppTypeName(applicationTypeID);
        }

        public static string getUsername(int createdByUserID)
        {
            return clsLocalDrivingLicensApplicationData.getUsername(createdByUserID);
        }

        public static int getTestFee(int TestTypeID)
        {
            return clsLocalDrivingLicensApplicationData.GetTestFees(TestTypeID);
        }

        public static int AddNewTestAppointment(int TestTypeID, int LocalDrivingLicenseApplicationID,
            DateTime AppointmentDate, decimal PaidFees, int CreatedByUserID, bool IsLocked)
        {
            return clsLocalDrivingLicensApplicationData.AddNewTestAppointment
                (TestTypeID,LocalDrivingLicenseApplicationID,AppointmentDate,PaidFees,CreatedByUserID,IsLocked);
        }

        public static DataTable LoadTestAppointments(int LocalDrivingLicenseApplicationID, int TestTypeID)
        {
            return clsLocalDrivingLicensApplicationData.LoadTestAppointments(LocalDrivingLicenseApplicationID, TestTypeID);
        }

        public static bool UpdateTestAppointmentDate(int LocalDrivingLicenseApplicationID, int TestAppointmentID, DateTime AppointmentDate)
        {
            return clsLocalDrivingLicensApplicationData.UpdateTestAppointmentDate(LocalDrivingLicenseApplicationID, TestAppointmentID, AppointmentDate);
        }

        public static DateTime GetTestAppointmentDate(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicensApplicationData.GetTestAppDate(LocalDrivingLicenseApplicationID);
        }

        public static bool hasUnlockedAppointment(int localDrivingLicenseAppID)
        {
            return clsLocalDrivingLicensApplicationData.hasUnlockedAppointment(localDrivingLicenseAppID);
        }

        public static bool AddNewTestResult(int testAppointmentID, bool result, string notes, int userID)
        {
            return clsLocalDrivingLicensApplicationData.AddNewTestResult(testAppointmentID, result, notes, userID);
        }

        public static bool LockTestAppointment(int testAppointmentID)
        {
            return clsLocalDrivingLicensApplicationData.LockTestAppointment(testAppointmentID);
        }

        public static bool IsTestAppointmentLocked(int testAppointmentID)
        {
            return clsLocalDrivingLicensApplicationData.isAppointmentLocked(testAppointmentID);
        }

        public static bool hasPassedTheTest(int testAppointmentID)
        {
            return clsLocalDrivingLicensApplicationData.GetLastTestResult(testAppointmentID); // 0 fail // 1 pass
        }

        public static bool IsStatusCompletedOrCancelled(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicensApplicationData.IsStatusCompletedOrCancelled(LocalDrivingLicenseApplicationID);
        }

        public static bool UpdateApplicationStatus(int LocalDrivingLicenseApplicationID, short newStatus)
        {
            return clsLocalDrivingLicensApplicationData.UpdateApplicaitonStatus(LocalDrivingLicenseApplicationID, newStatus);
        }

        public static int GetLicenseClassID(int LocalDrivingLicenseApplicationID)
        {
            return clsLocalDrivingLicensApplicationData.GetLicenseClassID(LocalDrivingLicenseApplicationID);
        }

        public static bool DeleteLocalDrivingLicenseApplication(int appID)
        {
            return clsLocalDrivingLicensApplicationData.DeleteLocalDrivingLicenseApplication(appID);
        }

        public static int GetLocalDrivingLicenseApplicationIDByNationalNo(string NationalNo)
        {
            return clsLocalDrivingLicensApplicationData.GetLocalDrivingLicenseApplicationIDByNationalNo(NationalNo);
        }
        public static int GetLocalDrivingLicenseApplicationIDByApplicationID(int ApplicationID)
        {
            return clsLocalDrivingLicensApplicationData.GetLocalDrivingLicenseApplicationIDByApplicationID(ApplicationID);
        }

    }
}
