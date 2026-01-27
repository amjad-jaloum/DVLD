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

namespace _19___Project___DVLD.People
{
    public partial class frmManagePeople : Form
    {
        public frmManagePeople()
        {
            InitializeComponent();
        }

        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            LoadPersons();
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

        public void LoadPersons()
        {
            DataTable PeopleDataTable = Person.GetAllPeople();
            dgvPeople.DataSource = PeopleDataTable;
            lblRowsCountValue.Text = dgvPeople.RowCount.ToString();
        }
        public void LoadPersons(DataTable dataTable)
        {
            DataTable PeopleDataTable = dataTable;
            dgvPeople.DataSource = PeopleDataTable;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddAndUpdatePerson frm = new frmAddAndUpdatePerson();
            frm.ShowDialog();
            LoadPersons();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = GetIdFromDataGridView();
            Person person = Person.FindPerson(PersonID);
            frmAddAndUpdatePerson frm = new frmAddAndUpdatePerson(person);
            frm.Handeler += HandleDelagetData;

            frm.ShowDialog();
        }

        private int GetIdFromDataGridView()
        {
            return Convert.ToInt32(dgvPeople.CurrentRow.Cells[0].Value);
        }

        private void HandleDelagetData(object obj)
        {
            LoadPersons();
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            mtxbSearch.Enabled = cbFilter.SelectedIndex == 0 ? false : true;
            if (cbFilter.SelectedItem.ToString() == "Phone" || cbFilter.SelectedItem.ToString() == "PersonID")
            {
                mtxbSearch.Mask = "000000000";
            }
            else
            {
                if (cbFilter.SelectedItem.ToString() == "None")
                {
                    mtxbSearch.Text = string.Empty;
                    LoadPersons();
                }
                mtxbSearch.Mask = "";
            }
        }

        private void mtxbSearch_TextChanged(object sender, EventArgs e)
        {
            if (!cbFilter.SelectedItem.ToString().Contains("None"))
            {
                dgvPeople.DataSource = Person.GetFilterdPeopleDataTable(cbFilter.SelectedItem.ToString(), mtxbSearch.Text);
                lblRowsCountValue.Text = dgvPeople.RowCount.ToString();
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = GetIdFromDataGridView();
            if (Person.DeletePerson(PersonID))
            {
                MessageBox.Show("Deleted Successfully","Delete",MessageBoxButtons.OK,MessageBoxIcon.Information);
                LoadPersons();
            }
            else
            {
                MessageBox.Show("This Person record is linked to other data","Delete Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = GetIdFromDataGridView();
            Person person = Person.FindPerson(PersonID);

            frmShowPersonDetails showDetails = new frmShowPersonDetails(person);
            showDetails.ShowDialog();
        }

        private void mtxbSearch_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
    }
}
