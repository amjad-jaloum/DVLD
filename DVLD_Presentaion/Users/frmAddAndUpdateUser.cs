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
using _19___Project___DVLD.People;
using DVLD_Business;

namespace _19___Project___DVLD.Users
{
    public partial class frmAddAndUpdateUser : Form
    {
        private enum enMode
        {
            NewUser = 1, UpdateUser = 2
        }
        enMode Mode = enMode.NewUser;
        User _UserInfo = null;
        Person _Person = null;
        public frmAddAndUpdateUser()
        {
            InitializeComponent();
            Mode = enMode.NewUser;
        }
        public frmAddAndUpdateUser(User user)
        {
            InitializeComponent();
            Mode = enMode.UpdateUser;
            _UserInfo = user;
        }

        public delegate void HandelDelegateData(object sender);
        public event HandelDelegateData Handeler;

        private void btnNextTab_Click(object sender, EventArgs e)
        {
            if (Mode == enMode.NewUser)
            {
                if (_Person == null)
                {
                    MessageBox.Show("Please get the person inforamtion to create a user!", "No person found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!User.IsUserFound(_Person.PersonID))
                {
                    tabControl1.SelectedIndex = 1;
                    gbUserDetails.Enabled = true;
                }
                else
                {
                    MessageBox.Show("This Person is already a User!");
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
            Handeler?.Invoke(this);
        }
        private void frmAddAndUpdateUser_Load(object sender, EventArgs e)
        {
            LoadComboBoxFilter();
            if (Mode == enMode.UpdateUser)
            {
                gbFilter.Enabled = false;

                if (LoadAllUserInfo(_UserInfo))
                {
                    _Person = User.GetPersonWithQueryFilter("PersonID", _UserInfo.PersonID.ToString());
                    LoadPersonDetailsToControl(_Person, e);
                }
                else
                {
                    MessageBox.Show("Couldn't Load User information...");
                    Close();
                }
            }
            else
            {
                gbFilter.Enabled = true;
            }
        }
        private bool LoadAllUserInfo(User user)
        {
            if (user == null)
            {
                return false;
            }

            lblUserID.Text = user.UserID.ToString();
            tbUsername.Text = user.UserName;
            tbPassword.Text = user.Password;
            tbConfirmPassword.Text = user.Password;
            chxIsActive.Checked = user.IsActive;

            return true;
        }
        private void LoadComboBoxFilter()
        {
            List<string> ColumnNames = Person.GetPeopleColumnNames();
            if (ColumnNames == null)
            {
                MessageBox.Show("Database error, Column names are not loaded properly!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                FillFilterComboBox(ColumnNames);
            }
        }
        private void FillFilterComboBox(List<string> ColumnNames)
        {
            cbFilter.Items.Add("None");
            cbFilter.SelectedItem = "None";

            foreach (string ColumnName in ColumnNames)
            {
                if (ColumnName.Contains("Gendor") || ColumnName.Contains("NationalityCountryID"))
                    continue;

                cbFilter.Items.Add(ColumnName);
            }
        }
        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            GetPersonDetailsWithFilterQuery(e);
        }
        private void GetPersonDetailsWithFilterQuery(EventArgs e)
        {
            if (!cbFilter.SelectedItem.ToString().Contains("None"))
            {
                _Person = User.GetPersonWithQueryFilter(cbFilter.SelectedItem.ToString(), mtxbSearch.Text);

                if (_Person != null)
                {
                    LoadPersonDetailsToControl(_Person, e);
                }
                else
                {
                    MessageBox.Show("This Person doesn't exist!", "Person not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void LoadPersonDetailsToControl(Person person, EventArgs e)
        {
            ctrlShowPersonDetails1.person = person;
            ctrlShowPersonDetails1.ctrlShowPersonDetails_Load(ctrlShowPersonDetails1, e);
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            mtxbSearch.Enabled = !(cbFilter.SelectedItem.ToString() == "None");

            if (cbFilter.SelectedItem.ToString() == "PersonID")
            {
                mtxbSearch.Mask = "000000";
            }
            else
            {
                if (cbFilter.SelectedItem.ToString() == "None")
                {
                    mtxbSearch.Text = string.Empty;
                }
                mtxbSearch.Mask = "";
            }
        }
        private void mtxbSearch_Leave(object sender, EventArgs e)
        {

        }
        private void tabControl1_Click(object sender, EventArgs e)
        {
        }
        private void mtxbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GetPersonDetailsWithFilterQuery(e);
            }
        }
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddAndUpdatePerson frm = new frmAddAndUpdatePerson();
            frm.PersonHandler += HandleDelegatePerson;
            frm.ShowDialog();
        }
        private void HandleDelegatePerson(object sender, int PersonID)
        {
            EventArgs e = new EventArgs();
            _Person = Person.GetPersonInfo(PersonID);
            if (_Person != null)
                LoadPersonDetailsToControl(_Person, e);
            else
                MessageBox.Show("Person details are not loaded properly!");
        }
        private void tbUsername_Leave(object sender, EventArgs e)
        {
            clsCommonMethods.MakeTextBoxFieldRequired(tbUsername, errorProvider1);
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (AreFieldsValid())
            {
                _UserInfo = LoadDataToUserObject();

                if (Mode == enMode.NewUser)
                {
                    AddNewUser();
                }
                else
                {
                    UpdateUser();
                }
            }
        }
        private void UpdateUser()
        {
            if (User.UpdateUser(_UserInfo))
            {
                MessageBox.Show("User is successfully updated!", "Data Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The User is not Updated!", "No Data to save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private User LoadDataToUserObject()
        {
            if (Mode == enMode.NewUser)
                return new User(-1, ctrlShowPersonDetails1.person.PersonID, tbUsername.Text, tbPassword.Text, chxIsActive.Checked);
            else
                return new User(Convert.ToInt32(lblUserID.Text), ctrlShowPersonDetails1.person.PersonID, tbUsername.Text, tbPassword.Text, chxIsActive.Checked);
        }
        private void AddNewUser()
        {
            int UserID = User.AddNewUser(_UserInfo);
            if (UserID > 0)
            {
                lblUserID.Text = UserID.ToString();
                MessageBox.Show("User is added!", "Used Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();

            }
            else
            {
                MessageBox.Show("User is not added!\nThis person is already a user", "Used ignored", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private bool AreFieldsValid()
        {
            if (
                !clsCommonMethods.HasErrors(errorProvider1.GetError(tbUsername)) &&
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
        private void tabControl1_Click_1(object sender, EventArgs e)
        {
            if (_Person == null && tabControl1.SelectedIndex == 1)
            {
                gbUserDetails.Enabled = false;
                MessageBox.Show("Please get the person inforamtion to create a user!", "No person found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                gbUserDetails.Enabled = _Person != null;
            }
        }

        private void frmAddAndUpdateUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            Handeler?.Invoke(this);
        }
    }
}
