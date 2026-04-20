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

namespace _19___Project___DVLD.Driving_License_Services
{
    public partial class frmLicensesHistory : Form
    {
        int DriverID;
        public frmLicensesHistory(int DriverID)
        {
            InitializeComponent();
            this.DriverID = DriverID;
        }

        private void frmLicensesHistory_Load(object sender, EventArgs e)
        {
            clsDriver driver = clsDriver.FindDriver(DriverID);
            if (driver != null)
            {
                ctrlPersonDetailWithFitler1.ShowPersonDetailsWithHistory(driver.PersonID);

                loadLocalLicensesHistory();
                loadInternationalLicensesHistroy();
            }
            else
            {
                MessageBox.Show("Driver Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void loadInternationalLicensesHistroy()
        {
            dgvInernationalLicensesHisory.DataSource = clsInternationalLicense.GetInternationalLicesnsHistory(DriverID);
            lblInternationalLicensesRowsCount.Text = dgvInernationalLicensesHisory.Rows.Count.ToString();
        }

        private void loadLocalLicensesHistory()
        {
            dgvLocalLicensesHisory.DataSource = clsLicense.GetLocalLicesnsHistory(DriverID);
            lblLocalLicensesRowsCount.Text = dgvLocalLicensesHisory.Rows.Count.ToString();
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = getLicenseIDFromDGV();
            if (LicenseID < 1)
            {
                MessageBox.Show("Please Select a License", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            frmShowLicenseInfo frmShowLicenseInfo = new frmShowLicenseInfo(LicenseID);
            frmShowLicenseInfo.ShowDialog();
        }

        private int getLicenseIDFromDGV()
        {
            return Convert.ToInt32(dgvLocalLicensesHisory.CurrentRow.Cells[0].Value);
        }
    }
}
