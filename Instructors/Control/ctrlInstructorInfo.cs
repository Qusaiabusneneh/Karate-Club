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
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace Karate.App.Instructors
{
    public partial class ctrlInstructorInfo : UserControl
    {
        private int? _InstructorID = null;
        private clsInstructors _Instructor;
        public int? InstructorID
        {
            get => _InstructorID;
        }
        public clsInstructors SelectedInstructorInfo
        {
            get => _Instructor;
        }
        public void _ResetInstructorInfo()
        {
            this._InstructorID = null;
            this._Instructor = null;
            ctrlPersonCard1._RestfulDefaultValue();
            lblInstructorID.Text = "[???]";
            lblQualification.Text = "[???]";
        }
        private void _FillInstructorInfo()
        {
            ctrlPersonCard1.LoadPersonInfo(_Instructor.PersonID);
            lblQualification.Text = _Instructor.Qualification;
            lblInstructorID.Text = _Instructor.InstructorID.ToString();
        }
        public void LoadInstructorInfo(int? InstructorID)
        {
            this._InstructorID=InstructorID;
            if (!_InstructorID.HasValue)
            {
                MessageBox.Show("There is no instructor with this ID", "Missing Member",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ResetInstructorInfo();
            }

            _Instructor = clsInstructors.Find(this._InstructorID);
            if (_Instructor == null)
            {
                _ResetInstructorInfo();
                MessageBox.Show("No Instructor with InstructorID = " + InstructorID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillInstructorInfo();
        }
        public ctrlInstructorInfo()
        {
            InitializeComponent();
        }
    }
}
