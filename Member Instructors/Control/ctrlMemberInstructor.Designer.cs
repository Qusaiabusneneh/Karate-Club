namespace Karate.App.Member_Instructors
{
    partial class ctrlMemberInstructor
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblAssignDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMemberInstructorID = new System.Windows.Forms.Label();
            this.grpMemberInstructor = new System.Windows.Forms.GroupBox();
            this.ctrlFindMember1 = new Karate.App.Members.ctrlFindMember();
            this.ctrlInstructorInfo1 = new Karate.App.Instructors.ctrlInstructorInfo();
            this.grpMemberInstructor.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(284, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Assign Date:";
            // 
            // lblAssignDate
            // 
            this.lblAssignDate.AutoSize = true;
            this.lblAssignDate.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAssignDate.ForeColor = System.Drawing.Color.White;
            this.lblAssignDate.Location = new System.Drawing.Point(435, 32);
            this.lblAssignDate.Name = "lblAssignDate";
            this.lblAssignDate.Size = new System.Drawing.Size(44, 29);
            this.lblAssignDate.TabIndex = 1;
            this.lblAssignDate.Text = "[???]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(6, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Member Instructor ID : ";
            // 
            // lblMemberInstructorID
            // 
            this.lblMemberInstructorID.AutoSize = true;
            this.lblMemberInstructorID.Font = new System.Drawing.Font("Cairo", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMemberInstructorID.ForeColor = System.Drawing.Color.White;
            this.lblMemberInstructorID.Location = new System.Drawing.Point(172, 32);
            this.lblMemberInstructorID.Name = "lblMemberInstructorID";
            this.lblMemberInstructorID.Size = new System.Drawing.Size(44, 29);
            this.lblMemberInstructorID.TabIndex = 1;
            this.lblMemberInstructorID.Text = "[???]";
            // 
            // grpMemberInstructor
            // 
            this.grpMemberInstructor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.grpMemberInstructor.Controls.Add(this.label2);
            this.grpMemberInstructor.Controls.Add(this.label1);
            this.grpMemberInstructor.Controls.Add(this.lblAssignDate);
            this.grpMemberInstructor.Controls.Add(this.lblMemberInstructorID);
            this.grpMemberInstructor.Font = new System.Drawing.Font("Cairo", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMemberInstructor.Location = new System.Drawing.Point(1, 0);
            this.grpMemberInstructor.Name = "grpMemberInstructor";
            this.grpMemberInstructor.Size = new System.Drawing.Size(727, 69);
            this.grpMemberInstructor.TabIndex = 2;
            this.grpMemberInstructor.TabStop = false;
            this.grpMemberInstructor.Text = "Member Instructor Info";
            // 
            // ctrlFindMember1
            // 
            this.ctrlFindMember1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ctrlFindMember1.Location = new System.Drawing.Point(2, 73);
            this.ctrlFindMember1.Name = "ctrlFindMember1";
            this.ctrlFindMember1.Size = new System.Drawing.Size(721, 349);
            this.ctrlFindMember1.TabIndex = 3;
            // 
            // ctrlInstructorInfo1
            // 
            this.ctrlInstructorInfo1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ctrlInstructorInfo1.Location = new System.Drawing.Point(0, 124);
            this.ctrlInstructorInfo1.Name = "ctrlInstructorInfo1";
            this.ctrlInstructorInfo1.Size = new System.Drawing.Size(727, 363);
            this.ctrlInstructorInfo1.TabIndex = 4;
            // 
            // ctrlMemberInstructor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.Controls.Add(this.ctrlFindMember1);
            this.Controls.Add(this.ctrlInstructorInfo1);
            this.Controls.Add(this.grpMemberInstructor);
            this.Name = "ctrlMemberInstructor";
            this.Size = new System.Drawing.Size(728, 488);
            this.grpMemberInstructor.ResumeLayout(false);
            this.grpMemberInstructor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAssignDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMemberInstructorID;
        private System.Windows.Forms.GroupBox grpMemberInstructor;
        private Members.ctrlFindMember ctrlFindMember1;
        private Instructors.ctrlInstructorInfo ctrlInstructorInfo1;
    }
}
