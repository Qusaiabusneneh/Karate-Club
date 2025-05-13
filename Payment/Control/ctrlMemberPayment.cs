using Karate.App.Properties;
using Karate_Bussines_Layers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karate.App.Payment.Control
{
    public partial class ctrlMemberPayment : UserControl
    {
        private int? _PaymetID = null;
        private clsPayment _Payment;
        public int? PaymentID => _PaymetID;
        public clsPayment Payment => _Payment;
        public void ResetDefaultValues()
        {
            this._PaymetID = null;
            this._Payment = null;
            lblAmount.Text = "[????]";
            lblGendor.Text = "[????]";
            lblMemberID.Text = "[????]";
            lblName.Text = "[????]";
            lblPaymentDate.Text = "[????]";
            lblPaymentFor.Text = "[????]";
            lblPaymentID.Text = "[????]";
            llEditMemberInfo.Visible = false;
        }
        private void _LoadMemberImage()
        {
            if (_Payment.MemberInfo.ImagePath != null)
            {
                if (File.Exists(_Payment.MemberInfo.ImagePath))
                    pbImage.ImageLocation=_Payment.MemberInfo.ImagePath;
                else
                    MessageBox.Show("Could not find this image: = " + _Payment.MemberInfo.ImagePath,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (_Payment.MemberInfo.Gender == clsPerson.enGender.Male)
                {
                    pbImage.Image = Resources.karate__1_;
                }
                else
                    pbImage.Image = Resources.martial_arts__1_;
            }
        }
        private void _HandlePaymentFor()
        {
            switch(_Payment.PaymentFor)
            {
                case clsPayment.enPaymentFor.enSubscriptionPeriod:
                    {
                        lblPaymentFor.Text = "Subscription Period";
                        break;
                    }
                case clsPayment.enPaymentFor.enBeltTest:
                    {
                        lblPaymentFor.Text = "Belt Test";
                        break;
                    }
            }
        }
        private void _FillPaymentInfo()
        {
            lblPaymentID.Text=_Payment.PaymentID.ToString();
            lblPaymentDate.Text=_Payment.Date.ToString();
            lblName.Text = _Payment.MemberInfo.Name;
            lblMemberID.Text=_Payment.MemberID.ToString();
            lblGendor.Text = _Payment.MemberInfo.GenderName;
            lblAmount.Text=_Payment.Amount.ToString();
            _HandlePaymentFor();
            _LoadMemberImage();
            llEditMemberInfo.Visible = true;


        }
        public void LoadPaymentInfo(int?PaymentID)
        {
            _PaymetID = PaymentID;
            if(!_PaymetID.HasValue)
            {
                MessageBox.Show("There is no payment with this ID", "Missing Payment",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetDefaultValues();
                return;

            }
            _Payment = clsPayment.Find(_PaymetID);
            if (_Payment == null)
            {
                MessageBox.Show($"There is no payment with id = {PaymentID}", "Missing Payment",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetDefaultValues();
                return;
            }
            _FillPaymentInfo();
        }
        public ctrlMemberPayment()
        {
            InitializeComponent();
        }
    }
}
