using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using _19___Project___DVLD.Properties;
using DVLD_Business;

namespace _19___Project___DVLD.People
{
    public partial class frmAddAndUpdatePerson : Form
    {
        private enum enMode
        {
            NewPerson = 1, UpdatePerson = 2
        }
        enMode Mode = enMode.NewPerson;
        Person PersonInfo = null;
        public frmAddAndUpdatePerson()
        {
            InitializeComponent();
            Mode = enMode.NewPerson;
        }

        public frmAddAndUpdatePerson(Person person)
        {
            InitializeComponent();
            Mode = enMode.UpdatePerson;
            PersonInfo = person;
        }

        public delegate void HandelDelegateData(object sender);
        public event HandelDelegateData Handeler;

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void frmAddAndUpdatePerson_Load(object sender, EventArgs e)
        {
            ActiveControl = tbFirstName;
            LoadAllCountriesToComboBox();
            if (Mode == enMode.NewPerson)
            {
                dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            }
            else
            {
                if (!LoadAllPersonInfo(PersonInfo))
                {
                    MessageBox.Show("Couldn't Load Person information...");
                    Close();
                }
                btnRemoveImage.Visible = true;
            }
        }
        private bool LoadAllPersonInfo(Person PersonInfo)
        {
            if (PersonInfo == null)
            {
                return false;
            }
            lblInsertedID.Text = PersonInfo.PersonID.ToString();
            tbFirstName.Text = PersonInfo.FirstName;
            tbSecondName.Text = PersonInfo.SecondName;
            tbThirdName.Text = PersonInfo.ThirdName;
            tbLastName.Text = PersonInfo.LastName;
            tbNationalNo.Text = PersonInfo.NationalNo;
            dtpDateOfBirth.Value = PersonInfo.DateOfBirth;
            rbMale.Checked = PersonInfo.Gender == 0;
            rbFemale.Checked = PersonInfo.Gender == 1;
            tbPhone.Text = PersonInfo.Phone;
            tbEmail.Text = PersonInfo.Email;
            cbCountriesNames.SelectedIndex = PersonInfo.NationalityCountryID;
            tbAddress.Text = PersonInfo.Address;
            pbUserImage.Image = GetImagePath(PersonInfo.ImagePath);

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
        private void LoadAllCountriesToComboBox()
        {
            List<string> lsCountries = Person.GetAllCountries();
            // add one item as a placeholder and close the gap
            cbCountriesNames.Items.Add("Select Country");
            foreach (string CountryName in lsCountries)
            {
                cbCountriesNames.Items.Add(CountryName);
            }
            cbCountriesNames.SelectedIndex = cbCountriesNames.FindString("Yemen");
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
        private void MakeTextBoxFieldRequired(TextBox sender)
        {
            if (sender.Text == string.Empty)
            {
                epPersonForm.SetError(sender, "This field is required");
            }
            else
            {
                epPersonForm.SetError(sender, "");
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
            Handeler?.Invoke(this);
        }
        private void tbFirstName_Leave(object sender, EventArgs e)
        {
            MakeTextBoxFieldRequired(tbFirstName);
        }
        private void tbSecondName_Leave(object sender, EventArgs e)
        {
            MakeTextBoxFieldRequired(tbSecondName);
        }
        private void tbThirdName_Leave(object sender, EventArgs e)
        {
            MakeTextBoxFieldRequired(tbThirdName);
        }
        private void tbLastName_Leave(object sender, EventArgs e)
        {
            MakeTextBoxFieldRequired(tbLastName);
        }
        private void tbNationalNo_Leave(object sender, EventArgs e)
        {
            if (tbNationalNo.Text == string.Empty)
            {
                MakeTextBoxFieldRequired(tbNationalNo);
            }
            else
            {
                bool isNationalNoFound = Person.IsNationalNoFound(tbNationalNo.Text);
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
            MakeTextBoxFieldRequired(tbPhone);
        }
        private void tbAddress_Leave(object sender, EventArgs e)
        {
            MakeTextBoxFieldRequired(tbAddress);
        }
        private void btnSetImage_Click(object sender, EventArgs e)
        {
            fdSetImage.Title = "Select a profile image";
            fdSetImage.Filter = "PNG images (*.png)|*.png|JPG images (*.jpg)|*.jpg|All Files (*.*)|*.*";
            fdSetImage.InitialDirectory = @"E:\Amjad\My folder\#desktop wallpapers";
            fdSetImage.FilterIndex = 3;

            if (fdSetImage.ShowDialog() == DialogResult.OK)
            {
                if (pbUserImage.Image != null)
                    pbUserImage.Image.Dispose();

                pbUserImage.Image = Image.FromFile(fdSetImage.FileName);
            }
        }
        private string SaveProfileToPath(string ImagePath)
        {
            if (ImagePath == string.Empty)
            {
                return string.Empty;
            }

            if (Mode == enMode.UpdatePerson)
            {
                RemoveImageWhenExists();
            }

            string destinationPath = "E:\\Amjad\\Mohammed Abu-Hadhoud Courses\\19 - Full Real Project\\19 - Project - DVLD\\ProfileImages";
            string ImageNameWithGUID = RenameImageByGUID(ImagePath);

            if (!Directory.Exists(destinationPath))
                Directory.CreateDirectory(destinationPath);

            string NewDestFilePath = Path.Combine(destinationPath, ImageNameWithGUID);
            File.Copy(ImagePath, NewDestFilePath, true);

            return NewDestFilePath;
        }
        private void RemoveImageWhenExists()
        {
            if (PersonInfo != null && PersonInfo.ImagePath != string.Empty)
                File.Delete(PersonInfo.ImagePath);
        }
        private string RenameImageByGUID(string fileName)
        {
            string GUID = Guid.NewGuid().ToString();
            return GUID + Path.GetExtension(fileName);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (AreFieldsValid())
            {
                PersonInfo = new Person(
                GetPersonID(),
                tbNationalNo.Text,
                tbFirstName.Text,
                tbSecondName.Text,
                tbThirdName.Text,
                tbLastName.Text,
                dtpDateOfBirth.Value,
                rbMale.Checked ? 0 : 1,
                tbAddress.Text,
                tbPhone.Text,
                tbEmail.Text,
                cbCountriesNames.SelectedIndex,
                SaveProfileToPath(fdSetImage.FileName)
                );

                if (Mode == enMode.NewPerson)
                {
                    AddNewPerson(PersonInfo);
                }
                else
                {
                    UpdatePreson();
                }
                //Close();
            }
            else
            {
                MessageBox.Show("Please fill the required fields!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private int GetPersonID()
        {
            return Mode == enMode.NewPerson ? -1 : Convert.ToInt32(lblInsertedID.Text);
        }
        private void AddNewPerson(Person PersonData)
        {
            int insertedID = Person.AddNewPerson(PersonData);

            if (insertedID != -1)
            {
                MessageBox.Show("New Person is successfully added!", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblInsertedID.Text = insertedID.ToString();
            }
            else
            {
                MessageBox.Show("The New Person couldn't be successfully added!\nDatabase Error", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void UpdatePreson()
        {
            if (Person.UpdatePerson(PersonInfo))
            {
                MessageBox.Show("Person is successfully updated!", "Data Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The Person couldn't be successfully Updated!\nDatabase Error", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool HasErrors(string errorMessage)
        {
            return errorMessage != string.Empty;
        }
        private bool AreFieldsValid()
        {
            if (!HasErrors(epPersonForm.GetError(tbFirstName)) &&
                !HasErrors(epPersonForm.GetError(tbSecondName)) &&
                !HasErrors(epPersonForm.GetError(tbThirdName)) &&
                !HasErrors(epPersonForm.GetError(tbLastName)) &&
                !HasErrors(epPersonForm.GetError(tbNationalNo)) &&
                !HasErrors(epPersonForm.GetError(tbPhone)) &&
                !HasErrors(epPersonForm.GetError(tbEmail)) &&
                !HasErrors(epPersonForm.GetError(tbAddress)) &&
                !HasErrors(epPersonForm.GetError(cbCountriesNames)))
            {
                return true;
            }
            else
                return false;
        }
        private void cbCountriesNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            epPersonForm.SetError(cbCountriesNames, cbCountriesNames.SelectedIndex > 0 ? "" : "Invalid Country Name");
        }
        private void btnRemoveImage_Click(object sender, EventArgs e)
        {
            pbUserImage.Image = GetDefaultImage();
        }
        private Image GetDefaultImage()
        {
            return rbMale.Checked ? Resources.male : Resources.female;
        }
    }
}
