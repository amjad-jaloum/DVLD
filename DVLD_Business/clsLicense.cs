using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;

namespace DVLD_Business
{
    public class clsLicense
    {
        public int LicenseID { get; set; }
        public int ApplicationID { get; set; }
        public int DriverID { get; set; }
        public int LicenseClass { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Notes { get; set; }
        public decimal PaidFees { get; set; }
        public bool IsActive
        {
            get;
            set;
        }
        public short IssueReason { get; set; }
        public int CreatedByUserID { get; set; }
        public enum enIssueReason
        {
            FirstTime = 1,
            Renewal = 2,
            LostReplacement = 3,
            DamagedReplacement = 4,
            ReleasedDetainedLicense = 5,
            InternationalLicense = 6
        }
        public string IssueReasonToString()
        {
            switch (IssueReason)
            {
                case 1:
                    return "First Time";
                case 2:
                    return "Renewal";
                case 3:
                    return "Lost Replacement";
                case 4:
                    return "Damaged Replacement";
                case 5:
                    return "Released Detained License";
                case 6:
                    return "International License";
                default:
                    return "Unknown";
            }
        }

        public clsLicense(int licenseID, int applicationID, int driverID, int licenseClass, DateTime issueDate,
            DateTime expirationDate, string notes, decimal paidFees, bool isActive, short issueReason, int createdByUserID)
        {
            LicenseID = licenseID;
            ApplicationID = applicationID;
            DriverID = driverID;
            LicenseClass = licenseClass;
            IssueDate = issueDate;
            ExpirationDate = expirationDate;
            Notes = notes;
            PaidFees = paidFees;
            IsActive = isActive;
            IssueReason = issueReason;
            CreatedByUserID = createdByUserID;
        }


        public static int AddNewLicense(int ApplicationID, int DriverID, int LicenseClass,
            DateTime IssueDate, DateTime ExpirationDate, string Notes, decimal PaidFees,
            bool IsActive, short IssueReason, int CreatedByUserID)
        {
            return DVLD_DataAccess.clsLicense.AddNewLicense(ApplicationID, DriverID, LicenseClass,
                IssueDate, ExpirationDate, Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
        }

        public static clsLicense FindLicense(int LicenseID)
        {
            int ApplicationID = -1;
            int DriverID = -1;
            int LicenseClass = -1;
            DateTime IssueDate = DateTime.MinValue;
            DateTime ExpirationDate = DateTime.MaxValue;
            string Notes = string.Empty;
            decimal PaidFees = 0;
            bool IsActive = false;
            short IssueReason = 0;
            int CreatedByUserID = -1;

            bool isFound = DVLD_DataAccess.clsLicense.FindLicense(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass,
                ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID);
            if (isFound)
            {
                return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate,
                    Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            }
            else
                return null;
        }

        public static int GetLicenseIDByLocalDrivingLicenseApplicationID(int localDrivingLicneseAppID)
        {
            return DVLD_DataAccess.clsLicense.GetLicenseID(localDrivingLicneseAppID);
        }

        public static DataTable GetLocalLicesnsHistory(int DriverID)
        {
            return DVLD_DataAccess.clsLicense.GetLicensesHistory(DriverID, (int)clsApplicationType.enApplicationType.NewInternationalLicense);
        }

        public bool IsExpired()
        {
            return DateTime.Now > ExpirationDate;
        }


        public bool Deactivate()
        {
            return DVLD_DataAccess.clsLicense.Deactivate(LicenseID);
        }

        internal static int GetActiveLicenseIDByPersonID(int applicantPersonID, int licenseClassID)
        {
            throw new NotImplementedException();
        }

        public static bool IsLicenseExistByPersonID(int personID, int licenseClassID)
        {
            throw new NotImplementedException();
        }
    }
}
