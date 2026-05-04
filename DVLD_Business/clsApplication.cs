using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVLD_DataAccess;
using static System.Net.Mime.MediaTypeNames;
using static DVLD_Business.clsLocalDrivingLicenseApplication;

namespace DVLD_Business
{
    public class clsApplication
    {
        public int ApplicationID { get; set; }
        public int ApplicantPersonID { get; set; }
        public DateTime ApplicationDate { get; set; }
        public int ApplicationTypeID { get; set; }
        public short ApplicationStatus { get; set; }
        public DateTime LastStatusDate { get; set; }
        public decimal PaidFees { get; set; }
        public int CreatedByUserID { get; set; }
        public enum enApplicationStatus : short
        {
            New = 1,
            Cancelled = 2,
            Completed = 3,
        }

        public clsApplication(int applicationID, int applicantPersonID, DateTime applicationDate,
            int applicationTypeID, short applicationStatus, DateTime lastStatusDate, decimal paidFees, int createdByUserID)
        {
            ApplicationID = applicationID;
            ApplicantPersonID = applicantPersonID;
            ApplicationDate = applicationDate;
            ApplicationTypeID = applicationTypeID;
            ApplicationStatus = applicationStatus;
            LastStatusDate = lastStatusDate;
            PaidFees = paidFees;
            CreatedByUserID = createdByUserID;
        }

        public static clsApplication Find(int applicationID)
        {
            int ApplicantPersonID = 0;
            DateTime ApplicationDate = DateTime.MinValue;
            int ApplicationTypeID = 0;
            short ApplicationStatus = 0;
            DateTime LastStatusDate = DateTime.MinValue;
            decimal PaidFees = 0;
            int CreatedByUserID = 0;

            bool isFound = DVLD_DataAccess.clsApplication.Find(applicationID, ref ApplicantPersonID, ref ApplicationDate, ref ApplicationTypeID,
                    ref ApplicationStatus, ref LastStatusDate, ref PaidFees, ref CreatedByUserID);
            if (isFound)
            {
                return new clsApplication(applicationID, ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus
                    , LastStatusDate, PaidFees, CreatedByUserID);
            }
            else
                return null;
        }

        public static int GetApplicantPersonID(int localDrivingLicenseAppID)
        {
            return DVLD_DataAccess.clsApplication.GetApplicantPersonID(localDrivingLicenseAppID);
        }

        public int AddNewApplication()
        {
            return DVLD_DataAccess.clsApplication.AddNewApplication(ApplicantPersonID, ApplicationDate, ApplicationTypeID, ApplicationStatus, LastStatusDate, PaidFees, CreatedByUserID);
        }
    }
}
