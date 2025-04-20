using Karate_Data_Accesses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_Bussines_Layers
{
    public class clsMemberInstructor
    {
        private enum enMode { AddNew=0,Update=1};
        private enMode _Mode = enMode.AddNew;
        public int? MemberInstructorID { set; get; }
        public int? MemberID { set; get; }
        public int? InstructorID { set; get; }
        public DateTime AssignDate { set; get; }
        public clsMember MemberInfo { set; get; }
        public clsInstructors InstructorInfo { set; get; }
        public clsMemberInstructor()
        {
            MemberInstructorID = null;
            InstructorID = null;
            MemberID= null;
            AssignDate = DateTime.Now;
            _Mode = enMode.AddNew;
        }
        public clsMemberInstructor(int? MemberInstructorID,int? MemberID,int? InstructorID,DateTime AssignDate)
        {
            this.MemberInstructorID = MemberInstructorID;
            this.MemberID = MemberID;
            this.InstructorID = InstructorID;
            this.AssignDate = AssignDate;
            this.MemberInfo=clsMember.Find(MemberID);
            this.InstructorInfo = clsInstructors.Find(InstructorID);
            _Mode = enMode.Update;
        }
        public static clsMemberInstructor Find(int? MemberInstructorID)
        {
            int? MemberID = null, InstructorID = null;
            DateTime AssignDate = DateTime.Now;
            bool isFound = clsMemberInstructorDataAccess.GetMemberInstructorInfoByID(MemberInstructorID, ref MemberID, ref InstructorID, ref AssignDate);
            if (isFound)
            {
                return new clsMemberInstructor(MemberInstructorID, MemberID, InstructorID, AssignDate);
            }
            else
                return null;
        }
        public static clsMemberInstructor FindByMemberID(int? MemberID)
        {
            int? MemberInstructorID = null, InstructorID = null;
            DateTime AssignDate = DateTime.Now;
            bool isFound = clsMemberInstructorDataAccess.GetMemberInstructorInfoByMemberID(MemberID, ref MemberInstructorID, ref InstructorID, ref AssignDate);
            if (isFound)
            {
                return new clsMemberInstructor(MemberInstructorID, MemberID, InstructorID, AssignDate);
            }
            else
                return null;
        }
        public static clsMemberInstructor FindByInstructorID(int? InstructorID)
        {
            int? MemberID = null, MemberInstructorID = null;
            DateTime AssignDate = DateTime.Now;
            bool isFound = clsMemberInstructorDataAccess.GetMemberInstructorInfoByInstructorID(InstructorID, ref MemberID, ref MemberInstructorID, ref AssignDate);
            if (isFound)
            {
                return new clsMemberInstructor(MemberInstructorID, MemberID, InstructorID, AssignDate);
            }
            else
                return null;
        }
        private bool _AddNewMemberInstructor()
        {
            this.MemberInstructorID = clsMemberInstructorDataAccess.AddNewMemberInstructor(this.MemberID, this.InstructorID, this.AssignDate);
            return this.MemberInstructorID.HasValue;
        }
        private bool _UpdateMemberInstructor()
        {
            return clsMemberInstructorDataAccess.UpdateMemberInstructor(this.MemberInstructorID, this.MemberID, this.InstructorID, this.AssignDate);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if(_AddNewMemberInstructor())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                    case enMode.Update:
                    {
                        return _UpdateMemberInstructor();
                    }
            }
            return false;
        }
        public static DataTable GetAllMemberInstructor()
        {
            return clsMemberInstructorDataAccess.GetAllMemberInstructor();
        }
        public static bool IsMemberInstructorExist(int? MemberInstructorID)
        {
            return clsMemberInstructorDataAccess.IsMemberInstructorExist(MemberInstructorID);
        }
        public static bool IsMemberInstructorExistByInstructorID(int? InstructorID)
        {
            return clsMemberInstructorDataAccess.IsMemberInstructorExistByInstructorID(InstructorID);
        }
        public static bool IsMemberInstructorExistByMemberID(int? MemberID)
        {
            return clsMemberInstructorDataAccess.IsMemberInstructorExistByMemberID(MemberID);
        }
        public static bool DeleteMemberInstructor(int? MemberInstructorID)
        {
            return clsMemberInstructorDataAccess.DeleteMemberInstructor(MemberInstructorID);
        }

    }
}
