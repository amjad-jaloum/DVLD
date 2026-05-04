using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _19___Project___DVLD.Global_Classes;
using DVLD_Business;

namespace _19___Project___DVLD.Test_Types
{
    public partial class frmEditTestType : Form
    {
        clsTestType _TestType;
        private clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;
        public frmEditTestType(clsTestType.enTestType testTypeID)
        {
            InitializeComponent();
            _TestTypeID = testTypeID;
        }
        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            _TestType = clsTestType.Find(_TestTypeID);
            if (_TestType != null)
            {
                lblTestID.Text = _TestType.ID.ToString();
                tbTestTitle.Text = _TestType.Title.ToString();
                tbTestDesc.Text = _TestType.Description.ToString();
                tbTestFees.Text = _TestType.Fees.ToString();
            }
            else
            {
                MessageBox.Show("Could not find Test Type with id = " + _TestTypeID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _TestType.Title = tbTestTitle.Text.Trim();
            _TestType.Description = tbTestDesc.Text.Trim();
            _TestType.Fees = Convert.ToSingle(tbTestFees.Text.Trim());

            if (_TestType.Save())
            {
                MessageBox.Show("Test Type updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update Test Type!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbTestTitle_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbTestTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbTestTitle, "Title is required!");
            }
            else
                errorProvider1.SetError(tbTestTitle, string.Empty);
        }

        private void tbTestDesc_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbTestTitle.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbTestDesc, "Description is required!");
            }
            else
                errorProvider1.SetError(tbTestDesc, string.Empty);
        }

        private void tbTestFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(tbTestFees.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(tbTestFees, "Fees is required!");
            }
            else
            {
                if (!clsValidation.IsNumber(tbTestFees.Text))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(tbTestFees, "Fees must be a number!");
                }
                else
                    errorProvider1.SetError(tbTestFees, string.Empty);
            }
        }
    }
}
