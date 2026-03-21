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
    public class DetainedLicense
    {
        public int DetainID { get; set; }
        public int LicenseID { get; set; }
        public DateTime DetainDate { get; set; }
        public decimal FineFees { get; set; }
        public int CreatedByUserID { get; set; }
        public bool IsReleased { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? ReleasedByUserID { get; set; }
        public int? ReleaseApplicationID { get; set; }

        public DetainedLicense(int detainID, int licenseID, DateTime detainDate, decimal fineFees,
            int createdByUserID, bool isReleased, DateTime? releaseDate, int? releasedByUserID, int? releaseApplicationID)
        {
            DetainID = detainID;
            LicenseID = licenseID;
            DetainDate = detainDate;
            FineFees = fineFees;
            CreatedByUserID = createdByUserID;
            IsReleased = isReleased;
            ReleaseDate = releaseDate;
            ReleasedByUserID = releasedByUserID;
            ReleaseApplicationID = releaseApplicationID;
        }

        public int AddNewDetainedLicense()
        {
            return DetainedLicensesData.AddNewDetainedLicense(LicenseID, DetainDate, FineFees, CreatedByUserID);
        }

        public static bool IsLicenseDetained(int LicenseID)
        {
            return DetainedLicensesData.IsLicenseDetained(LicenseID);
        }

        public static DetainedLicense Find(int licenseID)
        {
            int DetainID = -1;
            DateTime DetainDate = DateTime.MinValue;
            decimal FineFees = 0;
            int CreatedByUserID = -1;
            bool IsReleased = false;
            DateTime? ReleaseDate = null;
            int? ReleasedByUserID = null;
            int? ReleaseApplicationID = null;

            bool isFound = DetainedLicensesData.FindDetainedLicense(
                licenseID,
                ref DetainID,
                ref DetainDate,
                ref FineFees,
                ref CreatedByUserID,
                ref IsReleased,
                ref ReleaseDate,
                ref ReleasedByUserID,
                ref ReleaseApplicationID
            );

            if (isFound)
            {
                return new DetainedLicense(
                     DetainID,
                     licenseID,
                     DetainDate,
                     FineFees,
                     CreatedByUserID,
                     IsReleased,
                     ReleaseDate,
                     ReleasedByUserID,
                     ReleaseApplicationID
                 );

            }
            else
                return null;
        }

        public bool ReleaseDetainedLicense(int ReleasedByUserID, int ReleaseApplicationID)
        {
            return DetainedLicensesData.ReleaseDetainedLicense(DetainID, ReleasedByUserID, ReleaseApplicationID);
        }

        public static DataTable GetDetianedLicense()
        {
            return DetainedLicensesData.GetDetianedLicense();
        }

        public static List<string> GetColumnNames()
        {
            return DetainedLicensesData.GetColumnNames();
        }

        public static DataTable GetDataTableWithQuery(string colName, string searchValue)
        {
            return DetainedLicensesData.GetDataTableWithQuery(colName, searchValue);
        }
    }
}
