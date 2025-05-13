using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karate.App.Instructors
{
    public partial class FRMShowInstructorInfo : Form
    {
        private int _IntructorID;

        public FRMShowInstructorInfo(int InstructorID)
        {
            InitializeComponent();
            _IntructorID = InstructorID;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void ctrlInstructorInfo1_Load(object sender, EventArgs e)
        {
            ctrlInstructorInfo1.LoadInstructorInfo(_IntructorID);
        }
    }
}
