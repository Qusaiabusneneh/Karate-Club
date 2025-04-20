using Karate_Data_Accesses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_Bussines_Layers
{
    public class clsBeltTests
    {
        private enum enMode { AddNew=0,Update=1};
        private enMode _Mode= enMode.AddNew;
        public int? TestID { set; get; }    
        public int? MemberID { set; get; }
        public int? RankID { set; get; }
        public bool Result { set; get; }    
        public DateTime Date { set; get; }
        public int? TestedByInstructorID { set; get; }
        public int? PaymentID { set; get; }
        public clsMember MemberInfo { set; get; }
        public clsInstructors InstructorInfo { set;get; }
        public clsBeltRank BeltRankInfo { set; get; }
        public clsPayment PaymentInfo { set; get; } 
        public clsBeltTests()
        {
            TestID = null;
            MemberID = null;
            RankID = null;
            Result = false;
            Date = DateTime.MinValue;
            TestedByInstructorID = null;
            PaymentID = null;
            _Mode = enMode.AddNew;
        }
        public clsBeltTests(int? TestID,int? MemberID,int? RankID,bool Result,DateTime Date,int? TestedByInstructorID,int? PaymentID)
        {
            this.TestID = TestID;
            this.MemberID = MemberID;
            this.RankID = RankID;
            this.Result = Result;
            this.Date = Date;
            this.TestedByInstructorID=TestedByInstructorID;
            this.PaymentID = PaymentID;
            this.MemberInfo = clsMember.Find(MemberID);
            this.InstructorInfo = clsInstructors.Find(TestedByInstructorID);
            this.BeltRankInfo=clsBeltRank.Find(RankID);
            this.PaymentInfo = clsPayment.Find(PaymentID);
            _Mode = enMode.Update;
        }
        public static clsBeltTests Find(int? TestID)
        {
            int? MemberID = null, TestedByInstructorID = null, RankID = null, PaymentID = null;
            bool Result = true;
            DateTime Date= DateTime.MinValue;
            bool isFound = clsBeltTestsDataAccess.GetBeltTestInfoByID(TestID, ref MemberID, ref RankID,ref Result, ref Date, 
                ref TestedByInstructorID, ref PaymentID);
            if (isFound)
            {
                return new clsBeltTests(TestID, MemberID, RankID, Result, Date, TestedByInstructorID, PaymentID);
            }
            else
                return null;
        }
        private bool _AddNewBeltTest()
        {
            this.TestID = clsBeltTestsDataAccess.AddNewBeltTest(this.MemberID, this.RankID, this.Result, this.Date,
                this.TestedByInstructorID, this.PaymentID);
            return (this.TestID.HasValue);
        }
        private bool _UpdateBeltTest()
        {
            return clsBeltTestsDataAccess.UpdateBeltTest(this.TestID, this.MemberID, this.RankID, this.Result, this.Date, 
                this.TestedByInstructorID, this.PaymentID);
        }
        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    {
                        if(_AddNewBeltTest())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    {
                        return _UpdateBeltTest();
                    }
            }
            return false;
        }
        public static bool DeleteBeltTest(int? TestID)
        {
            return clsBeltTestsDataAccess.DeleteBeltTest(TestID);
        }
        public static DataTable GetAllBeltTests()
        {
            return clsBeltTestsDataAccess.GetAllBeltTest();
        }
        public static bool IsBeltTestExist(int? TestID)
        {
            return clsBeltTestsDataAccess.IsBeltTestExist(TestID);
        }
        public static DataTable GetAllBeltTestsForMember(int?MemberID)
        {
            return clsBeltTestsDataAccess.GetAllBeltTestsForMember(MemberID);
        }
        public static int? GetTestIDByPaymentID(int?PaymentID)
        {
            return clsBeltTestsDataAccess.GetTestIDByPaymentID(PaymentID);
        }
        public int?Pay(decimal Amount)
        {
            clsPayment payment=new clsPayment();
            payment.MemberID = this.MemberID;
            payment.Amount = Amount;

            if (!payment.Save())
                return null;

            return payment.PaymentID;
        }

        public static int Count()
        {
            return clsBeltTestsDataAccess.CountAllBeltTest();
        }
    }
}
