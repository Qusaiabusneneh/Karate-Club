using Karate_Bussines_Layers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karate.App.People
{
    public partial class ctrlFindPersonWithFilter : UserControl
    {
        #region Declare Event
        public class PersonSelectedEventArgs:EventArgs
        {
            public int? PersonID { get; }
            public PersonSelectedEventArgs(int? personID)
            {
                this.PersonID = personID;
            }
        }
        public event EventHandler<PersonSelectedEventArgs> OnPersonSelected;
        public void RaiseOnPersonSelected(int? PersonID)
        {
            RaiseOnPersonSelected(new PersonSelectedEventArgs(PersonID));
        }
        protected virtual void RaiseOnPersonSelected(PersonSelectedEventArgs e)
        {
            OnPersonSelected?.Invoke(this, e);
        }
        #endregion

        private bool _ShowPersonAdded = true;
        public bool ShowPersonAdded
        {
            get => _ShowPersonAdded;
            set
            {
                _ShowPersonAdded = value;
               // btnAddNewPerson.Enabled = _ShowPersonAdded;
            }
        }
        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get => _FilterEnabled;
            set
            {
                _FilterEnabled= value;
               // gbFilters.Enabled = _FilterEnabled;
            }
        }
        public int? PersonID => ctrlPersonCard1.PersonID;
        public clsPerson SelectedPersonInfo => ctrlPersonCard1.SelectedPersonInfo;
        private void _FindNow()
        {
            switch(cbFilterBy.Text)
            {
                case "PersonID":
                    {
                        ctrlPersonCard1.LoadPersonInfo((int.Parse(txtFilterValue.Text.Trim())));
                        break;
                    }
            }
            if (OnPersonSelected != null && FilterEnabled)
                RaiseOnPersonSelected(ctrlPersonCard1.PersonID);
        }
        public void LoadPersonInfo(int? PersonID)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Text = PersonID.ToString();
            _FindNow();
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valid!,put the mouse the red icon(s) to see the error", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FindNow();
        }
        private void ctrlFindPersonWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Focus();
        }
        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtFilterValue, "This filed is required!");
            }
            else
                errorProvider1.SetError(txtFilterValue, null);
        }
        private void DataBackEvent(object sender,int? PersonID)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Text = PersonID.ToString();
            ctrlPersonCard1.LoadPersonInfo(PersonID);
        }
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            FRMAddNewPeople frm = new FRMAddNewPeople();
            frm.DataBack += DataBackEvent;
            frm.ShowDialog();
        }
        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnFind.PerformClick();
            }

            if (cbFilterBy.Text == "Person ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
        public ctrlFindPersonWithFilter()
        {
            InitializeComponent();
        }

    }
}
