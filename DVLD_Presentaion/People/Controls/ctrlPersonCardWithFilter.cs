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

        public event Action<int> OnPersonSelected;
        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> action = OnPersonSelected;
            if (action != null)
            {
                action(PersonID);
            }
        }
        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get { return _ShowAddPerson; }
            set
            {
                _ShowAddPerson = value;
                btnAddPerson.Enabled = _ShowAddPerson;
            }
        }
        public bool _FilterEnabled;
        public bool FilterEnabled
        {
            get { return _FilterEnabled; }
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }
        public int PersonID
        {
            get { return ctrlPersonCard1.PersonID; }
        }
        public clsPerson SelectedPersonInfo
        {
            get { return ctrlPersonCard1.SelectedPersonInfo; }
        }
        public void LoadPersonInfo(int PersonID)
        {
            cbFilter.SelectedIndex = 1;
            mtxbSearch.Text = PersonID.ToString();

        }
        private void FindNow()
        {
            switch (cbFilter.Text)
            {
                case "Person ID":
                    ctrlPersonCard1.LoadPersonInfo(int.Parse(mtxbSearch.Text));
                    break;
                
                case "National No.":
                    ctrlPersonCard1.LoadPersonInfo(int.Parse(mtxbSearch.Text));
                    break;

                default:
                    break;
            }

            if(OnPersonSelected != null && FilterEnabled)
            {
                OnPersonSelected(ctrlPersonCard1.PersonID);
            }
        }
        private void ctrlPersonDetailWithFitler_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            mtxbSearch.Focus();
        }
        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {

            if (string.IsNullOrEmpty(mtxbSearch.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(mtxbSearch, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(mtxbSearch, null);
            }
        }
        private void btnFindPerson_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FindNow();
        }
        private void GetPersonDetailsWithFilterQuery(EventArgs e)
        {
            if (!cbFilter.SelectedItem.ToString().Contains("None"))
            {
                _Person = clsPerson.GetPersonInfoWithQueryFilter(cbFilter.SelectedItem.ToString(), mtxbSearch.Text);

                if (_Person != null)
                {
                    LoadPersonDetailsToControl(_Person, e);
                    if (OnPersonSelected != null)
                        OnPersonSelected(_Person.PersonID);
                }
                else
                {
                    MessageBox.Show("This Person doesn't exist!", "Person not found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void LoadPersonDetailsToControl(clsPerson person, EventArgs e)
        {
            ctrlPersonCard1._Person = person;
            ctrlPersonCard1.ctrlShowPersonDetails_Load(ctrlPersonCard1, e);
        }
        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.DataBack += DataBackEvent; // subscribe in the event
            frm.ShowDialog();
        }
        private void DataBackEvent(object sender, int PersonID)
        {
            cbFilter.SelectedIndex = 1;
            mtxbSearch.Text = PersonID.ToString();
            ctrlPersonCard1.LoadPersonInfo(PersonID);
        }
        public void FilterFocus()
        {
            mtxbSearch.Focus();
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (character code 13)
            if (e.KeyChar == (char)13)
            {
                btnFindPerson.PerformClick();
            }

            //this will allow only digits if person id is selected
            if (cbFilter.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            mtxbSearch.Text = string.Empty;
            mtxbSearch.Focus();
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
