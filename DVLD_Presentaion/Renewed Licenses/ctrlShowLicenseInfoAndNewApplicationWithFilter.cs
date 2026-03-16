using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;

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
            lblAppFees.Text = ApplicationType.GetFees((int)ApplicationType.enApplicationType.RenewDrivingLicenseService).ToString();
            if (!DesignMode)
                lblCreatedBy.Text = clsGloabalSettings.LogginUser.UserName;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool isLoaded = LoadLicenseInfo();
            btnShowLicensesInfo.Enabled = false;
            btnShowLicensesHistory.Enabled = isLoaded;
            btnRenew.Enabled = false;

            if (isLoaded)
            {
                license = ctrlShowLicenseInfo1.license;
                btnRenew.Enabled = CheckLicenseValidation();
                loadRenewDetails();
                //ResetRenewAppControls();

            }
        }

        private void loadRenewDetails()
        {
            if (true)
            {
                gbAppInfo.Enabled = true;
                lblOldLicenseID.Text = tbSearch.Text;
                lblLicenseFees.Text = license.PaidFees.ToString();
                lblTotalFees.Text = GetTotalFees().ToString();
                lblExpirationDate.Text = license.ExpirationDate.ToShortDateString();
            }
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

        private void ResetRenewAppControls()
        {
            if (!license.IsExpired())
            {
                lblLicenseFees.Text = "[???]";
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

        }

        private void btnShowLicensesInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnShowLicensesHistory_Click(object sender, EventArgs e)
        {

        }
    }
}
