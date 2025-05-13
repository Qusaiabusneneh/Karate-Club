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

namespace Karate.App.People
{
    public partial class FRMManagePeople : Form
    {
        DataTable _dtPeople = clsPerson.GetAllPeople();
        private void _FillComboBox()
        {
            foreach (DataColumn column in _dtPeople.Columns)
                cmbFilter.Items.Add(column.ColumnName);
            cmbFilter.SelectedIndex = 0;
        }
        public FRMManagePeople()
        {
            InitializeComponent();
        }
        private void FRMManagePeople_Load(object sender, EventArgs e)
        {
            _FillComboBox();
            DGVPeople.DataSource = _dtPeople;
            lblRecord.Text = _dtPeople.Rows.Count.ToString();
            if (_dtPeople.Rows.Count > 0)
            {
                DGVPeople.Columns[0].HeaderText = "Person ID";
                DGVPeople.Columns[0].Width = 110;

                DGVPeople.Columns[1].HeaderText = "Name";
                DGVPeople.Columns[1].Width = 110;

                DGVPeople.Columns[2].HeaderText = "Address";
                DGVPeople.Columns[2].Width = 110;

                DGVPeople.Columns[3].HeaderText = "Phone";
                DGVPeople.Columns[3].Width = 110;

                DGVPeople.Columns[4].HeaderText = "Email";
                DGVPeople.Columns[4].Width = 110;

                DGVPeople.Columns[5].HeaderText = "Date of Birth";
                DGVPeople.Columns[5].Width = 200;

                DGVPeople.Columns[6].HeaderText = "Gender";
                DGVPeople.Columns[6].Width = 110;

                DGVPeople.Columns[7].HeaderText = "ImagePath";
                DGVPeople.Columns[7].Width = 200;
            }
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch (cmbFilter.Text)
            {
                case "PersonID":
                    FilterColumn = "PersonID";
                    break;

                case "Name":
                    FilterColumn = "Name";
                    break;

                case "Address":
                    FilterColumn = "Address";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                case "DateOfBirth":
                    FilterColumn = "DateOfBirth";
                    break;
                case "Gender":
                    FilterColumn = "Gender";
                    break;
                case "ImagePath":
                    FilterColumn = "ImagePath";
                    break;
            }
            if (txtFilter.Text.Trim() == "" || cmbFilter.Text == "None")
            {

                _dtPeople.DefaultView.RowFilter = "";
                lblRecord.Text = _dtPeople.Rows.Count.ToString();
                return;
            }
            if (FilterColumn == "PersonID")
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
            else
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilter.Text.Trim());
        }
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible = (txtFilter.Text != "None");
            if (txtFilter.Visible)
            {
                txtFilter.Text = "";
                txtFilter.Focus();
            }
        }
        private void btnAddNewManage_Click(object sender, EventArgs e)
        {
            FRMAddNewPeople frm = new FRMAddNewPeople();
            frm.ShowDialog();
            FRMManagePeople_Load(null, null);
        }
        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMAddNewPeople frm = new FRMAddNewPeople();
            frm.ShowDialog();
            FRMManagePeople_Load(null, null);
        }
        private void findPersonInfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMFindPerson fRM = new FRMFindPerson();
            fRM.ShowDialog();
        }
        private void deletePersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)DGVPeople.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("Are you sure you wanna delete Member [" + PersonID + "]",
                "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if(clsPerson.DeletePerson(PersonID))
                {
                    MessageBox.Show("People Delete Successfully", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FRMManagePeople_Load(null, null);
                }
                else
                    MessageBox.Show("People was not deleted because it has data linked to it ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void updatePersonInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)DGVPeople.CurrentRow.Cells[0].Value;
            FRMAddNewPeople frm = new FRMAddNewPeople(PersonID);
            FRMManagePeople_Load(null, null);
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
