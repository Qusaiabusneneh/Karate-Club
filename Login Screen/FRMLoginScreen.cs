using Karate.App.Global_Classes;
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

namespace Karate.App.Login_Screen
{
    public partial class FRMLoginScreen : Form
    {
        public FRMLoginScreen()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser User = clsUser.FindUserByUsernamePassword(txtUsername.Text.Trim(),
               (txtPassword.Text.Trim())); 

            if (User != null)
            {
                if (chkRemeber.Checked)
                    clsGlobal.RememberUsernameAndPassword(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                else
                    clsGlobal.RememberUsernameAndPassword("", "");
                
                if(!User.IsActive)
                {
                    txtUsername.Focus();
                    MessageBox.Show("Your account is not active,Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                clsGlobal._CurrentUser = User;
                this.Hide();
                FRMDashbord frm = new FRMDashbord(this);
                frm.ShowDialog();
            }
            else
            {
                txtUsername.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtUsername.Text = "";
            }
        }
        private void FRMLoginScreen_Load(object sender, EventArgs e)
        {
            string Username = "", Password = "";
            if (clsGlobal.GetSortedCredential(ref Username, ref Password))
            {
                txtPassword.Text = Password;
                txtUsername.Text = Username;
                chkRemeber.Checked = true;
            }
            else
                chkRemeber.Checked = false;
        }
    }
}
