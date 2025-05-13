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
    public partial class FrmManageInstructors : Form
    {
        DataTable _dtInstructors = clsInstructors.GetAllInstructor();
        private int _InstructorID = -1;
        private void _FillComboBoxInstructor()
        {
            cmbFilter.Items.Clear();
            foreach(DataColumn column in _dtInstructors.Columns)
                cmbFilter.Items.Add(column.ToString());
            cmbFilter.SelectedItem = null;

        }
        private void FrmManageInstructors_Load(object sender, EventArgs e)
        {
            _FillComboBoxInstructor();
            cmbFilter.SelectedIndex = 0;
            DGVInstructors.DataSource = _dtInstructors;
            lblRecordCount.Text = DGVInstructors.Rows.Count.ToString();
            if (DGVInstructors.Rows.Count > 0)
            {
                DGVInstructors.Columns[0].HeaderText = "Instructor ID";
                DGVInstructors.Columns[0].Width = 110;

                DGVInstructors.Columns[1].HeaderText = "Name";
                DGVInstructors.Columns[1].Width = 110;

                DGVInstructors.Columns[2].HeaderText = "Gender";
                DGVInstructors.Columns[2].Width = 110;

                DGVInstructors.Columns[3].HeaderText = "DateOfBirth";
                DGVInstructors.Columns[3].Width = 110;

                DGVInstructors.Columns[4].HeaderText = "Phone";
                DGVInstructors.Columns[4].Width = 110;

                DGVInstructors.Columns[5].HeaderText = "Qualification";
                DGVInstructors.Columns[5].Width = 110;
            }
        }
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible=(cmbFilter.Text != "None");
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
                case "InstructorID":
                    FilterColumn = "InstructorID";
                    break;

                case "Name":
                    FilterColumn = "Name";
                    break;
                case "Gender":
                    FilterColumn = "Gender";
                    break;
                case "DateOfBirh":
                    FilterColumn = "DateOfBirth";
                    break;
                case "Address":
                    FilterColumn = "Address";
                    break;
                case "Email":
                    FilterColumn = "Email";
                    break;
                case "Phone":
                    FilterColumn = "Phone";
                    break;
                case "ImagePath":
                    FilterColumn = "ImagePath";
                    break;
                case "Qualification":
                    FilterColumn = "Qualification";
                    break;
            }
            if (txtFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtInstructors.DefaultView.RowFilter = "";
                lblRecordCount.Text = DGVInstructors.Rows.Count.ToString();
                return;
            }
            if (FilterColumn == "InstructorID")
                _dtInstructors.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
            else
                _dtInstructors.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text.Trim());
            lblRecordCount.Text = DGVInstructors.Rows.Count.ToString();
        }
        public FrmManageInstructors()
        {
            InitializeComponent();
        }
        private void addNewInstrucotrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMAddNewInstructor frm = new FRMAddNewInstructor();
            frm.ShowDialog();
            FrmManageInstructors_Load(null, null);
        }
        private void btnAddNewInstructor_Click(object sender, EventArgs e)
        {
            FRMAddNewInstructor frm = new FRMAddNewInstructor();
            frm.ShowDialog();
            FrmManageInstructors_Load(null, null);
        }
        private void updateInstructorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InstructorID = (int)DGVInstructors.CurrentRow.Cells["InstructorID"].Value;
            FRMAddNewInstructor frm = new FRMAddNewInstructor(InstructorID);
            frm.ShowDialog();
            FrmManageInstructors_Load(null, null);
        }
        private void deleteInstructorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InstructorID = (int)DGVInstructors.CurrentRow.Cells["InstructorID"].Value;
            if (MessageBox.Show("Are you sure you wanna delete Member [" + InstructorID + "]",
                "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsInstructors.DeleteInstructor(InstructorID))
                {
                    MessageBox.Show("Member Delete Successfully", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmManageInstructors_Load(null, null);
                }
                else
                    MessageBox.Show("Member was not deleted because it has data linked to it ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FrmManageInstructors_Load(null, null);
        }
        private void findInstructorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int InstructorID = (int)DGVInstructors.CurrentRow.Cells["InstructorID"].Value;
            FRMShowInstructorInfo frm=new FRMShowInstructorInfo(InstructorID);
            frm.ShowDialog();
        }
        private void showInstructorInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMFindInstructorWithFilter frm = new FRMFindInstructorWithFilter();
            frm.ShowDialog();
        }
    }
}
