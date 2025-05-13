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

namespace Karate.App.Members.Control
{
    public partial class ctrlFindMemberWithFilter : UserControl
    {
        #region Declare Event
        public class MemberSelectedEventArgs:EventArgs
        {
            public int? MemberID { get; set; }  
            public MemberSelectedEventArgs(int? MemberID)
            {
                this.MemberID = MemberID;
            }
        }
        public event EventHandler<MemberSelectedEventArgs> OnMemberSelected;
        public void RaiseOnMemberSelected(int?MemberID)
        {
            RaiseOnMemberSelected(new MemberSelectedEventArgs(MemberID));
        }
        protected virtual void RaiseOnMemberSelected(MemberSelectedEventArgs e)
        {
            OnMemberSelected?.Invoke(this, e);
        }
        #endregion
        private bool _ShowMemberAdd = false;
        public bool ShowMemberAdd
        {
            get { return _ShowMemberAdd; }
            set
            {
                _ShowMemberAdd = value;
                btnAddNewMember.Visible = _ShowMemberAdd;
            }
        }
        
        private bool _FilterEnable = true;
        public bool FilterEnable
        {
            get { return _FilterEnable; }
            set
            {
                _FilterEnable = value;
                gbFilters.Visible = _FilterEnable;
            }
        }
      
        private int? _MemberID = null;
        public int? MemberID => ctrlFindMember1.MemberID;
        public clsMember SelectedMemberInfo
        {
            get { return ctrlFindMember1.SelectedMemberInfo; }
        }
        public void _FindNow()
        {
            switch(cbFilterBy.Text)
            {
                case "Member ID":
                    ctrlFindMember1.LoadMemberInfo(int.Parse(txtFilterValue.Text.Trim()));
                    break;

                default:
                    break;
            }
            if (OnMemberSelected != null && FilterEnable)
                RaiseOnMemberSelected(ctrlFindMember1.MemberID);
        }
        public void LoadMemberInfo(int? MemberID)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Text = MemberID.ToString();
            _FindNow();
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valid!,put the mouse the red icon(s) to see the error", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FindNow();
        }
        private void ctrlFindMemberWithFilter_Load(object sender, EventArgs e)
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
        private void DataBackEvent(int? MemberID)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = MemberID.ToString();
            ctrlFindMember1.LoadMemberInfo(MemberID);
        }
        private void btnAddNewMember_Click(object sender, EventArgs e)
        {
            FRMAddNewMember frm = new FRMAddNewMember();
            frm.GetMemberID += DataBackEvent;
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

            if (cbFilterBy.Text == "Member ID") 
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
        public ctrlFindMemberWithFilter()
        {
            InitializeComponent();
        }
    }
}
