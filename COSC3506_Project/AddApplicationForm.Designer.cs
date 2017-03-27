namespace COSC3506_Project
{
    partial class AddApplicationForm
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
            this.applicationList = new System.Windows.Forms.ListView();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(13, 248);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(82, 44);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add App";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_OnClick);
            // 
            // applicationList
            // 
            this.applicationList.Location = new System.Drawing.Point(13, 13);
            this.applicationList.Name = "applicationList";
            this.applicationList.Size = new System.Drawing.Size(892, 217);
            this.applicationList.TabIndex = 1;
            this.applicationList.UseCompatibleStateImageBehavior = false;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(101, 248);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(82, 44);
            this.btnRemove.TabIndex = 2;
            this.btnRemove.Text = "Remove App";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_OnClick);
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(823, 248);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(82, 44);
            this.btnDownload.TabIndex = 3;
            this.btnDownload.Text = "Download";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_OnClick);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(189, 248);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(82, 44);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_OnClick);
            // 
            // AddApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 304);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.applicationList);
            this.Controls.Add(this.btnAdd);
            this.Name = "AddApplicationForm";
            this.Text = "AddApplicationForm";
            this.Activated += new System.EventHandler(this.AddApplicationForm_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddApplicationForm_Closed);
            this.Load += new System.EventHandler(this.AddApplication_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView applicationList;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnBack;
    }
}