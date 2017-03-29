namespace COSC3506_Project
{
    partial class CommitteeForm
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
            this.viewApp = new System.Windows.Forms.Button();
            this.jobList = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // viewApp
            // 
            this.viewApp.Location = new System.Drawing.Point(12, 213);
            this.viewApp.Name = "viewApp";
            this.viewApp.Size = new System.Drawing.Size(136, 36);
            this.viewApp.TabIndex = 0;
            this.viewApp.Text = "View Applications";
            this.viewApp.UseVisualStyleBackColor = true;
            // 
            // jobList
            // 
            this.jobList.Location = new System.Drawing.Point(12, 12);
            this.jobList.Name = "jobList";
            this.jobList.Size = new System.Drawing.Size(587, 195);
            this.jobList.TabIndex = 1;
            this.jobList.UseCompatibleStateImageBehavior = false;
            // 
            // CommitteeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 261);
            this.Controls.Add(this.jobList);
            this.Controls.Add(this.viewApp);
            this.Name = "CommitteeForm";
            this.Text = "CommitteeForm";
            this.Load += new System.EventHandler(this.CommitteeForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button viewApp;
        private System.Windows.Forms.ListView jobList;
    }
}