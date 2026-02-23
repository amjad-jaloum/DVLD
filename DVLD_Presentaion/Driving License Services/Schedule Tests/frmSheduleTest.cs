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

        private enum enTestTypeTitle
        {
            VisionTest = 1,
            WrittenTest = 2,
            PracticalTest = 3
        }
        public enum enFormMode
        {
            New, Update
        }
        public enFormMode enMode;

        public delegate void RefreshDataGridViewHandler(object sender);
        public event RefreshDataGridViewHandler RefreshDataGridView;

        public frmSheduleTest(int DLAppID, string CalssName, string ApplicantName)
        {
            InitializeComponent();
            this.DLAppID = DLAppID;
            this.CalssName = CalssName;
            this.ApplicantName = ApplicantName;
            enMode = enFormMode.New;
            Text = "Schedule New Vision Test Appointment";
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
        }
        private void loadInitialData()
        {
            lblLocalDrivingAppID.Text = DLAppID.ToString();
            lblLicenseName.Text = CalssName;
            lblApplicant.Text = ApplicantName;
            lblTrial.Text = "0";
            dtpTestAppointment.MinDate = DateTime.Now;
            dtpTestAppointment.Value = GetTestAppointmentDate();
            lblAppFees.Text = AppFees();
            lblRAppFees.Text = "0";
            lblTotalFees.Text = TotalFees();
        }

        private DateTime GetTestAppointmentDate()
        {
            return enMode == enFormMode.New ? DateTime.Now : LocalDrivingLicenseApplication.GetTestAppointmentDate(DLAppID);
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
            if (enMode == enFormMode.New)
                AddNewTestAppointment();
            else
                UpdateTestAppointment();

            RefreshDataGridView?.Invoke(this);
        }

        private bool UpdateTestAppointment()
        {
            bool isUpdated = LocalDrivingLicenseApplication.UpdateTestAppointmentDate(DLAppID, dtpTestAppointment.Value);

            if (isUpdated)
            {
                MessageBox.Show("Appointment data is updated successfullay!", "Added Successfullay", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Appointment data couldn't be updated!\nDatabase Error.", "Not Updated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return isUpdated;
        }

        private bool AddNewTestAppointment()
        {
            bool isAdded = LocalDrivingLicenseApplication.AddNewTestAppointment(
                (int)enTestTypeTitle.VisionTest, DLAppID, dtpTestAppointment.Value,
                Convert.ToDecimal(lblAppFees.Text), clsGloabalSettings.LogginUser.UserID, false);

            if (isAdded)
            {
                MessageBox.Show("Appointment data is added successfullay!", "Added Successfullay", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Appointment data couldn't be added!\nDatabase Error.", "Not Added", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return isAdded;
        }
    }
}
