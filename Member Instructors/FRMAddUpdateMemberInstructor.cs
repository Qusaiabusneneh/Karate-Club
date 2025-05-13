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
    public partial class FRMAddUpdateMemberInstructor : Form
    {
        public enum enMode { enAddNew,enUpdate};
        private enMode _Mode;
        private int? _MemberInstructorID = null;
        private int?_SelectedMemberID = null;
        private int? _SelectedInstructorID = null;
        public Action<int?> GetMemberInstructorID;
        private clsMemberInstructor _MemberInstructor;
        private void _RefreshDefaultValues()
        {
            if(_Mode==enMode.enAddNew)
            {
                lblTitle.Text = "Add New Member Instructor";
                this.Text = "Add New Member Instructor";
                _MemberInstructor= new clsMemberInstructor();
            }
            else
            {
                lblTitle.Text = "Update Member Instructor";
                this.Text = "Update Member Instructor";
            }
            dateTimePicker1.Value= DateTime.Now;
        }
        private void _LoadData()
        {
            _MemberInstructor = clsMemberInstructor.Find(_MemberInstructorID);
            if (_MemberInstructor == null)
            {
                MessageBox.Show("No MemberInstructor with ID = " + _MemberInstructorID, "MemberInstructor not found",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            lblMemberInstructorID.Text=_MemberInstructor.MemberInstructorID.ToString();
            ctrlMemberInstructorInfoWithFilter1.LoadMemberInfo(_MemberInstructor.MemberID);
            ctrlMemberInstructorInfoWithFilter1.LoadInstructorInfo(_MemberInstructor.InstructorID);

            if(_MemberInstructor.AssignDate<DateTime.Now)
                dateTimePicker1.Value= DateTime.Now;
            else
            dateTimePicker1.Value = _MemberInstructor.AssignDate;

            btnSaveeee.Enabled = true;

            _SelectedMemberID = ctrlMemberInstructorInfoWithFilter1.SelectedMemberID;
            _SelectedInstructorID = ctrlMemberInstructorInfoWithFilter1.SelectedInstructorID;
        }
        public FRMAddUpdateMemberInstructor()
        {
            InitializeComponent();
            _Mode = enMode.enAddNew;
        }
        public FRMAddUpdateMemberInstructor(int?MemberInstructorID)
        {
            InitializeComponent();
            this._MemberInstructorID = MemberInstructorID;
            this._Mode = enMode.enUpdate;
        }
        //private bool _IsInstructorTrainingThisMember()
        //{
        //}
        private void FRMAddUpdateMemberInstructor_Load(object sender, EventArgs e)
        {
            _RefreshDefaultValues();
            if (_Mode == enMode.enUpdate)
                _LoadData();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void btnSaveeee_Click(object sender, EventArgs e)
        {
            if (!_SelectedMemberID.HasValue || !_SelectedInstructorID.HasValue)
                return;

            _MemberInstructor.MemberID = _SelectedMemberID;
            _MemberInstructor.InstructorID = _SelectedInstructorID;
            _MemberInstructor.AssignDate = dateTimePicker1.Value;
            if (_MemberInstructor.Save())
            {
                MessageBox.Show($"Instructor with ID: [{_MemberInstructor.InstructorID}] " +
                         $"is assigned to Member with ID: [{_MemberInstructor.MemberID}] at:" +
                             $" [{_MemberInstructor.AssignDate.ToShortDateString()}]",
                                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                lblMemberInstructorID.Text = _MemberInstructor.MemberInstructorID.ToString();
                this._Mode = enMode.enUpdate;
                lblTitle.Text = "Update Member-Instructors";
                this.Text = lblTitle.Text;
                btnSaveeee.Enabled = false;
                ctrlMemberInstructorInfoWithFilter1.FilterEnableMember = false;
                ctrlMemberInstructorInfoWithFilter1.FilterEnableInstructor = false;
                GetMemberInstructorID?.Invoke(_MemberInstructor.MemberInstructorID);
            }
        }
    }
}
