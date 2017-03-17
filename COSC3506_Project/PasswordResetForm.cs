﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COSC3506_Project
{
    public partial class PasswordResetForm : Form
    {
        private DBConnection dbConnection;
        private int id;

        public PasswordResetForm(DBConnection dbConnection, int id)
        {
            this.dbConnection = dbConnection;
            this.id = id;

            InitializeComponent();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.TextLength < 1)
            {
                MessageBox.Show(this, "Please enter a new password.", "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtConfirmPassword.TextLength < 1)
            {
                MessageBox.Show(this, "Please confirm the new password.", "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!txtNewPassword.Text.Equals(txtConfirmPassword.Text))
            {
                MessageBox.Show(this, "The paasswords entered do not match.", "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
