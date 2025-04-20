using Karate_Data_Accesses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_Bussines_Layers
{
    public class clsMember:clsPerson
    {
        private new enum enMode { AddNew=0,Update=1};
        private enMode _Mode = enMode.AddNew;
        public int? MemberID { get; set; }
        public string EmergencyContactInfo { set; get; }
        public int? LastBeltRankID { set; get; }
        public bool IsActive { set; get; }
        public clsBeltRank LastBeltRankInfo { set; get; }
        // public clsBeltRank NewBeltRankInfo=>clsBeltRank.Find(this.LastBeltRankID);
        private clsMember(int? PersonID, string Name, string Address,
            string Phone, string Email, DateTime DateOfBirth, enGender Gender,
            string ImagePath, int? MemberID, string EmergencyContactInfo,
            int? LastBeltRankID, bool IsActive)
        {
            base.PersonID= PersonID;
            base.Name= Name;
            base.Address= Address;
            base.Phone= Phone;
            base.Email= Email;
            base.DateOfBirth= DateOfBirth;
            base.Gender= Gender;
            base.ImagePath= ImagePath;

            this.MemberID = MemberID;
            this.EmergencyContactInfo = EmergencyContactInfo;
            this.LastBeltRankID = LastBeltRankID;
            this.IsActive = IsActive;
            this.LastBeltRankInfo = clsBeltRank.Find(LastBeltRankID);
            _Mode = enMode.Update;
        }
        public clsMember()
        {
            MemberID = null;
            EmergencyContactInfo = string .Empty;
            LastBeltRankID = null;
            IsActive = false;
            _Mode = enMode.AddNew;
        }
        public static clsMember Find(int? MemberID)
        {
            int? PersonID = null;
            string EmergencyContactInfo = string.Empty;
            int? LastBeltRankID = null;
            bool IsActive = false;
            bool IsFound = clsMemberDataAccess.GetMemberInfoByID(MemberID,ref PersonID,ref EmergencyContactInfo,ref LastBeltRankID,ref IsActive);
            if(IsFound)
            {
                clsPerson person=clsPerson.Find(PersonID);
                if(person==null) return null;

                return new clsMember(person.PersonID, person.Name, person.Address, person.Phone, person.Email, person.DateOfBirth, person.Gender,
                    person.ImagePath, MemberID, EmergencyContactInfo, LastBeltRankID, IsActive);
            }
            else
                return null;
        }
        public static clsMember FindByPersonID(int? PersonID)
        {
            int? MemberID = null;
            string EmergencyContactInfo = string.Empty;
            int? LastBeltRankID = null;
            bool IsActive = false;
            bool isFound = clsMemberDataAccess.GetMemberInfoByPersonID(PersonID, ref MemberID, ref EmergencyContactInfo, ref LastBeltRankID, ref IsActive);
            if (isFound)
            {
                clsPerson person = clsPerson.Find(PersonID);
                if (person == null) return null;

                return new clsMember(person.PersonID, person.Name, person.Address, person.Phone, person.Email, person.DateOfBirth, person.Gender,
                     person.ImagePath, MemberID, EmergencyContactInfo, LastBeltRankID, IsActive);
            }
            else
                return null;
        }
        private bool _AddNewMember()
        {
                this.MemberID = clsMemberDataAccess.AddNewMember(this.PersonID, this.EmergencyContactInfo, this.LastBeltRankID,
                    this.IsActive);
                return this.MemberID.HasValue;
        }
        private bool _UpdateMember()
        {
            return clsMemberDataAccess.UpdateMember(this.MemberID, this.PersonID, this.EmergencyContactInfo, 
                this.LastBeltRankID, this.IsActive);
        }
        public bool Save()
        {
            base.Mode = (clsPerson.enMode)_Mode;

            if(!base.Save())
                return false;

            switch(_Mode)
            {
                case enMode.AddNew:
                    {
                        if(_AddNewMember())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    {
                        return _UpdateMember();
                    }
            }
            return false;
        }
        private static int?_GetPersonIDByMemberID(int?MemberID)
        {
            return clsMemberDataAccess.GetPersonIDByMemberID(MemberID);
        }
        public static bool DeleteMember(int? MemberID)
        {
            int? PersonID = _GetPersonIDByMemberID(MemberID);

            if (!PersonID.HasValue)
                return false;

            if (!clsMemberDataAccess.DeleteMember(MemberID))
                return false;

            return clsPersonDataAccess.DeletePerson(PersonID);
        }
        public static DataTable GetAllMember()
        {
            return clsMemberDataAccess.GetAllMembers();
        }
        public static bool IsMemberExist(int? MemberID)
        {
            return clsMemberDataAccess.IsMemberExists(MemberID);
        }
        public static bool SetActivity(int?MemberID,bool IsActive)
        {
            return clsMemberDataAccess.SetActivity(MemberID, IsActive);
        }
        public bool SetActivity(bool IsActive)
        {
            return SetActivity(this.MemberID, IsActive);
        }
        public int? GetLastActivePeriodID()
        {
            return clsSubscriptionPeriodsDataAccess.GetLastActivePeriodIDForMember(this.MemberID);
        }
        public bool DoesHaveAnActivePeriodID()
        {
            return (GetLastActivePeriodID().HasValue);
        }
        public DataTable GetAllPayments()
        {
            return clsPayment.GetAllPaymentForMember(this.MemberID);
        }
        public DataTable GetAllBeltTest()
        {
            return clsBeltTests.GetAllBeltTestsForMember(this.MemberID);
        }
        public static int Count()
        {
            return clsMemberDataAccess.CountAllMembers();
        }
    }
}
