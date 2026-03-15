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
        private int LicenseID = -1;
        public frmShowLicenseInfo(int LicenseID)
        {
            InitializeComponent();
            this.LicenseID = LicenseID;
        }
        private void frmShowLicenseInfo_Load(object sender, EventArgs e)
        {
            if (LicenseID == -1)
            {
                MessageBox.Show("License invalid.", "License not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ctrlShowLicenseInfo1.LicenseID = LicenseID;
            ctrlShowLicenseInfo1.ctrlShowLicenseInfo_Load(this, e);
        }
    }
}
