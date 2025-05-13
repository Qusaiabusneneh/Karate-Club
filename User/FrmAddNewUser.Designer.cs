namespace Karate.App.User
{
    partial class FrmAddNewUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddNewUser));
            this.tcUserInfo = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ctrlFindPersonWithFilter1 = new Karate.App.People.ctrlFindPersonWithFilter();
            this.btnPersonInfoNext = new System.Windows.Forms.Button();
            this.tpLoginInfo = new System.Windows.Forms.TabPage();
            this.gbPermissoions = new System.Windows.Forms.GroupBox();
            this.chkPayment = new System.Windows.Forms.CheckBox();
            this.chkBeltTest = new System.Windows.Forms.CheckBox();
            this.chkBeltRanks = new System.Windows.Forms.CheckBox();
            this.chkMangeSubscription = new System.Windows.Forms.CheckBox();
            this.chkManageInstructorMembers = new System.Windows.Forms.CheckBox();
            this.chkManageInstructors = new System.Windows.Forms.CheckBox();
            this.chkMangeUsers = new System.Windows.Forms.CheckBox();
            this.chkManageMembers = new System.Windows.Forms.CheckBox();
            this.chkAllPermission = new System.Windows.Forms.CheckBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblUserID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.chk_CheckedChanged = new System.Windows.Forms.CheckBox();
            this.tcUserInfo.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tpLoginInfo.SuspendLayout();
            this.gbPermissoions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tcUserInfo
            // 
            this.tcUserInfo.Controls.Add(this.tabPage1);
            this.tcUserInfo.Controls.Add(this.tpLoginInfo);
            this.tcUserInfo.Font = new System.Drawing.Font("Microsoft New Tai Lue", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcUserInfo.Location = new System.Drawing.Point(5, 72);
            this.tcUserInfo.Name = "tcUserInfo";
            this.tcUserInfo.SelectedIndex = 0;
            this.tcUserInfo.Size = new System.Drawing.Size(761, 586);
            this.tcUserInfo.TabIndex = 121;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.ctrlFindPersonWithFilter1);
            this.tabPage1.Controls.Add(this.btnPersonInfoNext);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(753, 558);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Member Info";
            // 
            // ctrlFindPersonWithFilter1
            // 
            this.ctrlFindPersonWithFilter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ctrlFindPersonWithFilter1.FilterEnabled = true;
            this.ctrlFindPersonWithFilter1.Location = new System.Drawing.Point(0, 0);
            this.ctrlFindPersonWithFilter1.Name = "ctrlFindPersonWithFilter1";
            this.ctrlFindPersonWithFilter1.ShowPersonAdded = true;
            this.ctrlFindPersonWithFilter1.Size = new System.Drawing.Size(728, 499);
            this.ctrlFindPersonWithFilter1.TabIndex = 121;
            // 
            // btnPersonInfoNext
            // 
            this.btnPersonInfoNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPersonInfoNext.Font = new System.Drawing.Font("Cairo", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPersonInfoNext.Image = ((System.Drawing.Image)(resources.GetObject("btnPersonInfoNext.Image")));
            this.btnPersonInfoNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPersonInfoNext.Location = new System.Drawing.Point(584, 507);
            this.btnPersonInfoNext.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPersonInfoNext.Name = "btnPersonInfoNext";
            this.btnPersonInfoNext.Size = new System.Drawing.Size(157, 42);
            this.btnPersonInfoNext.TabIndex = 120;
            this.btnPersonInfoNext.Text = "Next";
            this.btnPersonInfoNext.UseVisualStyleBackColor = true;
            this.btnPersonInfoNext.Click += new System.EventHandler(this.btnPersonInfoNext_Click);
            // 
            // tpLoginInfo
            // 
            this.tpLoginInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tpLoginInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tpLoginInfo.Controls.Add(this.gbPermissoions);
            this.tpLoginInfo.Controls.Add(this.pictureBox2);
            this.tpLoginInfo.Controls.Add(this.lblUserID);
            this.tpLoginInfo.Controls.Add(this.label4);
            this.tpLoginInfo.Controls.Add(this.chk_CheckedChanged);
            this.tpLoginInfo.Controls.Add(this.chkIsActive);
            this.tpLoginInfo.Controls.Add(this.txtUserName);
            this.tpLoginInfo.Controls.Add(this.txtConfirmPassword);
            this.tpLoginInfo.Controls.Add(this.label2);
            this.tpLoginInfo.Controls.Add(this.label3);
            this.tpLoginInfo.Controls.Add(this.label5);
            this.tpLoginInfo.Controls.Add(this.txtPassword);
            this.tpLoginInfo.Controls.Add(this.pictureBox1);
            this.tpLoginInfo.Controls.Add(this.pictureBox8);
            this.tpLoginInfo.Controls.Add(this.pictureBox3);
            this.tpLoginInfo.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpLoginInfo.Location = new System.Drawing.Point(4, 24);
            this.tpLoginInfo.Name = "tpLoginInfo";
            this.tpLoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tpLoginInfo.Size = new System.Drawing.Size(753, 558);
            this.tpLoginInfo.TabIndex = 1;
            this.tpLoginInfo.Text = "Login Info";
            // 
            // gbPermissoions
            // 
            this.gbPermissoions.Controls.Add(this.chkPayment);
            this.gbPermissoions.Controls.Add(this.chkBeltTest);
            this.gbPermissoions.Controls.Add(this.chkBeltRanks);
            this.gbPermissoions.Controls.Add(this.chkMangeSubscription);
            this.gbPermissoions.Controls.Add(this.chkManageInstructorMembers);
            this.gbPermissoions.Controls.Add(this.chkManageInstructors);
            this.gbPermissoions.Controls.Add(this.chkMangeUsers);
            this.gbPermissoions.Controls.Add(this.chkManageMembers);
            this.gbPermissoions.Controls.Add(this.chkAllPermission);
            this.gbPermissoions.ForeColor = System.Drawing.Color.White;
            this.gbPermissoions.Location = new System.Drawing.Point(485, 6);
            this.gbPermissoions.Name = "gbPermissoions";
            this.gbPermissoions.Size = new System.Drawing.Size(258, 384);
            this.gbPermissoions.TabIndex = 144;
            this.gbPermissoions.TabStop = false;
            this.gbPermissoions.Text = "Permissions";
            // 
            // chkPayment
            // 
            this.chkPayment.AutoSize = true;
            this.chkPayment.ForeColor = System.Drawing.Color.White;
            this.chkPayment.Location = new System.Drawing.Point(6, 342);
            this.chkPayment.Name = "chkPayment";
            this.chkPayment.Size = new System.Drawing.Size(162, 34);
            this.chkPayment.TabIndex = 0;
            this.chkPayment.Text = "Manage Payments";
            this.chkPayment.UseVisualStyleBackColor = true;
            // 
            // chkBeltTest
            // 
            this.chkBeltTest.AutoSize = true;
            this.chkBeltTest.ForeColor = System.Drawing.Color.White;
            this.chkBeltTest.Location = new System.Drawing.Point(6, 304);
            this.chkBeltTest.Name = "chkBeltTest";
            this.chkBeltTest.Size = new System.Drawing.Size(148, 34);
            this.chkBeltTest.TabIndex = 0;
            this.chkBeltTest.Text = "Manage BeltTest";
            this.chkBeltTest.UseVisualStyleBackColor = true;
            // 
            // chkBeltRanks
            // 
            this.chkBeltRanks.AutoSize = true;
            this.chkBeltRanks.ForeColor = System.Drawing.Color.White;
            this.chkBeltRanks.Location = new System.Drawing.Point(6, 264);
            this.chkBeltRanks.Name = "chkBeltRanks";
            this.chkBeltRanks.Size = new System.Drawing.Size(162, 34);
            this.chkBeltRanks.TabIndex = 0;
            this.chkBeltRanks.Text = "Manage BeltRanks";
            this.chkBeltRanks.UseVisualStyleBackColor = true;
            // 
            // chkMangeSubscription
            // 
            this.chkMangeSubscription.AutoSize = true;
            this.chkMangeSubscription.ForeColor = System.Drawing.Color.White;
            this.chkMangeSubscription.Location = new System.Drawing.Point(6, 224);
            this.chkMangeSubscription.Name = "chkMangeSubscription";
            this.chkMangeSubscription.Size = new System.Drawing.Size(180, 34);
            this.chkMangeSubscription.TabIndex = 0;
            this.chkMangeSubscription.Text = "Manage Subscription";
            this.chkMangeSubscription.UseVisualStyleBackColor = true;
            // 
            // chkManageInstructorMembers
            // 
            this.chkManageInstructorMembers.AutoSize = true;
            this.chkManageInstructorMembers.ForeColor = System.Drawing.Color.White;
            this.chkManageInstructorMembers.Location = new System.Drawing.Point(6, 184);
            this.chkManageInstructorMembers.Name = "chkManageInstructorMembers";
            this.chkManageInstructorMembers.Size = new System.Drawing.Size(238, 34);
            this.chkManageInstructorMembers.TabIndex = 0;
            this.chkManageInstructorMembers.Text = "Manage Member /Instructors";
            this.chkManageInstructorMembers.UseVisualStyleBackColor = true;
            // 
            // chkManageInstructors
            // 
            this.chkManageInstructors.AutoSize = true;
            this.chkManageInstructors.ForeColor = System.Drawing.Color.White;
            this.chkManageInstructors.Location = new System.Drawing.Point(6, 144);
            this.chkManageInstructors.Name = "chkManageInstructors";
            this.chkManageInstructors.Size = new System.Drawing.Size(169, 34);
            this.chkManageInstructors.TabIndex = 0;
            this.chkManageInstructors.Text = "Manage Instructors";
            this.chkManageInstructors.UseVisualStyleBackColor = true;
            // 
            // chkMangeUsers
            // 
            this.chkMangeUsers.AutoSize = true;
            this.chkMangeUsers.ForeColor = System.Drawing.Color.White;
            this.chkMangeUsers.Location = new System.Drawing.Point(6, 104);
            this.chkMangeUsers.Name = "chkMangeUsers";
            this.chkMangeUsers.Size = new System.Drawing.Size(131, 34);
            this.chkMangeUsers.TabIndex = 0;
            this.chkMangeUsers.Text = "Manage Users";
            this.chkMangeUsers.UseVisualStyleBackColor = true;
            // 
            // chkManageMembers
            // 
            this.chkManageMembers.AutoSize = true;
            this.chkManageMembers.ForeColor = System.Drawing.Color.White;
            this.chkManageMembers.Location = new System.Drawing.Point(6, 67);
            this.chkManageMembers.Name = "chkManageMembers";
            this.chkManageMembers.Size = new System.Drawing.Size(158, 34);
            this.chkManageMembers.TabIndex = 0;
            this.chkManageMembers.Text = "Manage Members";
            this.chkManageMembers.UseVisualStyleBackColor = true;
            // 
            // chkAllPermission
            // 
            this.chkAllPermission.AutoSize = true;
            this.chkAllPermission.ForeColor = System.Drawing.Color.White;
            this.chkAllPermission.Location = new System.Drawing.Point(6, 31);
            this.chkAllPermission.Name = "chkAllPermission";
            this.chkAllPermission.Size = new System.Drawing.Size(141, 34);
            this.chkAllPermission.TabIndex = 0;
            this.chkAllPermission.Text = "All Permissions";
            this.chkAllPermission.UseVisualStyleBackColor = true;
            this.chkAllPermission.CheckedChanged += new System.EventHandler(this.chkAllPermission_CheckedChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(232, 85);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(31, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 143;
            this.pictureBox2.TabStop = false;
            // 
            // lblUserID
            // 
            this.lblUserID.AutoSize = true;
            this.lblUserID.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserID.ForeColor = System.Drawing.Color.White;
            this.lblUserID.Location = new System.Drawing.Point(272, 85);
            this.lblUserID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUserID.Name = "lblUserID";
            this.lblUserID.Size = new System.Drawing.Size(34, 30);
            this.lblUserID.TabIndex = 142;
            this.lblUserID.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(141, 85);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 30);
            this.label4.TabIndex = 141;
            this.label4.Text = "UserID:";
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.ForeColor = System.Drawing.Color.White;
            this.chkIsActive.Location = new System.Drawing.Point(232, 241);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(90, 34);
            this.chkIsActive.TabIndex = 140;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // txtUserName
            // 
            this.txtUserName.Font = new System.Drawing.Font("Cairo", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Location = new System.Drawing.Point(270, 123);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUserName.MaxLength = 50;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(167, 32);
            this.txtUserName.TabIndex = 131;
            this.txtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserName_Validating);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Font = new System.Drawing.Font("Cairo", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPassword.Location = new System.Drawing.Point(270, 195);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtConfirmPassword.MaxLength = 50;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(167, 32);
            this.txtConfirmPassword.TabIndex = 137;
            this.txtConfirmPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtConfirmPassword_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(114, 123);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 30);
            this.label2.TabIndex = 133;
            this.label2.Text = "UserName:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(71, 195);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 30);
            this.label3.TabIndex = 138;
            this.label3.Text = "Confirm Password:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cairo", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(121, 159);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 30);
            this.label5.TabIndex = 134;
            this.label5.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Cairo", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(270, 159);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPassword.MaxLength = 50;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(167, 32);
            this.txtPassword.TabIndex = 132;
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(232, 195);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(31, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 139;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(232, 121);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(31, 26);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox8.TabIndex = 136;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(232, 158);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(31, 26);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 135;
            this.pictureBox3.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Cairo", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(236, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(382, 60);
            this.lblTitle.TabIndex = 122;
            this.lblTitle.Text = "Edit Application Type";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Cairo", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(640, 666);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 44);
            this.btnSave.TabIndex = 123;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Font = new System.Drawing.Font("Cairo", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(506, 666);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(126, 44);
            this.btnClose.TabIndex = 124;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // chk_CheckedChanged
            // 
            this.chk_CheckedChanged.AutoSize = true;
            this.chk_CheckedChanged.Checked = true;
            this.chk_CheckedChanged.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_CheckedChanged.ForeColor = System.Drawing.Color.White;
            this.chk_CheckedChanged.Location = new System.Drawing.Point(353, 242);
            this.chk_CheckedChanged.Name = "chk_CheckedChanged";
            this.chk_CheckedChanged.Size = new System.Drawing.Size(84, 34);
            this.chk_CheckedChanged.TabIndex = 140;
            this.chk_CheckedChanged.Text = "Change";
            this.chk_CheckedChanged.UseVisualStyleBackColor = true;
            this.chk_CheckedChanged.CheckedChanged += new System.EventHandler(this.chk_CheckedChanged_CheckedChanged);
            // 
            // FrmAddNewUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(778, 717);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.tcUserInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmAddNewUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add New User";
            this.Load += new System.EventHandler(this.FrmAddNewUser_Load);
            this.tcUserInfo.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tpLoginInfo.ResumeLayout(false);
            this.tpLoginInfo.PerformLayout();
            this.gbPermissoions.ResumeLayout(false);
            this.gbPermissoions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcUserInfo;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnPersonInfoNext;
        private System.Windows.Forms.TabPage tpLoginInfo;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblUserID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox gbPermissoions;
        private System.Windows.Forms.CheckBox chkAllPermission;
        private System.Windows.Forms.CheckBox chkBeltTest;
        private System.Windows.Forms.CheckBox chkBeltRanks;
        private System.Windows.Forms.CheckBox chkMangeSubscription;
        private System.Windows.Forms.CheckBox chkManageInstructorMembers;
        private System.Windows.Forms.CheckBox chkManageInstructors;
        private System.Windows.Forms.CheckBox chkMangeUsers;
        private System.Windows.Forms.CheckBox chkManageMembers;
        private System.Windows.Forms.CheckBox chkPayment;
        private People.ctrlFindPersonWithFilter ctrlFindPersonWithFilter1;
        private System.Windows.Forms.CheckBox chk_CheckedChanged;
    }
}