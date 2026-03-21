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

namespace _19___Project___DVLD.Driving_Licenses.Detained_Licenses
{
    public partial class frmManageDetainedLicenses : Form
    {
        public frmManageDetainedLicenses()
        {
            InitializeComponent();
        }

        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            dgvDetainedLicenses.DataSource = DetainedLicense.GetDetianedLicense();
            lblRowsCountValue.Text = dgvDetainedLicenses.Rows.Count.ToString();
            LoadComboBoxFilter();
            LoadComboBoxActiveStatus();

        }

        private void LoadComboBoxActiveStatus()
        {
            cbStatus.Items.Add("All");      // index 0
            cbStatus.Items.Add("Detained"); // index 1
            cbStatus.Items.Add("Released"); // index 2

            cbStatus.SelectedIndex = 0;
        }

        private void LoadComboBoxFilter()
        {
            List<string> ColumnNames = DetainedLicense.GetColumnNames();
            if (ColumnNames == null)
            {
                MessageBox.Show("Database error, Column names are not loaded properly!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                FillFilterComboBox(ColumnNames);
            }
        }

        private void FillFilterComboBox(List<string> ColumnNames)
        {
            cbFilter.Items.Add("None");
            cbFilter.SelectedItem = "None";

            foreach (string ColumnName in ColumnNames)
                cbFilter.Items.Add(ColumnName);
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = AppLicense.FindLicense(GetLicenseIDFromDGV()).DriverID;
            Person person = Person.FindPerson(Driver.FindDriver(DriverID).PersonID);
            if (person != null)
            {
                frmShowPersonDetails form = new frmShowPersonDetails(person);
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("No person found with the selected license ID",
                    "Invalid license ID", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetLicenseIDFromDGV()
        {
            return Convert.ToInt32(dgvDetainedLicenses.CurrentRow.Cells["L.ID"].Value.ToString());
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int licenseID = AppLicense.FindLicense(GetLicenseIDFromDGV()).LicenseID;
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

        private void showLicensesHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int DriverID = AppLicense.FindLicense(GetLicenseIDFromDGV()).DriverID;

            frmLicensesHistory frmLicensesHistory = new frmLicensesHistory(DriverID);
            frmLicensesHistory.ShowDialog();
        }

        private void ReleaseDetainedLicenseStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.FindDetainedLicense(GetLicenseIDFromDGV());
            frm.ShowDialog();
        }

        private void mtxbSearch_TextChanged(object sender, EventArgs e)
        {
            UpdateDataTableWithFilter();

        }

        private void UpdateDataTableWithFilter()
        {
            if (!cbFilter.SelectedItem.ToString().Contains("None"))
            {
                string SearchValue = GetSearchValue();
                dgvDetainedLicenses.DataSource = DetainedLicense.GetDataTableWithQuery(cbFilter.SelectedItem.ToString(), SearchValue);
                lblRowsCountValue.Text = dgvDetainedLicenses.RowCount.ToString();
            }
        }

        private string GetSearchValue()
        {
            string SearchValue;
            if (cbFilter.SelectedItem.ToString() == "Is Released")
            {
                if (cbStatus.SelectedItem.ToString() == "All")
                    SearchValue = string.Empty;
                else
                    SearchValue = GetItemValueByIndex();
            }
            else
            {
                SearchValue = mtxbSearch.Text;
            }

            return SearchValue;
        }

        private string GetItemValueByIndex()
        {
            return (cbStatus.SelectedIndex - 1).ToString();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            mtxbSearch.Visible = !(cbFilter.SelectedItem.ToString() == "None" || cbFilter.SelectedItem.ToString() == "Is Released");
            cbStatus.Visible = cbFilter.SelectedItem.ToString().Contains("Is Released");

            if (cbFilter.SelectedItem.ToString() == "D.ID" || cbFilter.SelectedItem.ToString() == "Release App.ID")
                mtxbSearch.Mask = "000000";
            else
            {
                if (cbFilter.SelectedItem.ToString() == "None")
                {
                    mtxbSearch.Text = string.Empty;
                    dgvDetainedLicenses.DataSource = DetainedLicense.GetDetianedLicense();
                    lblRowsCountValue.Text = dgvDetainedLicenses.Rows.Count.ToString();
                }
                mtxbSearch.Mask = "";
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnReleaseLicense_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();
        }

        private void btnDetainLicense_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataTableWithFilter();
        }
    }
}
