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

namespace Karate.App.Subscription_Periods.Control
{
    public partial class ctrlSubscriptionPeriodCard : UserControl
    {
        private int? _PeriodID = null;
        private clsSubscriptionPeriods _subscriptionPeriods;
        public int? PeriodID => _PeriodID;
        public clsSubscriptionPeriods PeriodSelected => _subscriptionPeriods;
        private void _fillSubscriptionPeriod()
        {
            ctrlFindMember1.LoadMemberInfo(_subscriptionPeriods.MemberID);
            lblEndDate.Text=_subscriptionPeriods.EndDate.ToShortDateString();
            lblStartDate.Text=_subscriptionPeriods.StartDate.ToShortDateString();
            lblFees.Text=_subscriptionPeriods.Fees.ToString("F0");
            lblIsActive.Text = (_subscriptionPeriods.IsActive) ? "Yes" : "No";
            lblIsPaid.Text = (_subscriptionPeriods.IsPaid) ? "Yes" : "No";
            lblIssueReason.Text = _subscriptionPeriods.IssueReasonText;
            lblPaymentID.Text = (_subscriptionPeriods.PaymentID.HasValue) ? _subscriptionPeriods.PaymentID.ToString() : "Not paid yet";
            lblMemberID.Text=_subscriptionPeriods.MemberID.ToString();  
            lblPeriodID.Text=_subscriptionPeriods.PeriodID.ToString();
        }
        private void _ResetDefaultValue()
        {
            ctrlFindMember1.ResetMemberInfo();
            lblEndDate.Text = "[????]";
            lblFees.Text= "[????]";
            lblIsActive.Text= "[????]";
            lblIsPaid.Text= "[????]";
            lblIssueReason.Text= "[????]";
            lblMemberID.Text= "[????]";
            lblPaymentID.Text= "[????]";
            lblPeriodID.Text= "[????]";
            lblStartDate.Text= "[????]";
        }
        public void LoadSubscriptionPeriodInfo(int?PeriodID)
        {
            this._PeriodID=PeriodID;
            if(!_PeriodID.HasValue)
            {
                MessageBox.Show("There is no subscription period with this ID", "Missing Subscription Period",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ResetDefaultValue();
                return;
            }

            _subscriptionPeriods = clsSubscriptionPeriods.Find(_PeriodID);
            if (_subscriptionPeriods == null)
            {
                MessageBox.Show("There is no subscription period with This ID", "Missing Subscription Period",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ResetDefaultValue();
                return;
            }
            _fillSubscriptionPeriod();
        }
        public ctrlSubscriptionPeriodCard()
        {
            InitializeComponent();
        }
    }
}
