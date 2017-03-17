﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace COSC3506_Project
{
    public partial class AddUserForm : Form
    {
        private DBConnection dbConnection;

        public AddUserForm(DBConnection dbConnection)
        {
            this.dbConnection = dbConnection;
            InitializeComponent();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            int securityStatus = 0;

            switch(securityComboBox.Text)
            {
                case "Administrator":
                    securityStatus = 1;
                    break;
                case "Secretary":
                    securityStatus = 2;
                    break;
                case "Committee Member":
                    securityStatus = 3;
                    break;
                case "Chairperson":
                    securityStatus = 4;
                    break;
            }

            if (dbConnection.OpenConnection())
            {
                int id = 0;

                MySqlCommand command = new MySqlCommand();

                command.Connection = dbConnection.getConnection();
                command.CommandText = "INSERT INTO user_login (username, password, security_status) VALUES (@username, @password, @securityStatus)";

                command.Parameters.AddWithValue("@username", txtUsername.Text);
                command.Parameters.AddWithValue("@password", txtPassword.Text);
                command.Parameters.AddWithValue("@securityStatus", securityStatus);

                command.ExecuteNonQuery();

                command.CommandText = "SELECT member_id FROM user_login WHERE username=@username";

                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                        id = Int32.Parse(dr[0].ToString());
                }

                command.CommandText = "INSERT INTO member_info (member_id, f_name, l_name) VALUES (@id, @firstName, @lastName)";
                command.Parameters.AddWithValue("@id", id);
                command.Parameters.AddWithValue("@firstName", txtFirstName.Text);
                command.Parameters.AddWithValue("@lastName", txtLastName.Text);

                command.ExecuteNonQuery();

                dbConnection.CloseConnection();
                command.Dispose();

                MessageBox.Show(this, "User successfully added.", "User Added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void AddUserForm_Load(object sender, EventArgs e)
        {
            securityComboBox.Items.Add("Administrator");
            securityComboBox.Items.Add("Secretary");
            securityComboBox.Items.Add("Committee Member");
            securityComboBox.Items.Add("Chairperson");

            securityComboBox.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
