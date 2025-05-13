using Karate.App.Global_Classes;
using Karate.App.Properties;
using Karate_Bussines_Layers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karate.App.Members
{
    public partial class FRMAddNewMember : Form
    {
        public enum enMode { enAddNew,enUpdate};
        private enMode _Mode = enMode.enAddNew;

        private int? _MemberID = null;
        private clsMember _Member;

        public Action<int?> GetMemberID;
        public FRMAddNewMember()
        {
            InitializeComponent();
            _Mode = enMode.enAddNew;
        }
        public FRMAddNewMember(int? MemberID)
        {
            InitializeComponent();
            _MemberID = MemberID;
            _Mode = enMode.enUpdate;
        }
        private void _FillBeltRanksInComboBox()
        {
            DataTable dtBeltRanks = clsBeltRank.GetAllBeltRanks();
            foreach (DataRow row in dtBeltRanks.Rows)
                cmbBeltRank.Items.Add(row["RankName"]);
        }
        private void _RestDefaultValues()
        {
            _FillBeltRanksInComboBox();
            if(_Mode==enMode.enAddNew)
            {
                lblTitle.Text = "Add New Member";
                _Member = new clsMember();
            }
            else
            {
                lblTitle.Text = "Update Member";
            }

            if (radMale.Checked)
                pbPersonImage.Image = Resources.karate__1_;
            else
                pbPersonImage.Image = Resources.martial_arts__1_;

            lblRemoveImage.Visible = (pbPersonImage.ImageLocation != null);
            cmbBeltRank.SelectedIndex = cmbBeltRank.FindString("White Belt");
            txtName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            radMale.Checked = true;
            chkIsActive.Checked = true;
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-6);
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);
        }
        private void _LoadData()
        {
            _Member = clsMember.Find(_MemberID);
            if (_Member == null)
            {
                MessageBox.Show("No Member with ID = " + _MemberID, "Member not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
            lblMemberID.Text = _MemberID.ToString();
            txtName.Text = _Member.Name;
            txtAddress.Text = _Member.Address;
            txtPhone.Text=_Member.Phone;
            dtpDateOfBirth.Value = _Member.DateOfBirth;
            chkIsActive.Checked = _Member.IsActive;
            cmbBeltRank.SelectedIndex = cmbBeltRank.FindString(_Member.LastBeltRankInfo.RankName);
            txtEmergencyContact.Text = _Member.EmergencyContactInfo;
            txtEmail.Text= _Member.Email;


            if (_Member.Gender == (byte)clsPerson.enGender.Female)
            {
                radFemale.Checked = true;
                pbPersonImage.Image = Resources.martial_arts__1_;
            }
            else
            {
                radMale.Checked = true;
                pbPersonImage.Image = Resources.karate__1_;
            }

            if(_Member.ImagePath!="")
                pbPersonImage.ImageLocation=_Member.ImagePath;

            lblRemoveImage.Visible = (_Member.ImagePath != "");
        }
        private void FRMAddNewMember_Load(object sender, EventArgs e)
        {
            _RestDefaultValues();
            if (_Mode == enMode.enUpdate)
                _LoadData();
        }
        //private bool _HandleImagePerson()
        //{
        //    if (_Member.ImagePath != pbPersonImage.ImageLocation)
        //    {
        //        if (_Member.ImagePath != null)
        //        {
        //            try
        //            {
        //                File.Delete(_Member.ImagePath);
        //            }
        //            catch(IOException)
        //            {

        //            }
        //        }
        //        if (pbPersonImage.ImageLocation != null) 
        //        {
        //            string SourceImageFile=pbPersonImage.ImageLocation;
        //            if (clsUtil.CopyImageToProjectImageFolder(ref SourceImageFile))
        //            {
        //                pbPersonImage.ImageLocation = SourceImageFile;
        //                return true;
        //            }
        //            else
        //            {
        //                MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //                return false;
        //            }
                    
        //        }
        //    }
        //    return true;
        //}
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("Some fildes are not valide!, put the mouse over the red icon(s) to see the error", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if (!_HandleImagePerson())
            //    return;

            //int? BeltRankID = clsBeltRank.Find(cmbBeltRank.Text).RankID;
            _Member.Name = txtName.Text.Trim();
            _Member.EmergencyContactInfo = txtEmergencyContact.Text.Trim();
            _Member.Phone= txtPhone.Text.Trim();
            _Member.Address=txtAddress.Text.Trim();
            _Member.DateOfBirth = dtpDateOfBirth.Value;
            _Member.Email= txtEmail.Text.Trim();
            _Member.IsActive = chkIsActive.Checked;
            _Member.LastBeltRankID = clsBeltRank.Find(cmbBeltRank.Text).RankID;
            _Member.Gender = (radMale.Checked) ? clsPerson.enGender.Male : clsPerson.enGender.Female;

            if (pbPersonImage.ImageLocation != null)
                _Member.ImagePath = pbPersonImage.ImageLocation.ToString();
            else
                _Member.ImagePath = "";

            if (_Member.Save())
            {
                lblTitle.Text = "Update Member";
                lblMemberID.Text = _Member.MemberID.ToString();
                _Mode = enMode.enUpdate;
                this.Text = "Update Member";
                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Trigger the event to send data back to the caller form
                GetMemberID?.Invoke(_Member.MemberID);
            }
            else
                MessageBox.Show("Error : Data is not Saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void lblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                string SelectedFilePath = openFileDialog1.FileName;
                pbPersonImage.Load(SelectedFilePath);
                lblRemoveImage.Visible = true;
            }
        }
        private void lblRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;
            if (radMale.Checked)
                pbPersonImage.Image = Resources.karate__1_;
            else
                pbPersonImage.Image = Resources.martial_arts__1_;
            lblRemoveImage.Visible = false;
        }
        private void radMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.karate__1_;
        }
        private void radFemale_CheckedChanged(object sender, EventArgs e)
        {
            if(pbPersonImage.ImageLocation==null)
                pbPersonImage.Image = Resources.martial_arts__1_;
        }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (txtEmail.Text.Trim() == "")
                return;
            if (!clsValidation.ValidationEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid Email Address Format");
            }
            else
                errorProvider1.SetError(txtEmail, null);
        }
        private void ValidateEmptyTextBox(object sender,CancelEventArgs e)
        {
            TextBox temp = ((TextBox)sender);
            if (string.IsNullOrEmpty(temp.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(temp, "This filed is required!");
            }
            else
                errorProvider1.SetError(temp, null);
        }
    }
}
