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
    public partial class CommentsForm : Form
    {
        private DBConnection dbConnection;
        private string memberId;
        private string appId;
        private Boolean viewAppsForm = false;

        public CommentsForm(DBConnection dbConnection)
        {
            this.dbConnection = dbConnection;
            InitializeComponent();
        }

        private void CommentsForm_Load(object sender, EventArgs e)
        {
            commentList.View = View.Details;
            commentList.GridLines = true;
            commentList.FullRowSelect = true;

            commentList.Columns.Add("Application", 150);
            commentList.Columns.Add("Commenter", 150);
            commentList.Columns.Add("Comment Text", 150);
        }

        public void RefreshJobList()
        {
            commentList.Items.Clear();

            if (dbConnection.OpenConnection())
            {
                MySqlCommand command = new MySqlCommand();

                command.Connection = dbConnection.getConnection();
                command.CommandText = "SELECT application_id, member_id, comment_text FROM comments";

                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ListViewItem item = new ListViewItem();

                        item.Text = dr[0].ToString();
                        item.SubItems.Add(dr[1].ToString());
                        item.SubItems.Add(dr[2].ToString());

                        commentList.Items.Add(item);
                    }
                }

                dbConnection.CloseConnection();
                command.Dispose();

                foreach (ListViewItem li in commentList.Items)
                {
                    if (li.SubItems[2].Text == "Approved")
                    {
                        li.BackColor = Color.LightGreen;
                    }
                }
            }
        }

        private void CommentsForm_Activated(object sender, EventArgs e)
        {
            Console.WriteLine("Form active, refreshing user list.");
            RefreshJobList();
        }

        private void CommentsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (viewAppsForm == false)
                Application.Exit();
        }

        private void btnAdd_OnClick(object sender, EventArgs e)
        {
            createCommentsForm createComment = new createCommentsForm(dbConnection, memberId, appId);
            createComment.ShowDialog();
        }

        private void btnBack_OnClick(object sender, EventArgs e)
        {
            SecretaryForm secretaryForm = new SecretaryForm(dbConnection);
            secretaryForm.Show();
            viewAppsForm = true;
            this.Close();
        }


    }
}

