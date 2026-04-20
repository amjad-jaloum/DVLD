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

namespace _19___Project___DVLD.Driving_License_Services.Schedule_Tests
{
    public partial class frmTakeTest : Form
    {
        private int _AppID;
        private int _TestAppointmentID;
        private string _LicenseName;
        private string _ApplicantName;
        private string _Trail;
        private DateTime _AppointmentDate;
        private string _fees;

        public delegate void RefreshDataGridViewHandler(object sender);
        public event RefreshDataGridViewHandler RefreshDataGridView;
        public frmTakeTest(int TestAppointmentID, int AppID, string LicenseName,
            string ApplicantName, DateTime AppointmentDate, string fees, string Trail)
        {
            InitializeComponent();
            _TestAppointmentID = TestAppointmentID;
            _AppID = AppID;
            _LicenseName = LicenseName;
            _ApplicantName = ApplicantName;
            _Trail = Trail;
            _AppointmentDate = AppointmentDate;
            _fees = fees;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            lblLocalDrivingAppID.Text = _AppID.ToString();
            lblLicenseName.Text = _LicenseName;
            lblApplicant.Text = _ApplicantName;
            lblTrail.Text = _Trail;
            lblTestAppointmentDate.Text = _AppointmentDate.ToString();
            lblAppFees.Text = _fees;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (AddNewTestResult(_TestAppointmentID, TestResult(), tbTestNotes.Text, clsGlobal.CurrentUser.UserID))
            {
                MessageBox.Show("Test Result Added Successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                RefreshDataGridView?.Invoke(this);
                Close();
            }
            else
            {
                MessageBox.Show("Failed to add test result or block test appointment\nDatabase Error.",
                    "Failed To Add/Block Appointment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool AddNewTestResult(int testAppointmentID, bool result, string notes, int userID)
        {
            return (clsLocalDrivingLicenseApplication.AddNewTestResult(testAppointmentID, result, notes, userID)
                && clsLocalDrivingLicenseApplication.LockTestAppointment(testAppointmentID));
        }

        private bool TestResult()
        {
            return rbPassed.Checked;
        }
    }
}

