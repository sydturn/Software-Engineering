namespace COSC3506_Project
{
    partial class ApplicantForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicantForm));
            this.lblApplicantWelcome = new System.Windows.Forms.Label();
            this.lblCurrentApplications = new System.Windows.Forms.Label();
            this.applicationsListBox = new System.Windows.Forms.ListBox();
            this.btnViewStatus = new System.Windows.Forms.Button();
            this.lblJobPosting = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.postingListBox = new System.Windows.Forms.ListBox();
            this.btnViewDescription = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnSignOut = new System.Windows.Forms.Button();
            this.btnUpdateContactInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblApplicantWelcome
            // 
            this.lblApplicantWelcome.AutoSize = true;
            this.lblApplicantWelcome.Font = new System.Drawing.Font("Segoe UI Semilight", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicantWelcome.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblApplicantWelcome.Location = new System.Drawing.Point(21, 20);
            this.lblApplicantWelcome.Name = "lblApplicantWelcome";
            this.lblApplicantWelcome.Size = new System.Drawing.Size(299, 30);
            this.lblApplicantWelcome.TabIndex = 0;
            this.lblApplicantWelcome.Text = "Welcome, Firstname Lastname";
            // 
            // lblCurrentApplications
            // 
            this.lblCurrentApplications.AutoSize = true;
            this.lblCurrentApplications.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentApplications.Location = new System.Drawing.Point(23, 67);
            this.lblCurrentApplications.Name = "lblCurrentApplications";
            this.lblCurrentApplications.Size = new System.Drawing.Size(101, 15);
            this.lblCurrentApplications.TabIndex = 4;
            this.lblCurrentApplications.Text = "Your applications:\r\n";
            // 
            // applicationsListBox
            // 
            this.applicationsListBox.FormattingEnabled = true;
            this.applicationsListBox.Location = new System.Drawing.Point(26, 95);
            this.applicationsListBox.Name = "applicationsListBox";
            this.applicationsListBox.Size = new System.Drawing.Size(329, 121);
            this.applicationsListBox.TabIndex = 5;
            // 
            // btnViewStatus
            // 
            this.btnViewStatus.Enabled = false;
            this.btnViewStatus.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewStatus.Location = new System.Drawing.Point(361, 95);
            this.btnViewStatus.Name = "btnViewStatus";
            this.btnViewStatus.Size = new System.Drawing.Size(106, 31);
            this.btnViewStatus.TabIndex = 6;
            this.btnViewStatus.Text = "View Status";
            this.btnViewStatus.UseVisualStyleBackColor = true;
            // 
            // lblJobPosting
            // 
            this.lblJobPosting.AutoSize = true;
            this.lblJobPosting.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobPosting.Location = new System.Drawing.Point(23, 228);
            this.lblJobPosting.Name = "lblJobPosting";
            this.lblJobPosting.Size = new System.Drawing.Size(280, 15);
            this.lblJobPosting.TabIndex = 7;
            this.lblJobPosting.Text = "International School of Software Open Job Postings:\r\n";
            // 
            // btnClear
            // 
            this.btnClear.Enabled = false;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(361, 132);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(106, 31);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // postingListBox
            // 
            this.postingListBox.FormattingEnabled = true;
            this.postingListBox.Location = new System.Drawing.Point(26, 256);
            this.postingListBox.Name = "postingListBox";
            this.postingListBox.Size = new System.Drawing.Size(329, 121);
            this.postingListBox.TabIndex = 9;
            // 
            // btnViewDescription
            // 
            this.btnViewDescription.Enabled = false;
            this.btnViewDescription.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewDescription.Location = new System.Drawing.Point(361, 293);
            this.btnViewDescription.Name = "btnViewDescription";
            this.btnViewDescription.Size = new System.Drawing.Size(106, 31);
            this.btnViewDescription.TabIndex = 10;
            this.btnViewDescription.Text = "View Description";
            this.btnViewDescription.UseVisualStyleBackColor = true;
            // 
            // btnApply
            // 
            this.btnApply.Enabled = false;
            this.btnApply.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(361, 256);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(106, 31);
            this.btnApply.TabIndex = 11;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // btnSignOut
            // 
            this.btnSignOut.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignOut.Location = new System.Drawing.Point(200, 390);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(75, 23);
            this.btnSignOut.TabIndex = 12;
            this.btnSignOut.Text = "Logout";
            this.btnSignOut.UseVisualStyleBackColor = true;
            // 
            // btnUpdateContactInfo
            // 
            this.btnUpdateContactInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateContactInfo.Location = new System.Drawing.Point(26, 390);
            this.btnUpdateContactInfo.Name = "btnUpdateContactInfo";
            this.btnUpdateContactInfo.Size = new System.Drawing.Size(168, 23);
            this.btnUpdateContactInfo.TabIndex = 13;
            this.btnUpdateContactInfo.Text = "Update Contact Information";
            this.btnUpdateContactInfo.UseVisualStyleBackColor = true;
            // 
            // applicantForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(492, 435);
            this.Controls.Add(this.btnUpdateContactInfo);
            this.Controls.Add(this.btnSignOut);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnViewDescription);
            this.Controls.Add(this.postingListBox);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblJobPosting);
            this.Controls.Add(this.btnViewStatus);
            this.Controls.Add(this.applicationsListBox);
            this.Controls.Add(this.lblCurrentApplications);
            this.Controls.Add(this.lblApplicantWelcome);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "applicantForm";
            this.Text = "Applicant Portal - EARS - International School of Software";
            this.Load += new System.EventHandler(this.applicantForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblApplicantWelcome;
        private System.Windows.Forms.Label lblCurrentApplications;
        private System.Windows.Forms.ListBox applicationsListBox;
        private System.Windows.Forms.Button btnViewStatus;
        private System.Windows.Forms.Label lblJobPosting;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ListBox postingListBox;
        private System.Windows.Forms.Button btnViewDescription;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnSignOut;
        private System.Windows.Forms.Button btnUpdateContactInfo;
    }
}