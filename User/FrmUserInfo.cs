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
    public partial class FrmUserInfo : Form
    {
        private int _UserID;
        public FrmUserInfo(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
        }
        private void ctrlUserInfo1_Load(object sender, EventArgs e)
        {
            ctrlUserInfo1.LoadUserInfo(_UserID);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
