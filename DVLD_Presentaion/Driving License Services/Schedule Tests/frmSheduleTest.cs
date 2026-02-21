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

        enum enTestTypeTitle
        {
            VisionTest = 1,
            WrittenTest = 2,
            PracticalTest = 3
        }
        public frmSheduleTest(int DLAppID, string CalssName, string ApplicantName)
        {
            InitializeComponent();
            this.DLAppID = DLAppID;
            this.CalssName = CalssName;
            this.ApplicantName = ApplicantName;
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
            lblAppFees.Text = AppFees();
            lblRAppFees.Text = "0";
            lblTotalFees.Text = TotalFees();
        }

        private string TotalFees()
        {
            return (Convert.ToInt32(lblAppFees.Text) + Convert.ToInt32(lblRAppFees.Text)).ToString();
        }

        private string AppFees()
        {
            return LocalDrivingLicenseApplication.getTestFee(GetTestTypeTitle(enTestTypeTitle.VisionTest)).ToString();
        }
    }
}
