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
    public partial class FRMSubscriptionPeriodCard : Form
    {
        public FRMSubscriptionPeriodCard(int?PeriodID)
        {
            InitializeComponent();
            ctrlSubscriptionPeriodCard1.LoadSubscriptionPeriodInfo(PeriodID);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
