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
    public partial class ctrlUserInfo : UserControl
    {
        private clsUser _User;
        private int? _UserID=null;
        public int? UserID
        {
            get { return _UserID; }
        }
        private void _ResetUserInfo()
        {
            //ctrlFindMember1.ResetMemberInfo();
            ctrlPersonCard1._RestfulDefaultValue();
            lblIsActive.Text = "[???]";
            lblUserID.Text = "[???]";
            lblUserName.Text = "[???]";
        }
        private void _FillUserInfo()
        {
            ctrlPersonCard1.LoadPersonInfo(_User.PersonID);
            //ctrlFindMember1.LoadMemberInfoByPersonID(_User.PersonID);
            lblUserName.Text = _User.Username;
            lblUserID.Text = _User.UserID.ToString();
            if (_User.IsActive)
                lblIsActive.Text = "Yes";
            else
                lblIsActive.Text = "No";
        }
        public void LoadUserInfo(int? UserID)
        {
            UserID = _UserID;
            _User = clsUser.FindByUserID(UserID);
            if (_User == null)
            {
                _ResetUserInfo();
                MessageBox.Show("No User with UserID = " + UserID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillUserInfo();
        }
        public ctrlUserInfo()
        {
            InitializeComponent();
        }
    }
}
