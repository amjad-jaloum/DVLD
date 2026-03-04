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
    public partial class ctrlShowDrivingLicenseAppInfo : UserControl
    {
        public int LocalDrivingLicenseAppID { get; set; }
        public string licenseName { get; set; }
        public string applicantFullName { get; set; }
        public DateTime appDate { get; set; }
        public short passedTests { get; set; }
        public string appStatus { get; set; }

        private LocalDrivingLicenseApplication _Application;
        public ctrlShowDrivingLicenseAppInfo()
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
            int ApplicationID = LocalDrivingLicenseApplication.GetApplicationID(LocalDrivingLicenseAppID);
            _Application = LocalDrivingLicenseApplication.FindLocalDrivingLicenseApplication(ApplicationID);
            if (_Application != null && ApplicationID > 0)
            {
                lblAppID.Text = ApplicationID.ToString();
                lblAppDate.Text = appDate.ToString();
                lblAppFees.Text = _Application.PaidFees.ToString();
                lblAppTypeName.Text = LocalDrivingLicenseApplication.getAppTypeName(_Application.ApplicationTypeID);
                lblCreatedByUsername.Text = LocalDrivingLicenseApplication.getUsername(_Application.CreatedByUserID);
            }
            
        }

        private void btnViewPersonInfo_Click(object sender, EventArgs e)
        {
            Person _Person = Person.FindPerson(_Application.ApplicantPersonID);
            if (_Person != null)
            {
                frmShowPersonDetails PersonDetails = new frmShowPersonDetails(_Person);
                PersonDetails.ShowDialog();
            }
            else
                MessageBox.Show("Person details are not loaded properly!");
        }
    }
}
