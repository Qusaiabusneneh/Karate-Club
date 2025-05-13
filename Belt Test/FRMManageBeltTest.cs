using DevExpress.XtraEditors.Filtering;
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

namespace Karate.App.Belt_Test
{
    public partial class FRMManageBeltTest : Form
    {
        private DataTable _dtBeltTest = clsBeltTests.GetAllBeltTests();
        public FRMManageBeltTest()
        {
            InitializeComponent();
        }
        private void _FillcomboBox()
        {
            foreach (DataColumn column in _dtBeltTest.Columns)
                cmbFilter.Items.Add(column.ColumnName);
            cmbFilter.SelectedIndex = 0;
        }
        private void FRMManageBeltTest_Load(object sender, EventArgs e)
        {
            _FillcomboBox();
            DGVBeltTest.DataSource=_dtBeltTest;
            lblRecord.Text = DGVBeltTest.Rows.Count.ToString();
            if(DGVBeltTest.Rows.Count>0)
            {
                DGVBeltTest.Columns[0].HeaderText = "TestID";
                DGVBeltTest.Columns[0].Width = 115;

                DGVBeltTest.Columns[1].HeaderText = "MemberName";
                DGVBeltTest.Columns[1].Width = 190;

                DGVBeltTest.Columns[2].HeaderText = "RankName";
                DGVBeltTest.Columns[2].Width = 190;

                DGVBeltTest.Columns[3].HeaderText = "TestDate";
                DGVBeltTest.Columns[3].Width = 130;

                DGVBeltTest.Columns[4].HeaderText = "InstructorName";
                DGVBeltTest.Columns[4].Width = 190;

                DGVBeltTest.Columns[5].HeaderText = "PaymentID";
                DGVBeltTest.Columns[5].Width = 115;

                DGVBeltTest.Columns[6].HeaderText = "Result";
                DGVBeltTest.Columns[6].Width = 80;
            }
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            switch(cmbFilter.Text)
            {
                case "TestID":
                    FilterColumn = "TestID";
                    break;

                case "MemberName":
                    FilterColumn = "MemberName";
                    break;

                case "RankName":
                    FilterColumn = "RankName";
                    break;

                case "TestDate":
                    FilterColumn = "TestDate";
                    break;

                case "InstructorName":
                    FilterColumn = "InstructorName";
                    break;

                case "PaymentID":
                    FilterColumn = "PaymentID";
                    break;

                case "Result":
                    FilterColumn = "Result";
                    break;
            }

            if (txtFilter.Text.Trim() == "" || cmbFilter.Text == "None")
            {
                _dtBeltTest.DefaultView.RowFilter = "";
                lblRecord.Text = DGVBeltTest.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "TestID")
                _dtBeltTest.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilter.Text.Trim());
            else
                _dtBeltTest.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'",FilterColumn, txtFilter.Text.Trim());
        }
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilter.Visible = (txtFilter.Text != "None");
            if(txtFilter.Visible)
            {
                txtFilter.Text = "";
                txtFilter.Focus();
            }
        }
        private void btnAddNewBeltTest_Click(object sender, EventArgs e)
        {
            FRMAddUpdateBeltTest frm=new FRMAddUpdateBeltTest();
            frm.ShowDialog();
            FRMManageBeltTest_Load(null, null);
        }

        private void addNewBeltTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMAddUpdateBeltTest frm=new FRMAddUpdateBeltTest();
            frm.ShowDialog();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMAddUpdateBeltTest frm = new FRMAddUpdateBeltTest((int)DGVBeltTest.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int TestID = (int)DGVBeltTest.CurrentRow.Cells[0].Value;
            if (MessageBox.Show("Are you sure you wanna delete Member [" + TestID + "]",
                "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsBeltTests.DeleteBeltTest(TestID))
                {
                    MessageBox.Show("Test Delete Successfully", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FRMManageBeltTest_Load(null, null);
                }
                else
                    MessageBox.Show("Test was not deleted because it has data linked to it ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            FRMManageBeltTest_Load(null, null);
        }
    }
}
