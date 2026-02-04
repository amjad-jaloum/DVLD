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
    }
}
