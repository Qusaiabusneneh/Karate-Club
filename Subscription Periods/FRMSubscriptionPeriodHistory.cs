using DevExpress.XtraEditors.Filtering.Templates;
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
    public partial class FRMSubscriptionPeriodHistory : Form
    {
        private DataTable _dtSubscriptionPeriodForMember;
        public FRMSubscriptionPeriodHistory(int? MemberID)
        {
            InitializeComponent();
            ctrlFindMember1.LoadMemberInfo(MemberID);
            _LoadSubscriptionPeriodInfo(MemberID);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _LoadSubscriptionPeriodInfo(int? MemberID)
        {
            _dtSubscriptionPeriodForMember = clsSubscriptionPeriods.GetAllSubscriptionPeriodForMember(MemberID);
            dgvSubscriptionPeriodHistory.DataSource = _dtSubscriptionPeriodForMember;
            lblRecord.Text = dgvSubscriptionPeriodHistory.Rows.Count.ToString();

            if (dgvSubscriptionPeriodHistory.Rows.Count > 0)
            {
                dgvSubscriptionPeriodHistory.Columns[0].HeaderText = "PeriodID";
                dgvSubscriptionPeriodHistory.Columns[0].Width = 110;

                dgvSubscriptionPeriodHistory.Columns[1].HeaderText = "MemberName";
                dgvSubscriptionPeriodHistory.Columns[1].Width = 150;

                dgvSubscriptionPeriodHistory.Columns[2].HeaderText = "Fees";
                dgvSubscriptionPeriodHistory.Columns[2].Width = 110;

                dgvSubscriptionPeriodHistory.Columns[3].HeaderText = "IsPaid";
                dgvSubscriptionPeriodHistory.Columns[3].Width = 150;

                dgvSubscriptionPeriodHistory.Columns[4].HeaderText = "StartDate";
                dgvSubscriptionPeriodHistory.Columns[4].Width = 150;

                dgvSubscriptionPeriodHistory.Columns[5].HeaderText = "EndDate";
                dgvSubscriptionPeriodHistory.Columns[5].Width = 150;

                dgvSubscriptionPeriodHistory.Columns[6].HeaderText = "SubscriptionDays";
                dgvSubscriptionPeriodHistory.Columns[6].Width = 110;

                dgvSubscriptionPeriodHistory.Columns[7].HeaderText = "PaymentID";
                dgvSubscriptionPeriodHistory.Columns[7].Width = 110;

                dgvSubscriptionPeriodHistory.Columns[8].HeaderText = "IsActive";
                dgvSubscriptionPeriodHistory.Columns[8].Width = 110;

            }
        }
        private void FRMSubscriptionPeriodHistory_Load(object sender, EventArgs e)
        {

        }
    }
}
