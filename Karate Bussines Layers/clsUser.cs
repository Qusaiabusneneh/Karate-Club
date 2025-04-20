using Karate_Data_Accesses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_Bussines_Layers
{
    public class clsUser:clsPerson
    {
        private enum enMode { AddNew=0,Update=1}
        public enum enPermission
        {
            eAll=-1,eMangeMembers=1,eManageUsers=2,eManageInstructors=4,
            eManageInstructorMembers=8,eManageSubscriptions=16,eManageBeltRanks=32,eManageBeltTests=64,eManagePayments=128
        };
        private enMode Mode = enMode.AddNew;
        private enPermission EnPermission;
        public int? UserID;
        public string Username { set; get; }
        public string Password { set; get; }
        public int Permissions { set; get; }
        public bool IsActive { set;get; }
        public clsUser()
        {
            this.UserID = null;
            this.PersonID = null;
            this.Username = string.Empty;
            this.Password = string.Empty;
            this.Permissions = -1;
            this.IsActive = false;
            Mode = enMode.AddNew;
        }
        public clsUser(int? PersonID, string Name, string Address,
            string Phone, string Email, DateTime DateOfBirth, enGender Gender,
            string ImagePath, int? UserID, string Username, string Password,
            int Permissions, bool IsActive)
        {
            base.PersonID= PersonID;
            base.Name= Name;
            base.Address= Address;
            base.Phone= Phone;
            base.Email= Email;
            base.DateOfBirth= DateOfBirth;
            base.Gender= Gender;
            base.ImagePath= ImagePath;

            this.UserID = UserID;
            this.Username= Username;
            this.Password = Password;
            this.Permissions = Permissions;
            this.IsActive = IsActive;

            Mode = enMode.Update;
        }
        public static clsUser FindByUserID(int? UserID)
        {
            int? PersonID = null;
            int Permissons = -1;
            string Username = string.Empty, Password = string.Empty;
            bool IsActive = false;
            bool isFound = clsUserDataAccess.GetUserInfoByUserID(UserID,ref PersonID,ref Username,ref Password, ref Permissons, ref IsActive);
            if (isFound)
            {
                clsPerson person = clsPerson.Find(PersonID);
                if (person == null) return null;

                return new clsUser(person.PersonID, person.Name, person.Address, person.Phone, person.Email, person.DateOfBirth, person.Gender,
                 person.ImagePath, UserID, Username, Password, Permissons, IsActive);
            }   
            else
                return null;
        }
        public static clsUser FindUserByUsernamePassword(string Username,string Password)
        {
            int? PersonID = null,UserID=null;
            int Permissons = -1;
            bool IsActive = false;
            bool isFound = clsUserDataAccess.GetUserInfoByUsernameAndPassword(Username, Password, ref PersonID, ref UserID,
                ref Permissons, ref IsActive);
            if (isFound)
            {
                clsPerson person = clsPerson.Find(PersonID);
                if (person == null) return null;

                return new clsUser(person.PersonID, person.Name, person.Address, person.Phone, person.Email, person.DateOfBirth, person.Gender,
                    person.ImagePath, UserID, Username, Password, Permissons, IsActive);
            }
            else
                return null;
        }
        public static clsUser FindByPersonID(int PersonID)
        {
            int? UserID = -1;
            int Permissions = -1;
            string Username=string.Empty, Password = string.Empty;
            bool IsActive = false;
            bool isFound = clsUserDataAccess.GetUserInfoByPersonID(PersonID, ref UserID, ref Username, ref Password,
                ref Permissions, ref IsActive);
            if (isFound)
            {
                clsPerson person = clsPerson.Find(PersonID);
                if (person != null) return null;

                return new clsUser(person.PersonID, person.Name, person.Address, person.Phone, person.Email, person.DateOfBirth, person.Gender,
                  person.ImagePath, UserID, Username, Password, Permissions, IsActive);
            }
            else
                return null;
        }
        private bool _AddNewUser()
        {
            this.UserID = clsUserDataAccess.AddNewUser(this.PersonID, this.Username, this.Password, this.Permissions, this.IsActive);
            return (this.UserID.HasValue);
        }
        private bool _UpdateUser()
        {
            return clsUserDataAccess.UpdateUser
            (this.UserID,this.PersonID, this.Username, this.Password, this.Permissions, this.IsActive);
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewUser())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    return _UpdateUser();
            }
            return false;
        }
        public static bool DeleteUser(int? UserID)
        {
            return clsUserDataAccess.DeleteUser(UserID);
        }
        public static DataTable GetAllUsers()
        {
            return clsUserDataAccess.GetAllUsers();
        }
        public static bool IsUserExistByUsername(string Username)
        {
            return clsUserDataAccess.IsUserExistByUsername(Username);
        }
        public static bool IsUserExistByUsernameAndPassword(string Username,string Password)
        {
            return clsUserDataAccess.IsUserExistByUsernameAndPassword(Username, Password);
        }
        public static bool IsUserExistsByPersonID(int? PersonID)
        {
            return clsUserDataAccess.IsUserExistByPersonID(PersonID);
        }

        public static int Count()
        {
            return clsUserDataAccess.CountAllUsers();
        }
    }
}
