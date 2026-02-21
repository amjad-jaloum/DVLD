using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _19___Project___DVLD.Driving_License_Services.Schedule_Tests;
using _19___Project___DVLD.Users;
using DVLD_Business;

namespace _19___Project___DVLD.Driving_License_Services
{
    public partial class frmManageLocalDrivingLicenseApplications : Form
    {
        private enum enAppStatus
        {
            New = 1, Cancelled = 2, Completed = 3
        }

        public frmManageLocalDrivingLicenseApplications()
        {
            InitializeComponent();
        }
        private void frmManageLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            LoadLocalDrivingLicensesToDGV();
            LoadComboBoxFilter();
            LoadComboBoxActiveStatus();
        }
        private string GetStatusName(enAppStatus enAppStatus)
        {
            switch (enAppStatus)
            {
                case enAppStatus.New: return "New";
                case enAppStatus.Cancelled: return "Cancelled";
                case enAppStatus.Completed: return "Completed";
                default: return "";
            }
        }
        private void LoadComboBoxActiveStatus()
        {
            cbStatus.Items.Add("All");
            cbStatus.Items.Add(GetStatusName(enAppStatus.New));
            cbStatus.Items.Add(GetStatusName(enAppStatus.Cancelled));
            cbStatus.Items.Add(GetStatusName(enAppStatus.Completed));

            cbStatus.SelectedIndex = 0;
        }
        private void LoadComboBoxFilter()
        {
            List<string> ColumnNames = LocalDrivingLicenseApplication.GetLocalDrivingLincesesColumns();
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
        private void LoadLocalDrivingLicensesToDGV()
        {
            dgvLocalLicenses.DataSource = LocalDrivingLicenseApplication.GetLocalLicenseApplications();
            dgvLocalLicenses.Columns[0].HeaderText = "L.App ID";
            lblRowsCountValue.Text = dgvLocalLicenses.Rows.Count.ToString();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnNewLocalLicense_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicenseApplications frm = new frmNewLocalDrivingLicenseApplications();
            frm.DataBack += HandleDelgateData;
            frm.ShowDialog();
        }
        private void HandleDelgateData(object sender)
        {
            LoadLocalDrivingLicensesToDGV();
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            mtxbSearch.Visible = !(cbFilter.SelectedItem.ToString() == "None" || cbFilter.SelectedItem.ToString() == "Status");
            cbStatus.Visible = cbFilter.SelectedItem.ToString().Contains("Status");

            if (cbFilter.SelectedItem.ToString() == "LocalDrivingLicenseApplicationID")
                mtxbSearch.Mask = "000000";
            else
            {
                if (cbFilter.SelectedItem.ToString() == "None")
                {
                    mtxbSearch.Text = string.Empty;
                    LoadLocalDrivingLicensesToDGV();
                }
                mtxbSearch.Mask = "";
            }
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
                dgvLocalLicenses.DataSource = LocalDrivingLicenseApplication.GetDataTableWithQuery(cbFilter.SelectedItem.ToString(), SearchValue);
                lblRowsCountValue.Text = dgvLocalLicenses.RowCount.ToString();
            }
        }
        private string GetSearchValue()
        {
            string SearchValue;
            if (cbFilter.SelectedItem.ToString() == "Status")
            {
                if (cbStatus.SelectedItem.ToString() == "All")
                    SearchValue = string.Empty;
                else
                    SearchValue = cbStatus.SelectedItem.ToString();
            }
            else
            {
                SearchValue = mtxbSearch.Text;
            }

            return SearchValue;
        }
        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataTableWithFilter();
        }
        private void cancelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to cancel this person Application?","Confirm",MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int AppID = GetAppIDFromDGV();
                if (LocalDrivingLicenseApplication.UpdateLocalDrivingLicenseAppStatus(AppID, (int)enAppStatus.Cancelled))
                {
                    MessageBox.Show("Appliction status is cancelled!", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLocalDrivingLicensesToDGV();
                }
            }
        }
        private int GetAppIDFromDGV()
        {
            return Convert.ToInt32(dgvLocalLicenses.CurrentRow.Cells[0].Value);
        }
        private short GetPassedTestsCountFromDGV()
        {
            return Convert.ToInt16(dgvLocalLicenses.CurrentRow.Cells[5].Value);
        }
        private string GetLecenseNameFromDGV()
        {
            return Convert.ToString(dgvLocalLicenses.CurrentRow.Cells[1].Value);
        }
        private DateTime GetAppDateFromDGV()
        {
            return Convert.ToDateTime(dgvLocalLicenses.CurrentRow.Cells[4].Value);
        }
        private string GetStatusFromDGV()
        {
            return Convert.ToString(dgvLocalLicenses.CurrentRow.Cells[6].Value);
        }
        private string GetApplicantFullNameFromDGV()
        {
            return Convert.ToString(dgvLocalLicenses.CurrentRow.Cells[3].Value);
        }
        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppID = 0;
            string LicenseName = "";
            string ApplicantFullName = "";
            DateTime AppDate = DateTime.MinValue;
            short PassedTests = 0;
            string AppStatus = "";

            GetAppDataFromDGV(ref AppID, ref LicenseName, ref ApplicantFullName, ref AppDate, ref PassedTests, 
                ref AppStatus);

            frmShowDrivingLicenseApp frm = new frmShowDrivingLicenseApp(
                AppID,LicenseName,ApplicantFullName,AppDate, PassedTests, AppStatus);

            frm.ShowDialog();
        }
        private void GetAppDataFromDGV(ref int AppID, ref string LicenseName, 
            ref string ApplicantFullName, ref DateTime AppDate, ref short PassedTests, ref string AppStatus)
        {
            AppID = GetAppIDFromDGV();
            LicenseName = GetLecenseNameFromDGV();
            ApplicantFullName = GetApplicantFullNameFromDGV();
            AppDate = GetAppDateFromDGV();
            PassedTests = GetPassedTestsCountFromDGV();
            AppStatus = GetStatusFromDGV();
        }
        private void visionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int AppID = 0;
            string LicenseName = "";
            string ApplicantFullName = "";
            DateTime AppDate = DateTime.MinValue;
            short PassedTests = 0;
            string AppStatus = "";

            GetAppDataFromDGV(ref AppID, ref LicenseName, ref ApplicantFullName, ref AppDate, ref PassedTests,
                ref AppStatus);

            frmVisionTestAppointments form = new frmVisionTestAppointments(
                AppID, LicenseName, ApplicantFullName, AppDate, PassedTests, AppStatus);
            form.ShowDialog();
        }
    }
}
