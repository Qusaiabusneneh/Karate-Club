using Karate_Data_Accesses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_Bussines_Layers
{
    public class clsPayment
    {
        private enum enMode { AddNew=0, Update=1}
        private enMode _Mode = enMode.AddNew; 
        public enum enPaymentFor { enSubscriptionPeriod,enBeltTest};
        public enPaymentFor PaymentFor = enPaymentFor.enSubscriptionPeriod;
        public int? PaymentID { set; get; }
        public decimal Amount { set; get; }
        public DateTime Date {  set; get; }
        public int? MemberID { set; get; }  
        public clsMember MemberInfo { set; get; }
        private int? _TempID = null;
        public int? PaymentForID
        {
            get
            {
                if ((_TempID = clsBeltTests.GetTestIDByPaymentID(PaymentID)).HasValue)
                {
                    PaymentFor = enPaymentFor.enBeltTest;
                    return _TempID;
                }
                if ((_TempID = clsSubscriptionPeriods.GetPeriodIDByPaymentID(PaymentID)).HasValue)
                {
                    PaymentFor = enPaymentFor.enSubscriptionPeriod;
                    return _TempID;
                }
                return null;
            }
        }
        public clsPayment()
        {
            PaymentID = null;
            Amount = 0;
            Date = DateTime.Now;
            MemberID = null;
            _Mode = enMode.AddNew;
        }
        public clsPayment(int? PaymentID,decimal Amount,DateTime Date,int? MemberID)
        {
            this.PaymentID = PaymentID;
            this.Amount = Amount;
            this.Date = Date;
            this.MemberID = MemberID;
            this.MemberInfo=clsMember.Find(MemberID);
            _Mode = enMode.Update;
        }
        public static clsPayment Find(int? PaymentID)
        {
            decimal Amount = 0;
            DateTime Date= DateTime.Now;
            int? MemberID = null;
            bool isFound = clsPaymentDataAccess.GetPaymentInfoByID(PaymentID,ref Amount,ref Date,ref MemberID);
            if (isFound)
            {
                return new clsPayment(PaymentID, Amount, Date, MemberID);
            }
            else
                return null;
        }
        private bool _AddNewPayment()
        {
            this.PaymentID = clsPaymentDataAccess.AddNewPayment(this.Amount, this.Date, this.MemberID);
            return this.PaymentID.HasValue;
        }
        private bool _UpdatePayment()
        {
            return clsPaymentDataAccess.UpdatePayment(this.PaymentID, this.Amount, this.Date, this.MemberID);
        }
        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewPayment())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    {
                        return _UpdatePayment();
                    }
            }
            return false;
        }
        public static bool DeletePayment(int? PaymentID)
        {
            return clsPaymentDataAccess.DeletePayment(PaymentID);
        }
        public static DataTable GetAllPayment()
        {
            return clsPaymentDataAccess.GetAllPayment();
        }
        public static bool IsPaymentExist(int? PaymentID)
        {
            return clsPaymentDataAccess.IsPaymentExist(PaymentID);
        }
        public static DataTable GetAllPaymentForMember(int?MemberID)
        {
            return clsPaymentDataAccess.GetAllPaymentsForMember(MemberID);
        }

        public static int Count()
        {
            return clsPaymentDataAccess.CountAllPayments();
        }
    }
}
