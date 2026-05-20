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

namespace _19___Project___DVLD.Drivers
{
    public partial class frmListDrivers : Form
    {
        public frmListDrivers()
        {
            InitializeComponent();
        }

        private void frmManageDrivers_Load(object sender, EventArgs e)
        {
            LoadDriversToDGV();
            LoadComboBoxFilter();
        }
        private void LoadComboBoxFilter()
        {
            //List<string> ColumnNames = clsDriver.GetDriversColumnNames();
            //if (ColumnNames == null)
            //{
            //    MessageBox.Show("Database error, Column names are not loaded properly!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //else
            //{
            //    FillFilterComboBox(ColumnNames);
            //}
        }
        private void FillFilterComboBox(List<string> ColumnNames)
        {
            cbFilter.Items.Add("None");
            cbFilter.SelectedItem = "None";

            foreach (string ColumnName in ColumnNames)
                cbFilter.Items.Add(ColumnName);
        }

        private void LoadDriversToDGV()
        {
            //dgvDrivers.DataSource = clsDriver.GetDriversData();
            //lblRowsCountValue.Text = dgvDrivers.Rows.Count.ToString();
        }

        private void mtxbSearch_TextChanged(object sender, EventArgs e)
        {
            UpdateDataTableWithFilter();
        }
        private void UpdateDataTableWithFilter()
        {
            //if (!cbFilter.SelectedItem.ToString().Contains("None"))
            //{
            //    string SearchValue = mtxbSearch.Text;
            //    dgvDrivers.DataSource = clsDriver.GetDataTableWithQuery(cbFilter.SelectedItem.ToString(), SearchValue);
            //    lblRowsCountValue.Text = dgvDrivers.RowCount.ToString();
            //}
        }

    }
}
