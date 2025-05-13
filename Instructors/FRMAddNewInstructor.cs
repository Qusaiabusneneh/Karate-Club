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

namespace Karate.App.Instructors
{
    public partial class FRMAddNewInstructor : Form
    {
        public enum enMode { enAddNew=0,enUpdate=1};
        private enMode _Mode;
        private int? _InstructorID = null;
        private clsInstructors _Instructor;
        public Action<int?> GetInstructotID;
        private void _ResetInstructorInfo()
        {
            ctrlFindPersonWithFilter1.ResetText();
        }
        private void _RefreshDefaulValues()
        {
            if(_Mode==enMode.enAddNew)
            {
                lblTitle.Text = "Add New Instructor";
                this.Text = "Add New Instrucotr";
                _Instructor = new clsInstructors();
                tpInstructor.Enabled = false;
                ctrlFindPersonWithFilter1.FilterFocus();
            }
            else
            {
                lblTitle.Text = "Update Instructor";
                this.Text = "this Instructor";
                btnNext.Enabled = true;
                tpInstructor.Enabled = true;
            }
            txtQualification.Text = "";

        }
        private void _LoadData()
        {
            _Instructor = clsInstructors.Find(_InstructorID);
            if (_Instructor == null)
            {
                MessageBox.Show("No Instructor with ID = " + _InstructorID, "Instructor not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            lblInstructorID.Text = _Instructor.InstructorID.ToString();
            txtQualification.Text = _Instructor.Qualification;
            ctrlFindPersonWithFilter1.LoadPersonInfo(_Instructor.PersonID);
        }
        public FRMAddNewInstructor()
        {
            InitializeComponent();
            _Mode = enMode.enAddNew;
        }
        public FRMAddNewInstructor(int? InstructorID)
        {
            InitializeComponent();
            _InstructorID = InstructorID;
            _Mode = enMode.enUpdate;
        }
        private void FRMAddNewInstructor_Load(object sender, EventArgs e)
        {
            _RefreshDefaulValues();
            if (_Mode == enMode.enUpdate)
                _LoadData();
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.enUpdate)
            {
                btnSave.Enabled = true;
                tpInstructor.Enabled = true;
                tcInstructorInfo.SelectedTab = tcInstructorInfo.TabPages["tpInstructor"];
            }
            if (ctrlFindPersonWithFilter1.SelectedPersonInfo.PersonID != null) 
            {
                if (clsInstructors.IsInstructorExistByPersonID(ctrlFindPersonWithFilter1.SelectedPersonInfo.PersonID))
                {
                    MessageBox.Show("Selected Person already has a instructor, choose another one...", "Selected another Person",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlFindPersonWithFilter1.FilterFocus();
                }

                else
                {
                    btnSave.Enabled = true;
                    tpInstructor.Enabled = true;
                    tcInstructorInfo.SelectedTab = tcInstructorInfo.TabPages["tpInstructor"];
                }
            }
            else
            {
                MessageBox.Show("Please selected a Person ", "Selected a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlFindPersonWithFilter1.FilterFocus();
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fileds are not Valide !, put the mouse over the red icon(s) to see the error "
                    , "Validation Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Instructor.PersonID = ctrlFindPersonWithFilter1.PersonID;
            _Instructor.Qualification = txtQualification.Text;
            if(_Instructor.Save())
            {
                lblInstructorID.Text = _Instructor.InstructorID.ToString();
                _Mode = enMode.enUpdate;
                lblTitle.Text = "Update Instructor Info";
                this.Text = "Update Instructor Info";
                MessageBox.Show("Data Saved Successfully...", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error : Data Is not Saved Successfully...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void txtQualification_Validating(object sender, CancelEventArgs e)
        {
            if (txtQualification.Text.Trim() != txtQualification.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtQualification, "Password Confirmation Does not match Password!");
            }
            else
                errorProvider1.SetError(txtQualification, null);
        }
    }
}
