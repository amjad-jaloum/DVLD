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
using DVLD_Business;

namespace _19___Project___DVLD.People
{
    public partial class ctrlShowPersonDetails : UserControl
    {
        public Person person = null;
        public ctrlShowPersonDetails()
        {
            InitializeComponent();
        }

        public void LoadPersonInfo()
        {
            if (person != null)
            {
                lblPersonID.Text = person.PersonID.ToString();
                lblName.Text = GetFullName();
                lblNationalNo.Text = person.NationalNo;
                lblPhone.Text = person.Phone;
                lblGender.Text = Convert.ToBoolean(person.Gender) ? "Female" : "Male";
                lblCountryName.Text = GetCountryName();
                lblAddress.Text = person.Address;
                lblDateOfBirth.Text = person.DateOfBirth.ToShortDateString();
                lblEmail.Text = person.Email;
                pictureBox1.Image = GetImagePath(person.ImagePath);
            }
            else
            {
                //MessageBox.Show("Person is null");
            }
        }
        private Image GetImagePath(string ImagePath)
        {
            if (ImagePath == string.Empty)
                return GetDefaultImage();

            if (!File.Exists(ImagePath))
                return Convert.ToBoolean(person.Gender) ? Resources.femaleWrong : Resources.maleWrong;

            return Image.FromFile(ImagePath);
        }
        private Image GetDefaultImage()
        {
            return Convert.ToBoolean(person.Gender) ? Resources.female : Resources.male;
        }
        private string GetCountryName()
        {
            return Person.GetCountryName(person.NationalityCountryID);
        }
        private string GetFullName()
        {
            return person.FirstName + " " + person.SecondName + " " + person.ThirdName + " " + person.LastName;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmAddAndUpdatePerson frmAddAndUpdate = new frmAddAndUpdatePerson(person);
            frmAddAndUpdate.ShowDialog();
        }
        public void ctrlShowPersonDetails_Load(object sender, EventArgs e)
        {
            LoadPersonInfo();
        }
    }
}
