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

namespace _19___Project___DVLD.Test_Types
{
    public partial class frmUpdateTestType : Form
    {
        TestType testType = null;
        public frmUpdateTestType(TestType testType)
        {
            InitializeComponent();
            this.testType = testType;
        }
        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {

            LoadTestTypes();
        }
        private void LoadTestTypes()
        {
            if (testType != null)
            {
                lblTestID.Text = testType.TestTypeID.ToString();
                tbTestTitle.Text = testType.TestTypeTitle;
                tbTestDesc.Text = testType.TestTypeDescription;
                tbTestFees.Text = testType.TestTypeFees.ToString();
            }
            else
            {
                MessageBox.Show("Test object is null to load!");
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (AreFieldsValied())
            {
                if (UpdateTestType())
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
                !clsCommonMethods.HasErrors(errorProvider1.GetError(tbTestTitle)) &&
                !clsCommonMethods.HasErrors(errorProvider1.GetError(tbTestDesc)) &&
                !clsCommonMethods.HasErrors(errorProvider1.GetError(tbTestFees))
                )
            {
                return true;
            }
            return false;
        }
        private bool UpdateTestType()
        {
            TestType test = new TestType(Convert.ToInt32(lblTestID.Text), tbTestTitle.Text, tbTestDesc.Text, (float)Convert.ToDouble(tbTestFees.Text));
            return TestType.UpdateTestType(test);
        }
        private void tbTestTitle_Leave(object sender, EventArgs e)
        {
            clsCommonMethods.MakeTextBoxFieldRequired(tbTestTitle, errorProvider1);
        }
        private void tbTestDesc_Leave(object sender, EventArgs e)
        {
            clsCommonMethods.MakeTextBoxFieldRequired(tbTestDesc, errorProvider1);
        }
        private void tbTestFees_Leave(object sender, EventArgs e)
        {
            clsCommonMethods.MakeTextBoxFieldRequired(tbTestFees, errorProvider1);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
