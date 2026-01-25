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

namespace _19___Project___DVLD.Users
{
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            LoadUsers();
            LoadComboBoxFilter();
        }
        public void LoadUsers()
        {
            DataTable dtUsers = User.GetAllUsers();
            dgvUsers.DataSource = dtUsers;
            lblRowsCountValue.Text = dgvUsers.RowCount.ToString();
        }
        private void LoadComboBoxFilter()
        {
            List<string> ColumnNames = User.GetUserColumnNames();
            if (ColumnNames == null)
            {
                MessageBox.Show("Database error, Column names are not loaded properly!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                FillFilterComboBox(ColumnNames);
            }
        }
        private void FillFilterComboBox(List<string> ColumnNames)
        {
            cbFilter.Items.Add("None");
            cbFilter.SelectedItem = "None";

            foreach (string ColumnName in ColumnNames)
                cbFilter.Items.Add(ColumnName);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddAndUpdateUser frm = new frmAddAndUpdateUser();
            frm.ShowDialog();
        }
    }
}
