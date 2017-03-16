using System;
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
    public partial class SystemAdminForm : Form
    {
        private DBConnection dbConnection;

        public SystemAdminForm(DBConnection dbConnection)
        {
            this.dbConnection = dbConnection;
            InitializeComponent();
        }

        private void systemAdminForm_Load(object sender, EventArgs e)
        {
            usersListView.View = View.Details;
            usersListView.GridLines = true;
            usersListView.FullRowSelect = true;

            usersListView.Columns.Add("Member ID", 150);
            usersListView.Columns.Add("First Name", 150);
            usersListView.Columns.Add("Last Name", 150);

            if (dbConnection.OpenConnection())
            {
                MySqlCommand command = new MySqlCommand();

                command.Connection = dbConnection.getConnection();
                command.CommandText = "SELECT member_id, f_name, l_name FROM member_info";

                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ListViewItem item = new ListViewItem();

                        item.Text = dr[0].ToString();
                        item.SubItems.Add(dr[1].ToString());
                        item.SubItems.Add(dr[2].ToString());

                        usersListView.Items.Add(item);
                    }
                }

                dbConnection.CloseConnection();
                command.Dispose();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddUserForm addUserForm = new AddUserForm(dbConnection);
            addUserForm.ShowDialog();
        }

        private void SystemAdminForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void usersListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (usersListView.SelectedItems.Count > 0)
            {
                btnModifyUser.Enabled = true;
                btnDeleteUser.Enabled = true;
                btnChangePassword.Enabled = true;
            } else
            {
                btnModifyUser.Enabled = false;
                btnDeleteUser.Enabled = false;
                btnChangePassword.Enabled = false;
            }
        }
    }
}
