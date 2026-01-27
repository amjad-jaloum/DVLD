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
            LoadComboBoxActiveStatus();
        }
        private void LoadComboBoxActiveStatus()
        {
            cbActiveStatus.Items.Add("All");
            cbActiveStatus.Items.Add("Acitve");
            cbActiveStatus.Items.Add("Not Active");

            cbActiveStatus.SelectedIndex = 0;
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
            LoadUsers();
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            mtxbSearch.Visible = !(cbFilter.SelectedItem.ToString() == "None" || cbFilter.SelectedItem.ToString() == "IsActive");
            cbActiveStatus.Visible = cbFilter.SelectedItem.ToString() == "IsActive";

            if (cbFilter.SelectedItem.ToString() == "UserID" || cbFilter.SelectedItem.ToString() == "PersonID")
            {
                mtxbSearch.Mask = "000000";
            }
            else
            {
                if (cbFilter.SelectedItem.ToString() == "None")
                {
                    mtxbSearch.Text = string.Empty;
                    LoadUsers();
                }
                mtxbSearch.Mask = "";
            }
        }
        private void mtxbSearch_TextChanged(object sender, EventArgs e)
        {
            UpdateDataTableWithFilter();
        }
        private void cbActiveStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateDataTableWithFilter();
        }
        private void UpdateDataTableWithFilter()
        {
            if (!cbFilter.SelectedItem.ToString().Contains("None"))
            {
                string SearchValue;
                if (cbFilter.SelectedItem.ToString() == "IsActive")
                {
                    if (cbActiveStatus.SelectedItem.ToString() == "Active")
                    {
                        SearchValue = "1";
                    }
                    else if (cbActiveStatus.SelectedItem.ToString() == "Not Active")
                    {
                        SearchValue = "0";
                    }
                    else
                    {
                        SearchValue = string.Empty;
                    }
                }
                else
                {
                    SearchValue = mtxbSearch.Text;
                }

                dgvUsers.DataSource = User.GetDataTableWithQuery(cbFilter.SelectedItem.ToString(), SearchValue);
                lblRowsCountValue.Text = dgvUsers.RowCount.ToString();
            }

        }
        private void mtxbSearch_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = GetUserIDFromDGV();
            User user = User.FindUser(UserID);
            frmAddAndUpdateUser frm = new frmAddAndUpdateUser(user);
            frm.Handeler += HandleDelagetData;

            frm.ShowDialog();
        }
        private int GetUserIDFromDGV()
        {
            return Convert.ToInt32(dgvUsers.CurrentRow.Cells[0].Value);
        }
        private int GetPersonIDFromDGV()
        {
            return Convert.ToInt32(dgvUsers.CurrentRow.Cells[1].Value);
        }
        private void HandleDelagetData(object obj)
        {
            LoadUsers();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = GetUserIDFromDGV();
            if (User.DeleteUser(UserID))
            {
                MessageBox.Show("Deleted Successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
            }
            else
            {
                MessageBox.Show("This User record is linked to other data", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = GetPersonIDFromDGV();
            int UserID = GetUserIDFromDGV();

            frmShowUserDetails frm = new frmShowUserDetails(PersonID, UserID);
            frm.Show();
        }
        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = GetPersonIDFromDGV();
            int UserID = GetUserIDFromDGV();

            frmChangeUserPassword frm = new frmChangeUserPassword(PersonID, UserID);
            frm.ShowDialog();
            LoadUsers();
        }
    }
}
