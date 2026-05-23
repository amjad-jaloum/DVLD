using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _19___Project___DVLD.Application_Types;
using _19___Project___DVLD.Drivers;
using _19___Project___DVLD.Driving_License_Services;
using _19___Project___DVLD.Driving_Licenses.Detained_Licenses;
using _19___Project___DVLD.Driving_Licenses.International_Licenses;
using _19___Project___DVLD.Driving_Licenses.Licenses_Replacement;
using _19___Project___DVLD.People;
using _19___Project___DVLD.Renewed_Licenses;
using _19___Project___DVLD.Test_Types;
using _19___Project___DVLD.Users;

namespace _19___Project___DVLD
{
    public partial class frmMain : Form
    {
        frmLogin _frmLogin;
        public frmMain(frmLogin frmLogin)
        {
            InitializeComponent();
            _frmLogin = frmLogin;
        }

        private void peopleToolStripMenuItem_People_Click(object sender, EventArgs e)
        {
            frmListPeople PeopleForm = new frmListPeople();
            PeopleForm.ShowDialog();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _frmLogin.Show();
            Close();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListUsers frmManageUsers = new frmListUsers();
            frmManageUsers.ShowDialog();
        }

        private void showCurrentUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frmShowDetails = new frmUserInfo(clsGlobal.CurrentUser.UserID);
            frmShowDetails.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListApplicationType frm = new frmListApplicationType();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestTypes frm = new frmListTestTypes();
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicenseApplication frm = new frmAddUpdateLocalDrivingLicenseApplication();
            frm.ShowDialog();
        }

        private void localDrivingApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicenseApplications frm = new frmListLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDrivers frm = new frmListDrivers();
            frm.ShowDialog();
        }

        private void inernationalLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseApplication frm = new frmNewInternationalLicenseApplication();
            frm.ShowDialog();
        }

        private void internationalDrivingApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListInternationalLicensesApplication frm = new frmListInternationalLicensesApplication();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLocalDrivingLicenseApplication form = new frmRenewLocalDrivingLicenseApplication();
            form.ShowDialog();
        }

        private void replaceDamagedOrLostLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplaceLostOrDamagedLicenseApplication frmLicesneReplacement = new frmReplaceLostOrDamagedLicenseApplication();
            frmLicesneReplacement.ShowDialog();
        }

        private void manageDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListDetainedLicenses frm = new frmListDetainedLicenses();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frm = new frmDetainLicenseApplication();
            frm.ShowDialog();
        }

        private void releaseDetainedLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmListTestTypes frm = new frmListTestTypes();
            frm.ShowDialog();
        }

        private void retakeTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListLocalDrivingLicenseApplications frm = new frmListLocalDrivingLicenseApplications();
            frm.ShowDialog();
        }

        private void releaseDetainedDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();
        }
    }
}
