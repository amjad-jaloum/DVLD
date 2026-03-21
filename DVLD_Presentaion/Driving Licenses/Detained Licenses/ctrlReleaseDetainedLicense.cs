using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _19___Project___DVLD.Driving_License_Services;
using DVLD_Business;
using Application = DVLD_Business.Application;

namespace _19___Project___DVLD.Driving_Licenses.Detained_Licenses
{
    public partial class ctrlReleaseDetainedLicense : UserControl
    {
        public ctrlReleaseDetainedLicense()
        {
            InitializeComponent();
        }
        AppLicense license = null;
        DetainedLicense detainedLicense = null;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchForLicense();
        }

        private void SearchForLicense()
        {
            bool isLoaded = LoadLicenseInfo();
            btnShowLicensesInfo.Enabled = false;
            btnShowLicensesHistory.Enabled = isLoaded;
            btnShowLicensesInfo.Enabled = isLoaded;
            btnRelease.Enabled = false;

            if (isLoaded)
            {
                license = ctrlShowLicenseInfo1.license;
                btnRelease.Enabled = CheckLicenseValidation();
                loadDetainDetails();
            }
        }

        private void loadDetainDetails()
        {
            gbAppInfo.Enabled = true;
            lblLicenseID.Text = tbSearch.Text;

            detainedLicense = DetainedLicense.Find(license.LicenseID);
            if (detainedLicense != null)
            {
                lblDetainID.Text = detainedLicense.DetainID.ToString();
                lblDetainDate.Text = detainedLicense.DetainDate.ToShortDateString();
                lblAppFees.Text = ApplicationType.GetFees(ApplicationType.enApplicationType.ReleaseDetainedDrivingLicense).ToString();
                lblCreatedBy.Text = User.FindUser(detainedLicense.CreatedByUserID).UserName;
                lblFineFees.Text = detainedLicense.FineFees.ToString();
                lblTotalFees.Text = GetTotalFees();
            }
            else
            {
                MessageBox.Show($"No detain record found for this license.",
                    "Regection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string GetTotalFees()
        {
            return (Convert.ToDouble(lblAppFees.Text) + Convert.ToDouble(lblFineFees.Text)).ToString();
        }

        private bool CheckLicenseValidation()
        {
            if (DetainedLicense.IsLicenseDetained(license.LicenseID))
            {
                return true;
            }
            else
            {
                MessageBox.Show($"This License is not detained.",
                    "Regection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private bool LoadLicenseInfo()
        {
            object sender = null;
            EventArgs e = new EventArgs();

            ctrlShowLicenseInfo1.LicenseID = Convert.ToInt32(tbSearch.Text);
            ctrlShowLicenseInfo1.ctrlShowLicenseInfo_Load(sender, e);
            return ctrlShowLicenseInfo1.IsLoaded;
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch.PerformClick();
                e.Handled = true;
            }
        }

        private void btnRelease_Click(object sender, EventArgs e)
        {
            if (detainedLicense.IsReleased)
            {
                MessageBox.Show("This License is already released",
                "Regection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to release this detained license?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialogResult == DialogResult.Yes)
            {
                ReleaseDetainedLicense();
            }
        }

        private void ReleaseDetainedLicense()
        {
            int DetainedApplicationID = AddNewDetainedApplication();

            if (DetainedApplicationID != -1)
            {
                ReleaseDetainedLicense(DetainedApplicationID);
                lblD_L_ApplicationID.Text = DetainedApplicationID.ToString();
            }
            else
            {
                MessageBox.Show($"Failed to add new application.",
                "Database error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ReleaseDetainedLicense(int DetainedApplicationID)
        {
            if (detainedLicense.ReleaseDetainedLicense(clsGloabalSettings.LogginUser.UserID, DetainedApplicationID))
            {
                MessageBox.Show($"License released successfully.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnRelease.Enabled = false;
            }
            else
            {
                MessageBox.Show($"Failed to release the license.",
                    "Database error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private int AddNewDetainedApplication()
        {
            Driver driver = Driver.FindDriver(license.DriverID);
            Application LicenseApplication = Application.Find(license.ApplicationID);

            Application application = new Application(
                0,
                driver.PersonID,
                DateTime.Now,
                (int)ApplicationType.enApplicationType.ReleaseDetainedDrivingLicense,
                LicenseApplication.ApplicationStatus,
                DateTime.Now,
                ApplicationType.GetFees(ApplicationType.enApplicationType.ReleaseDetainedDrivingLicense),
                clsGloabalSettings.LogginUser.UserID
                );

            return application.AddNewApplication();
        }

        private void btnShowLicensesInfo_Click(object sender, EventArgs e)
        {
            frmShowLicenseInfo showLicenseInfo = new frmShowLicenseInfo(license.LicenseID);
            showLicenseInfo.ShowDialog();
        }

        private void btnShowLicensesHistory_Click(object sender, EventArgs e)
        {
            frmLicensesHistory licensesHistory = new frmLicensesHistory(license.DriverID);
            licensesHistory.ShowDialog();
        }

        public void FindDetainedLicense(int LicenseID)
        {
            tbSearch.Text = LicenseID.ToString();
            SearchForLicense();
            btnSearch.Enabled = false;
            tbSearch.Enabled = false;
        }
    }
}
