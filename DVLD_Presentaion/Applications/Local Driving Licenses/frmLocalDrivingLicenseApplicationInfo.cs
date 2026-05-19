using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using DVLD_Business;

namespace _19___Project___DVLD.Driving_License_Services
{
    public partial class frmShowDrivingLicenseApp : Form
    {
        private int _ApplicationID = -1;

        public frmShowDrivingLicenseApp(int ApplicationID)
        {
            InitializeComponent();
            _ApplicationID = ApplicationID;
        }
        private void frmShowDrivingLicenseApp_Load(object sender, EventArgs e)
        {
            ctrlShowDrivingLicenseAppInfo1.LoadApplicationInfoByLocalDrivingAppID(_ApplicationID);
        }
    }
}
