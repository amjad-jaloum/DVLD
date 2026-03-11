using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _19___Project___DVLD.Properties;
using DVLD_Business;

namespace _19___Project___DVLD.Driving_License_Services
{
    public partial class ctrlShowLicenseInfo : UserControl
    {
        private Person _person = null;
        private AppLicense _license = null;
        public int LicenseID = -1;
        public ctrlShowLicenseInfo()
        {
            InitializeComponent();
        }

        public void ctrlShowLicenseInfo_Load(object sender, EventArgs e)
        {
            if (LicenseID != -1)
            {
                GetLicenseAndPersonDetails();
                LoadLicenseAndPersonDetails();
            }
        }

        private void LoadLicenseAndPersonDetails()
        {
            if (_license != null)
            {
                lblClass.Text = LocalDrivingLicenseApplication.FindLicenceName(_license.LicenseClass);
                lblName.Text = _person.FullName;
                lblLicenseID.Text = LicenseID.ToString();
                lblNatioinalNo.Text = _person.NationalNo;
                lblGender.Text = _person.GenderString;
                lblIssueDate.Text = _license.IssueDate.ToShortDateString();
                lblNotes.Text = _license.Notes;
                lblIsActive.Text = _license.IsAciveString;
                lblDateOfBirth.Text = _person.DateOfBirth.ToShortDateString();
                lblDriverID.Text = _license.DriverID.ToString();
                lblExpirationDate.Text = _license.ExpirationDate.ToShortDateString();
                lblIsDetained.Text = DetainedLicense.IsLicenseDetained(LicenseID) ? "Yes" : "No";
                pbProfileImage.Image = GetImagePath(_person.ImagePath);
            }
            else
            {
                MessageBox.Show($"Couldn't Load License Details",
                    "Not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private Image GetImagePath(string ImagePath)
        {
            if (ImagePath == string.Empty)
                return GetDefaultImage();

            if (!File.Exists(ImagePath))
                return Convert.ToBoolean(_person.Gender) ? Resources.femaleWrong : Resources.maleWrong;

            return Image.FromFile(ImagePath);
        }

        private Image GetDefaultImage()
        {
            return Convert.ToBoolean(_person.Gender) ? Resources.female : Resources.male;
        }

        private void GetLicenseAndPersonDetails()
        {
            _license = AppLicense.FindLicense(LicenseID);
            if (_license != null)
            {
                int PersonID = Driver.FindDriver(_license.DriverID).PersonID;
                if (PersonID != -1)
                {
                    _person = Person.FindPerson(PersonID);
                }
                else
                {
                    MessageBox.Show($"Person is not found with Database error. Person ID: {PersonID}",
                        "Not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show($"Licnese is not found\nDatabase error\nLicnese ID: {LicenseID}",
                    "Not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
