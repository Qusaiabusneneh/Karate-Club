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
    public partial class FRMMemberCard : Form
    {
        public FRMMemberCard(int? MemberID)
        {
            InitializeComponent();
            ctrlFindMember1.LoadMemberInfo(MemberID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
