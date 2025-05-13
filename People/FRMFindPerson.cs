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
    public partial class FRMFindPerson : Form
    {
        public delegate void DataBackEventHandler(object sender, int? PersonID);
        public DataBackEventHandler DataBack;
        public FRMFindPerson()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, ctrlFindPersonWithFilter1.PersonID);
        }
    }
}
