namespace COSC3506_Project
{
    partial class ViewApplicationForm
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
            this.applicationList = new System.Windows.Forms.ListView();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnComment = new System.Windows.Forms.Button();
            this.btnTag = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // applicationList
            // 
            this.applicationList.Location = new System.Drawing.Point(12, 12);
            this.applicationList.Name = "applicationList";
            this.applicationList.Size = new System.Drawing.Size(590, 194);
            this.applicationList.TabIndex = 0;
            this.applicationList.UseCompatibleStateImageBehavior = false;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(444, 212);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(76, 39);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // btnComment
            // 
            this.btnComment.Enabled = false;
            this.btnComment.Location = new System.Drawing.Point(12, 210);
            this.btnComment.Name = "btnComment";
            this.btnComment.Size = new System.Drawing.Size(75, 39);
            this.btnComment.TabIndex = 2;
            this.btnComment.Text = "Comments";
            this.btnComment.UseVisualStyleBackColor = true;
            // 
            // btnTag
            // 
            this.btnTag.Enabled = false;
            this.btnTag.Location = new System.Drawing.Point(93, 210);
            this.btnTag.Name = "btnTag";
            this.btnTag.Size = new System.Drawing.Size(75, 39);
            this.btnTag.TabIndex = 3;
            this.btnTag.Text = "Tag";
            this.btnTag.UseVisualStyleBackColor = true;
            // 
            // btnApprove
            // 
            this.btnApprove.Enabled = false;
            this.btnApprove.Location = new System.Drawing.Point(174, 210);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(75, 39);
            this.btnApprove.TabIndex = 4;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = true;
            // 
            // btnDownload
            // 
            this.btnDownload.Enabled = false;
            this.btnDownload.Location = new System.Drawing.Point(526, 212);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(76, 39);
            this.btnDownload.TabIndex = 5;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            // 
            // ViewApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 261);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnTag);
            this.Controls.Add(this.btnComment);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.applicationList);
            this.Name = "ViewApplicationForm";
            this.Text = "ViewApplicationsForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView applicationList;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnComment;
        private System.Windows.Forms.Button btnTag;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnDownload;
    }
}