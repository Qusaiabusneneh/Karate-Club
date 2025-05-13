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
    public partial class FRMManageMemberInstructors : Form
    {
        DataTable _dtMemberInstructor = clsMemberInstructor.GetAllMemberInstructor();
        private void _FillComboBox()
        {
            cmbFilter.Items.Clear();
            foreach (DataColumn column in _dtMemberInstructor.Columns)
                cmbFilter.Items.Add(column.ToString());
            cmbFilter.SelectedItem = null;
        }
        public FRMManageMemberInstructors()
        {
            InitializeComponent();
        }
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible = (cmbFilter.Text != "None");
            if(txtFilter.Visible)
            {
                txtFilter.Text = "";
                txtFilter.Focus();
            }
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch(cmbFilter.Text)
            {
                case "MemberInstructorID":
                    FilterColumn = "MemberInstructorID";
                    break;
                case "MemberID":
                    FilterColumn = "MemberID";
                    break;
                case "InstructorID":
                    FilterColumn = "InstructorID";
                    break;
                case "AssignDate":
                    FilterColumn = "AssignDate";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }
            if (txtFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtMemberInstructor.DefaultView.RowFilter = "";
                lblRecord.Text=DGVMemberInstructor.Rows.Count.ToString();
                return;
            }
            if (FilterColumn == "MemberInstructorID")
                _dtMemberInstructor.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
            else
                _dtMemberInstructor.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text.Trim());

            lblRecord.Text = DGVMemberInstructor.Rows.Count.ToString();
        }
        private void FRMManageMemberInstructors_Load(object sender, EventArgs e)
        {
            _FillComboBox();
            DGVMemberInstructor.DataSource = _dtMemberInstructor;
            lblRecord.Text = DGVMemberInstructor.Rows.Count.ToString();
            if(DGVMemberInstructor.Rows.Count>0)
            {
                DGVMemberInstructor.Columns[0].HeaderText = "MemberInstructorID";
                DGVMemberInstructor.Columns[0].Width = 200;

                DGVMemberInstructor.Columns[1].HeaderText = "Member Name";
                DGVMemberInstructor.Columns[1].Width = 200;

                DGVMemberInstructor.Columns[2].HeaderText = "Instructor Name";
                DGVMemberInstructor.Columns[2].Width = 200;

                DGVMemberInstructor.Columns[3].HeaderText = "Assign Date";
                DGVMemberInstructor.Columns[3].Width = 210;
            }
        }
        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilter.Text == "MemberInstructorID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void addNewMemeberInstructorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMAddUpdateMemberInstructor fRM = new FRMAddUpdateMemberInstructor();
            fRM.ShowDialog();
            FRMManageMemberInstructors_Load(null, null);
        }
        private void deleteMemberInstructorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you wanna delete Person[" + DGVMemberInstructor.CurrentRow.Cells[0].Value + "]",
                "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsMemberInstructor.DeleteMemberInstructor((int?)DGVMemberInstructor.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("MemberInstructor Delete Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FRMManageMemberInstructors_Load(null, null);
                }
                else
                    MessageBox.Show("MemberInstructor was not delete because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FRMManageMemberInstructors_Load(null, null);

        }
        private void updateMemberInstructorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMAddUpdateMemberInstructor frm = new FRMAddUpdateMemberInstructor((int)DGVMemberInstructor.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            FRMManageMemberInstructors_Load(null, null);

        }
        private void findMemberInstructorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMManageMemberInstructors_Load(null, null);

        }
        private void showMemberIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMManageMemberInstructors_Load(null, null);

        }
        private void btnAddNewMemberInstructor_Click(object sender, EventArgs e)
        {
            FRMAddUpdateMemberInstructor fRM = new FRMAddUpdateMemberInstructor();
            fRM.ShowDialog();
            FRMManageMemberInstructors_Load(null, null);

        }
    }
}
