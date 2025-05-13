namespace Karate.App.Member_Instructors.Control
{
    partial class ctrlMemberInstructorInfoWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctrlMemberInstructorInfoWithFilter));
            this.tpMemberInstructor = new System.Windows.Forms.TabControl();
            this.tpSelectMember = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ctrlFindMemberWithFilter1 = new Karate.App.Members.Control.ctrlFindMemberWithFilter();
            this.tpSelectInstructor = new System.Windows.Forms.TabPage();
            this.ctrlFindIndtructorWithFilter1 = new Karate.App.Instructors.ctrlFindIndtructorWithFilter();
            this.tpMemberInstructor.SuspendLayout();
            this.tpSelectMember.SuspendLayout();
            this.tpSelectInstructor.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpMemberInstructor
            // 
            this.tpMemberInstructor.Controls.Add(this.tpSelectMember);
            this.tpMemberInstructor.Controls.Add(this.tpSelectInstructor);
            this.tpMemberInstructor.Location = new System.Drawing.Point(0, 0);
            this.tpMemberInstructor.Name = "tpMemberInstructor";
            this.tpMemberInstructor.SelectedIndex = 0;
            this.tpMemberInstructor.Size = new System.Drawing.Size(731, 516);
            this.tpMemberInstructor.TabIndex = 0;
            this.tpMemberInstructor.SelectedIndexChanged += new System.EventHandler(this.tpMemberInstructor_SelectedIndexChanged);
            // 
            // tpSelectMember
            // 
            this.tpSelectMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tpSelectMember.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tpSelectMember.Controls.Add(this.btnNext);
            this.tpSelectMember.Controls.Add(this.ctrlFindMemberWithFilter1);
            this.tpSelectMember.Location = new System.Drawing.Point(4, 22);
            this.tpSelectMember.Name = "tpSelectMember";
            this.tpSelectMember.Padding = new System.Windows.Forms.Padding(3);
            this.tpSelectMember.Size = new System.Drawing.Size(723, 490);
            this.tpSelectMember.TabIndex = 0;
            this.tpSelectMember.Text = "Select Member";
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Font = new System.Drawing.Font("Cairo", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.Image")));
            this.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNext.Location = new System.Drawing.Point(462, 370);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(134, 42);
            this.btnNext.TabIndex = 128;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrlFindMemberWithFilter1
            // 
            this.ctrlFindMemberWithFilter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ctrlFindMemberWithFilter1.FilterEnable = true;
            this.ctrlFindMemberWithFilter1.Location = new System.Drawing.Point(0, 0);
            this.ctrlFindMemberWithFilter1.Name = "ctrlFindMemberWithFilter1";
            this.ctrlFindMemberWithFilter1.ShowMemberAdd = false;
            this.ctrlFindMemberWithFilter1.Size = new System.Drawing.Size(727, 437);
            this.ctrlFindMemberWithFilter1.TabIndex = 0;
            this.ctrlFindMemberWithFilter1.OnMemberSelected += new System.EventHandler<Karate.App.Members.Control.ctrlFindMemberWithFilter.MemberSelectedEventArgs>(this.ctrlFindMemberWithFilter1_OnMemberSelected);
            // 
            // tpSelectInstructor
            // 
            this.tpSelectInstructor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.tpSelectInstructor.Controls.Add(this.ctrlFindIndtructorWithFilter1);
            this.tpSelectInstructor.Location = new System.Drawing.Point(4, 22);
            this.tpSelectInstructor.Name = "tpSelectInstructor";
            this.tpSelectInstructor.Padding = new System.Windows.Forms.Padding(3);
            this.tpSelectInstructor.Size = new System.Drawing.Size(723, 490);
            this.tpSelectInstructor.TabIndex = 1;
            this.tpSelectInstructor.Text = "Select Instructor";
            // 
            // ctrlFindIndtructorWithFilter1
            // 
            this.ctrlFindIndtructorWithFilter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ctrlFindIndtructorWithFilter1.FilterEnable = true;
            this.ctrlFindIndtructorWithFilter1.Location = new System.Drawing.Point(-3, 0);
            this.ctrlFindIndtructorWithFilter1.Name = "ctrlFindIndtructorWithFilter1";
            this.ctrlFindIndtructorWithFilter1.ShowAddInstructor = true;
            this.ctrlFindIndtructorWithFilter1.Size = new System.Drawing.Size(731, 479);
            this.ctrlFindIndtructorWithFilter1.TabIndex = 0;
            this.ctrlFindIndtructorWithFilter1.OnInstructorSelected += new System.EventHandler<Karate.App.Instructors.ctrlFindIndtructorWithFilter.InstructorSelectedEventArgs>(this.ctrlFindIndtructorWithFilter1_OnInstructorSelected_1);
            // 
            // ctrlMemberInstructorInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Controls.Add(this.tpMemberInstructor);
            this.Name = "ctrlMemberInstructorInfoWithFilter";
            this.Size = new System.Drawing.Size(734, 522);
            this.tpMemberInstructor.ResumeLayout(false);
            this.tpSelectMember.ResumeLayout(false);
            this.tpSelectInstructor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tpMemberInstructor;
        private System.Windows.Forms.TabPage tpSelectMember;
        private Members.Control.ctrlFindMemberWithFilter ctrlFindMemberWithFilter1;
        private System.Windows.Forms.TabPage tpSelectInstructor;
        private System.Windows.Forms.Button btnNext;
        private Instructors.ctrlFindIndtructorWithFilter ctrlFindIndtructorWithFilter1;
    }
}
