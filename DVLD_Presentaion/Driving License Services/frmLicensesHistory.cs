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
        private int LocalDrivingLicenseApplicationID;
        int DriverID;
        public frmLicensesHistory(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            this.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }

        private void frmLicensesHistory_Load(object sender, EventArgs e)
        {
            DriverID = AppLicense.FindLicense(AppLicense.GetLicenseID(LocalDrivingLicenseApplicationID)).DriverID;
            loadLocaLicensesHistory();
            loadInternationalLicensesHistroy();
            
        }

        private void loadInternationalLicensesHistroy()
        {
            dgvInernationalLicensesHisory.DataSource = AppLicense.GetInternationalLicesnsHistory(DriverID);
            lblInternationalLicensesRowsCount.Text = dgvInernationalLicensesHisory.Rows.Count.ToString();
        }

        private void loadLocaLicensesHistory()
        {
            dgvLocalLicensesHisory.DataSource = AppLicense.GetLocalLicesnsHistory(DriverID);
            lblLocalLicensesRowsCount.Text = dgvLocalLicensesHisory.Rows.Count.ToString();
        }

    }
}
