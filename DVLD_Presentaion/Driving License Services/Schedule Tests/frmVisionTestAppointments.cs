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
    public partial class frmVisionTestAppointments : Form
    {
        private int _LocalDrivingLicenseAppID { get; set; }
        string _licenseName { get; set; }
        string _applicantFullName { get; set; }
        DateTime _appDate { get; set; }
        short _passedTests { get; set; }
        string _appStatus { get; set; }

        public frmVisionTestAppointments(int LocalDrivingLicenseAppID, string licenseName,
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

        private void frmVisionTestAppointments_Load(object sender, EventArgs e)
        {
            LoadTestAppointmentsToDGV();
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
            frmSheduleTest scheduleTestForm = new frmSheduleTest(_LocalDrivingLicenseAppID, _licenseName, _applicantFullName);
            scheduleTestForm.RefreshDataGridView += RefreshDataGridViewHandler;
            scheduleTestForm.ShowDialog();
        }
        
        private void RefreshDataGridViewHandler(object sender)
        {
            LoadTestAppointmentsToDGV();
        }

        private void LoadTestAppointmentsToDGV()
        {
            dgvVisionTestAppointments.DataSource = LocalDrivingLicenseApplication.LoadTestAppointments(_LocalDrivingLicenseAppID);
            lblRecordsCount.Text = dgvVisionTestAppointments.Rows.Count.ToString();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSheduleTest scheduleTestForm = new frmSheduleTest(_LocalDrivingLicenseAppID, _licenseName, _applicantFullName);
            scheduleTestForm.enMode = frmSheduleTest.enFormMode.Update;
            scheduleTestForm.Text = "Update Vision Test Appointment";
            scheduleTestForm.RefreshDataGridView += RefreshDataGridViewHandler;
            scheduleTestForm.ShowDialog();
        }
    }
}
