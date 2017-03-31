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
    public partial class TaggedInForm : Form
    {
        private DBConnection dbConnection;
        private Boolean otherWindowOpen = false;
        private int securityStatus;
   
        private int memberId; //make this the member logged in

        public TaggedInForm(DBConnection dbConnection, int securityStatus)
        {
            this.securityStatus = securityStatus;
            this.dbConnection = dbConnection;
            InitializeComponent();
        }
        private void TaggedInForm_Activated(object sender, EventArgs e)
        {
            Console.WriteLine("Form active, refreshing user list.");
            RefreshApplicationList();
        }

        private void TaggedInForm_Closed(object sender, FormClosedEventArgs e)
        {
            if (otherWindowOpen == false)
                Application.Exit();
        }

        private void tagsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tagsList.SelectedItems.Count > 0)
            {
                btnGo.Enabled = true;
            }
            else
            {
                btnGo.Enabled = false;
            }
        }

        private void tagsList_Load(object sender, EventArgs e)
        {
            tagsList.View = View.Details;
            tagsList.GridLines = true;
            tagsList.FullRowSelect = true;

            tagsList.Columns.Add("Job ID", 150);
            tagsList.Columns.Add("Application ID", 150);
            tagsList.Columns.Add("Tagee", 150);
        }

        public void RefreshApplicationList()
        {
            tagsList.Items.Clear();

            if (dbConnection.OpenConnection())
            {
                MySqlCommand command = new MySqlCommand();

                command.Connection = dbConnection.getConnection();
                command.CommandText = "SELECT job_id, application_id, tagee_id FROM tags WHERE member_id = @member_id";

                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ListViewItem item = new ListViewItem();

                        item.Text = dr[0].ToString();
                        item.SubItems.Add(dr[1].ToString());
                        item.SubItems.Add(dr[2].ToString());

                        tagsList.Items.Add(item);
                    }
                }

                dbConnection.CloseConnection();
                command.Dispose();

                foreach (ListViewItem li in tagsList.Items)
                {
                    if (li.SubItems[5].Text == "Yes")
                    {
                        li.BackColor = Color.LightGreen;
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void btnBack_OnClick(object sender, EventArgs e)
        {
            MemberForm form = new MemberForm(dbConnection, securityStatus, memberId);
            form.Show();
            otherWindowOpen = true;
            this.Close();
        }
        private void btnGo_OnClick(object sender, EventArgs e)
        {
            ApplicationForm applicationsForm = new ApplicationForm(dbConnection, Int32.Parse(tagsList.SelectedItems[0].Text), securityStatus, memberId);
            //perhaps we can pass the application id too so we can highlight it when we get there
            applicationsForm.Show();
            otherWindowOpen = true;
            this.Close();
        }
    }
}
