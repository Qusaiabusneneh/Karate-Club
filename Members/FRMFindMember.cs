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
    public partial class FRMFindMember : Form
    {
        public delegate void DataBackEventHandler(object sender, int? MemberID);
        public event DataBackEventHandler DataBack;
        public FRMFindMember()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, ctrlFindMemberWithFilter1.MemberID);
        }
    }
}
