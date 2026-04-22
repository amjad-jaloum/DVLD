using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _19___Project___DVLD.Properties;
using DVLD_Buisness;
using DVLD_Business;

namespace _19___Project___DVLD.People
{
    public partial class ctrlPersonCard : UserControl
    {
        public clsPerson _Person = null;
        private int _PersonID = -1;

        public int PersonID
        {
            get { return _PersonID; }
        }

        public clsPerson SelectedPersonInfo
        {
            get { return _Person; }
        }
        public ctrlPersonCard()
        {
            InitializeComponent();
        }

        public void LoadPersonInfo(int PersonID)
        {
            _Person = clsPerson.Find(PersonID);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with PersonID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                _fillPersonInfo();
            }
        }
        public void LoadPersonInfo(string NationalNo)
        {
            _Person = clsPerson.Find(NationalNo);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with NationalNo = " + NationalNo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                _fillPersonInfo();
            }
        }

        private void _fillPersonInfo()
        {
            lblPersonID.Text = _Person.PersonID.ToString();
            _PersonID = _Person.PersonID;
            lblNationalNo.Text = _Person.NationalNo;
            lblName.Text = _Person.FullName;
            lblGender.Text = Convert.ToBoolean(_Person.Gender) ? "Female" : "Male";
            lblEmail.Text = _Person.Email;
            lblPhone.Text = _Person.Phone;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lblCountryName.Text = clsCountry.Find(_Person.NationalityCountryID).CountryName;
            lblAddress.Text = _Person.Address;
            pictureBox1.Image = GetImagePath(_Person.ImagePath);
        }

        public void ResetPersonInfo()
        {
            _PersonID = -1;
            lblPersonID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblName.Text = "[????]";
            pictureBox1.Image = Resources.male;
            lblGender.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblCountryName.Text = "[????]";
            lblAddress.Text = "[????]";

        }

        private Image GetImagePath(string ImagePath)
        {
            if (ImagePath == string.Empty)
                return GetDefaultImage();

            if (!File.Exists(ImagePath))
                return Convert.ToBoolean(_Person.Gender) ? Resources.femaleWrong : Resources.maleWrong;

            return Image.FromFile(ImagePath);
        }
        private Image GetDefaultImage()
        {
            return Convert.ToBoolean(_Person.Gender) ? Resources.female : Resources.male;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmAddAndUpdate = new frmAddUpdatePerson(_Person.PersonID);
            frmAddAndUpdate.ShowDialog();

            LoadPersonInfo(_PersonID);
        }
        public void ctrlShowPersonDetails_Load(object sender, EventArgs e)
        {
            LoadPersonInfo(_PersonID);
        }
    }
}
