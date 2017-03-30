using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using MySql.Data.MySqlClient;
using System.IO;

namespace COSC3506_Project
{
    public partial class createCommentsForm : Form
    {
        private DBConnection dbConnection;
        private string commentId; //should be incremented in the database, gottta change that and figure out how to impliment
        private string appId;
        private string memberId;
        private string filePath;
        private string fileName;

        public createCommentsForm(DBConnection dbConnection, string appId, string memberId)
        {
            appId = this.appId; //somehow get the application id of the application we currently have selected
            memberId = this.memberId; //get member ID of he who is currently logged in somehow
            this.dbConnection = dbConnection;
            InitializeComponent();
        }
        private void btnCancel_OnClick(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnCreate_OnClick(object sender, EventArgs e)
        {
            try
            {
                string comment = commentBox.Text;

                if (comment == null)
                    throw new Exception();

                if (dbConnection.OpenConnection())
                {
                    MySqlCommand command = new MySqlCommand();

                    command.Connection = dbConnection.getConnection();
                    command.CommandText = "INSERT INTO comments (comment_id, application_id, comment_text, member_id) VALUES (@comment_id, @application_id, @comment_text, @member_id)";
                    command.Parameters.AddWithValue("@comment_id", commentId);
                    command.Parameters.AddWithValue("@application_id", appId);
                    command.Parameters.AddWithValue("@@comment_text", comment);
                    command.Parameters.AddWithValue("@member_id", memberId);

                    command.ExecuteNonQuery();
                    dbConnection.CloseConnection();
                    command.Dispose();
                }
                MessageBox.Show("Comment posted!", "EARS System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch
            { Console.WriteLine("All fields must be complete..."); }
        }
    }
}
