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
    public partial class frmAddAndUpdateUser : Form
    {
        public frmAddAndUpdateUser()
        {
            InitializeComponent();
        }

        private void btnNextTab_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAddAndUpdateUser_Load(object sender, EventArgs e)
        {
            LoadComboBoxFilter();
        }

        private void LoadComboBoxFilter()
        {
            List<string> ColumnNames = Person.GetPeopleColumnNames();
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
    }
}
