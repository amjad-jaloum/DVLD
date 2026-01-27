using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _19___Project___DVLD.Application_Types;
using DVLD_Business;

namespace _19___Project___DVLD.Test_Types
{
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmManageTestTypes_Load(object sender, EventArgs e)
        {
            LoadTestTypes();
        }
        public void LoadTestTypes()
        {
            DataTable TestsDataTable = TestType.GetTestTypes();
            dgvTestTypes.DataSource = TestsDataTable;
            lblRowsCountValue.Text = dgvTestTypes.RowCount.ToString();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestType test = GetAppTypeFromDGV();
            frmUpdateTestType frm = new frmUpdateTestType(test);
            frm.ShowDialog();

            LoadTestTypes();
        }
        private TestType GetAppTypeFromDGV()
        {
            int TestID = GetIDFromDataGridView();
            string TestTitle = GetTestTitleFromDataGridView();
            string TestDesc = GetTestDescFromDataGridView();
            float TestFees = GetAppFeesFromDataGridView();

            TestType test = new TestType(TestID, TestTitle, TestDesc, TestFees);
            return test;
        }
        private int GetIDFromDataGridView()
        {
            return Convert.ToInt32(dgvTestTypes.CurrentRow.Cells[0].Value);
        }
        private string GetTestTitleFromDataGridView()
        {
            return Convert.ToString(dgvTestTypes.CurrentRow.Cells[1].Value);
        }
        private string GetTestDescFromDataGridView()
        {
            return Convert.ToString(dgvTestTypes.CurrentRow.Cells[2].Value);
        }
        private float GetAppFeesFromDataGridView()
        {
            return (float)Convert.ToDouble(dgvTestTypes.CurrentRow.Cells[3].Value);
        }
    }
}
