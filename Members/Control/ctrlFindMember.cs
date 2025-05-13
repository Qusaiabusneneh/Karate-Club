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

namespace Karate.App.Members
{
    public partial class ctrlFindMember : UserControl
    {
        private clsMember _Member;
        private int? _MemberID = null;
        public int? MemberID => _MemberID;
        public clsMember SelectedMemberInfo => _Member;
        public void ResetMemberInfo()
        {
            this._MemberID = null;
            this._Member = null;
            lblMemberID.Text = "[???]";
            lblName.Text= "[???]"; 
            lblEmergencyContact.Text= "[???]";
            lblAddress.Text= "[???]";
            lblEmail.Text= "[???]";
            lblBletRank.Text= "[???]";
            lblDateOfBirth.Text= "[???]";
            lblGendor.Text= "[???]";
            lblPhone.Text= "[???]";
            pbImage.Image = Resources.karate__1_;
            pbGendor.Image = Resources.karate__1_;
        }
        private void _LoadMemberImage()
        {
            if (_Member.Gender == 0)
                pbImage.Image = Resources.martial_arts__1_;
            else
                pbImage.Image = Resources.karate__1_;
            string ImagePath = _Member.ImagePath;
            if(ImagePath!="")
            {
                if (File.Exists(ImagePath))
                    pbImage.ImageLocation = ImagePath;
                else
                    MessageBox.Show("Could not find this image = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void _FillMemberInfo()
        {
            llEditMemberInfo.Enabled = true;
            _MemberID = _Member.MemberID;
            lblMemberID.Text=_Member.MemberID.ToString();
            lblAddress.Text = _Member.Address;
            lblEmail.Text = _Member.Email;
            lblAddress.Text= _Member.Address;
            lblDateOfBirth.Text = _Member.DateOfBirth.ToShortDateString();
            lblEmergencyContact.Text = _Member.EmergencyContactInfo;
            lblName.Text = _Member.Name;
            lblPhone.Text = _Member.Phone;
            lblBletRank.Text = clsBeltRank.Find(_Member.LastBeltRankID).RankName;
            lblGendor.Text = _Member.Gender == clsPerson.enGender.Male ? "Male" : "Female";
            lblIsActive.Text = _Member.IsActive ? "Yes" : "No";
            
            _LoadMemberImage();
        }
        public void LoadMemberInfo(int? MemberID)
        {
            this._MemberID= MemberID;
            if(!_MemberID.HasValue)
            {
                MessageBox.Show("There is no member with this ID", "Missing Member",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetMemberInfo();
                return;
            }

            _Member = clsMember.Find(MemberID);
            if (_Member == null)  
            {
                ResetMemberInfo();
                MessageBox.Show("No Member with Member ID = " + MemberID.ToString(), "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            _FillMemberInfo();
        }
        //public void LoadMemberInfoByPersonID(int? PersonID)
        //{
        //    this._Member.PersonID = PersonID;
        //    if(!_Member.PersonID.HasValue)
        //    {
        //        MessageBox.Show("There is no member with this ID", "Missing Member",
        //                MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        ResetMemberInfo();
        //        return;
        //    }

        //    _Member = clsMember.FindByPersonID(PersonID);
        //    if (_Member == null)
        //    {
        //        ResetMemberInfo();
        //        MessageBox.Show("No Person with PersonID ID = " + PersonID.ToString(), "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
        //        return;
        //    }
        //    _FillMemberInfo();
        //}
        public ctrlFindMember()
        {
            InitializeComponent();
        }
        private void llEditMemberInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FRMAddNewMember frm = new FRMAddNewMember(_MemberID);
            frm.ShowDialog();
            LoadMemberInfo(_MemberID);
        }
    }
}
