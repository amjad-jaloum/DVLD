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
    public partial class frmChangePassword : Form
    {
        clsUser _User;
        private int _UserID;
       
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }
       
        private void _ResetDefualtValues()
        {
            tbCurrentPassword.Text = "";
            tbPassword.Text = "";
            tbConfirmPassword.Text = "";
            tbCurrentPassword.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                _User.Password = tbCurrentPassword.Text;

                if (_User.Save())
                {
                    MessageBox.Show("Password Changed Successfully.",
                       "Saved.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _ResetDefualtValues();
                }
                else
                {
                    MessageBox.Show("Password is not changed!",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        
        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            _User = clsUser.FindByUserID(_UserID);

            if (_User == null)
            {
                MessageBox.Show("Could not Find User with id = " + _UserID,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

                return;
            }

            ctrlUserCard1.LoadUserInfo(_UserID);
        }

        private void tbCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbCurrentPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbCurrentPassword, "Username cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(tbCurrentPassword, null);
            }

            if (_User.Password != tbCurrentPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(tbCurrentPassword, "Current password is wrong!");
                return;
            }
            else
            {
                errorProvider1.SetError(tbCurrentPassword, null);
            }
        }

        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbPassword, "Password cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(tbPassword, null);
            }
        }

        private void tbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbConfirmPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbConfirmPassword, "Confirm password cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(tbConfirmPassword, null);
            }

            if (tbPassword.Text.Trim() != tbConfirmPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(tbConfirmPassword, "Password confirmation does not match Password!");
                return;
            }
            else
            {
                errorProvider1.SetError(tbConfirmPassword, null);
            }
        }
    }
}
