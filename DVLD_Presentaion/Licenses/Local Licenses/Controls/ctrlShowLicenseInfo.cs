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
        private int _LicenseID = -1;
        private clsLicense _License;
        public int LicenseID
        {
            get { return _LicenseID; }
        }

        public ctrlShowLicenseInfo()
        {
            InitializeComponent();
        }

        public void LoadInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
            _License = clsLicense.Find(LicenseID);
            if (_License == null)
            {
                MessageBox.Show("No License with ID=" + LicenseID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }

            lblLicenseID.Text = _License.LicenseID.ToString();
            lblIsActive.Text = _License.IsActive ? "Yes" : "No";
            lblIsDetained.Text = _License.IsDetained ? "Yes" : "No";
            lblClass.Text = _License.LicenseClassIfo.ClassName;
            lblName.Text = _License.DriverInfo.PersonInfo.FullName;
            lblNatioinalNo.Text = _License.DriverInfo.PersonInfo.NationalNo;
            lblGender.Text = _License.DriverInfo.PersonInfo.Gender == 0 ? "Male" : "Female";
            lblDateOfBirth.Text = _License.DriverInfo.PersonInfo.DateOfBirth.ToShortDateString();

            lblDriverID.Text = _License.DriverID.ToString();
            lblIssueDate.Text = _License.IssueDate.ToShortDateString();
            lblExpirationDate.Text = _License.ExpirationDate.ToShortDateString();
            lblIssueReason.Text = _License.IssueReasonText;
            lblNotes.Text = _License.Notes == "" ? "No Notes" : _License.Notes;
            _LoadPersonImage();


        }
        private void _LoadPersonImage()
        {
            string ImagePath = _License.DriverInfo.PersonInfo.ImagePath;
            if (ImagePath == string.Empty)
            {
                pbProfileImage.Image = _License.DriverInfo.PersonInfo.Gender == 0 ? Resources.male : Resources.female;
                return;
            }

            if (!File.Exists(ImagePath))
            {
                pbProfileImage.Image = Convert.ToBoolean(_License.DriverInfo.PersonInfo.Gender) ? Resources.femaleWrong : Resources.maleWrong;
                return;
            }

            pbProfileImage.Load(ImagePath);
        }

    }
}
