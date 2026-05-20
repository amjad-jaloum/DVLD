using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Business
{

    public class clsInternationalLicense
    {
        public clsDriver DriverInfo;
        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        public clsInternationalLicense(int internationalLicenseID, int applicationID, int driverID, int issuedUsingLocalLicenseID, DateTime issueDate, DateTime expirationDate, bool isActive, int createdByUserID)
        {
            InternationalLicenseID = internationalLicenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            IssuedUsingLocalLicenseID = issuedUsingLocalLicenseID;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            IsActive = isActive;
            CreatedByUserID = createdByUserID;
        }

        public static int AddNewInternationalDrivingApplication(clsInternationalLicense application)
        {
            return DVLD_DataAccess.clsInternationalLicense.AddNewInternationalDrivingApplication(
                application.ApplicationID,
                application.DriverID,
                application.IssuedUsingLocalLicenseID,
                application.IssueDate,
                application.ExpirationDate,
                application.IsActive,
                application.CreatedByUserID
                );
        }

        public static DataTable GetInternationalDrivingLicensApplications()
        {
            return DVLD_DataAccess.clsInternationalLicense.GetInternationalDrivingLicensApplications();
        }

        public static bool IsInternationalLicenseExists(int IssuedUsingLocalLicenseID)
        {
            return DVLD_DataAccess.clsInternationalLicense.IsInternationalLicenseExists(IssuedUsingLocalLicenseID);
        }

        public static clsInternationalLicense FindLicenseByLocalLicenseID(int IssuedUsingLocalLicenseID)
        {
            int InternationalLicenseID = 0;
            int ApplicationID = 0;
            int DriverID = 0;
            DateTime IssueDate = DateTime.MinValue;
            DateTime ExpirationDate = DateTime.MinValue;
            bool IsActive = false;
            int CreatedByUserID = 0;

            if (DVLD_DataAccess.clsInternationalLicense.FindLicenseByLocalLicenseID(ref InternationalLicenseID, ref ApplicationID, ref DriverID,
                IssuedUsingLocalLicenseID, ref IssueDate, ref ExpirationDate,
                ref IsActive, ref CreatedByUserID))
            {
                return new clsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID,
                IssuedUsingLocalLicenseID, IssueDate, ExpirationDate,
                IsActive, CreatedByUserID);
            }
            else
            {
                return null;
            }

        }

        public static clsInternationalLicense FindLicenseByInternationalLicenseID(int InternationalLicenseID)
        {
            int IssuedUsingLocalLicenseID = 0;
            int ApplicationID = 0;
            int DriverID = 0;
            DateTime IssueDate = DateTime.MinValue;
            DateTime ExpirationDate = DateTime.MinValue;
            bool IsActive = false;
            int CreatedByUserID = 0;

            if (DVLD_DataAccess.clsInternationalLicense.FindLicenseByInternationalLicenseID(InternationalLicenseID, ref ApplicationID, ref DriverID,
                ref IssuedUsingLocalLicenseID, ref IssueDate, ref ExpirationDate,
                ref IsActive, ref CreatedByUserID))
            {
                return new clsInternationalLicense(InternationalLicenseID, ApplicationID, DriverID,
                IssuedUsingLocalLicenseID, IssueDate, ExpirationDate,
                IsActive, CreatedByUserID);
            }
            else
            {
                return null;
            }

        }

        public static DataTable GetInternationalLicesnsHistory(int driverID)
        {
            return DVLD_DataAccess.clsInternationalLicense.GetInternationalLicesnsHistory(driverID);
        }

        internal static DataTable GetDriverInternationalLicenses(int driverID)
        {
            throw new NotImplementedException();
        }
    }
}
