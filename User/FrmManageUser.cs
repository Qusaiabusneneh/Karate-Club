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

namespace Karate.App.User
{
    public partial class FrmManageUser : Form
    {
        private DataTable _dtUser = new DataTable();
        private void _FillComboBoxUser()
        {
            cmbFilter.Items.Clear();
            _dtUser = clsUser.GetAllUsers();
            foreach(DataColumn column in _dtUser.Columns)
                cmbFilter.Items.Add(column.ToString());
            cmbFilter.SelectedItem = null;
        }
        public FrmManageUser()
        {
            InitializeComponent();
        }
        private void FrmManageUser_Load(object sender, EventArgs e)
        {
            _FillComboBoxUser();
            _dtUser = clsUser.GetAllUsers();
            cmbFilter.SelectedIndex = 1;
            DGVUser.DataSource = _dtUser;
            lblRecord.Text = _dtUser.Rows.Count.ToString();
            if (DGVUser.Rows.Count > 0) 
            {
                DGVUser.Columns[0].HeaderText = "User ID";
                DGVUser.Columns[0].Width = 110;

                DGVUser.Columns[1].HeaderText = "Name";
                DGVUser.Columns[1].Width = 120;

                DGVUser.Columns[2].HeaderText = "Userame";
                DGVUser.Columns[2].Width = 120;

                DGVUser.Columns[3].HeaderText = "Gender";
                DGVUser.Columns[3].Width = 120;

                DGVUser.Columns[4].HeaderText = "Permissions";
                DGVUser.Columns[4].Width = 120;

                DGVUser.Columns[5].HeaderText = "Phone";
                DGVUser.Columns[5].Width = 120;

                DGVUser.Columns[6].HeaderText = "Is Active";
                DGVUser.Columns[6].Width = 120;
            }
        }
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbFilter.Text=="Is Active")
            {
                txtFilter.Visible = false;
                cmbFilter.Visible = true;
                cmbFilter.Focus();
                cmbFilter.SelectedIndex = 0;
            }
            else
            {
                txtFilter.Visible = (cmbFilter.Text != "None");
                cmbFilter.Visible = true;
                txtFilter.Text = "";
                txtFilter.Focus();
            }
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch(cmbFilter.Text)
            {
                case "UserID":
                    FilterColumn = "UserID";
                    break;

                case "PersonID":
                    FilterColumn = "PersonID";
                    break;

                case "Name":
                    FilterColumn = "Name";
                    break;

                case "UserName":
                    FilterColumn = "UserName";
                    break;

                case "Permissions":
                    FilterColumn = "Permissions";
                    break;

                case "IsActive":
                    FilterColumn = "IsActive";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtFilter.Text.Trim() == "" || cmbFilter.Text == "None") 
            {
                _dtUser.DefaultView.RowFilter = "";
                lblRecord.Text=DGVUser.Rows.Count.ToString();
                return;
            }

            if (FilterColumn != "Name" && FilterColumn != "UserName") 
                _dtUser.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
            else
                _dtUser.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text.Trim());
            
            lblRecord.Text = DGVUser.Rows.Count.ToString();
        }
        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            FrmAddNewUser frm=new FrmAddNewUser();
            frm.ShowDialog();
            FrmManageUser_Load(null, null);
        }
        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID=(int)DGVUser.CurrentRow.Cells[0].Value;
            FrmAddNewUser frm = new FrmAddNewUser(UserID,true);
            frm.ShowDialog();
        }
        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)DGVUser.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("Are you sure you wanna delete Member [" + UserID + "]",
                     "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsMember.DeleteMember(UserID))
                {
                    MessageBox.Show("Member Delete Successfully", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FrmManageUser_Load(null, null);
                }
                else
                    MessageBox.Show("Member was not deleted because it has data linked to it ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void updateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID=(int)DGVUser.CurrentRow.Cells[0].Value;
            FrmAddNewUser frm = new FrmAddNewUser(UserID, false);
            frm.ShowDialog();
            FrmManageUser_Load(null, null);
        }
        private void showUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)DGVUser.CurrentRow.Cells[0].Value;
            FrmUserInfo frm=new FrmUserInfo(UserID);
            frm.ShowDialog();
        }
    }
}
