using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karate_Data_Accesses;
namespace Karate_Bussines_Layers
{
    public class clsPerson
    {
        public enum enMode { AddNew=0,Update=1};
        public enMode Mode = enMode.AddNew;
        public enum enGender { Male=1,Female=0};
        public int? PersonID { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public DateTime DateOfBirth { set; get; }
        public enGender Gender { set; get; }
        public string ImagePath { set; get; }
        public string GenderName => _GetGenderName(this.Gender);
        private string _GetGenderName(enGender gender)
        {
            switch(gender)
            {
                case enGender.Male:
                    return "Male";
                   case enGender.Female:
                    return "Female";
                default:
                    return "Unknown";
            }
        }
            
        public clsPerson()
        {
            PersonID = null;
            Name = string.Empty;
            Address = string.Empty;
            Phone = string.Empty;
            Email = string.Empty;
            DateOfBirth = DateTime.Now;
            Gender = 0;
            ImagePath = string.Empty;
            Mode = enMode.AddNew;
        }
        public clsPerson(int? PersonID, string Name, string Address, string Phone,
            string Email, DateTime DateOfBirth, enGender Gender, string ImagePath)
        {
            this.PersonID = PersonID;
            this.Name = Name;
            this.Address = Address;
            this.Phone = Phone;
            this.Email = Email;
            this.DateOfBirth = DateOfBirth;
            this.Gender = Gender;
            this.ImagePath = ImagePath;
            Mode = enMode.Update;
        }
        public static clsPerson Find(int? PersonID)
        {
            string Name = string.Empty, Address = string.Empty, Phone = string.Empty, Email = string.Empty, ImagePath = string.Empty;
            DateTime DateOfBirth = DateTime.MinValue;
            byte Gender = 0;
            bool IsFound = clsPersonDataAccess.GetPersonInfoByPersonID(PersonID, ref Name, ref Address, ref Phone, ref Email, ref DateOfBirth,
                ref Gender, ref ImagePath);
            if (IsFound)
                return new clsPerson(PersonID, Name, Address, Phone, Email, DateOfBirth,(enGender)Gender, ImagePath);
            else
                return null;
        }
        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonDataAccess.AddNewPerson
                (this.Name, this.Address, this.Phone, this.Email, this.DateOfBirth, (byte)this.Gender, this.ImagePath);
            return (this.PersonID.HasValue);
        }
        private bool _UpdatePerson()
        {
            return clsPersonDataAccess.UpdatePerson
                (this.PersonID,this.Name, this.Address, this.Phone, this.Email, this.DateOfBirth,(byte)this.Gender, this.ImagePath);
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    {
                        if(_AddNewPerson())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    return _UpdatePerson();
            }
            return false;
        }
        public static bool DeletePerson(int? PersonID)
        {
            return clsPersonDataAccess.DeletePerson(PersonID);
        }
        public static DataTable GetAllPeople()
        {
            return clsPersonDataAccess.GetAllPeople();
        }
        public static bool IsPersonExist(int? PersonID)
        {
            return clsPersonDataAccess.IsPersonExist(PersonID);
        }
    }
}
