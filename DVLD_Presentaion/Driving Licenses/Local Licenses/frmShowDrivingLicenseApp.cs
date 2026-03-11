using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DVLD_Business;

namespace _19___Project___DVLD.Driving_License_Services
{
    public partial class frmShowDrivingLicenseApp : Form
    {
        private int _LocalDrivingLicenseAppID { get; set; }
        string _licenseName{ get; set; }
        string _applicantFullName{ get; set; }
        DateTime _appDate { get; set; }
        short _passedTests{ get; set; }
        string _appStatus { get; set; }
        public frmShowDrivingLicenseApp(int LocalDrivingLicenseAppID, string licenseName, 
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

        private void frmShowDrivingLicenseApp_Load(object sender, EventArgs e)
        {
            if (_LocalDrivingLicenseAppID > 0)
            {
                ctrlShowDrivingLicenseAppInfo1.LocalDrivingLicenseAppID = _LocalDrivingLicenseAppID;
                ctrlShowDrivingLicenseAppInfo1.licenseName = _licenseName;
                ctrlShowDrivingLicenseAppInfo1.applicantFullName = _applicantFullName;
                ctrlShowDrivingLicenseAppInfo1.passedTests = _passedTests;
                ctrlShowDrivingLicenseAppInfo1.appDate = _appDate;
                ctrlShowDrivingLicenseAppInfo1.appStatus = _appStatus;

                ctrlShowDrivingLicenseAppInfo1.ctrlShowDrivingLicenseAppInfo_Load(sender, e);
            }
            else
                MessageBox.Show("Invalid Application ID");
        }
    }
}
