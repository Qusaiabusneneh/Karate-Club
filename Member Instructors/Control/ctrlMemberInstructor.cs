using Karate.App.Instructors;
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

namespace Karate.App.Member_Instructors
{
    public partial class ctrlMemberInstructor : UserControl
    {
        private int? _MemberInstructorID = null;

        private clsMemberInstructor _MemberInstructor;
        public int? MemberInstructorID => _MemberInstructorID;
        public clsMemberInstructor SelectedMemberInstrcutorInfo => _MemberInstructor;
        public void _ResetDefaultValue()
        {
            this._MemberInstructorID = null;
            this._MemberInstructor=null;
            ctrlInstructorInfo1._ResetInstructorInfo();
            ctrlFindMember1.ResetMemberInfo();
            
            lblAssignDate.Text = "[???]";
            lblMemberInstructorID.Text = "[???]";
        }
        private void _FillMemberInstructorInfo()
        {
            ctrlInstructorInfo1.LoadInstructorInfo(_MemberInstructor.InstructorID);
            ctrlFindMember1.LoadMemberInfo(_MemberInstructor.MemberID);
            lblAssignDate.Text=_MemberInstructor.AssignDate.ToString();
            lblMemberInstructorID.Text=_MemberInstructor.MemberInstructorID.ToString();
        }
        public void LoadMemberInstructorInfoByID(int ? MemberInstructorID)
        {
            _MemberInstructorID = MemberInstructorID;
            if(!this._MemberInstructorID.HasValue)
            {
                MessageBox.Show("There is no Members-Instructors with this ID", "Missing Member",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ResetDefaultValue();
                return;
            }

            _MemberInstructor = clsMemberInstructor.Find(MemberInstructorID);
            if (_MemberInstructor == null)
            {
                _ResetDefaultValue();
                MessageBox.Show("No MemberInstructor with MemberInstructorID = " + MemberInstructorID.ToString(), 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillMemberInstructorInfo();
        }
        public ctrlMemberInstructor()
        {
            InitializeComponent();
        }    
    }
}
