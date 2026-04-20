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

namespace _19___Project___DVLD.Driving_Licenses.Detained_Licenses
{
    public partial class ctrlShowLicenseAndDetainInfo : UserControl
    {
        public ctrlShowLicenseAndDetainInfo()
        {
            InitializeComponent();
        }
        clsLicense license = null;

        private void ctrlShowLicenseAndDetainInfo_Load(object sender, EventArgs e)
        {
            lblDetainDate.Text = DateTime.Now.ToShortDateString();
            if (!DesignMode)
                lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool isLoaded = LoadLicenseInfo();
            btnShowLicensesInfo.Enabled = false;
            btnShowLicensesHistory.Enabled = isLoaded;
            btnShowLicensesInfo.Enabled = isLoaded;
            btnDetain.Enabled = false;

            if (isLoaded)
            {
                license = ctrlShowLicenseInfo1.license;
                btnDetain.Enabled = CheckLicenseValidation();
                loadDetainDetails();
            }
        }

        private void loadDetainDetails()
        {
            gbAppInfo.Enabled = true;
            lblLicenseID.Text = tbSearch.Text;
            tbFineFees.Text = "50";
        }

        private bool CheckLicenseValidation()
        {
            if (!clsDetainedLicense.IsLicenseDetained(license.LicenseID))
            {
                return true;
            }
            else
            {
                MessageBox.Show($"This License is already detained.",
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

        private void btnDetain_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show($"Are you sure you want to detain this license?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                AddNewDetainedLicense();
            }
        }

        private void AddNewDetainedLicense()
        {
            clsDetainedLicense detainedLicense = new clsDetainedLicense(
                0,
                license.LicenseID,
                Convert.ToDateTime(lblDetainDate.Text),
                Convert.ToDecimal(tbFineFees.Text),
                clsGlobal.CurrentUser.UserID,
                false, null, null, null);

            int detainedLicenseID = detainedLicense.AddNewDetainedLicense();
            if (detainedLicenseID > 0)
            {
                MessageBox.Show($"License has been detained successfully.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSearch.PerformClick();
            }
            else
            {
                MessageBox.Show($"Failed to detain the license.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
