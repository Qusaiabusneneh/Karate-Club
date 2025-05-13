using DevExpress.Utils.CommonDialogs;
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

namespace Karate.App.People
{
    public partial class FRMAddNewPeople : Form
    {
        public enum enMode {enAddNew=0,enUpdate=1}
        private enMode _Mode = enMode.enAddNew;
        public enum enGender { Male=1,Female=0};
        private enGender _Gender= enGender.Male;
        public delegate void DataBackHandler(object sender, int? PersonID);
        public event DataBackHandler DataBack;
        private int? _PersonID = null;
        private clsPerson _Person;
        public FRMAddNewPeople()
        {
            InitializeComponent();
            _Mode = enMode.enAddNew;
        }
        public FRMAddNewPeople(int? PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
            _Mode = enMode.enUpdate;
        }
        private void _ResetfulDeafultValues()
        {
            if (_Mode == enMode.enAddNew)
            {
                lblTitle.Text = "Add New Person";
                _Person = new clsPerson();
            }
            else
                lblTitle.Text = "Update Person info";

            if(radMale.Checked)
                pbPersonImage.Image = Resources.karate__1_;
            else
                pbPersonImage.Image = Resources.martial_arts__1_;
           
            lblRemoveImage.Visible = (pbPersonImage.ImageLocation != null);
            txtAddress.Text= string.Empty;
            txtEmail.Text= string.Empty;
            txtName.Text= string.Empty;
            txtPhone.Text= string.Empty;
            dtpDateOfBirth.Value= DateTime.Now;
            lblPersonID.Text= string.Empty;
            radMale.Checked = true;
        }
        private void _LoadData()
        {
            _Person = clsPerson.Find(_PersonID);
            if (_Person == null)
            {
                MessageBox.Show("No Person with ID = " + _PersonID, "Person not found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            txtName.Text= _Person.Name;
            txtPhone.Text= _Person.Phone;
            txtPhone.Text= _Person.Phone;
            txtAddress.Text= _Person.Address;
            dtpDateOfBirth.Value=_Person.DateOfBirth;
            txtEmail.Text = _Person.Email;

            if ((byte)_Person.Gender == 1)
                radMale.Checked = true;
            else
                radFemale.Checked = true;

            if (_Person.ImagePath != "")
                pbPersonImage.ImageLocation = _Person.ImagePath;
            lblRemoveImage.Visible = (_Person.ImagePath != "");
        }
        private void FRMAddNewPeople_Load(object sender, EventArgs e)
        {
            _ResetfulDeafultValues();
            if (_Mode == enMode.enUpdate) 
                _LoadData();
        }
        private bool _HandleImagePerson()
        {
            if (_Person.ImagePath != pbPersonImage.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException)
                    {

                    }
                }
                if (pbPersonImage.ImageLocation != null)
                {
                    string SourceImageFile = pbPersonImage.ImageLocation.ToString();
                    if (clsUtil.CopyImageToProjectImageFolder(ref SourceImageFile))
                    {
                        pbPersonImage.ImageLocation = SourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                }
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fildes are not valide!, put the mouse over the red icon(s) to see the error", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_HandleImagePerson())
                return;

            _Person.Email=txtEmail.Text;
            _Person.Name=txtName.Text;
            _Person.Address=txtAddress.Text;
            _Person.DateOfBirth=dtpDateOfBirth.Value;
            _Person.Phone=txtPhone.Text;

            if (radMale.Checked)
                _Person.Gender = clsPerson.enGender.Male;
            else
                _Person.Gender =clsPerson.enGender.Female;

            if (pbPersonImage.ImageLocation != null)
                _Person.ImagePath = pbPersonImage.ImageLocation.ToString();
            else
                _Person.ImagePath = "";

            if(_Person.Save())
            {
                lblPersonID.Text = _PersonID.ToString();
                _Mode = enMode.enUpdate;
                this.Text = "Update Person info ";
                MessageBox.Show("Data Saved Successfully", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                DataBack?.Invoke(this, _Person.PersonID);
            }
            else
                MessageBox.Show("Error : Data is not Saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void lblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
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
            if (pbPersonImage.ImageLocation == null)
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
        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
