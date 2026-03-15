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
        public Person person = null;
        public AppLicense license = null;
        public int LicenseID = -1;
        public bool IsLoaded = false;
        public ctrlShowLicenseInfo()
        {
            InitializeComponent();
        }

        public void ctrlShowLicenseInfo_Load(object sender, EventArgs e)
        {
            if (LicenseID != -1)
            {
                if (GetLicenseAndPersonDetails() && LoadLicenseAndPersonDetails())
                {
                    IsLoaded = true;
                    return;
                }
            }
            IsLoaded = false;
        }

        private bool LoadLicenseAndPersonDetails()
        {
            if (license != null)
            {
                lblClass.Text = LocalDrivingLicenseApplication.FindLicenceName(license.LicenseClass);
                lblName.Text = person.FullName;
                lblLicenseID.Text = LicenseID.ToString();
                lblNatioinalNo.Text = person.NationalNo;
                lblGender.Text = person.GenderString;
                lblIssueDate.Text = license.IssueDate.ToShortDateString();
                lblNotes.Text = license.Notes;
                lblIsActive.Text = license.IsAciveString;
                lblDateOfBirth.Text = person.DateOfBirth.ToShortDateString();
                lblDriverID.Text = license.DriverID.ToString();
                lblExpirationDate.Text = license.ExpirationDate.ToShortDateString();
                lblIsDetained.Text = DetainedLicense.IsLicenseDetained(LicenseID) ? "Yes" : "No";
                pbProfileImage.Image = GetImagePath(person.ImagePath);
                return true;
            }
            else
            {
                MessageBox.Show($"Couldn't Load License Details",
                    "Not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
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
        private bool GetLicenseAndPersonDetails()
        {
            license = AppLicense.FindLicense(LicenseID);
            if (license != null)
            {
                int PersonID = Driver.FindDriver(license.DriverID).PersonID;
                if (PersonID != -1)
                {
                    person = Person.FindPerson(PersonID);
                    return true;
                }
                else
                {
                    MessageBox.Show($"Person is not found with Database error. Person ID: {PersonID}",
                        "Not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show($"Licnese is not found Database error. Licnese ID: {LicenseID}",
                    "Not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return false;
        }
    }
}
