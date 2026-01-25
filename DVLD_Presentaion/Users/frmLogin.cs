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
            if (AreFormFieldsValid())
            {
                bool isUserFound = false;
                User user = User.FindUser(tbUsername.Text, tbPassword.Text, ref isUserFound);
                if (isUserFound)
                {
                    if (chxRememberMe.Checked)
                        User.SaveUsernameAndPasswordToFile(tbUsername.Text, tbPassword.Text);
                    else
                        User.ResetUsernameAndPasswrodFile();

                    if (user.IsActive)
                    {
                        frmMain frmMain = new frmMain();
                        frmMain.ShowDialog();
                        Close();
                    }
                    else
                        MessageBox.Show("The user is not allowed to login, please try another user", "Permession denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The Username/Password is wrong", "Permession denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please make sure your fields are valid, all fields are required!", "Required fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool AreFormFieldsValid()
        {
            return (!clsCommonMethods.HasErrors(errorProvider1.GetError(tbUsername)) && 
                !clsCommonMethods.HasErrors(errorProvider1.GetError(tbPassword)));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbUsername_Leave(object sender, EventArgs e)
        {
            if (tbUsername.Text == string.Empty)
                errorProvider1.SetError(tbUsername, "This field is required");
            else
                errorProvider1.SetError(tbUsername, string.Empty);
        }

        private void tbPassword_Leave(object sender, EventArgs e)
        {
            clsCommonMethods.MakeTextBoxFieldRequired(tbPassword, errorProvider1);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string username = "", password = "";
            if(User.LoadSavedLoginData(ref username, ref password))
            {
                tbUsername.Text = username;
                tbPassword.Text = password;
            }
           
        }
    }
}
