using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
