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
    public partial class FRMFindInstructorWithFilter : Form
    {
        public delegate void DataBackEventHandler(object sender, int? InstructorID);
        public event DataBackEventHandler DataBack;
        public FRMFindInstructorWithFilter()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, ctrlFindIndtructorWithFilter1.InstructorID);
        }
    }
}
