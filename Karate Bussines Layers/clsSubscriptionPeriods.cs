using Karate_Data_Accesses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_Bussines_Layers
{
    public class clsSubscriptionPeriods
    {
        private enum enMode { AddNew=0,Update=1};
        private enMode _Mode = enMode.AddNew;
        public enum enIssueReason { FirstTime=1,Renew=2};
        public int? PeriodID {  get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Fees { get; set; }
        public bool IsPaid {  get; set; }
        public int? MemberID { get; set; }
        public int? PaymentID { get; set; }
        public enIssueReason IssueReason { get; set; }
        public bool IsActive {  get; set; }
        public clsMember MemberInfo { get; set; }
        public clsPayment PaymentInfo { set; get; }
        private string _IssueReasonText(enIssueReason issueReason)
        {
            switch (issueReason)
            {
                case enIssueReason.FirstTime:
                    return "First Time";
                case enIssueReason.Renew:
                    return "Renew";
                default:
                    return "First Time";
            }
        }
        public string IssueReasonText => _IssueReasonText(this.IssueReason);
        public clsSubscriptionPeriods()
        {
            this.PeriodID = null;
            this.StartDate = DateTime.MinValue;
            this.EndDate = DateTime.MaxValue;
            this.Fees = 0;
            this.IsPaid = false;
            this.MemberID = null;
            this.PaymentID = null;
            this.IssueReason = enIssueReason.FirstTime;
            this.IsActive = false;
            this._Mode = enMode.AddNew;
        }
        public clsSubscriptionPeriods(int? PeriodID,DateTime StartDate,DateTime EndDate,decimal Fees,
            bool IsPaid,int? MemberID,int? PaymentID,enIssueReason IssueReason, bool IsActive)
        {
            this.PeriodID = PeriodID;
            this.StartDate = StartDate;
            this.EndDate = EndDate;
            this.Fees = Fees;
            this.IsPaid = IsPaid;
            this.MemberID = MemberID;
            this.PaymentID = PaymentID;
            this.IssueReason = IssueReason;
            this.IsActive = IsActive;
            _Mode = enMode.Update;
        }
        public static clsSubscriptionPeriods Find(int? PeriodID)
        {
            DateTime StartDate= DateTime.MinValue,EndDate= DateTime.MaxValue;
            decimal Fees = 0;
            bool IsPaid = false, IsActive = false;
            int? MemberID= null,PaymentID = null;
            byte IssueReason = 0;
            bool isFound = clsSubscriptionPeriodsDataAccess.GetSubscriptionPeriodsInfoByID(PeriodID, ref StartDate, ref EndDate, ref Fees,
                ref IsPaid, ref MemberID, ref PaymentID, ref IssueReason, ref IsActive);
            if (isFound)
                return new clsSubscriptionPeriods(PeriodID, StartDate, EndDate, Fees,IsPaid, MemberID, PaymentID,(enIssueReason)IssueReason, IsActive);
            else
                return null;
        }
        public static clsSubscriptionPeriods FindByMemberID(int? MemberID)
        {
            DateTime StartDate = DateTime.MinValue, EndDate = DateTime.MaxValue;
            decimal Fees = 0;
            bool IsPaid = false, IsActive = false;
            int? PeriodID = null, PaymentID = null;
            byte IssueReason = 0;
            bool isFound = clsSubscriptionPeriodsDataAccess.GetSubscriptionPeriodsInfoByMemberID(MemberID, ref StartDate, ref EndDate,
                ref Fees,ref IsPaid, ref PeriodID, ref PaymentID, ref IssueReason, ref IsActive);
            if (isFound)
                return new clsSubscriptionPeriods(PeriodID, StartDate, EndDate, Fees, IsPaid, PeriodID, PaymentID, (enIssueReason)IssueReason, IsActive);
            else
                return null;
        }
        private bool _AddNewSubscriptionPeriod()
        {
            this.PeriodID = clsSubscriptionPeriodsDataAccess.AddNewSubscriptionPeriod(this.StartDate, this.EndDate, this.Fees, this.IsPaid,
                this.MemberID, this.PaymentID, (byte)this.IssueReason, this.IsActive);
            return this.PeriodID != null;
        }
        private bool _UpdateSubscriptionPeriod()
        {
            return clsSubscriptionPeriodsDataAccess.UpdateSubscriptionPeriod(this.PeriodID, this.StartDate, this.EndDate, this.Fees, this.IsPaid,
                this.MemberID, this.PaymentID, (byte)this.IssueReason, this.IsActive);
        }
        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewSubscriptionPeriod())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    {
                        return _UpdateSubscriptionPeriod();
                    }
            }
            return false;
        }
        public static bool DeleteSubscriptionPeriod(int? PeriodID)
        {
            return clsSubscriptionPeriodsDataAccess.DeleteSubscriptionPeriod(PeriodID);
        }
        public static DataTable GetAllSubscriptionPeriods()
        {
            return clsSubscriptionPeriodsDataAccess.GetAllSubscriptionPeriods();
        }
        public static DataTable GetAllSubscriptionPeriodForMember(int?MemberID)
        {
            return clsSubscriptionPeriodsDataAccess.GetAllSubscriptionPeriodsForMember(MemberID);
        }
        public static bool IsSubscriptionPeriodExists(int? PeriodID)
        {
           return clsSubscriptionPeriodsDataAccess.IsSubscriptionPeriodExist(PeriodID);
        }
        public int?Pay(decimal Amount)
        {
            clsPayment payment=new clsPayment();
            payment.MemberID = this.MemberID;
            payment.Amount = Amount;

            if(!payment.Save())
            {
                clsMember.SetActivity(this.MemberID, false);
                return null;
            }

            clsMember.SetActivity(this.MemberID, true);
            return payment.PaymentID;
        }
        public int? Renew(decimal Fees, DateTime StartDate, DateTime EndDate, bool IsPaid, ref int? PaymentID)
        {
            clsSubscriptionPeriods NewPeriod=new clsSubscriptionPeriods();
            NewPeriod.MemberID = this.MemberID;
            NewPeriod.StartDate = StartDate;
            NewPeriod.EndDate = EndDate;
            NewPeriod.Fees= Fees;
            NewPeriod.IsPaid= IsPaid;
            NewPeriod.IssueReason = enIssueReason.Renew;
            NewPeriod.IsActive = true;

            if(NewPeriod.IsPaid)
            {
                NewPeriod.PaymentID = NewPeriod.Pay(Fees);
                PaymentID = NewPeriod.PaymentID;
            }

            if (!NewPeriod.Save()) return null;

            return NewPeriod.PeriodID;
        }
        public bool DidPeriodExpire()
        {
            return (DateTime.Now > this.EndDate);
        }
        public static int? GetPeriodIDByPaymentID(int?PaymentID)
        {
            return clsSubscriptionPeriodsDataAccess.GetPeriodIDByPaymentID(PaymentID);
        }
        public static int Count()
        {
            return clsSubscriptionPeriodsDataAccess.CountAllSubscriptionPeriods();
        }
    }
}
