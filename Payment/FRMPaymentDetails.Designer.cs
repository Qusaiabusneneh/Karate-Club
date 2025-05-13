namespace Karate.App.Payment
{
    partial class FRMPaymentDetails
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
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlMemberPayment1 = new Karate.App.Payment.Control.ctrlMemberPayment();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cairo", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(251, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 40);
            this.label1.TabIndex = 4;
            this.label1.Text = "Payment Details";
            // 
            // ctrlMemberPayment1
            // 
            this.ctrlMemberPayment1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ctrlMemberPayment1.Location = new System.Drawing.Point(3, 52);
            this.ctrlMemberPayment1.Name = "ctrlMemberPayment1";
            this.ctrlMemberPayment1.Size = new System.Drawing.Size(719, 253);
            this.ctrlMemberPayment1.TabIndex = 5;
            // 
            // FRMPaymentDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ClientSize = new System.Drawing.Size(722, 304);
            this.Controls.Add(this.ctrlMemberPayment1);
            this.Controls.Add(this.label1);
            this.Name = "FRMPaymentDetails";
            this.Text = "Payment Details";
            this.Load += new System.EventHandler(this.FRMPaymentDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Control.ctrlMemberPayment ctrlMemberPayment1;
    }
}