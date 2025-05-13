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

namespace Karate.App.Members
{
    public partial class FRMMangeMembers : Form
    {
        private static DataTable _dtAllMembers=new DataTable();
        private void _FillFilterComboBox()
        {
            cmbFilter.Items.Clear();
            _dtAllMembers = clsMember.GetAllMember();
            foreach (DataColumn column in _dtAllMembers.Columns)
                cmbFilter.Items.Add(column.ToString());
            cmbFilter.SelectedItem = null;
        }
        public FRMMangeMembers()
        {
            InitializeComponent();
        }
        private void FRMMangeMembers_Load(object sender, EventArgs e)
        {
            _FillFilterComboBox();
            _dtAllMembers = clsMember.GetAllMember();
            cmbFilter.SelectedIndex = 0;
            DGVMembers.DataSource= _dtAllMembers;
            lblRecordCount.Text = _dtAllMembers.Rows.Count.ToString();

            if(DGVMembers.Rows.Count>0)
            {
                DGVMembers.Columns[0].HeaderText = "Member ID";
                DGVMembers.Columns[0].Width = 110;

                DGVMembers.Columns[1].HeaderText = "Name";
                DGVMembers.Columns[1].Width = 110;

                DGVMembers.Columns[2].HeaderText = "Rank Name";
                DGVMembers.Columns[2].Width = 110;

                DGVMembers.Columns[3].HeaderText = "Gender";
                DGVMembers.Columns[3].Width = 110;

                DGVMembers.Columns[4].HeaderText = "DateOfBirth";
                DGVMembers.Columns[4].Width = 110;

                DGVMembers.Columns[5].HeaderText = "Phone";
                DGVMembers.Columns[5].Width = 110;

                DGVMembers.Columns[6].HeaderText = "Is Active";
                DGVMembers.Columns[6].Width = 110;

            }
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
            switch (cmbFilter.Text)
            {
                case "MemberID":
                    FilterColumn = "MemberID";
                    break;
                case "Name":
                    FilterColumn = "Name";
                    break;
                case "RankName":
                    FilterColumn = "RankName";
                    break;
                case "Gender":
                    FilterColumn = "Gender";
                    break;
                case "DateOfBirth":
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
                case "EmergencyContact":
                    FilterColumn = "EmergencyContact";
                    break;
                case "IsActive":
                    FilterColumn = "IsActive";
                    break;
                case "ImagePath":
                    FilterColumn = "ImagePath";
                    break;
                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtFilter.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtAllMembers.DefaultView.RowFilter = "";
                lblRecordCount.Text = DGVMembers.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "MemberID")
                _dtAllMembers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
            else
                _dtAllMembers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text.Trim());
            lblRecordCount.Text=DGVMembers.Rows.Count.ToString();
        }
        private void btnAddNewMember_Click(object sender, EventArgs e)
        {
            FRMAddNewMember fRM = new FRMAddNewMember();
            fRM.ShowDialog();
            FRMMangeMembers_Load(null, null);
        }
        private void addNewMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMAddNewMember frm=new FRMAddNewMember();
            frm.ShowDialog();
            FRMMangeMembers_Load(null, null);
        }
        private void editMemberInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMAddNewMember frm = new FRMAddNewMember((int)DGVMembers.CurrentRow.Cells["MemberID"].Value);
            frm.ShowDialog();
            FRMMangeMembers_Load(null, null);
        }
        private void deleteMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you wanna delete Member [" + DGVMembers.CurrentRow.Cells[0].Value+"]",
                "Confirm Delete",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
            {
                if (clsMember.DeleteMember((int)DGVMembers.CurrentRow.Cells["MemberID"].Value))
                {
                    MessageBox.Show("Member Delete Successfully", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FRMMangeMembers_Load(null, null);
                }
                else
                    MessageBox.Show("Member was not deleted because it has data linked to it ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is not Implemented Yet", "Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        }
        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature is not Implemented Yet", "Not Ready", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int MemberID = (int)DGVMembers.CurrentRow.Cells[0].Value;
            FRMMemberCard frm = new FRMMemberCard(MemberID);
            frm.ShowDialog();
        }
        private void findMemberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMFindMember frm = new FRMFindMember();
            frm.ShowDialog();
        }
    }
}
