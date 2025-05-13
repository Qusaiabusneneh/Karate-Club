using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karate.App.Payment
{
    public partial class FRMPaymentDetails : Form
    {
        private int?_PaymentID=null;
        public FRMPaymentDetails(int? PaymentID)
        {
            InitializeComponent();
            this._PaymentID = PaymentID;
        }
        private void FRMPaymentDetails_Load(object sender, EventArgs e)
        {
            ctrlMemberPayment1.LoadPaymentInfo(_PaymentID);
        }
    }
}
