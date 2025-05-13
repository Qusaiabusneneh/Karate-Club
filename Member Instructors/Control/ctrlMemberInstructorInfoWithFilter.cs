using Karate_Bussines_Layers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Karate.App.Instructors.ctrlFindIndtructorWithFilter;

namespace Karate.App.Member_Instructors.Control
{
    public partial class ctrlMemberInstructorInfoWithFilter : UserControl
    {
        public Action<int?> SendMemberID;
        public Action<int?> SendInstructorID;

        private int? _SelectedMemberID = null;
        private int? _SelectedInstructorID = null;
        public int? SelectedMemberID => ctrlFindMemberWithFilter1.MemberID;
        public int? SelectedInstructorID => ctrlFindIndtructorWithFilter1.InstructorID;
        public clsMember SelectedMemberInfo => ctrlFindMemberWithFilter1.SelectedMemberInfo;
        public clsInstructors SelectedInstructorInfo => ctrlFindIndtructorWithFilter1.SelectedInstructorInfo;
        
        private bool _FilterEnableMember = true;
        public bool FilterEnableMember
        {
            get=> _FilterEnableMember;
            set
            {
                _FilterEnableMember= value;
                ctrlFindMemberWithFilter1.FilterEnable = value;
            }
        }

        private bool _FilterEnableInstructor = true;
        public bool FilterEnableInstructor
        {
            get=> _FilterEnableInstructor;
            set
            {
                _FilterEnableInstructor= value;
                ctrlFindIndtructorWithFilter1.FilterEnable= value;
            }
        }
        private bool _IsMemberCorrect()
        {
            if(!_SelectedMemberID.HasValue)
            {
                tpMemberInstructor.SelectedTab = tpSelectMember;
                MessageBox.Show("You have to select a member first!", "Error",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(!ctrlFindMemberWithFilter1.SelectedMemberInfo.IsActive)
            {
                tpMemberInstructor.SelectedTab= tpSelectMember;
                MessageBox.Show("Selected Member is Not Active, choose an active member."
                    , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public void LoadMemberInfo(int?MemberID)
        {
            ctrlFindMemberWithFilter1.LoadMemberInfo(MemberID);
        }
        public void LoadInstructorInfo(int?InstructorID)
        {
            ctrlFindIndtructorWithFilter1.LoadInstructorInfo(InstructorID);
        }
        public ctrlMemberInstructorInfoWithFilter()
        {
            InitializeComponent();
        }
        private void ctrlFindMemberWithFilter1_OnMemberSelected(object sender, Members.Control.ctrlFindMemberWithFilter.MemberSelectedEventArgs e)
        {
            _SelectedMemberID=e.MemberID;
            if(!_SelectedMemberID.HasValue)
            {
                btnNext.Enabled = false;
                SendMemberID?.Invoke(null);
                return;
            }

            //if(ctrlFindMemberWithFilter1.SelectedMemberInfo.IsActive)
            //{
            //    MessageBox.Show("Selected Member is Not Active, choose an active member.",
            //            "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    btnNext.Enabled = false;
            //    return;
            //}

            btnNext.Enabled = true;
            SendMemberID?.Invoke(ctrlFindMemberWithFilter1.MemberID);
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if(_IsMemberCorrect())
            {
                tpMemberInstructor.SelectedTab = tpSelectInstructor;
                ctrlFindIndtructorWithFilter1.FilterFocus();
            }
        }
        private void tpMemberInstructor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ctrlFindIndtructorWithFilter1.SelectedInstructorInfo != null &&
                ctrlFindMemberWithFilter1.SelectedMemberInfo.IsActive)
                return;

            TabPage selectedTabPage = tpMemberInstructor.SelectedTab;

            if(selectedTabPage==tpSelectInstructor)
            {
                tpMemberInstructor.SelectedTab = tpSelectMember;
                if(_IsMemberCorrect())
                {
                    ctrlFindIndtructorWithFilter1.FilterFocus();
                    tpMemberInstructor.SelectedTab = tpSelectInstructor;
                }
            }
        }
        private void ctrlFindIndtructorWithFilter1_OnInstructorSelected_1(object sender, InstructorSelectedEventArgs e)
        {
            _SelectedInstructorID = e.InstructorID;
            if(!_SelectedInstructorID.HasValue)
            {
                SendInstructorID?.Invoke(null);
                return;
            }
            SendInstructorID?.Invoke(ctrlFindIndtructorWithFilter1.InstructorID);
        }
    }
}
