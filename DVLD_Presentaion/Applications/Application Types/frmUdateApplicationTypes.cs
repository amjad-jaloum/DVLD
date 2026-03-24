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

namespace _19___Project___DVLD.Application_Types
{
    public partial class frmUdateApplicationTypes : Form
    {
        ApplicationType applicationType = null;
        public frmUdateApplicationTypes(ApplicationType applicationType)
        {
            InitializeComponent();
            this.applicationType = applicationType;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (AreFieldsValied())
            {
                if (UpdateAppType())
                {
                    MessageBox.Show("Upated successfully!");
                }
                else
                    MessageBox.Show("Not Upated!");
            }
        }
        private bool AreFieldsValied()
        {
            if (
                !clsCommonMethods.HasErrors(errorProvider1.GetError(tbAppTitle)) &&
                !clsCommonMethods.HasErrors(errorProvider1.GetError(tbAppFees))
                )
            {
                return true;
            }
            return false;
        }

        private bool UpdateAppType()
        {
            ApplicationType application = new ApplicationType(Convert.ToInt32(lblAppID.Text), tbAppTitle.Text, (float)Convert.ToDouble(tbAppFees.Text));
            return ApplicationType.UpdateAppType(application);
        }

        private void tbAppTitle_Leave(object sender, EventArgs e)
        {
            clsCommonMethods.MakeTextBoxFieldRequired(tbAppTitle, errorProvider1);
        }

        private void tbAppFees_Leave(object sender, EventArgs e)
        {
            clsCommonMethods.MakeTextBoxFieldRequired(tbAppFees, errorProvider1);
        }

        private void frmUdateApplicationTypes_Load(object sender, EventArgs e)
        {
            LoadAppTypes();
        }

        private void LoadAppTypes()
        {
            if (applicationType != null)
            {
                lblAppID.Text = applicationType.AppID.ToString();
                tbAppTitle.Text = applicationType.AppTitle;
                tbAppFees.Text = applicationType.AppFees.ToString();
            }
            else
            {
                MessageBox.Show("Applicatoin is null to load!");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
