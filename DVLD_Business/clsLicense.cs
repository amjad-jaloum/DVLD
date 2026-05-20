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
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public enum enIssueReason { FirstTime = 1, Renew = 2, DamagedReplacement = 3, LostReplacement = 4 };

        public clsDriver DriverInfo;
        public int LicenseID { set; get; }
        public int ApplicationID { set; get; }
        public int DriverID { set; get; }
        public int LicenseClass { set; get; }
        public clsLicenseClass LicenseClassIfo;
        public DateTime IssueDate { set; get; }
        public DateTime ExpirationDate { set; get; }
        public string Notes { set; get; }
        public float PaidFees { set; get; }
        public bool IsActive { set; get; }
        public enIssueReason IssueReason { set; get; }
        public string IssueReasonText
        {
            get
            {
                return GetIssueReasonText(this.IssueReason);
            }
        }

        public static string GetIssueReasonText(enIssueReason IssueReason)
        {

            switch (IssueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                case enIssueReason.DamagedReplacement:
                    return "Replacement for Damaged";
                case enIssueReason.LostReplacement:
                    return "Replacement for Lost";
                default:
                    return "First Time";
            }
        }

        public clsDetainedLicense DetainedInfo { set; get; }
        public int CreatedByUserID { set; get; }
        public bool IsDetained
        {
            get { return clsDetainedLicense.IsLicenseDetained(this.LicenseID); }
        }


        public string IssueReasonToString()
        {
            //switch (IssueReason)
            //{
            //    case 1:
            //        return "First Time";
            //    case 2:
            //        return "Renewal";
            //    case 3:
            //        return "Lost Replacement";
            //    case 4:
            //        return "Damaged Replacement";
            //    case 5:
            //        return "Released Detained License";
            //    case 6:
            //        return "International License";
            //    default:
            //        return "Unknown";
            //}
            return "";
        }

        public clsLicense(int licenseID, int applicationID, int driverID, int licenseClass, DateTime issueDate,
            DateTime expirationDate, string notes, float paidFees, bool isActive, short issueReason, int createdByUserID)
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
            IssueReason =(enIssueReason) issueReason;
            CreatedByUserID = createdByUserID;
        }

        public clsLicense()
        {
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
            //int ApplicationID = -1;
            //int DriverID = -1;
            //int LicenseClass = -1;
            //DateTime IssueDate = DateTime.MinValue;
            //DateTime ExpirationDate = DateTime.MaxValue;
            //string Notes = string.Empty;
            //float PaidFees = 0;
            //bool IsActive = false;
            //short IssueReason = 0;
            //int CreatedByUserID = -1;

            //bool isFound = DVLD_DataAccess.clsLicense.FindLicense(LicenseID, ref ApplicationID, ref DriverID, ref LicenseClass,
            //    ref IssueDate, ref ExpirationDate, ref Notes, ref PaidFees, ref IsActive, ref IssueReason, ref CreatedByUserID);
            //if (isFound)
            //{
            //    return new clsLicense(LicenseID, ApplicationID, DriverID, LicenseClass, IssueDate, ExpirationDate,
            //        Notes, PaidFees, IsActive, IssueReason, CreatedByUserID);
            //}
            //else
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

        internal bool Save()
        {
            throw new NotImplementedException();
        }
    }
}
