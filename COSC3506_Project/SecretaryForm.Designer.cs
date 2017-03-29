namespace COSC3506_Project
{
    partial class SecretaryForm
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.jobList = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(12, 185);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(108, 51);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add Job";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_OnClick);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(126, 185);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(108, 51);
            this.btnRemove.TabIndex = 1;
            this.btnRemove.Text = "Remove Job";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_OnClick);
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(240, 185);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(108, 51);
            this.btnView.TabIndex = 2;
            this.btnView.Text = "View Apps";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_OnClick);
            // 
            // jobList
            // 
            this.jobList.Location = new System.Drawing.Point(12, 12);
            this.jobList.Name = "jobList";
            this.jobList.Size = new System.Drawing.Size(435, 167);
            this.jobList.TabIndex = 3;
            this.jobList.UseCompatibleStateImageBehavior = false;
            this.jobList.SelectedIndexChanged += new System.EventHandler(this.jobList_SelectedIndexChanged);
            // 
            // SecretaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 248);
            this.Controls.Add(this.jobList);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Name = "SecretaryForm";
            this.Text = "SecretaryForm";
            this.Activated += new System.EventHandler(this.SecretaryForm_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SecretaryForm_FormClosed);
            this.Load += new System.EventHandler(this.SecretaryForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.ListView jobList;
    }
}