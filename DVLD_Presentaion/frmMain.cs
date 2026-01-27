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
using _19___Project___DVLD.People;
using _19___Project___DVLD.Users;

namespace _19___Project___DVLD
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void peopleToolStripMenuItem_People_Click(object sender, EventArgs e)
        {
            frmManagePeople PeopleForm = new frmManagePeople();
            PeopleForm.MdiParent = this;
            PeopleForm.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageUsers frmManageUsers = new frmManageUsers();
            frmManageUsers.MdiParent = this;
            frmManageUsers.Show();
        }

        private void showCurrentUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserDetails frmShowDetails = new frmShowUserDetails(clsGloabalSettings.LogginUser.PersonID,clsGloabalSettings.LogginUser.UserID);
            frmShowDetails.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangeUserPassword frm = new frmChangeUserPassword(clsGloabalSettings.LogginUser.PersonID, clsGloabalSettings.LogginUser.UserID);
            frm.Show();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes frm = new frmManageApplicationTypes();
            frm.ShowDialog();
        }
    }
}
