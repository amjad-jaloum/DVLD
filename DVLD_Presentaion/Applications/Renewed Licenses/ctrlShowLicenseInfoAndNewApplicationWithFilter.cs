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

namespace _19___Project___DVLD.Renewed_Licenses
{
    public partial class ctrlShowLicenseInfoAndNewApplicationWithFilter : UserControl
    {
        AppLicense license = null;
        public ctrlShowLicenseInfoAndNewApplicationWithFilter()
        {
            InitializeComponent();
        }

        private void ctrlShowLicenseInfoAndNewApplicationWithFilter_Load(object sender, EventArgs e)
        {
            lblAppDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblAppFees.Text = ApplicationType.GetFees(ApplicationType.enApplicationType.RenewDrivingLicenseService).ToString();
            if (!DesignMode)
                lblCreatedBy.Text = clsGloabalSettings.LogginUser.UserName;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool isLoaded = LoadLicenseInfo();
            btnShowLicensesInfo.Enabled = false;
            btnShowLicensesHistory.Enabled = isLoaded;
            btnShowLicensesInfo.Enabled = isLoaded;
            btnRenew.Enabled = false;

            if (isLoaded)
            {
                license = ctrlShowLicenseInfo1.license;
                btnRenew.Enabled = CheckLicenseValidation();
                loadRenewDetails();
            }
        }

        private void loadRenewDetails()
        {
            gbAppInfo.Enabled = true;
            lblOldLicenseID.Text = tbSearch.Text;
            lblLicenseFees.Text = license.PaidFees.ToString();
            lblTotalFees.Text = GetTotalFees().ToString();
            lblExpirationDate.Text = license.ExpirationDate.ToShortDateString();
        }

        private int GetTotalFees()
        {
            return (int)(Convert.ToDouble(lblLicenseFees.Text) + Convert.ToDouble(lblAppFees.Text));
        }

        private bool CheckLicenseValidation()
        {
            if (license.IsExpired())
            {
                return true;
            }
            else
            {
                MessageBox.Show($"This License is not expired yet. This license will expire at: {license.ExpirationDate.ToShortDateString()}",
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

        private void btnRenew_Click(object sender, EventArgs e)
        {
            if (license.IsActive)
            {
                int RenewedApplicationID = AddNewRenewedApplication();

                if (RenewedApplicationID != -1)
                {
                    AddNewLocalLicense(RenewedApplicationID);
                    DeactivateCurrentLicense();
                }
                else
                {
                    MessageBox.Show($"Failed to add new application.",
                    "Database error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show($"This license is not active. Renewing licenses require active licenses!",
                "Rejection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private int AddNewRenewedApplication()
        {
            Driver driver = Driver.FindDriver(license.DriverID);
            Application application = new Application(
                0,
                driver.PersonID,
                DateTime.Now,
                (int)ApplicationType.enApplicationType.RenewDrivingLicenseService,
                (short)Application.enApplicationStatus.New,
                license.IssueDate,
                license.PaidFees,
                clsGloabalSettings.LogginUser.UserID
                );

            return application.AddNewApplication();
        }

        private void AddNewLocalLicense(int RenewedApplicationID)
        {
            int NewLicenseID = AppLicense.AddNewLicense(
                RenewedApplicationID,
                license.DriverID,
                license.LicenseClass,
                DateTime.Now,
                DateTime.Now.AddYears(10),
                tbLicenseNotes.Text,
                license.PaidFees,
                true,
                (short)AppLicense.enIssueReason.Renewal,
                clsGloabalSettings.LogginUser.UserID
                );

            if (NewLicenseID == -1)
            {
                MessageBox.Show($"Failed to add new license.",
                "Database error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show($"The renewed driving license is issued successfully!\nLicense ID: {NewLicenseID}",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeactivateCurrentLicense()
        {
            if (!license.Deactivate())
            {
                MessageBox.Show($"Couldn't deactivte the previous license. It could be already deactivated",
                 "Failed To Deactivate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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
    }
}