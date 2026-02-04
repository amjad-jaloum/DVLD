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
    public partial class frmManageLocalDrivingLicenseApplications : Form
    {
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
        private void LoadComboBoxActiveStatus()
        {
            cbStatus.Items.Add("All");
            cbStatus.Items.Add("New");
            cbStatus.Items.Add("Completed");
            cbStatus.Items.Add("Cancelled");

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
    }
}
