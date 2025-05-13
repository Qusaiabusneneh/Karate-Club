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
    public partial class ctrlSubscriptionPeriodInfoWithFilter : UserControl
    {
        #region DecalreEvent
        public class SubscriptionPeriodSelectedEventArgs
        {
            public int? PeriodID { set;get; }
            public SubscriptionPeriodSelectedEventArgs(int?PeriodID)
            {
                this.PeriodID = PeriodID;   
            }
        }
        public EventHandler<SubscriptionPeriodSelectedEventArgs> OnSubscriptionPeriodSelected;
        public void RaiseOnSubscriptionPeriodSelected(int?PeriodID)
        {
            RaiseOnSubscriptionPeriodSelected(new SubscriptionPeriodSelectedEventArgs(PeriodID));
        }
        protected virtual void RaiseOnSubscriptionPeriodSelected(SubscriptionPeriodSelectedEventArgs e)
        {
            OnSubscriptionPeriodSelected?.Invoke(this, e);
        }
        #endregion
        private bool _showSubPeriodAdd = false;
        public bool showSubPeriodAdd
        {
            get => _showSubPeriodAdd;
            set
            {
                _showSubPeriodAdd = value;
                btnAddNewSubscriptionPeriod.Visible = _showSubPeriodAdd;
            }
        }
        private bool _FilterEnable = true;
        public bool FilterEnable
        {
            get => _FilterEnable;
            set
            {
                _FilterEnable = value;
                gbFilters.Visible = _FilterEnable;
            }
        }
        private int? _PeriodID = null;
        public int? PeriodID => _PeriodID;
        public clsSubscriptionPeriods selectredSubscriptionPeriods => ctrlSubscriptionPeriodCard1.PeriodSelected;
        private void _FindNow()
        {
            switch(cbFilterBy.Text)
            {
                case "Period ID":
                    {
                        ctrlSubscriptionPeriodCard1.LoadSubscriptionPeriodInfo(int.Parse(txtFilterValue.Text.Trim()));
                        break;
                    }
            }
            if (OnSubscriptionPeriodSelected != null && FilterEnable)
                RaiseOnSubscriptionPeriodSelected(ctrlSubscriptionPeriodCard1.PeriodID);
        }
        public void LoadSubscriptionPeriodInfo(int?PeriodID)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text=PeriodID.ToString();
            _FindNow();
        }
        public ctrlSubscriptionPeriodInfoWithFilter()
        {
            InitializeComponent();
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
        private void ctrlSubscriptionPeriodInfoWithFilter_Load(object sender, EventArgs e)
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
        
        private void DataBackEvent(int?PeriodID)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text=PeriodID.ToString();
            ctrlSubscriptionPeriodCard1.LoadSubscriptionPeriodInfo(PeriodID);
        }
        private void btnAddNewSubscriptionPeriod_Click(object sender, EventArgs e)
        {
            FRMAddUpdateSubscriptionPeriod fRM= new FRMAddUpdateSubscriptionPeriod();
            fRM.GetPeriodID += DataBackEvent;
            fRM.ShowDialog();
        }
    }
}
