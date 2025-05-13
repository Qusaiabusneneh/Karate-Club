using Karate.App.Members;
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
    public partial class ctrlPersonCard : UserControl
    {
        private int? _PersonID = null;
        public int? PersonID
        {
            get => _PersonID;
            set
            {
                _PersonID = value;
            }
        }
        private clsPerson _Person;
        public clsPerson SelectedPersonInfo => _Person;
        public void _RestfulDefaultValue()
        {
            this._Person = null;
            this._PersonID = null;
            lblAddress.Text = "[???]";
            lblDateOfBirth.Text = "[???]";
            lblEmail.Text = "[???]";
            lblGendor.Text = "[???]";
            lblName.Text = "[???]";
            lblPersonID.Text = "[???]";
            lblPhone.Text = "[???]";
        }
        private void _LoadPersonImage()
        {
            if (_Person.Gender == 0)
                pbImage.Image = Resources.martial_arts__1_;
            else
                pbImage.Image = Resources.karate__1_;
            
            string ImagePath = _Person.ImagePath;
            if (ImagePath != "")
            {
                if(File.Exists(ImagePath))
                    pbImage.ImageLocation= ImagePath;
                else
                    MessageBox.Show("Could not find this image = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void _FillPersonInfo()
        {
            lblEditPersonInfo.Enabled = true;
            _PersonID = _Person.PersonID;
            lblAddress.Text = _Person.Address;
            lblDateOfBirth.Text = _Person.DateOfBirth.ToString();
            lblEmail.Text = _Person.Email;
            lblGendor.Text = (byte)_Person.Gender == 1 ? "Male" : "Female";
            lblName.Text = _Person.Name;
            lblPhone.Text = _Person.Phone;
            lblPersonID.Text = _Person.PersonID.ToString();
            _LoadPersonImage();
        }
        public void LoadPersonInfo(int? PersonID)
        {
            this._PersonID= PersonID;
            if(!PersonID.HasValue)
            {
                MessageBox.Show("There is no User with this ID", "Missing User",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                _RestfulDefaultValue();
                return;
            }

            _Person = clsPerson.Find(this._PersonID);

            if (_Person == null)
            {
                _RestfulDefaultValue();
                MessageBox.Show("No Person with Person ID = " + PersonID.ToString(), "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }
        public ctrlPersonCard()
        {
            InitializeComponent();
        }
        private void lblEditPersonInfo_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FRMAddNewMember fRM = new FRMAddNewMember(_PersonID);
            fRM.ShowDialog();
            LoadPersonInfo(_PersonID);
        }
    }
}
