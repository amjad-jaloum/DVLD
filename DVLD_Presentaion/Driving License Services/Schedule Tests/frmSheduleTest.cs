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
        int DLAppID;
        string CalssName;
        string ApplicantName;
        int TestAppointmentID;
        string Trail;
        int RAppFees = 5;
        private enum enTestTypeTitle
        {
            VisionTest = 1,
            WrittenTest = 2,
            PracticalTest = 3
        }
        public enum enTestMode
        {
            New, Edit, Retake
        }
        public enTestMode Mode = enTestMode.New;

        public delegate void RefreshDataGridViewHandler(object sender);
        public event RefreshDataGridViewHandler RefreshDataGridView;

        public frmSheduleTest(int DLAppID, string CalssName, string ApplicantName, string Trail)
        {
            InitializeComponent();
            this.DLAppID = DLAppID;
            this.CalssName = CalssName;
            this.ApplicantName = ApplicantName;
            this.Trail = Trail;

            Text = "Schedule New Vision Test Appointment";
        }
        public frmSheduleTest(int DLAppID, int TestAppointmentID, string CalssName, string ApplicantName, string Trail)
        {
            InitializeComponent();
            this.DLAppID = DLAppID;
            this.CalssName = CalssName;
            this.ApplicantName = ApplicantName;
            this.TestAppointmentID = TestAppointmentID;
            this.Trail = Trail;
            Mode = enTestMode.Edit;
            Text = "Edit Vision Test Appointment";
        }

        private string GetTestTypeTitle(enTestTypeTitle testType)
        {
            switch (testType)
            {
                case enTestTypeTitle.VisionTest:
                    return "Vision Test";
                case enTestTypeTitle.WrittenTest:
                    return "Written (Theory) Test";
                case enTestTypeTitle.PracticalTest:
                    return "Practical (Street) Test";
                default:
                    return "Unknown Test Type";
            }
        }

        private void frmSheduleTest_Load(object sender, EventArgs e)
        {
            loadInitialData();

            bool isAppointmentStateLocked = LocalDrivingLicenseApplication.IsTestAppointmentLocked(TestAppointmentID);
            if (isAppointmentStateLocked)
            {
                dtpTestAppointment.Enabled = !(Mode == enTestMode.Edit && isAppointmentStateLocked);
                btnSave.Enabled = !(Mode == enTestMode.Edit && isAppointmentStateLocked);
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
            return Mode == enTestMode.New ? DateTime.Now : LocalDrivingLicenseApplication.GetTestAppointmentDate(DLAppID);
        }

        private string TotalFees()
        {
            return (Convert.ToInt32(lblAppFees.Text) + Convert.ToInt32(lblRAppFees.Text)).ToString();
        }

        private string AppFees()
        {
            return LocalDrivingLicenseApplication.getTestFee(GetTestTypeTitle(enTestTypeTitle.VisionTest)).ToString();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (Mode)
            {
                case enTestMode.New:
                    AddNewTestAppointment();
                    break;
                case enTestMode.Edit:
                    UpdateTestAppointment();
                    break;
                case enTestMode.Retake:
                    AddNewRetakeTestAppointment();
                    break;
            }

            RefreshDataGridView?.Invoke(this);
        }

        private void AddNewRetakeTestAppointment()
        {
            lblRTestAppID.Text = AddNewTestAppointment().ToString();

        }

        private void UpdateTestAppointment()
        {
            bool isUpdated = LocalDrivingLicenseApplication.UpdateTestAppointmentDate(DLAppID, TestAppointmentID, dtpTestAppointment.Value);

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
            int ReturnedAppID = LocalDrivingLicenseApplication.AddNewTestAppointment(
                (int)enTestTypeTitle.VisionTest, DLAppID, dtpTestAppointment.Value,
                Convert.ToDecimal(TotalFees()), clsGloabalSettings.LogginUser.UserID, false);

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
