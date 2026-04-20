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
using DVLD_Business;

namespace _19___Project___DVLD.Driving_License_Services.Schedule_Tests
{
    public partial class frmSheduleTest : Form
    {
        private int DLAppID;
        private string CalssName;
        private string ApplicantName;
        private int TestAppointmentID;
        private string Trail;
        private int RAppFees = 5;
        frmListTestAppointments.enTestMode Mode { get; set; }

        public delegate void RefreshDataGridViewHandler(object sender);
        public event RefreshDataGridViewHandler RefreshDataGridView;

        public frmSheduleTest(int DLAppID, string CalssName, string ApplicantName, 
            string Trail, frmListTestAppointments.enTestMode mode)
        {
            InitializeComponent();
            this.DLAppID = DLAppID;
            this.CalssName = CalssName;
            this.ApplicantName = ApplicantName;
            this.Trail = Trail;
            Mode = mode;
            Text = "Schedule New " + GetTestName() + " Test Appointment";
        }
        public frmSheduleTest(int DLAppID, int TestAppointmentID, string CalssName, 
            string ApplicantName, string Trail, frmListTestAppointments.enTestMode mode)
        {
            InitializeComponent();
            this.DLAppID = DLAppID;
            this.CalssName = CalssName;
            this.ApplicantName = ApplicantName;
            this.TestAppointmentID = TestAppointmentID;
            this.Trail = Trail;
            Mode = mode;

            Text = "Edit " + GetTestName() + " Test Appointment";
        }

        private string GetTestName()
        {
            switch (frmListTestAppointments.TestType)
            {
                case frmListTestAppointments.enTestType.Vision:
                    return "Vision";
                case frmListTestAppointments.enTestType.Written:
                    return "Written";
                case frmListTestAppointments.enTestType.Streat:
                    return "Streat";
                default:
                    return string.Empty;
            }
        }

        private void frmSheduleTest_Load(object sender, EventArgs e)
        {
            loadInitialData();

            if (Mode == frmListTestAppointments.enTestMode.Edit)
            {
                bool isAppointmentStateLocked = clsLocalDrivingLicenseApplication.IsTestAppointmentLocked(TestAppointmentID);
                dtpTestAppointment.Enabled = !(isAppointmentStateLocked);
                btnSave.Enabled = !(isAppointmentStateLocked);
            }
            if (Trail == "1")
            {
                gbRetakeTest.Enabled = true;
                lblRAppFees.Text = RAppFees.ToString();
                lblTotalFees.Text = TotalFees();
                lblRTestAppID.Text = TestAppointmentID.ToString();
            }
        }

        private void loadInitialData()
        {
            lblLocalDrivingAppID.Text = DLAppID.ToString();
            lblLicenseName.Text = CalssName;
            lblApplicant.Text = ApplicantName;
            lblTrial.Text = Trail;
            dtpTestAppointment.MinDate = DateTime.MinValue;
            dtpTestAppointment.Value = GetTestAppointmentDate();
            lblAppFees.Text = AppFees();
            lblRAppFees.Text = "0";
            lblTotalFees.Text = TotalFees();

        }

        private DateTime GetTestAppointmentDate()
        {
            return Mode == frmListTestAppointments.enTestMode.New ? DateTime.Now : 
                clsLocalDrivingLicenseApplication.GetTestAppointmentDate(DLAppID);
        }

        private string TotalFees()
        {
            return (Convert.ToInt32(lblAppFees.Text) + Convert.ToInt32(lblRAppFees.Text)).ToString();
        }

        private string AppFees()
        {
            return clsLocalDrivingLicenseApplication.getTestFee((int)frmListTestAppointments.TestType).ToString();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (Mode)
            {
                case frmListTestAppointments.enTestMode.New:
                    AddNewTestAppointment();
                    break;
                case frmListTestAppointments.enTestMode.Edit:
                    UpdateTestAppointment();
                    break;
                case frmListTestAppointments.enTestMode.Retake:
                    AddRetakeTestAppointment();
                    break;
            }

            RefreshDataGridView?.Invoke(this);
        }

        private void AddRetakeTestAppointment()
        {
            lblRTestAppID.Text = AddNewTestAppointment().ToString();
        }

        private void UpdateTestAppointment()
        {
            bool isUpdated = clsLocalDrivingLicenseApplication.UpdateTestAppointmentDate(DLAppID, TestAppointmentID, dtpTestAppointment.Value);

            if (isUpdated)
            {
                MessageBox.Show("Appointment data is updated successfullay!", "Added Successfullay", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Appointment data couldn't be updated!\nDatabase Error.", "Not Updated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private int AddNewTestAppointment()
        {
            int ReturnedAppID = clsLocalDrivingLicenseApplication.AddNewTestAppointment(
                (int)frmListTestAppointments.TestType, DLAppID, dtpTestAppointment.Value,
                Convert.ToDecimal(TotalFees()), clsGlobal.CurrentUser.UserID, false);

            if (ReturnedAppID != -1)
            {
                MessageBox.Show("Appointment data is added successfullay!", "Added Successfullay", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Appointment data couldn't be added!\nDatabase Error.", "Not Added", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return ReturnedAppID;
        }
    }
}
