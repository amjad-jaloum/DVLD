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
    public partial class frmListApplicationType : Form
    {
        private DataTable _dtAllApplicationTypes;
        public frmListApplicationType()
        {
            InitializeComponent();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _dtAllApplicationTypes = clsApplicationType.GetAllApplicationTypes();
            dgvApplications.DataSource = _dtAllApplicationTypes;
            lblRowsCountValue.Text = dgvApplications.RowCount.ToString();

            if (dgvApplications.RowCount > 0)
            {
                dgvApplications.Columns[0].HeaderText = "ID";
                dgvApplications.Columns[0].Width = 110;

                dgvApplications.Columns[1].HeaderText = "Title";
                dgvApplications.Columns[1].Width = 400;

                dgvApplications.Columns[2].HeaderText = "Fees";
                dgvApplications.Columns[2].Width = 100;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditApplicationTypes frm = new frmEditApplicationTypes((int)dgvApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmManageApplicationTypes_Load(null, null);
        }
    }
}
