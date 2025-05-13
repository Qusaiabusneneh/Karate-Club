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
    public partial class ctrlFindIndtructorWithFilter : UserControl
    {
        #region Declare Event
        public class InstructorSelectedEventArgs:EventArgs
        {
            public int ? InstructorID { set;get; }
            public InstructorSelectedEventArgs(int?InstructorID)
            {
                this.InstructorID = InstructorID;
            }
        }
        public event EventHandler<InstructorSelectedEventArgs> OnInstructorSelected;
        public void RaiseOnInstructorSelected(int?InstructorID)
        {
            RaiseOnInstructorSelected(new InstructorSelectedEventArgs(InstructorID));
        }
        protected virtual void RaiseOnInstructorSelected(InstructorSelectedEventArgs e)
        {
            OnInstructorSelected?.Invoke(this, e);
        }
        #endregion
        private bool _ShowAddInstructor = true;
        public bool ShowAddInstructor
        {
            get => _ShowAddInstructor;
            set
            {
                _ShowAddInstructor = value;
                btnAddNewInstructor.Visible = _ShowAddInstructor;
            }
        }
        private bool _FilterEnable = true;
        public bool FilterEnable
        {
            get => _FilterEnable;
            set
            {
                _FilterEnable = value;
                gbFilters.Enabled = _FilterEnable;
            }
        }
        private int? _InstructorID = null;
        public int? InstructorID
        {
            get => ctrlInstructorInfo1.InstructorID;
        }
        public clsInstructors SelectedInstructorInfo
        {
            get => ctrlInstructorInfo1.SelectedInstructorInfo;
        }
        private void FindNow()
        {
            switch(cbFilterBy.Text)
            {
                case "InstructorID":
                    ctrlInstructorInfo1.LoadInstructorInfo(int.Parse(txtFilterValue.Text));
                    break;
            }
            if (OnInstructorSelected != null && FilterEnable)
                RaiseOnInstructorSelected(ctrlInstructorInfo1.InstructorID);
        }
        public void LoadInstructorInfo(int? InstructorID)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Text= InstructorID.ToString();
            FindNow();
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }
        private void DataBackEvent(int? InstructorID)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Text=InstructorID.ToString();
            ctrlInstructorInfo1.LoadInstructorInfo(InstructorID);
        }
        private void btnAddNewInstructor_Click(object sender, EventArgs e)
        {
            FRMAddNewInstructor frm=new FRMAddNewInstructor();
            frm.GetInstructotID += DataBackEvent;
            frm.ShowDialog();
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!,put the mouse over the red icon(s) to see the error", "Validation Error",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            FindNow();
        }
        private void ctrlFindIndtructorWithFilter_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Focus();
        }
        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //check if hte pressed key is enter (char code 13)
            if (e.KeyChar == (char)13)
            {
                btnFind.PerformClick();
            }

            if (cbFilterBy.Text == "Instructor ID")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
        public ctrlFindIndtructorWithFilter()
        {
            InitializeComponent();
        }
    }
}
