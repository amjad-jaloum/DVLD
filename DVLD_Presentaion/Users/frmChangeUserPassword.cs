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

namespace _19___Project___DVLD.Users
{
    public partial class frmChangeUserPassword : Form
    {
        User _UserInfo = null;
        public frmChangeUserPassword(int PersonID, int UserID)
        {
            InitializeComponent();

            User user = User.FindUser(UserID);
            ctrlPersonWithLoggedUserDetails1.user = user;
            ctrlPersonWithLoggedUserDetails1.person = Person.FindPerson(PersonID);

            _UserInfo = user;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (AreFieldsValid())
            {
                UpdateUserPassword();
            }
            else
            {
                MessageBox.Show("Please fill the requirment fields first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void UpdateUserPassword()
        {
            if (User.UpdateUserPassword(_UserInfo.UserID, tbPassword.Text))
            {
                MessageBox.Show("User is successfully updated!", "Data Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The User is not Updated!", "No Data to save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool AreFieldsValid()
        {
            if (
                !clsCommonMethods.HasErrors(errorProvider1.GetError(tbCurrentPassword)) &&
                !clsCommonMethods.HasErrors(errorProvider1.GetError(tbPassword)) &&
                !clsCommonMethods.HasErrors(errorProvider1.GetError(tbConfirmPassword))
               )
            {
                return true;
            }
            else
            {
                MessageBox.Show("Please make fill the fileds correctly!", "Form is not valid", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        private void tbCurrentPassword_Leave(object sender, EventArgs e)
        {
            clsCommonMethods.MakeTextBoxFieldRequired(tbCurrentPassword, errorProvider1);

            if (!IsCurrentPasswordCorrect(_UserInfo.Password, tbCurrentPassword.Text))
                errorProvider1.SetError(tbCurrentPassword, "Current password is wrong!");
            else
                errorProvider1.SetError(tbCurrentPassword, string.Empty);

        }
        private bool IsCurrentPasswordCorrect(string UserPassword, string CurrentPassword)
        {
            return UserPassword == CurrentPassword;
        }
        private void tbPassword_Leave(object sender, EventArgs e)
        {
            clsCommonMethods.MakeTextBoxFieldRequired(tbPassword, errorProvider1);
        }
        private void tbConfirmPassword_Leave(object sender, EventArgs e)
        {
            clsCommonMethods.MakeTextBoxFieldRequired(tbConfirmPassword, errorProvider1);
            string password = tbPassword.Text;
            string confirmPassword = tbConfirmPassword.Text;

            if (tbPassword.Text != string.Empty)
            {
                if (password != confirmPassword)
                {
                    errorProvider1.SetError(tbConfirmPassword, "The confirm passwrod field doesn't match the passwrod field!");
                }
                else
                {
                    errorProvider1.SetError(tbConfirmPassword, string.Empty);
                }
            }
        }
    }
}
