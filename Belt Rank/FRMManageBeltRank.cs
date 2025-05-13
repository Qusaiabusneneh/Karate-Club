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

namespace Karate.App.Belt_Rank
{
    public partial class FRMManageBeltRank : Form
    {
        DataTable _dtBeltRank;

        public FRMManageBeltRank()
        {
            InitializeComponent();
        }
        private void _RefreshListBeltRank()
        {
            _dtBeltRank = clsBeltRank.GetAllBeltRanks();
            DGVBeltRank.DataSource= _dtBeltRank;
            lblRecordCount.Text = DGVBeltRank.Rows.Count.ToString();
            if (DGVBeltRank.Rows.Count > 0)
            {
                DGVBeltRank.Columns[0].HeaderText = "BeltID";
                DGVBeltRank.Columns[0].Width = 115;

                DGVBeltRank.Columns[1].HeaderText = "RankName";
                DGVBeltRank.Columns[1].Width = 250;

                DGVBeltRank.Columns[2].HeaderText = "TestFees";
                DGVBeltRank.Columns[2].Width = 180;
            }
        }
        private void FRMManageBeltRank_Load(object sender, EventArgs e)
        {
            _RefreshListBeltRank();
        }
    }
}
