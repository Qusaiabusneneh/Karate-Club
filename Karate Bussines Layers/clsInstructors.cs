using Karate_Data_Accesses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_Bussines_Layers
{
    public class clsInstructors:clsPerson
    {
        private enum enMode { AddNew=0,Update=1};
        private enMode _Mode = enMode.AddNew;
        public int? InstructorID { set;get; }  
        public string Qualification { set; get; }
        public clsInstructors()
        {
            InstructorID = null;
            PersonID= null;
            Qualification = string.Empty;
            _Mode = enMode.AddNew;
        }
        public clsInstructors(int? PersonID, string Name, string Address,
            string Phone, string Email, DateTime DateOfBirth,
            enGender Gender, string ImagePath, int? InstructorID,string Qualification)
        {
            base.PersonID= PersonID;
            base.Name= Name;
            base.Address= Address;
            base.Phone= Phone;
            base.Email= Email;
            base.DateOfBirth= DateOfBirth;
            base.Gender = Gender;
            base.ImagePath= ImagePath;
            this.InstructorID = InstructorID;
            this.Qualification = Qualification;
            _Mode = enMode.Update;
        }
        public static clsInstructors Find(int? InstructorID)
        {
            int? PersonID = null;
            string Qualification = string.Empty;
            bool isFound = clsInstructorsDataAccess.GetInstructorInfoByID(InstructorID, ref PersonID, ref Qualification);
            if (isFound)
            {
                clsPerson Person = clsPerson.Find(PersonID);
                if (Person == null) 
                    return null;

                return new clsInstructors(Person.PersonID, Person.Name, Person.Address,
                    Person.Phone, Person.Email, Person.DateOfBirth, Person.Gender,
                    Person.ImagePath, InstructorID, Qualification);

            }
            else
                return null;
        }
        public static clsInstructors FindByPersonID(int? PersonID)
        {
            int? InstructorID = null;
            string Qualification = string.Empty;
            bool isFound = clsInstructorsDataAccess.GetInstructortInfoByPersonID(PersonID, ref InstructorID, ref Qualification);
            if (isFound)
            {
                clsInstructors instructor=clsInstructors.Find(InstructorID);
                if (instructor == null) return null;

                return new clsInstructors(instructor.PersonID, instructor.Name, instructor.Address,
                             instructor.Phone, instructor.Email, instructor.DateOfBirth, instructor.Gender,
                                instructor.ImagePath, InstructorID, Qualification);
            }
            else
                return null;
        }
        private bool _AddNewInstructor()
        {
            this.InstructorID = clsInstructorsDataAccess.AddNewInstructor(this.PersonID, this.Qualification);
            return this.InstructorID.HasValue;
        }
        private bool _UpdateInstructor()
        {
            return clsInstructorsDataAccess.UpdateInstructor(this.InstructorID, this.PersonID, this.Qualification);
        }
        public bool Save()
        {
            switch(_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewInstructor())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    {
                        return _UpdateInstructor();
                    }
            }
            return false;
        }
        public static bool DeleteInstructor(int? InstructorID)
        {
            return clsInstructorsDataAccess.DeleteInstructor(InstructorID); 
        }
        public static DataTable GetAllInstructor()
        {
            return clsInstructorsDataAccess.GetAllInstructor();
        }
        public static bool IsInstructorExist(int? InstructorID)
        {
            return clsInstructorsDataAccess.IsInstructorExist(InstructorID);
        }
        public static bool IsInstructorExistByPersonID(int? PersonID)
        {
            return clsInstructorsDataAccess.IsInstructorExistByPersonID(PersonID);
        }
        public static int Count()
        {
            return clsInstructorsDataAccess.CountAllInstructors();
        }
    }
}
