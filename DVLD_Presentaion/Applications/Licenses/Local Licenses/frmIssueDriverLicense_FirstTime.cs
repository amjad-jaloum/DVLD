using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using DVLD_Business;

namespace _19___Project___DVLD.Driving_License_Services
{
    public partial class frmIssueDriverLicense_FirstTime : Form
    {
        private int _LocalDrivingLicenseAppID { get; set; }
        private string _licenseName { get; set; }
        private string _applicantFullName { get; set; }
        private DateTime _appDate { get; set; }
        private short _passedTests { get; set; }
        private string _appStatus { get; set; }

        public delegate void IssueDriverLincenseHandler(object sender);
        public event IssueDriverLincenseHandler OnIssueDriverLicense;

        public frmIssueDriverLicense_FirstTime(int LocalDrivingLicenseAppID, string licenseName,
            string applicantFullName, DateTime appDate, short passedTests, string appStatus)
        {
            InitializeComponent();
            _LocalDrivingLicenseAppID = LocalDrivingLicenseAppID;
            _licenseName = licenseName;
            _applicantFullName = applicantFullName;
            _appDate = appDate;
            _passedTests = passedTests;
            _appStatus = appStatus;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            int ApplicationID = LocalDrivingLicenseApplication.GetApplicationID(_LocalDrivingLicenseAppID);
            int LicenseID = AppLicense.AddNewLicense(
                ApplicationID
                , GetDriverID(ApplicationID)
                , GetLinenseClassID()
                , DateTime.Now
                , DateTime.Now.AddYears(10)
                , tbNotes.Text
                , GetPaidFees()
                , true
                , 1
                , clsGloabalSettings.LogginUser.UserID
                );

            if (LicenseID != -1)
            {
                MessageBox.Show("License issued successfully!\nLicese ID: " + LicenseID, 
                    "Issued Successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LocalDrivingLicenseApplication.UpdateApplicationStatus(_LocalDrivingLicenseAppID,
                    (short)LocalDrivingLicenseApplication.enApplicationStatus.Completed);
                OnIssueDriverLicense?.Invoke(this);
            }
            else
            {
                MessageBox.Show("License not issued!", "Not Issued!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private int GetDriverID(int applicationID)
        {
            int driverID = -1;
            if (Driver.FindDriverID(_LocalDrivingLicenseAppID, ref driverID))
            {
                return driverID;
            }
            else
            {
                return AddNewDriverAndGetID();
            }
        }

        private decimal GetPaidFees()
        {
            return Convert.ToDecimal(LocalDrivingLicenseApplication.GetNewLocalDrivingLicenseAppFees());
        }
        private int GetLinenseClassID()
        {
            int licenseClassID = LocalDrivingLicenseApplication.GetLicenseClassID(_LocalDrivingLicenseAppID);
            if (licenseClassID != -1)
            {
                return licenseClassID;
            }
            else
            {
                MessageBox.Show("Error while getting license class ID");
                return licenseClassID;
            }
        }
        private int AddNewDriverAndGetID()
        {
            int PersonID = Driver.AddNewDriver(
            DVLD_Business.Application.GetApplicantPersonID(_LocalDrivingLicenseAppID), clsGloabalSettings.LogginUser.UserID);
            if (PersonID != -1)
            {
                return PersonID;
            }
            else
            {
                MessageBox.Show("Error while creating new driver");
                return PersonID;
            }
        }
        private void LoadPesronInfoToCTRL(object sender, EventArgs e)
        {
            ctrlShowDrivingLicenseAppInfo1.LocalDrivingLicenseAppID = _LocalDrivingLicenseAppID;
            ctrlShowDrivingLicenseAppInfo1.licenseName = _licenseName;
            ctrlShowDrivingLicenseAppInfo1.applicantFullName = _applicantFullName;
            ctrlShowDrivingLicenseAppInfo1.passedTests = _passedTests;
            ctrlShowDrivingLicenseAppInfo1.appDate = _appDate;
            ctrlShowDrivingLicenseAppInfo1.appStatus = _appStatus;

            ctrlShowDrivingLicenseAppInfo1.ctrlShowDrivingLicenseAppInfo_Load(sender, e);
        }
        private void frmIssueDriverLicense_FirstTime_Load(object sender, EventArgs e)
        {
            if (_LocalDrivingLicenseAppID != 0)
                LoadPesronInfoToCTRL(this, e);
            else
                MessageBox.Show("Invalid Local Driving License ID");
        }
    }
}
