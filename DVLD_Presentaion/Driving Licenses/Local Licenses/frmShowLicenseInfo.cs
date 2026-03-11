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
    public partial class frmShowLicenseInfo : Form
    {
        private int _LocalDrivingLicneseAppID = -1;
        public frmShowLicenseInfo(int LocalDrivingLicneseAppID)
        {
            InitializeComponent();
            _LocalDrivingLicneseAppID = LocalDrivingLicneseAppID;
        }
        private void frmShowLicenseInfo_Load(object sender, EventArgs e)
        {

            if (_LocalDrivingLicneseAppID == -1)
            {
                MessageBox.Show($"ID (-1) not Valid",
                    "Not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int LicenseID = AppLicense.GetLicenseID(_LocalDrivingLicneseAppID);
            if (LicenseID == -1)
            {
                MessageBox.Show("License not found. ID = -1", "License not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ctrlShowLicenseInfo1.LicenseID = LicenseID;
            ctrlShowLicenseInfo1.ctrlShowLicenseInfo_Load(this, e);
        }
    }
}
