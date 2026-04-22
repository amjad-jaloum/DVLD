using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using _19___Project___DVLD.Global_Classes;
using _19___Project___DVLD.Properties;
using DVLD_Buisness;
using DVLD_Business;
using static _19___Project___DVLD.People.frmAddUpdatePerson;

namespace _19___Project___DVLD.People
{
    public partial class frmAddUpdatePerson : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;
        public enum enMode
        {
            AddNew, Update
        }
        public enum enGender
        {
            Male, Female
        }

        enMode Mode;
        private int _PersonID = -1;
        clsPerson _Person;
        public frmAddUpdatePerson()
        {
            InitializeComponent();
            Mode = enMode.AddNew;
        }
        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            Mode = enMode.Update;
            _PersonID = PersonID;
        }

        private void _ResetDefaultValues()
        {
            _FillCountriesInComoboBox();

            if (Mode == enMode.AddNew)
            {
                Text = "Add New Person";
                _Person = new clsPerson();
            }
            else
            {
                Text = "Update Person";
            }

            if (rbMale.Checked)
            {
                pbUserImage.Image = Resources.male;
            }
            else
            {
                pbUserImage.Image = Resources.female;
            }

            btnRemoveImage.Enabled = pbUserImage.ImageLocation != null;

            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            cbCountriesNames.SelectedIndex = cbCountriesNames.FindString("Jordan");

            tbFirstName.Text = "";
            tbSecondName.Text = "";
            tbThirdName.Text = "";
            tbLastName.Text = "";
            tbNationalNo.Text = "";
            rbMale.Checked = true;
            tbPhone.Text = "";
            tbEmail.Text = "";
            tbAddress.Text = "";


        }
        private void _FillCountriesInComoboBox()
        {
            DataTable dtCountries = clsCountry.GetAllCountries();

            foreach (DataRow row in dtCountries.Rows)
            {
                cbCountriesNames.Items.Add(row["CountryName"]);
            }
        }
        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void frmAddAndUpdatePerson_Load(object sender, EventArgs e)
        {
            ActiveControl = tbFirstName;

            _ResetDefaultValues();
            if (Mode == enMode.Update)
            {
                _LoadData();
            }
        }
        private bool _LoadData()
        {
            _Person = clsPerson.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("No Person with ID = " + _PersonID, "Person Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return false;
            }

            lblInsertedID.Text = _Person.PersonID.ToString();
            tbFirstName.Text = _Person.FirstName;
            tbSecondName.Text = _Person.SecondName;
            tbThirdName.Text = _Person.ThirdName;
            tbLastName.Text = _Person.LastName;
            tbNationalNo.Text = _Person.NationalNo;
            dtpDateOfBirth.Value = _Person.DateOfBirth;

            rbMale.Checked = _Person.Gender == 0;
            rbFemale.Checked = _Person.Gender == 1;

            tbAddress.Text = _Person.Address;
            tbPhone.Text = _Person.Phone;
            tbEmail.Text = _Person.Email;
            cbCountriesNames.SelectedIndex = cbCountriesNames.FindString(_Person.CountryInfo.CountryName);

            pbUserImage.Image = GetImagePath(_Person.ImagePath);
            btnRemoveImage.Enabled = _Person.ImagePath != "";

            return true;
        }
        private Image GetImagePath(string ImagePath)
        {
            if (ImagePath == string.Empty)
                return GetDefaultImage();

            if (!File.Exists(ImagePath))
                return rbMale.Checked ? Resources.maleWrong : Resources.femaleWrong;

            return Image.FromFile(ImagePath);
        }
        private void tbEmail_Leave(object sender, EventArgs e)
        {
            if (!IsEmailValid() && tbEmail.Text != string.Empty)
            {
                epPersonForm.SetError(tbEmail, "Email is not valid");
            }
            else
            {
                epPersonForm.SetError(tbEmail, "");
            }
        }
        private bool IsEmailValid()
        {
            return tbEmail.Text.Contains("@gmail.com");
        }
        private void rbFemale_CheckedChanged_1(object sender, EventArgs e)
        {
            pbUserImage.Image = GetDefaultImage();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void tbFirstName_Leave(object sender, EventArgs e)
        {
            clsCommonMethods.MakeTextBoxFieldRequired(tbFirstName, epPersonForm);
        }
        private void tbSecondName_Leave(object sender, EventArgs e)
        {
            clsCommonMethods.MakeTextBoxFieldRequired(tbSecondName, epPersonForm);
        }
        private void tbThirdName_Leave(object sender, EventArgs e)
        {
            clsCommonMethods.MakeTextBoxFieldRequired(tbThirdName, epPersonForm);
        }
        private void tbLastName_Leave(object sender, EventArgs e)
        {
            clsCommonMethods.MakeTextBoxFieldRequired(tbLastName, epPersonForm);
        }
        private void tbNationalNo_Leave(object sender, EventArgs e)
        {
            if (tbNationalNo.Text == string.Empty)
            {
                clsCommonMethods.MakeTextBoxFieldRequired(tbNationalNo, epPersonForm);
            }
            else
            {
                bool isNationalNoFound = clsPerson.IsNationalNoFound(tbNationalNo.Text);
                if (isNationalNoFound && tbNationalNo.Text != string.Empty)
                {
                    epPersonForm.SetError(tbNationalNo, "This national number already exist!");
                }
                else
                {
                    epPersonForm.SetError(tbNationalNo, "");
                }
            }
        }
        private void tbPhone_Leave(object sender, EventArgs e)
        {
            clsCommonMethods.MakeTextBoxFieldRequired(tbPhone, epPersonForm);
        }
        private void tbAddress_Leave(object sender, EventArgs e)
        {
            clsCommonMethods.MakeTextBoxFieldRequired(tbAddress, epPersonForm);
        }
        private void btnSetImage_Click(object sender, EventArgs e)
        {
            fdSetImage.Title = "Select a profile image";
            fdSetImage.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            fdSetImage.InitialDirectory = @"E:\Amjad\My folder\#desktop wallpapers";
            fdSetImage.FilterIndex = 1;
            fdSetImage.RestoreDirectory = true;

            if (fdSetImage.ShowDialog() == DialogResult.OK)
            {
                pbUserImage.Load(fdSetImage.FileName);
                btnRemoveImage.Enabled = true;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_HandlePersonImage())
            {
                return;
            }

            int NationalityCountryID = clsCountry.Find(cbCountriesNames.Text).ID;

            _Person.FirstName = tbFirstName.Text.Trim();
            _Person.SecondName = tbSecondName.Text.Trim();
            _Person.ThirdName = tbThirdName.Text.Trim();
            _Person.LastName = tbLastName.Text.Trim();
            _Person.NationalNo = tbNationalNo.Text.Trim();
            _Person.Email = tbEmail.Text.Trim();
            _Person.Phone = tbPhone.Text.Trim();
            _Person.Address = tbAddress.Text.Trim();
            _Person.DateOfBirth = dtpDateOfBirth.Value;

            if (rbMale.Checked)
                _Person.Gender = (short)enGender.Male;
            else
                _Person.Gender = (short)enGender.Female;
            _Person.NationalityCountryID = NationalityCountryID;

            if (pbUserImage.ImageLocation != null)
            {
                _Person.ImagePath = pbUserImage.ImageLocation;
            }
            else
            {
                _Person.ImagePath = string.Empty;
            }

            if (_Person.Save())
            {
                lblInsertedID.Text = _Person.PersonID.ToString();
                Mode = enMode.Update;
                Text = "Update Person";
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataBack?.Invoke(this, _Person.PersonID);
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private bool _HandlePersonImage()
        {
            if (_Person.ImagePath != pbUserImage.ImageLocation)
            {
                if (_Person.ImagePath != string.Empty)
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {
                        // log
                    }
                }

                if (pbUserImage.ImageLocation != null)
                {
                    string sourceImageFile = pbUserImage.ImageLocation.ToString();

                    if (clsUtil.CopyImageToProjectImagesFolder(ref sourceImageFile))
                    {
                        pbUserImage.ImageLocation = sourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                }
            }
            return true;
        }
        private void cbCountriesNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            epPersonForm.SetError(cbCountriesNames, cbCountriesNames.SelectedIndex > 0 ? "" : "Invalid Country Name");
        }
        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            pbUserImage.ImageLocation = null;
            pbUserImage.Image = rbMale.Checked ? Resources.male : Resources.female;
            btnRemoveImage.Enabled = false;
        }
        private Image GetDefaultImage()
        {
            return rbMale.Checked ? Resources.male : Resources.female;
        }
        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            TextBox temp = (TextBox)sender;
            if (string.IsNullOrEmpty(temp.Text.Trim()))
            {
                e.Cancel = true;
                epPersonForm.SetError(temp, "This filed is required!");
            }
            else
            {
                epPersonForm.SetError(temp, null);
            }
        }
        private void tbEmail_Validating(object sender, CancelEventArgs e)
        {
            if (tbEmail.Text.Trim() == string.Empty)
            {
                return;
            }

            if (!clsValidation.ValidateEmail(tbEmail.Text))
            {
                e.Cancel = true;
                epPersonForm.SetError(tbEmail, "Invalid Email Address Format!");
            }
            else
            {
                epPersonForm.SetError(tbEmail, null);

            }
        }
        private void tbNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                epPersonForm.SetError(tbNationalNo, "This field is required!");
                return;
            }
            else
            {
                epPersonForm.SetError(tbNationalNo, null);
            }

            //Make sure the national number is not used by another person
            if (tbNationalNo.Text.Trim() != _Person.NationalNo && clsPerson.isPersonExist(tbNationalNo.Text.Trim()))
            {
                e.Cancel = true;
                epPersonForm.SetError(tbNationalNo, "National Number is used for another person!");
            }
            else
            {
                epPersonForm.SetError(tbNationalNo, null);
            }
        }
    }
}
