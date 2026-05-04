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
using clsApplication = DVLD_Business.clsApplication;

namespace _19___Project___DVLD.Driving_Licenses.Licenses_Replacement
{
    public partial class ctrlReplacementForDamagedOrLostLicense : UserControl
    {
        clsLicense license = null;

        public ctrlReplacementForDamagedOrLostLicense()
        {
            InitializeComponent();
        }
        private void ctrlReplacementForDamagedOrLostLicense_Load(object sender, EventArgs e)
        {
            lblAppDate.Text = DateTime.Now.ToShortDateString();
            lblAppFees.Text = GetFees();
            if (!DesignMode)
                lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }

        private string GetFees()
        {
            return rbDamaged.Checked ? clsApplicationType.GetFees(clsApplicationType.enApplicationType.ReplacementForDamagedDrivingLicense).ToString() : clsApplicationType.GetFees(clsApplicationType.enApplicationType.ReplacementForLostDrivingLicense).ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool isLoaded = LoadLicenseInfo();
            btnShowLicensesInfo.Enabled = false;
            btnShowLicensesHistory.Enabled = isLoaded;
            btnShowLicensesInfo.Enabled = isLoaded;
            btnIssueReplacement.Enabled = false;

            if (isLoaded)
            {
                license = ctrlShowLicenseInfo1.license;
                btnIssueReplacement.Enabled = CheckLicenseValidation();
                loadRenewDetails();
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

        private void loadRenewDetails()
        {
            gbAppInfo.Enabled = true;
            lblOldLicenseID.Text = tbSearch.Text;
        }

        private bool CheckLicenseValidation()
        {
            if (license.IsActive)
            {
                return true;
            }
            else
            {
                MessageBox.Show($"This License is not active. Please choose an active license.",
                    "Regection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch.PerformClick();
                e.Handled = true;
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

        private void rbDamaged_CheckedChanged(object sender, EventArgs e)
        {
            lblAppFees.Text = GetFees();
        }

        private void rbLost_CheckedChanged(object sender, EventArgs e)
        {
            lblAppFees.Text = GetFees();
        }

        private void btnIssueReplacement_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to issue new replacement license?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                int ReplacedApplicationID = AddNewReplacementApplication();

                if (ReplacedApplicationID != -1)
                {
                    AddNewLocalLicense(ReplacedApplicationID);
                    DeactivateCurrentLicense();
                    btnSearch.PerformClick();
                }
                else
                {
                    MessageBox.Show($"Failed to add new application.",
                    "Database error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private int AddNewReplacementApplication()
        {
            clsDriver driver = clsDriver.FindDriver(license.DriverID);

            clsApplication application = new clsApplication(
                0,
                driver.PersonID,
                DateTime.Now,
                GetAppStatusFromRadioBox(),
                clsApplication.Find(license.ApplicationID).ApplicationStatus,
                license.IssueDate,
                license.PaidFees,
                clsGlobal.CurrentUser.UserID
                );

            return application._AddNewApplication();
        }

        private int GetAppStatusFromRadioBox()
        {
            return rbDamaged.Checked ? (int)clsApplicationType.enApplicationType.ReplacementForDamagedDrivingLicense : (int)clsApplicationType.enApplicationType.ReplacementForLostDrivingLicense;
        }

        private void AddNewLocalLicense(int ReplacedApplicationID)
        {
            int NewLicenseID = clsLicense.AddNewLicense(
                ReplacedApplicationID,
                license.DriverID,
                license.LicenseClass,
                license.IssueDate,
                license.ExpirationDate,
                string.Empty,
                license.PaidFees,
                true,
                GetLicenseIssueReasonFromRadioBox(),
                clsGlobal.CurrentUser.UserID
                );

            if (NewLicenseID == -1)
            {
                MessageBox.Show($"Failed to add new license.",
                "Database error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show($"The replacement driving license is issued successfully!\nLicense ID: {NewLicenseID}",
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private short GetLicenseIssueReasonFromRadioBox()
        {
            return rbDamaged.Checked ? (short)clsLicense.enIssueReason.DamagedReplacement : (short)clsLicense.enIssueReason.LostReplacement;
        }

        private void DeactivateCurrentLicense()
        {
            if (!license.Deactivate())
            {
                MessageBox.Show($"Couldn't deactivte the previous license. It could be already deactivated",
                 "Failed To Deactivate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }

}
