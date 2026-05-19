using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _19___Project___DVLD.Driving_License_Services;
using DVLD_Business;
using clsApplication = DVLD_Business.clsApplication;

namespace _19___Project___DVLD.Driving_Licenses.International_Licenses
{
    public partial class ctrlDriverInternationalLicenseInfoWithFilter : UserControl
    {
        public ctrlDriverInternationalLicenseInfoWithFilter()
        {
            InitializeComponent();
        }

        private void ctrlShowDriverLicenseAndApplicationInfoWithFilter_Load(object sender, EventArgs e)
        {
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblAppDate.Text = DateTime.Now.ToShortDateString();
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();
            lblFees.Text = clsApplicationType.GetFees(clsApplicationType.enApplicationType.NewInternationalLicense).ToString();
            if (!DesignMode)
                lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool isLoaded = LoadLicenseInfo();
            btnShowLicensesInfo.Enabled = false;
            gbAppInfo.Enabled = false;
            btnShowLicensesHistory.Enabled = isLoaded;
            btnIssue.Enabled = false;

            if (isLoaded)
            {
                if (IsInternationalLicenseExists())
                {
                    MessageBox.Show("The international driving license is already issued!",
                        "Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    loadInternationalLicenseInfo(Convert.ToInt32(tbSearch.Text));
                    btnShowLicensesInfo.Enabled = true;
                    gbAppInfo.Enabled = true;
                }
                else if (!ctrlShowLicenseInfo1.IsLicenseValid())
                {
                    MessageBox.Show("The international driving license is not active or expired!",
                        "Expired/Not Active", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    lblLocalLicenseID.Text = tbSearch.Text;
                    btnIssue.Enabled = CheckClassValidation();
                }
            }
        }

        private bool LoadLicenseInfo()
        {
            object sender = null;
            EventArgs e = new EventArgs();

            ctrlShowLicenseInfo1.LicenseID = Convert.ToInt32(tbSearch.Text);
            ctrlShowLicenseInfo1.ctrlShowLicenseInfo_Load(sender, e);
            return ctrlShowLicenseInfo1.IsLoaded;
        }

        private bool CheckClassValidation()
        {
            if (isClassThree())
            {
                return true;
            }
            else
            {
                MessageBox.Show("This Class can not be applied for an International License. Only Class 3 is allowed!",
                    "Regection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        private bool isClassThree()
        {
            return ctrlShowLicenseInfo1.license.LicenseClass == (int)clsLicenseClass.LicenseType.Class_3_Ordinarydrivinglicense;
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            btnSearch.Enabled = !string.IsNullOrEmpty(tbSearch.Text);
        }

        private void tbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSearch.PerformClick();
                e.Handled = true; // prevent the beep sound
            }
        }

        private void btnShowLicensesHistory_Click(object sender, EventArgs e)
        {
            int DriverId = ctrlShowLicenseInfo1.license.DriverID;
            if (DriverId > 0)
            {
                frmLicensesHistory frm = new frmLicensesHistory(DriverId);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Failed to load the licenses history!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            int InsertedID = AddNewInternationalLicense();
            if (InsertedID > 0)
            {
                MessageBox.Show($"The international driving license is issued successfully!\nLicense ID: {InsertedID}",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnShowLicensesInfo.Enabled = true;
                btnIssue.Enabled = false;
                loadInternationalLicenseInfo(InsertedID);
            }
            else
            {
                MessageBox.Show("The international driving license is NOT issued successfully!",
                    "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void loadInternationalLicenseInfo(int IssuedUsingLocalLicenseID)
        {
            clsInternationalLicense InternationalApplication = clsInternationalLicense.FindLicenseByLocalLicenseID(IssuedUsingLocalLicenseID);
            if (InternationalApplication == null)
            {
                MessageBox.Show("Failed to load the international driving license information!",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //clsApplication Application = clsApplication.Find(InternationalApplication.ApplicationID);
            //if(Application == null)
            {
                //MessageBox.Show("Failed to load the application information!",
                //    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //lblILAppID.Text = Application.ApplicationID.ToString();
            //lblIL_LicenseID.Text = InternationalApplication.InternationalLicenseID.ToString();
            //lblLocalLicenseID.Text = IssuedUsingLocalLicenseID.ToString();

            //lblAppDate.Text = Application.ApplicationDate.ToShortDateString();
            //lblIssueDate.Text = InternationalApplication.IssueDate.ToShortDateString();
            //lblExpirationDate.Text = InternationalApplication.ExpirationDate.ToShortDateString();
        }

        private bool IsInternationalLicenseExists()
        {
            return clsInternationalLicense.IsInternationalLicenseExists(Convert.ToInt32(tbSearch.Text));
        }

        private int AddNewInternationalLicense()
        {
            int LicenseID = Convert.ToInt32(tbSearch.Text);
            clsLicense appLicense = clsLicense.FindLicense(LicenseID);
            clsInternationalLicense internationalLicense = new clsInternationalLicense(
                0,
                appLicense.ApplicationID,
                appLicense.DriverID,
                LicenseID,
                DateTime.Now,
                DateTime.Now.AddYears(10),
                true,
                clsGlobal.CurrentUser.UserID
                );

            return clsInternationalLicense.AddNewInternationalDrivingApplication(internationalLicense);
        }

        private void btnShowLicensesInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
