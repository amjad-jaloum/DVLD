using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using DVLD_Business;

namespace _19___Project___DVLD.People
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        clsPerson _Person;
        enum enMode { History = 0, Search = 1 }
        enMode Mode = enMode.Search;

        public event Action<clsPerson> WhenUserFound;
        protected virtual void UserFound(clsPerson person)
        {
            Action<clsPerson> action = WhenUserFound;
            if (action != null)
            {
                action(person);
            }
        }
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }
        private void ctrlPersonDetailWithFitler_Load(object sender, EventArgs e)
        {
            LoadComboBoxFilter();
        }
        private void LoadComboBoxFilter()
        {
            List<string> ColumnNames = clsPerson.GetPeopleColumnNames();
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
            {
                if (!ColumnName.Contains("PersonID") && !ColumnName.Contains("NationalNo"))
                    continue;

                cbFilter.Items.Add(ColumnName);
            }
        }
        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            GetPersonDetailsWithFilterQuery(e);
        }
        private void GetPersonDetailsWithFilterQuery(EventArgs e)
        {
            if (!cbFilter.SelectedItem.ToString().Contains("None"))
            {
                _Person = clsPerson.GetPersonInfoWithQueryFilter(cbFilter.SelectedItem.ToString(), mtxbSearch.Text);

                if (_Person != null)
                {
                    LoadPersonDetailsToControl(_Person, e);
                    if (WhenUserFound != null)
                        UserFound(_Person);
                }
                else
                {
                    MessageBox.Show("This Person doesn't exist!", "Person not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void LoadPersonDetailsToControl(clsPerson person, EventArgs e)
        {
            ctrlShowPersonDetails1.person = person;
            ctrlShowPersonDetails1.ctrlShowPersonDetails_Load(ctrlShowPersonDetails1, e);
        }
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.DataBack += HandleDelegatePerson;
            frm.ShowDialog();
        }
        private void HandleDelegatePerson(object sender, int PersonID)
        {
            EventArgs e = new EventArgs();
            _Person = clsPerson.Find(PersonID);
            if (_Person != null)
                LoadPersonDetailsToControl(_Person, e);
            else
                MessageBox.Show("Person details are not loaded properly!");
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Mode != enMode.History)
                mtxbSearch.Enabled = cbFilter.SelectedItem.ToString() != "None";
        }
        private void gbFilter_Enter(object sender, EventArgs e)
        {

        }
        public void ShowPersonDetailsWithHistory(int Value, string ColumnName = "PersonID")
        {
            Mode = enMode.History;
            mtxbSearch.Text = Value.ToString();
            mtxbSearch.Enabled = false;

            cbFilter.SelectedItem = ColumnName;
            cbFilter.Enabled = false;

            btnAddPerson.Enabled = false;
            btnFindPerson.Enabled = false;

            GetPersonDetailsWithFilterQuery(new EventArgs());
        }
    }
}
