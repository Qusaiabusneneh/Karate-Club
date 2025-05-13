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

namespace Karate.App.Payment
{
    public partial class FRMMangePayment : Form
    {
        private DataTable _dtPayment = clsPayment.GetAllPayment();
        private void _FillComboBox()
        {
            foreach(DataColumn column in _dtPayment.Columns)
                cmbFilter.Items.Add(column.ColumnName);
            cmbFilter.SelectedIndex = 0;
        }

        public FRMMangePayment()
        {
            InitializeComponent();
        }
        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            string ColumnString = "";
            switch(cmbFilter.Text)
            {
                case "PaymentID":
                    ColumnString = "PaymentID";
                    break;

                case "MemberName":
                    ColumnString = "MemberName";
                    break;

                case "Date":
                    ColumnString = "Date";
                    break;

                case "PaymentAmount":
                    ColumnString = "PaymentAmount";
                    break;

                default:
                    ColumnString = "None";
                    break;
            }
            if (cmbFilter.Text == "PaymentID" || cmbFilter.Text == "PaymentAmount")
            {
                _dtPayment.DefaultView.RowFilter = string.Format("[{0}] like '{1}%'", ColumnString, txtFilter.Text.Trim());
            }
            else
            {
                _dtPayment.DefaultView.RowFilter =
                        string.Format("[{0}] like '{1}%'", ColumnString,txtFilter.Text.Trim());
            }
            lblRecordCount.Text = DGVPayment.Rows.Count.ToString();
        }
        private void FRMMangePayment_Load(object sender, EventArgs e)
        {
            _FillComboBox();
            DGVPayment.DataSource = _dtPayment;
            lblRecordCount.Text=DGVPayment.Rows.Count.ToString();
            if(DGVPayment.Rows.Count>0)
            {
                DGVPayment.Columns[0].HeaderText = "PaymentID";
                DGVPayment.Columns[0].Width = 130;

                DGVPayment.Columns[1].HeaderText = "MemberName";
                DGVPayment.Columns[1].Width = 200;

                DGVPayment.Columns[2].HeaderText = "PaymentDate";
                DGVPayment.Columns[2].Width = 150;

                DGVPayment.Columns[3].HeaderText = "PaymentAmount";
                DGVPayment.Columns[3].Width = 150;
            }
        }
        private void showPaymentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRMPaymentDetails frm=new FRMPaymentDetails((int?)DGVPayment.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
