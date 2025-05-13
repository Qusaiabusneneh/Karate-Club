using DevExpress.XtraSplashScreen;
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
    public partial class FrmAddNewUser : Form
    {
        public Action<int?> GetUserID;
        public enum enMode { enAddNew=0,enUpdate=1};
        private enMode _Mode=enMode.enAddNew;
        private int? _UserID = null;
        private clsUser _User;
        public FrmAddNewUser()
        {
            InitializeComponent();
            _Mode = enMode.enAddNew;
        }
        public FrmAddNewUser(int? UserID,bool ShowPermission)
        {
            InitializeComponent();
            _UserID= UserID;
            _Mode = enMode.enUpdate;
            gbPermissoions.Enabled = ShowPermission;
            chkIsActive.Enabled=ShowPermission;
        }
        private bool _IsAllItemIsChecked()
        {
            foreach (CheckBox item in gbPermissoions.Controls)
            {
                if (item.Tag.ToString() != "-1")
                {
                    if (!item.Checked)
                        return false;
                }
            }
            return true;
        }
        private void chkAllPermission_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAllPermission.Checked)
            {
                foreach (CheckBox item in gbPermissoions.Controls)
                    item.Checked = true;
            }
        }
        private bool _DoesNotSelectAnyPermission()
        {
            foreach (CheckBox item in gbPermissoions.Controls)
            {
                if (item.Checked)
                    return false;
            }
            return true;
        }
        private void chk_CheckedChanged_CheckedChanged(object sender, EventArgs e)
        {
            if (!((CheckBox)sender).Checked)
            {
                chkAllPermission.Checked = false;
                return;
            }
            if (!_IsAllItemIsChecked())
            {
                chkAllPermission.Checked = false;
            }
            else
                chkAllPermission.Checked = true;
        }
        private void _RefershDefaultValues()
        {
            if (_Mode == enMode.enAddNew)
            {
                lblTitle.Text = "Add New User";
                this.Text = "Add New User";
                _User=new clsUser();
                tpLoginInfo.Enabled = false;
                ctrlFindPersonWithFilter1.FilterFocus();
            }
            else
            {
                lblTitle.Text = "Update User Info";
                this.Text = "Update User Info";
                tpLoginInfo.Enabled = true;
                btnSave.Enabled = true;
            }
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            chkIsActive.Checked = true;

        }
        private int _CountPermissions()
        {
            int Permissions = 0;
            if (chkAllPermission.Checked)
                return -1;

            if (chkManageMembers.Checked)
                Permissions += (byte) clsUser.enPermission.eMangeMembers;

            if (chkMangeUsers.Checked)
                Permissions += (byte)clsUser.enPermission.eManageUsers;

            if (chkManageInstructors.Checked)
                Permissions += (byte)clsUser.enPermission.eManageInstructors;

            if (chkMangeSubscription.Checked)
                Permissions += (byte)clsUser.enPermission.eManageSubscriptions;

            if (chkBeltRanks.Checked)
                Permissions += (byte)clsUser.enPermission.eManageBeltRanks;

            if (chkBeltTest.Checked)
                Permissions += (byte)clsUser.enPermission.eManageBeltTests;

            if (chkManageInstructorMembers.Checked)
                Permissions += (byte)clsUser.enPermission.eManageInstructorMembers;

            if (chkPayment.Checked)
                Permissions += (byte)clsUser.enPermission.eManagePayments;

            return Permissions;

        }
        private void _FillCheckBoxPermission()
        {
            if (_User.Permissions == -1)
            {
                chkAllPermission.Checked = true;
                return;
            }
            foreach(CheckBox item in gbPermissoions.Controls)
            {
                if (item.Tag.ToString() != "-1")
                {
                    if ((Convert.ToUInt32(item.Tag) & _User.Permissions) == (Convert.ToUInt32(item.Tag)))
                        item.Checked = true;
                }
            }
        }
        private void _FillFiledWithUserInfo()
        {
            lblUserID.Text = _User.UserID.ToString();
            txtUserName.Text = _User.Username;
            txtConfirmPassword.Text = _User.Password;
            ctrlFindPersonWithFilter1.LoadPersonInfo(_User.PersonID);
            chkIsActive.Checked = _User.IsActive;
            _FillCheckBoxPermission();

        }
        private void _LoadData()
        {
            _User = clsUser.FindByUserID(_UserID);
            if (_User == null)
            {
                MessageBox.Show("No Member with ID = " + _UserID, "Member not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            _FillFiledWithUserInfo();

        }
        private void _FillUserObjectWithFieldsData()
        {
            if (_Mode == enMode.enUpdate)
                _User = clsUser.FindByUserID(_UserID);

            //ctrlFindPersonWithFilter1.LoadPersonInfo(_User.PersonID);                
            _User.Permissions = _CountPermissions();
            _User.Password=txtPassword.Text;
            _User.Username=txtUserName.Text;
            _User.IsActive = chkIsActive.Checked;
            _User.PersonID = ctrlFindPersonWithFilter1.PersonID;

        }
        private void _SaveUser()
        {
            _FillUserObjectWithFieldsData();
            if(_User.Save())
            {
                lblTitle.Text = "Update User";
                lblUserID.Text=_User.UserID.ToString();
                this.Text = "Update User";

                _Mode = enMode.enUpdate;

                MessageBox.Show("Data Saved Successfully", "Saved",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                GetUserID?.Invoke(_User.UserID);
            }
            else
                MessageBox.Show("Data Saved Failed", "Failed",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void FrmAddNewUser_Load(object sender, EventArgs e)
        {
            _RefershDefaultValues();
            if (_Mode == enMode.enUpdate)
                _LoadData();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some Fileds are not Valide !, put the mouse over the red icon(s) to see the error "
                    , "Validation Error ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(_DoesNotSelectAnyPermission())
            {
                MessageBox.Show("You have to select permissions for the user!",
                       "Permissions Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _SaveUser();
        }
        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtUserName, "Username cannot be blank");
                return;
            }
            else
                errorProvider1.SetError(txtUserName, null);
            
            if(_Mode==enMode.enAddNew)
            {
                if (clsUser.IsUserExistByUsername(txtUserName.Text.Trim()))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtUserName, "Username is used by another User...");
                    return;
                }
                else
                    errorProvider1.SetError(txtUserName, null);
            }
            else
            {
                if(_User.Username!=txtUserName.Text.Trim())
                {
                    if(clsUser.IsUserExistByUsername(txtUserName.Text.Trim()))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtUserName, "Username is used by another User...");
                        return;
                    }
                    else
                        errorProvider1.SetError(txtUserName, null); 
                }
            }

        }
        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPassword, "Password cannot be blank");
            }
            else
                errorProvider1.SetError(txtPassword, null);
        }
        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                e.Cancel = true;
                errorProvider1.SetError(txtConfirmPassword, "Password Confirmation Does not match Password!");
            }
            else
                errorProvider1.SetError(txtConfirmPassword, null);
        }
        private void btnPersonInfoNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.enUpdate)
            {
                btnSave.Enabled = true;
                tpLoginInfo.Enabled = true;
                tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
            }

            if (ctrlFindPersonWithFilter1.PersonID != -1)
            {
                if (clsUser.IsUserExistsByPersonID(ctrlFindPersonWithFilter1.SelectedPersonInfo.PersonID)) 
                {
                    MessageBox.Show("Selected Person already has a user, choose another one...", "Selected another Person",
                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlFindPersonWithFilter1.FilterFocus();
                }
                else
                {
                    btnSave.Enabled = true;
                    tpLoginInfo.Enabled = true;
                    tcUserInfo.SelectedTab = tcUserInfo.TabPages["tpLoginInfo"];
                }
            }
            else
            {
                MessageBox.Show("Please selected a Person ", "Selected a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlFindPersonWithFilter1.FilterFocus();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
