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
using static _19___Project___DVLD.Driving_License_Services.Schedule_Tests.frmSheduleTest;

namespace _19___Project___DVLD.Driving_License_Services.Schedule_Tests
{
    public partial class frmListTestAppointments : Form
    {
        private int _LocalDrivingLicenseAppID { get; set; }
        private string _licenseName { get; set; }
        private string _applicantFullName { get; set; }
        private DateTime _appDate { get; set; }
        private short _passedTests { get; set; }
        private string _appStatus { get; set; }
        public enum enTestType { Vision = 1, Written = 2, Streat = 3 }
        public static enTestType TestType { get; set; }
        public enum enTestMode { New, Edit, Retake }
        enTestMode Mode = enTestMode.New;

        public delegate void RefreshManageLocalDrivingLicenseApplicationsDGVHandler(object sender);
        public event RefreshManageLocalDrivingLicenseApplicationsDGVHandler RefreshManageLocalDrivingLicenseApplicationsDGV;

        public frmListTestAppointments(int LocalDrivingLicenseAppID, string licenseName,
            string applicantFullName, DateTime appDate, short passedTests, string appStatus)
        {
            InitializeComponent();
            _LocalDrivingLicenseAppID = LocalDrivingLicenseAppID;
            _licenseName = licenseName;
            _applicantFullName = applicantFullName;
            _appDate = appDate;
            _passedTests = passedTests;
            _appStatus = appStatus;
        }

        public frmListTestAppointments()
        {
            InitializeComponent();
        }

        private void frmVisionTestAppointments_Load(object sender, EventArgs e)
        {
            LoadTestAppointmentsToDGV((int)TestType);
            if (_LocalDrivingLicenseAppID > 0)
            {
                LoadPesronInfoToCTRL(sender, e);
            }
            else
                MessageBox.Show("Invalid Application ID");
        }

        private void LoadPesronInfoToCTRL(object sender, EventArgs e)
        {
            ctrlShowDrivingLicenseAppInfo1.LocalDrivingLicenseAppID = _LocalDrivingLicenseAppID;
            ctrlShowDrivingLicenseAppInfo1.licenseName = _licenseName;
            ctrlShowDrivingLicenseAppInfo1.applicantFullName = _applicantFullName;
            ctrlShowDrivingLicenseAppInfo1.passedTests = _passedTests;
            ctrlShowDrivingLicenseAppInfo1.appDate = _appDate;
            ctrlShowDrivingLicenseAppInfo1.appStatus = _appStatus;

            ctrlShowDrivingLicenseAppInfo1.ctrlShowDrivingLicenseAppInfo_Load(sender, e);
        }

        private void btnNewAppointment_Click(object sender, EventArgs e)
        {
            if (dgvVisionTestAppointments.Rows.Count == 0)
            {
                // new test
                frmSheduleTest scheduleTestForm = new frmSheduleTest(_LocalDrivingLicenseAppID,
                    _licenseName, _applicantFullName, GetTrailState(), Mode);

                scheduleTestForm.RefreshDataGridView += RefreshDataGridViewHandler;
                scheduleTestForm.ShowDialog();
            }
            else if (!hasAciveAppointment())
            {
                if (clsLocalDrivingLicenseApplication.hasPassedTheTest(GetTestAppointmentIDFromDGV()))
                {
                    MessageBox.Show("The person has already passed this test.\n" +
                        "The last Test has to be failed to add new appointment!",
                        "Last Test is Passed!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    // retake test
                    Mode = enTestMode.Retake;

                    frmSheduleTest scheduleTestForm = new frmSheduleTest(_LocalDrivingLicenseAppID,
                        _licenseName, _applicantFullName, GetTrailState(), Mode);

                    scheduleTestForm.Text = "Retake Test";
                    scheduleTestForm.RefreshDataGridView += RefreshDataGridViewHandler;
                    scheduleTestForm.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("This Person already has an active appointment!",
                    "Active Appointment Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool hasAciveAppointment()
        {
            return clsLocalDrivingLicenseApplication.hasUnlockedAppointment(_LocalDrivingLicenseAppID);
        }

        private void RefreshDataGridViewHandler(object sender)
        {
            LoadTestAppointmentsToDGV((int)TestType);
        }

        private void LoadTestAppointmentsToDGV(int TestTypeID)
        {
            dgvVisionTestAppointments.DataSource = clsLocalDrivingLicenseApplication.LoadTestAppointments(_LocalDrivingLicenseAppID, TestTypeID);
            lblRecordsCount.Text = dgvVisionTestAppointments.Rows.Count.ToString();

            if (dgvVisionTestAppointments.Rows.Count > 0)
                dgvVisionTestAppointments.Sort(dgvVisionTestAppointments.Columns["Appointment Date"], ListSortDirection.Descending);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mode = IsRetakeTest() ? enTestMode.Retake : enTestMode.Edit;

            frmSheduleTest scheduleTestForm =
                new frmSheduleTest(_LocalDrivingLicenseAppID, GetTestAppointmentIDFromDGV(), _licenseName,
                _applicantFullName, GetTrailState(), Mode);

            scheduleTestForm.RefreshDataGridView += RefreshDataGridViewHandler;
            scheduleTestForm.ShowDialog();
        }

        private bool IsRetakeTest()
        {
            return Convert.ToDouble(GetFeesFromDGV()) != clsLocalDrivingLicenseApplication.getTestFee((int)TestType);
        }

        private void takeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CheckTestAppointmentStatus())
            {
                MessageBox.Show("This Test is already taken! you can take a new Test.", "Test Already Taken",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                frmTakeTest form = new frmTakeTest(GetTestAppointmentIDFromDGV(), _LocalDrivingLicenseAppID, _licenseName,
                    _applicantFullName, _appDate, GetFeesFromDGV(), GetTrailState());
                form.RefreshDataGridView += RefreshDataGridViewHandler;
                form.ShowDialog();
            }
        }

        private string GetTrailState()
        {
            return Mode == enTestMode.Retake ? "1" : "0";
        }

        private bool CheckTestAppointmentStatus()
        {
            return clsLocalDrivingLicenseApplication.IsTestAppointmentLocked(GetTestAppointmentIDFromDGV());
        }

        private int GetTestAppointmentIDFromDGV()
        {
            return Convert.ToInt32(dgvVisionTestAppointments.CurrentRow.Cells[0].Value.ToString());
        }

        private string GetFeesFromDGV()
        {
            return dgvVisionTestAppointments.CurrentRow.Cells[2].Value.ToString();
        }

        private void frmVisionTestAppointments_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (clsLocalDrivingLicenseApplication.hasPassedTheTest(GetTestAppointmentIDFromDGV()))
                RefreshManageLocalDrivingLicenseApplicationsDGV?.Invoke(this);
        }
    }
}
