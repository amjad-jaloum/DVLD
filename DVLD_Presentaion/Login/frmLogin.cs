using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _19___Project___DVLD.Global_Classes;
using DVLD_Business;

namespace _19___Project___DVLD
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser user = clsUser.FindByUsernameAndPassword(tbUsername.Text, tbPassword.Text);

            if (user != null)
            {
                if (chxRememberMe.Checked)
                    clsGlobal.RemeberUsernameAndPassword(tbUsername.Text, tbPassword.Text);
                else
                    clsGlobal.RemeberUsernameAndPassword("", ""); // reset

                if (user.IsActive)
                {
                    clsGlobal.CurrentUser = user;
                    this.Hide();
                    frmMain frmMain = new frmMain(this);
                    frmMain.ShowDialog();
                }
                else
                    MessageBox.Show("The user is not allowed to login, please try another user",
                        "Permession denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                MessageBox.Show("The Username/Password is wrong",
                    "Permession denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string username = "", password = "";
            if (clsGlobal.GetStoredCredential(ref username, ref password))
            {
                tbUsername.Text = username;
                tbPassword.Text = password;
                chxRememberMe.Checked = true;
            }
            else
                chxRememberMe.Checked = false;
        }

        private void tbUsername_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnLogin.PerformClick();
        }
    }
}
