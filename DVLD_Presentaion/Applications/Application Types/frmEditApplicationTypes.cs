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
    public partial class frmEditApplicationTypes : Form
    {
        clsApplicationType _ApplicationType;
        private int _ApplicationTypeID;
        public frmEditApplicationTypes(int ApplicaitonTypeID)
        {
            InitializeComponent();
            _ApplicationTypeID = ApplicaitonTypeID;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _ApplicationType.Title = tbAppTitle.ToString();
            _ApplicationType.Fees = Convert.ToSingle(tbAppFees.Text.Trim());

            if (_ApplicationType.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void frmUdateApplicationTypes_Load(object sender, EventArgs e)
        {
            lblAppID.Text = _ApplicationTypeID.ToString();
            _ApplicationType = clsApplicationType.Find(_ApplicationTypeID);

            if (_ApplicationType != null)
            {
                tbAppTitle.Text = _ApplicationType.Title;
                tbAppFees.Text = _ApplicationType.Fees.ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbAppTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbAppTitle.Text.Trim()))
            {
                e.Cancel = true; // This prevents the user from moving to another control
                errorProvider1.SetError(tbAppTitle, "Title cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(tbAppTitle, string.Empty);
            }
        }

        private void tbAppFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbAppFees.Text.Trim()))
            {
                e.Cancel = true; //
                errorProvider1.SetError(tbAppFees, "Fees cannot be empty!");
            }
            else
            {
                errorProvider1.SetError(tbAppFees, string.Empty);
            }
        }
    }
}
