using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _19___Project___DVLD.Tests.Controls;
using DVLD_Business;

namespace _19___Project___DVLD.Driving_License_Services.Schedule_Tests
{
    public partial class frmSheduleTest : Form
    {
        private int _LocalDrivingLicenseApplicationID = -1;
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        private int _AppointmentID = -1;

        public frmSheduleTest(int LocalDrivingLicenseApplicationID,
            clsTestType.enTestType TestTypeID, int AppointmentID = -1)
        {
            InitializeComponent();
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
            _TestTypeID = TestTypeID;
            _AppointmentID = AppointmentID;

        }


        private void frmSheduleTest_Load(object sender, EventArgs e)
        {
            ctrlSchduleTest1.TestTypeID = _TestTypeID;
            ctrlSchduleTest1.LoadInfo(_LocalDrivingLicenseApplicationID, _AppointmentID);

        }



    }
}
