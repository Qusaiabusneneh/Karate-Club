using DevExpress.XtraEditors.Filtering.Templates;
using Karate_Bussines_Layers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karate.App.Subscription_Periods
{
    public partial class FRMAddUpdateSubscriptionPeriod : Form
    {
        public Action<int?> GetPeriodID;
        private enum enMode { enAddNew,enUpdate};
        private enMode _Mode = enMode.enAddNew;
        private int? _PeriodID = null;
        private int? _SelectedMemberID = null;
        private clsSubscriptionPeriods _subscriptionPeriods;
        public FRMAddUpdateSubscriptionPeriod()
        {
            InitializeComponent();
            _Mode= enMode.enAddNew;
        }
        public FRMAddUpdateSubscriptionPeriod(int?PeriodId)
        {
            InitializeComponent();
            this._PeriodID=PeriodId;
            _Mode = enMode.enUpdate;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _ResetDefaultValue()
        {
            if (_Mode == enMode.enAddNew)
            {
                lblTitle.Text = "Add New Subscription Period";
                this.Text = lblTitle.Text;
                _subscriptionPeriods = new clsSubscriptionPeriods();
            }
            else
            {
                lblTitle.Text = "Update Subscription Period";
                this.Text= lblTitle.Text;
            
            }
            dtpStartDate.MinDate = DateTime.Now;
            dtpEndDate.MinDate = dtpStartDate.Value.AddMonths(clsSettings.DefaultSubscriptionPeriod());
            chkIsActive.Checked = true;
            chkIsPaid.Checked = false;
        }
        private void _LoadData()
        {
            _subscriptionPeriods = clsSubscriptionPeriods.Find(_PeriodID);
            if (_subscriptionPeriods == null)
            {
                MessageBox.Show($"There is no Period with ID = {_PeriodID}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            ctrlFindMemberWithFilter1.FilterEnable = false;
            ctrlFindMemberWithFilter1.LoadMemberInfo(_subscriptionPeriods.MemberID);
            lblPeriodID.Text=_subscriptionPeriods.PeriodID.ToString();
            lblMemberID.Text=_subscriptionPeriods.MemberID.ToString();
            txtFees.Text=_subscriptionPeriods.Fees.ToString();

            if (_subscriptionPeriods.StartDate < DateTime.Now) 
                dtpStartDate.Value = DateTime.Now;
            else
                dtpStartDate.Value = _subscriptionPeriods.EndDate;

            if (_subscriptionPeriods.EndDate < DateTime.Now.AddMonths(clsSettings.DefaultSubscriptionPeriod()))
                dtpEndDate.Value = DateTime.Now.AddMonths(clsSettings.DefaultSubscriptionPeriod());
            else
                dtpEndDate.Value = _subscriptionPeriods.EndDate;

            if(_subscriptionPeriods.IsPaid)
            {
                chkIsPaid.Checked = true;
                chkIsPaid.Enabled = false;
                lblPaymentID.Text = _subscriptionPeriods.PaymentID.ToString();
                btnSave.Enabled = false;
            }
        }
        private void ctrlFindMemberWithFilter1_OnMemberSelected(object sender, 
            Members.Control.ctrlFindMemberWithFilter.MemberSelectedEventArgs e)
        {
            _SelectedMemberID = e.MemberID;
            if(!_SelectedMemberID.HasValue)
            {
                btnSave.Enabled = false;
                lblMemberID.Text = "[????]";
                return;
            }

            int? PeriodID = ctrlFindMemberWithFilter1.SelectedMemberInfo.GetLastActivePeriodID();
            if (PeriodID.HasValue)
            {

                clsSubscriptionPeriods LastPeriod = clsSubscriptionPeriods.Find(PeriodID);
                if (LastPeriod == null)
                {
                    btnSave.Enabled = false;
                    return;
                }

                MessageBox.Show("This member already has an active subscription period !", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }
            lblMemberID.Text = _SelectedMemberID.ToString();
            btnSave.Enabled = true;
            txtFees.Focus();
        }

        private void AddUpdateSubscriptionPeriod_Load(object sender, EventArgs e)
        {
            _ResetDefaultValue();
            if (_Mode == enMode.enUpdate)
                _LoadData();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wanna save this subscription?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            _subscriptionPeriods.StartDate = dtpStartDate.Value;
            _subscriptionPeriods.EndDate = dtpEndDate.Value;
            _subscriptionPeriods.MemberID = ctrlFindMemberWithFilter1.MemberID;
            _subscriptionPeriods.Fees = Convert.ToDecimal(txtFees.Text.Trim());
            _subscriptionPeriods.IsActive = true;
            
            if(_Mode==enMode.enAddNew)
            {
                _subscriptionPeriods.IssueReason = clsSubscriptionPeriods.enIssueReason.FirstTime;
            }

            int? PaymentID = null;
            if (chkIsActive.Checked == true && chkIsPaid.Checked == true)
            {
                PaymentID = _subscriptionPeriods.Pay(Convert.ToDecimal(txtFees.Text.Trim()));
                lblPaymentID.Text= PaymentID.ToString();
            }
            _subscriptionPeriods.PaymentID= PaymentID;
            _subscriptionPeriods.IsPaid = (PaymentID.HasValue);

            clsMember.SetActivity(_subscriptionPeriods.MemberID, _subscriptionPeriods.IsPaid);

             if(_subscriptionPeriods.Save())
            {
                MessageBox.Show("Successfully Registered", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                ctrlFindMemberWithFilter1.FilterEnable = false;
                btnSave.Enabled = false;
                txtFees.Enabled = false;
                //GetPeriodID?.Invoke(_subscriptionPeriods.PeriodID);
            }
            else
                MessageBox.Show("Failed Registered", "Failed",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
    }
}
