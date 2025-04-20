using Karate_Data_Accesses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_Bussines_Layers
{
    public class clsBeltRank
    {
        private enum enMode { AddNew=0,Update=1}
        private enMode _Mode = enMode.AddNew;
        public int? RankID { set;get; }    
        public string RankName { set;get; } 
        public decimal TestFees { set;get; }    
        public clsBeltRank()
        {
            RankID = null;
            RankName = string.Empty;
            TestFees = 0;
            _Mode= enMode.AddNew;
        }
        public clsBeltRank(int? RankID,string RankName,decimal TestFees)
        {
            this.RankID = RankID;
            this.RankName = RankName;
            this.TestFees = TestFees;
            _Mode = enMode.Update;
        }
        public static clsBeltRank Find(int? RankID)
        {
            string RankName = string.Empty;
            decimal TestFees = 0;
            bool isFound = clsBeltRankDataAccess.GetRankInfoByID(RankID, ref RankName, ref TestFees);
            if (isFound)
            {
                return new clsBeltRank(RankID, RankName, TestFees);
            }
            else
                return null;
        }
        public static clsBeltRank Find(string RankName)
        {
            int?  RankID =null;
            decimal TestFees = 0;
            bool isFound = clsBeltRankDataAccess.GetRankInfoByName(RankName, ref RankID, ref TestFees);
            if (isFound)
            {
                return new clsBeltRank(RankID, RankName, TestFees);
            }
            else
                return null;
        }
        private bool _AddNewBeltRank()
        {
            this.RankID = clsBeltRankDataAccess.AddNewBeltRank(this.RankName, this.TestFees);
            return this.RankID.HasValue;
        }
        private bool _UpdateBeltRank()
        {
            return clsBeltRankDataAccess.UpdateBeltRank(this.RankID, this.RankName, this.TestFees);
        }
        public bool Save()
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewBeltRank())
                        {
                            _Mode = enMode.Update;
                            return true;
                        }
                        else
                            return false;
                    }
                case enMode.Update:
                    {
                        return _UpdateBeltRank();
                    }
            }
            return false;
        }
        public static bool DeleteBeltRank(int RankID)
        {
           return  clsBeltRankDataAccess.DeleteBeltRank(RankID);
        }
        public static DataTable GetAllBeltRanks()
        {
            return clsBeltRankDataAccess.GetAllBeltRanks();
        }
        public static bool IsBeltRankExist(int? RankID)
        {
            return clsBeltRankDataAccess.IsBeltRankExists(RankID);
        }
    }
}
