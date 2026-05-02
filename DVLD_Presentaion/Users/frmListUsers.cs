using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _19___Project___DVLD.People;
using DVLD_Business;

namespace _19___Project___DVLD.Users
{
    public partial class frmListUsers : Form
    {
        private static DataTable _dtAllUsers;
        public frmListUsers()
        {
            InitializeComponent();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            _dtAllUsers = clsUser.GetAllUsers();
            dgvUsers.DataSource = _dtAllUsers;

            cbFilter.SelectedIndex = 0;
            lblRowsCountValue.Text = dgvUsers.RowCount.ToString();

            dgvUsers.Columns[0].HeaderText = "User ID";
            dgvUsers.Columns[0].Width = 110;

            dgvUsers.Columns[1].HeaderText = "Person ID";
            dgvUsers.Columns[1].Width = 120;

            dgvUsers.Columns[2].HeaderText = "Full Name";
            dgvUsers.Columns[2].Width = 350;

            dgvUsers.Columns[3].HeaderText = "UserName";
            dgvUsers.Columns[3].Width = 120;

            dgvUsers.Columns[4].HeaderText = "Is Active";
            dgvUsers.Columns[4].Width = 120;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.ShowDialog();
            frmManageUsers_Load(null, null);
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilter.Text == "Is Active")
            {
                mtxbSearch.Visible = false;
                cbActiveStatus.Visible = true;
                cbActiveStatus.Focus();
                cbActiveStatus.SelectedIndex = 0;
            }
            else
            {
                mtxbSearch.Visible = (cbFilter.Text != "None");
                cbActiveStatus.Visible = false;

                if (cbFilter.Text == "None")
                {
                    mtxbSearch.Enabled = false;
                }
                else
                    mtxbSearch.Enabled = true;

                mtxbSearch.Text = "";
                mtxbSearch.Focus();
            }
        }
        private void mtxbSearch_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";

            switch (cbFilter.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "UserName":
                    FilterColumn = "UserName";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            if (mtxbSearch.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllUsers.DefaultView.RowFilter = string.Empty;
                lblRowsCountValue.Text = dgvUsers.Rows.Count.ToString();
                return;
            }

            if (FilterColumn != "FullName" && FilterColumn != "UserName")
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", FilterColumn, mtxbSearch.Text);
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, mtxbSearch.Text);

            lblRowsCountValue.Text = dgvUsers.Rows.Count.ToString();
        }
        private void cbActiveStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterColumn = "IsActive";
            string FilterValue = cbActiveStatus.Text;

            switch (FilterValue)
            {
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
                default:
                    break;
            }

            if (FilterValue == "All")
                _dtAllUsers.DefaultView.RowFilter = string.Empty;
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", FilterColumn, FilterValue);

            lblRowsCountValue.Text = _dtAllUsers.Rows.Count.ToString();

        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser(GetUserIDFromDGV());
            frm.ShowDialog();
            frmManageUsers_Load(null, null);
        }
        private int GetUserIDFromDGV()
        {
            return Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value);
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = GetUserIDFromDGV();

            if (clsUser.DeleteUser(UserID))
            {
                MessageBox.Show("Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmManageUsers_Load(null, null);
            }
            else
            {
                MessageBox.Show("This User record is linked to other data", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(GetUserIDFromDGV());
            frm.ShowDialog();
        }
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(GetUserIDFromDGV());
            frm.ShowDialog();
        }
        private void mtxbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilter.Text == "Person ID" || cbFilter.Text == "User ID")
            {
                e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
            }
        }
    }
}
