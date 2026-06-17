using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _19___Project___DVLD.Global_Classes;
using _19___Project___DVLD.People;
using DVLD_Business;

namespace _19___Project___DVLD.Users
{
    public partial class frmAddUpdateUser : Form
    {
        private enum enMode
        {
            AddNew = 1, Update = 2
        }
        enMode Mode;
        clsUser _User;
        int _UserID = -1;
        public frmAddUpdateUser()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }
        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            Mode = enMode.Update;
            _UserID = UserID;
        }

        private void _ResetDefulatValues()
        {
            if (Mode == enMode.AddNew)
            {
                Text = "Add New User";
                _User = new clsUser();
                gbUserDetails.Enabled = false;
                ctrlPersonCardWithFilter1.FilterFocus();
            }
            else
            {
                Text = "Update User";
                gbUserDetails.Enabled = true;
                btnSave.Enabled = true;
            }

            tbUsername.Text = string.Empty;
            tbPassword.Text = string.Empty;
            tbConfirmPassword.Text = string.Empty;
            chxIsActive.Checked = true;
        }
        private void _LoadData()
        {
            _User = clsUser.FindByUserID(_UserID);
            ctrlPersonCardWithFilter1.FilterEnabled = false;

            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _User, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            lblUserID.Text = _User.ToString();
            tbUsername.Text = _User.UserName;
            tbPassword.Text = string.Empty;           
            tbConfirmPassword.Text = tbPassword.Text;    
            chxIsActive.Checked = _User.IsActive;
            ctrlPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);
        }
        private void btnNextTab_Click(object sender, EventArgs e)
        {
            if (Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                gbUserDetails.Enabled = true;
                tabControl1.SelectedTab = tabControl1.TabPages[1];
                return;
            }

            // incase add new
            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {
                if (clsUser.IsUserExistForPersonID(ctrlPersonCardWithFilter1.PersonID))
                {
                    MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonCardWithFilter1.FilterFocus();
                }
                else
                {
                    btnSave.Enabled = true;
                    gbUserDetails.Enabled = true;
                    tabControl1.SelectedTab = tabControl1.TabPages[1];
                }
            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFocus();
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            //Close();
            //Handeler?.Invoke(this);
        }
        private void frmAddAndUpdateUser_Load(object sender, EventArgs e)
        {
            _ResetDefulatValues();
            if (Mode == enMode.Update)
            {
                _LoadData();
            }
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }
            _User.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _User.UserName = tbUsername.Text.Trim();

            if (clsUser.ComputeHashed(tbPassword.Text) != _User.Password) // if true = new password
                _User.Password = tbPassword.Text.Trim(); 

            _User.IsActive = chxIsActive.Checked;

            if (_User.Save())
            {
                lblUserID.Text = _User.UserID.ToString();
                //change form mode to update.
                Mode = enMode.Update;
                this.Text = "Update User";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
        private void tabControl1_Click_1(object sender, EventArgs e)
        {
            //if (_Person == null && tabControl1.SelectedIndex == 1)
            //{
            //    gbUserDetails.Enabled = false;
            //    MessageBox.Show("Please get the person inforamtion to create a user!", "No person found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //else
            //{
            //    gbUserDetails.Enabled = _Person != null;
            //}
        }
        private void frmAddAndUpdateUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Handeler?.Invoke(this);
        }
        private void tbConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (tbConfirmPassword.Text.Trim() != tbPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(tbConfirmPassword, "Password Confirmation does not match Password!");
            }
            else
            {
                errorProvider1.SetError(tbConfirmPassword, null);
            }
        }
        private void tbUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbUsername.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbUsername, "Username cannot be blank");
                return;
            }
            else
            {
                errorProvider1.SetError(tbUsername, null);
            }

            if (Mode == enMode.AddNew)
            {

                if (clsUser.IsUserExist(tbUsername.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(tbUsername, "username is used by another user");
                }
                else
                {
                    errorProvider1.SetError(tbUsername, null);
                }
            }
            else
            {
                //incase update make sure not to use anothers user name
                if (_User.UserName != tbUsername.Text.Trim())
                {
                    if (clsUser.IsUserExist(tbUsername.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(tbUsername, "username is used by another user");
                        return;
                    }
                    else
                    {
                        errorProvider1.SetError(tbUsername, null);
                    }
                }
            }
        }
        private void frmAddUpdateUser_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FilterFocus();
        }
    }
}
