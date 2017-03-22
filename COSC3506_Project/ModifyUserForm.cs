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
    public partial class ModifyUserForm : Form
    {
        private int memberID;
        private DBConnection dbConnection;

        public ModifyUserForm(DBConnection dbConnection, int memberID)
        {
            this.dbConnection = dbConnection;
            this.memberID = memberID;

            InitializeComponent();
        }

        private void ModifyUserForm_Load(object sender, EventArgs e)
        {
            securityComboBox.Items.Add("Administrator");
            securityComboBox.Items.Add("Secretary");
            securityComboBox.Items.Add("Committee Member");
            securityComboBox.Items.Add("Chairperson");

            bool available = false;

            if (dbConnection.OpenConnection())
            {
                MySqlCommand command = new MySqlCommand();

                command.Connection = dbConnection.getConnection();
                command.CommandText = "SELECT f_name, l_name, available FROM member_info WHERE member_id=@id";

                command.Parameters.AddWithValue("@id", memberID);

                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        txtFirstName.Text = dr[0].ToString();
                        txtLastName.Text = dr[1].ToString();

                        if (!DBNull.Value.Equals(dr[2]))
                            available = (Boolean)dr[2];
                    }
                }

                if (available)
                    chkAvailable.Checked = true;
                else
                    chkAvailable.Checked = false;

                command.CommandText = "SELECT username, security_status FROM user_login WHERE member_id=@id";

                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        txtUsername.Text = dr[0].ToString();
                        securityComboBox.SelectedIndex = Int32.Parse(dr[1].ToString()) - 1;
                    }
                }

                dbConnection.CloseConnection();
                command.Dispose();
            }
        }

        private void securityComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (securityComboBox.SelectedIndex != 2)
                chkAvailable.Enabled = false;
            else
                chkAvailable.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
