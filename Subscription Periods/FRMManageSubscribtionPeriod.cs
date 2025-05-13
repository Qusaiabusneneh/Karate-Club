using DevExpress.XtraEditors.Filtering;
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

namespace Karate.App.Subscription_Periods
{
    public partial class FRMManageSubscribtionPeriod : Form
    {
        DataTable _dtSubscriptionPeriod = clsSubscriptionPeriods.GetAllSubscriptionPeriods();
        private void _FillComboBox()
        {
            foreach(DataColumn column in _dtSubscriptionPeriod.Columns)
                cmbFilter.Items.Add(column.ColumnName);
            cmbFilter.SelectedIndex = 0;
        }
        public FRMManageSubscribtionPeriod()
        {
            InitializeComponent();
        }
        private void FRMManageSubscribtionPeriod_Load(object sender, EventArgs e)
        {
            _FillComboBox();
            DGVSubscriptionPeriod.DataSource = _dtSubscriptionPeriod;
            lblRecord.Text=DGVSubscriptionPeriod.Rows.Count.ToString();
            if (_dtSubscriptionPeriod.Rows.Count > 0)
            {
                DGVSubscriptionPeriod.Columns[0].HeaderText = "PeriodID";
                DGVSubscriptionPeriod.Columns[0].Width = 110;

                DGVSubscriptionPeriod.Columns[1].HeaderText = "MemberName";
                DGVSubscriptionPeriod.Columns[1].Width = 150;

                DGVSubscriptionPeriod.Columns[2].HeaderText = "Fees";
                DGVSubscriptionPeriod.Columns[2].Width = 150;

                DGVSubscriptionPeriod.Columns[3].HeaderText = "IsPaid";
                DGVSubscriptionPeriod.Columns[3].Width = 110;

                DGVSubscriptionPeriod.Columns[4].HeaderText = "StartDate";
                DGVSubscriptionPeriod.Columns[4].Width = 150;
                
                DGVSubscriptionPeriod.Columns[5].HeaderText = "EndDate";
                DGVSubscriptionPeriod.Columns[5].Width = 150;

                DGVSubscriptionPeriod.Columns[6].HeaderText = "SubscriptionDays";
                DGVSubscriptionPeriod.Columns[6].Width = 110;

                DGVSubscriptionPeriod.Columns[7].HeaderText = "PaymentID";
                DGVSubscriptionPeriod.Columns[7].Width = 110;

                DGVSubscriptionPeriod.Columns[8].HeaderText = "IsActive";
                DGVSubscriptionPeriod.Columns[8].Width = 100;
            }
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string Filtercolumn = "";
                switch(cmbFilter.Text)
            {
                case "PeriodID":
                    Filtercolumn = "PeriodID";
                    break;
                case "MemberName":
                    Filtercolumn = "MemberName";
                    break;
                case "Fees":
                    Filtercolumn = "Fees";
                    break;
                case "IsPaid":
                    Filtercolumn = "IsPaid";
                    break;
                case "StartDate":
                    Filtercolumn = "StartDate";
                    break;
                case "EndDate":
                    Filtercolumn = "EndDate";
                    break;
                case "SubscriptionDays":
                    Filtercolumn = "SubscriptionDays";
                    break;
                case "PaymentID":
                    Filtercolumn = "PaymentID";
                    break;
                case "IsActive":
                    Filtercolumn = "IsActive";
                    break;
            }

            if (txtFilter.Text.Trim() == "" || cmbFilter.Text == "None")
            {
                _dtSubscriptionPeriod.DefaultView.RowFilter = "";
                lblRecord.Text=_dtSubscriptionPeriod.Rows.Count.ToString();
                return;
            }

            if (Filtercolumn == "PeriodID")
                _dtSubscriptionPeriod.DefaultView.RowFilter = string.Format("[{0}] = {1}", Filtercolumn, txtFilter.Text.Trim());
            else
                _dtSubscriptionPeriod.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", Filtercolumn, txtFilter.Text.Trim());

        }
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible = (txtFilter.Text != "None");
            if(txtFilter.Visible)
            {
                txtFilter.Text = "";
                txtFilter.Focus();
            }
        }
        private void showPeriodHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? PeriodID = (int)DGVSubscriptionPeriod.CurrentRow.Cells[0].Value;
            clsSubscriptionPeriods _Period = clsSubscriptionPeriods.Find(PeriodID);
            FRMSubscriptionPeriodHistory frm = new FRMSubscriptionPeriodHistory(_Period.MemberID);
            frm.ShowDialog();
            FRMManageSubscribtionPeriod_Load(null, null);
        }
        private void showPeriodDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMSubscriptionPeriodCard frm = new FRMSubscriptionPeriodCard((int)DGVSubscriptionPeriod.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            FRMManageSubscribtionPeriod_Load(null, null);
        }
        private void addNewPeriodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMAddUpdateSubscriptionPeriod fRM = new FRMAddUpdateSubscriptionPeriod();
            fRM.ShowDialog();
            FRMManageSubscribtionPeriod_Load(null, null);
        }
        private void btnAddNewSubscriptionPeriod_Click(object sender, EventArgs e)
        {
            FRMAddUpdateSubscriptionPeriod frm = new FRMAddUpdateSubscriptionPeriod();
            frm.ShowDialog();
            FRMManageSubscribtionPeriod_Load(null, null);
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //clsSubscriptionPeriods _Period = clsSubscriptionPeriods.Find((int?)DGVSubscriptionPeriod.CurrentRow.Cells[0].Value);
            FRMAddUpdateSubscriptionPeriod frm = new FRMAddUpdateSubscriptionPeriod((int?)DGVSubscriptionPeriod.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            FRMManageSubscribtionPeriod_Load(null, null);
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this period?", "Confirm", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (clsSubscriptionPeriods.DeleteSubscriptionPeriod((int?)DGVSubscriptionPeriod.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Deleted Done Successfully", "Deleted",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    FRMManageSubscribtionPeriod_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Deleted Failed", "Failed",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                FRMManageSubscribtionPeriod_Load(null, null);
            }
        }
        private void payToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to pay for this period?", "Confirm", MessageBoxButtons.YesNo,
                  MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                clsSubscriptionPeriods Period = clsSubscriptionPeriods.Find((int?)DGVSubscriptionPeriod.CurrentRow.Cells[0].Value);
                if (Period == null)
                {
                    MessageBox.Show("Pay Failed", "Failed",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int? PaymentID = Period.Pay((decimal)DGVSubscriptionPeriod.CurrentRow.Cells["Fees"].Value);
                if(PaymentID.HasValue)
                {
                    Period.PaymentID = PaymentID;
                    Period.IsPaid = (PaymentID.HasValue);
                    if (Period.Save())
                    {
                        MessageBox.Show("Pay Done Successfully", "Deleted",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FRMManageSubscribtionPeriod_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Deleted Failed", "Failed",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
