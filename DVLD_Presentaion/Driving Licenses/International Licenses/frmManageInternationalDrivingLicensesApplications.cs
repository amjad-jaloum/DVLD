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

namespace _19___Project___DVLD.Driving_Licenses.International_Licenses
{
    public partial class frmManageInternationalDrivingLicensesApplications : Form
    {
        public frmManageInternationalDrivingLicensesApplications()
        {
            InitializeComponent();
        }

        private void frmManageInternationalDrivingLicensesApplications_Load(object sender, EventArgs e)
        {
            dgvInternationalLicenses.DataSource = InternationalDrivingLicensesApplication.GetInternationalDrivingLicensApplications();
            lblRowsCountValue.Text = dgvInternationalLicenses.Rows.Count.ToString();
        }
    }
}
