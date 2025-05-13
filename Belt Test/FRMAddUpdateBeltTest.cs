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
    public partial class FRMAddUpdateBeltTest : Form
    {
        private int? _NewBeltTestID = null;
        public FRMAddUpdateBeltTest()
        {
            InitializeComponent();
        }
        private void _LoadNextBeltInfoUsingDelegate(int? MemberID)
        {
            if (ctrlMemberInstructorInfoWithFilter1.SelectedMemberInfo == null)
            {
                btnSave.Enabled = false;
                return;
            }
            lblBeltRankID.Text=ctrlMemberInstructorInfoWithFilter1.SelectedMemberInfo.LastBeltRankInfo.RankID.ToString();
            lblRankName.Text = ctrlMemberInstructorInfoWithFilter1.SelectedMemberInfo.LastBeltRankInfo.RankName;
            lblFees.Text=ctrlMemberInstructorInfoWithFilter1.SelectedMemberInfo.LastBeltRankInfo.TestFees.ToString();
            
            if (ctrlMemberInstructorInfoWithFilter1.SelectedInstructorID.HasValue)
                btnSave.Enabled = true;
        }
        public FRMAddUpdateBeltTest(int?MemberID)
        {
            InitializeComponent();
            ctrlMemberInstructorInfoWithFilter1.SendMemberID += _LoadNextBeltInfoUsingDelegate;
            ctrlMemberInstructorInfoWithFilter1.LoadMemberInfo(MemberID);
            ctrlMemberInstructorInfoWithFilter1.FilterEnableMember = false;
        }
        private void _LoadData()
        {
            dtpStartDate.MinDate=DateTime.Now;
            radPass.Checked = true;
        }
        private void EnableBtnSaveWhenSelectInstructor(int?InstrucotorID)
        {
            btnSave.Enabled = (InstrucotorID.HasValue);
        }
        private void FRMAddUpdateBeltTest_Load(object sender, EventArgs e)
        {
            _LoadData();
            ctrlMemberInstructorInfoWithFilter1.SendMemberID -= _LoadNextBeltInfoUsingDelegate;
            ctrlMemberInstructorInfoWithFilter1.SendInstructorID += EnableBtnSaveWhenSelectInstructor;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!ctrlMemberInstructorInfoWithFilter1.SelectedMemberID.HasValue ||
                !ctrlMemberInstructorInfoWithFilter1.SelectedInstructorID.HasValue)
            {
                MessageBox.Show("You have to select member and instructor first!", "Missing Data",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            clsBeltTests BeltTest= new clsBeltTests();
            BeltTest.MemberID = ctrlMemberInstructorInfoWithFilter1.SelectedMemberID;
            BeltTest.TestedByInstructorID = ctrlMemberInstructorInfoWithFilter1.SelectedInstructorID;
            BeltTest.RankID = ctrlMemberInstructorInfoWithFilter1.SelectedMemberInfo.LastBeltRankInfo.RankID;
            BeltTest.Result = (radPass.Checked);
            BeltTest.Date = dtpStartDate.Value;
            BeltTest.PaymentID = BeltTest.Pay(ctrlMemberInstructorInfoWithFilter1.SelectedMemberInfo.LastBeltRankInfo.TestFees);
            lblPaymentID.Text = (BeltTest.PaymentID.HasValue) ? BeltTest.PaymentID.ToString() : "[????]";

            if (BeltTest.Save())
            {
                MessageBox.Show("Data Saved Successfully", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                _NewBeltTestID = BeltTest.TestID;
                lblTestID.Text=_NewBeltTestID.ToString();
                btnSave.Enabled = false;
                ctrlMemberInstructorInfoWithFilter1.FilterEnableInstructor = false;
                ctrlMemberInstructorInfoWithFilter1.FilterEnableMember=false;
                FRMAddUpdateBeltTest_Load(null, null);
            }
            else
                MessageBox.Show("Failed to save data", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);


        }
    }
}
