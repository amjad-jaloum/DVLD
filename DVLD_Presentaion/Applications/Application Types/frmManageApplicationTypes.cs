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
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            LoadApplications();
        }

        public void LoadApplications()
        {
            DataTable AppsDataTable = ApplicationType.GetApplicationTypes();
            dgvApplications.DataSource = AppsDataTable;
            lblRowsCountValue.Text = dgvApplications.RowCount.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationType applicationType = GetAppTypeFromDGV();
            frmUdateApplicationTypes frm = new frmUdateApplicationTypes(applicationType);
            frm.ShowDialog();

            LoadApplications();
        }
        private ApplicationType GetAppTypeFromDGV()
        {
            int AppID = GetIDFromDataGridView();
            string AppTitle = GetAppTitleFromDataGridView();
            float AppFees = GetAppFeesFromDataGridView();

            ApplicationType applicationType = new ApplicationType(AppID,AppTitle,AppFees);
            return applicationType;
        }
        private float GetAppFeesFromDataGridView()
        {
            return (float)Convert.ToDouble(dgvApplications.CurrentRow.Cells[2].Value);
        }
        private string GetAppTitleFromDataGridView()
        {
            return Convert.ToString(dgvApplications.CurrentRow.Cells[1].Value);
        }
        private int GetIDFromDataGridView()
        {
            return Convert.ToInt32(dgvApplications.CurrentRow.Cells[0].Value);
        }
    }
}
