using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _19___Project___DVLD.People;
using DVLD_Business;

namespace _19___Project___DVLD.Driving_License_Services
{
    public partial class frmAddUpdateLocalDrivingLicenseApplication : Form
    {
        clsPerson _Person = null;
        enum enApplicationStatus
        {
            New = 1, Cancelled = 2, Completed = 3
        }
        enum enApplicationTypeID
        {
            NewLocalDrivingLicense = 1,
        }

        public delegate void DataBackEventHandler(object sender);
        public event DataBackEventHandler DataBack;

        public frmAddUpdateLocalDrivingLicenseApplication()
        {
            InitializeComponent();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_Person != null)
            {
                clsLocalDrivingLicenseApplication application = new clsLocalDrivingLicenseApplication
                    (
                        _Person.PersonID,
                        DateTime.Parse(lblAppDate.Text),
                        (int)enApplicationTypeID.NewLocalDrivingLicense,
                        (int)enApplicationStatus.New,
                        DateTime.Now,
                        Convert.ToInt16(lblAppFees.Text),
                        clsGlobal.CurrentUser.UserID
                    );

                int AppID = application.AddNewApplication();

                if (AppID == -1)
                    MessageBox.Show("Couldn't Add this Licnese!", "Database rejection");
                else
                {
                    lblDLAppID.Text = AppID.ToString();
                    if (clsLocalDrivingLicenseApplication.IsClassNameAvialable(_Person.NationalNo, cbLicenseClass.SelectedItem))
                    {
                        clsLocalDrivingLicenseApplication.AddNewLocalDrivingLicenseApplication(AppID, cbLicenseClass.SelectedIndex);
                        MessageBox.Show("License data added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataBack?.Invoke(this);

                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Please choose another driving class. This class already exists with this Person!", "Class Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
        }
        private void frmNewLocalDrivingLicenseApplications_Load(object sender, EventArgs e)
        {
            LoadLicenseClassesToCB();
        }
        private void LoadLicenseClassesToCB()
        {
            List<string> lsCalssNames = clsLocalDrivingLicenseApplication.GetUserColumnNames();
            if (lsCalssNames == null)
            {
                MessageBox.Show("Database error, Column names are not loaded properly!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                FillComboBox(lsCalssNames);
            }
        }
        private void FillComboBox(List<string> lsClassNames)
        {
            cbLicenseClass.Items.Add("None");

            foreach (string ColumnName in lsClassNames)
                cbLicenseClass.Items.Add(ColumnName);

            cbLicenseClass.SelectedIndex = 3;
        }
        private void cbLicenseClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = !cbLicenseClass.SelectedItem.ToString().Contains("None");
        }
        private void btnNextTab_Click(object sender, EventArgs e)
        {
            if (_Person != null)
            {
                tabControl1.SelectedIndex = 1;
                LoadLocalLicenseInitialData();
            }
            else
            {
                MessageBox.Show("Please get the person inforamtion!", "No person found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void LoadLocalLicenseInitialData()
        {
            lblAppDate.Text = DateTime.Now.ToString();
            lblAppFees.Text = clsLocalDrivingLicenseApplication.GetNewLocalDrivingLicenseAppFees();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }
        private void ctrlPersonDetailWithFitler1_WhenUserFound(clsPerson obj)
        {
            _Person = obj;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1 && _Person == null)
            {
                MessageBox.Show("Please get the person inforamtion!", "No person found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabControl1.SelectedIndex = 0;
            }
        }
    }
}
