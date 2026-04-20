using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _19___Project___DVLD.People;
using DVLD_Business;

namespace _19___Project___DVLD.Driving_License_Services
{
    public partial class ctrlDrivingLicenseApplicationInfo : UserControl
    {
        public int LocalDrivingLicenseAppID { get; set; }
        public string licenseName { get; set; }
        public string applicantFullName { get; set; }
        public DateTime appDate { get; set; }
        public short passedTests { get; set; }
        public string appStatus { get; set; }

        private clsLocalDrivingLicenseApplication _Application;
        public ctrlDrivingLicenseApplicationInfo()
        {
            InitializeComponent();
        }

        public void ctrlShowDrivingLicenseAppInfo_Load(object sender, EventArgs e)
        {
            // D.L App info
            lblLocalDrivingAppID.Text = LocalDrivingLicenseAppID.ToString();
            lblLicenseName.Text = licenseName;
            lblPassedTests.Text = passedTests.ToString() + "/3";
            lblStatusDate.Text = appStatus;
            lblApplicant.Text = applicantFullName;

            // Basic App info
            int ApplicationID = clsLocalDrivingLicenseApplication.GetApplicationID(LocalDrivingLicenseAppID);
            _Application = clsLocalDrivingLicenseApplication.FindApplication(ApplicationID);
            if (_Application != null && ApplicationID > 0)
            {
                lblAppID.Text = ApplicationID.ToString();
                lblAppDate.Text = appDate.ToString();
                lblAppFees.Text = _Application.PaidFees.ToString();
                lblAppTypeName.Text = clsLocalDrivingLicenseApplication.getAppTypeName(_Application.ApplicationTypeID);
                lblCreatedByUsername.Text = clsLocalDrivingLicenseApplication.getUsername(_Application.CreatedByUserID);
            }
            
        }

        private void btnViewPersonInfo_Click(object sender, EventArgs e)
        {
            clsPerson _Person = clsPerson.Find(_Application.ApplicantPersonID);
            if (_Person != null)
            {
                frmShowPersonInfo PersonDetails = new frmShowPersonInfo(_Person);
                PersonDetails.ShowDialog();
            }
            else
                MessageBox.Show("Person details are not loaded properly!");
        }
    }
}
