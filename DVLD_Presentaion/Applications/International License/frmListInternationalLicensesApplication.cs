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
using _19___Project___DVLD.People;
using DVLD_Business;

namespace _19___Project___DVLD.Driving_Licenses.International_Licenses
{
    public partial class frmListInternationalLicensesApplication : Form
    {
        public frmListInternationalLicensesApplication()
        {
            InitializeComponent();
        }

        private void frmManageInternationalDrivingLicensesApplications_Load(object sender, EventArgs e)
        {
            dgvInternationalLicenses.DataSource = clsInternationalLicense.GetInternationalDrivingLicensApplications();
            lblRowsCountValue.Text = dgvInternationalLicenses.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void showLicensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InternationalLicenseID = GetInternationalLicenseIDFromDGV();
            if (InternationalLicenseID > 0)
            {
                clsInternationalLicense internationalLicense = clsInternationalLicense.FindLicenseByInternationalLicenseID(InternationalLicenseID);
                if (internationalLicense == null)
                {
                    MessageBox.Show("No license found with the selected license ID",
                        "Invalid license ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int DriverID = internationalLicense.DriverID;
                frmLicensesHistory frm = new frmLicensesHistory(DriverID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a license to show its history",
                    "No license ID is valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private int GetInternationalLicenseIDFromDGV()
        {
            return Convert.ToInt16(dgvInternationalLicenses.CurrentRow.Cells[0].Value);
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int licenseID = clsInternationalLicense.FindLicenseByInternationalLicenseID(GetInternationalLicenseIDFromDGV()).IssuedUsingLocalLicenseID;
            if (licenseID > 0)
            {
                frmShowLicenseInfo form = new frmShowLicenseInfo(licenseID);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("No license found with the selected license ID",
                    "Invalid license ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = clsInternationalLicense.FindLicenseByInternationalLicenseID(GetInternationalLicenseIDFromDGV()).DriverID;
            clsPerson person = clsPerson.Find(clsDriver.FindDriver(DriverID).PersonID);
            if (person != null)
            {
                frmShowPersonInfo form = new frmShowPersonInfo(person);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("No person found with the selected license ID",
                    "Invalid license ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
