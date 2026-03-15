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

    public class InternationalDrivingLicensesApplication
    {
        public int InternationalLicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int IssuedUsingLocalLicenseID { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsActive { get; set; }
        public int CreatedByUserID { get; set; }

        public InternationalDrivingLicensesApplication(int internationalLicenseID, int applicationID, int driverID, int issuedUsingLocalLicenseID, DateTime issueDate, DateTime expirationDate, bool isActive, int createdByUserID)
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

        public static int AddNewInternationalDrivingApplication(InternationalDrivingLicensesApplication application)
        {
            return InternationalDrivingLicenseApplicatioansData.AddNewInternationalDrivingApplication(
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
            return InternationalDrivingLicenseApplicatioansData.GetInternationalDrivingLicensApplications();
        }

        public static bool IsInternationalLicenseExists(int IssuedUsingLocalLicenseID)
        {
            return InternationalDrivingLicenseApplicatioansData.IsInternationalLicenseExists( IssuedUsingLocalLicenseID );
        }

        public static InternationalDrivingLicensesApplication FindLicense(int IssuedUsingLocalLicenseID)
        {
            int InternationalLicenseID = 0;
            int ApplicationID = 0;
            int DriverID = 0;
            DateTime IssueDate = DateTime.MinValue;
            DateTime ExpirationDate = DateTime.MinValue;
            bool IsActive = false;
            int CreatedByUserID = 0;

            if (InternationalDrivingLicenseApplicatioansData.FindLicense(ref InternationalLicenseID, ref ApplicationID, ref DriverID,
                IssuedUsingLocalLicenseID, ref IssueDate, ref ExpirationDate,
                ref IsActive, ref CreatedByUserID))
            {
                return new InternationalDrivingLicensesApplication(InternationalLicenseID, ApplicationID, DriverID,
                IssuedUsingLocalLicenseID, IssueDate, ExpirationDate,
                IsActive, CreatedByUserID);
            }
            else
            {
                return null;
            }

        }
    }
}
