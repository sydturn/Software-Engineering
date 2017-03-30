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
    public partial class ViewApplicationForm : Form
    {

        private string tagId; //this will eventually become the id of the selected individual
        private string appId; //make this the selected app
        private string memberId; //make this the current member logged in
        private DBConnection dbConnection;
        private string jobId;
        private Boolean openCommmitteeForm = false;

        public ViewApplicationForm(DBConnection dbConnection, string jobId)
        {
            this.jobId = jobId;
            this.dbConnection = dbConnection;
            InitializeComponent();
        }

        private void ViewApplicationForm_Activated(object sender, EventArgs e)
        {
            Console.WriteLine("Form active, refreshing user list.");
            RefreshApplicationList();
        }

        private void ViewApplicationForm_Closed(object sender, FormClosedEventArgs e)
        {
            if (openCommmitteeForm == false)
                Application.Exit();
        }

        private void applicationList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (applicationList.SelectedItems.Count > 0)
            {
                btnComment.Enabled = true;
                btnTag.Enabled = true;
                btnApprove.Enabled = true;
                btnDownload.Enabled = true;
            }
            else
            {
                btnComment.Enabled = false;
                btnTag.Enabled = false;
                btnApprove.Enabled = false;
                btnDownload.Enabled = false; 
            }
        }

        private void ViewApplicationForm_Load(object sender, EventArgs e)
        {
            applicationList.View = View.Details;
            applicationList.GridLines = true;
            applicationList.FullRowSelect = true;

            applicationList.Columns.Add("Job ID", 150);
            applicationList.Columns.Add("Application ID", 150);
            applicationList.Columns.Add("Name", 150);
            applicationList.Columns.Add("Phone", 150);
            applicationList.Columns.Add("Email", 150);
            applicationList.Columns.Add("Approved", 150);
        }

        public void RefreshApplicationList()
        {
            applicationList.Items.Clear();

            if (dbConnection.OpenConnection())
            {
                MySqlCommand command = new MySqlCommand();

                command.Connection = dbConnection.getConnection();
                command.CommandText = "SELECT job_id, application_id, name, phone, email, approved FROM applications WHERE job_id = @job_id";
                command.Parameters.AddWithValue("@job_id", jobId);

                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ListViewItem item = new ListViewItem();

                        item.Text = dr[0].ToString();
                        item.SubItems.Add(dr[1].ToString());
                        item.SubItems.Add(dr[2].ToString());
                        item.SubItems.Add(dr[3].ToString());
                        item.SubItems.Add(dr[4].ToString());
                        item.SubItems.Add(dr[5].ToString());

                        applicationList.Items.Add(item);
                    }
                }

                dbConnection.CloseConnection();
                command.Dispose();

                foreach (ListViewItem li in applicationList.Items)
                {
                    if (li.SubItems[5].Text == "Yes")
                    {
                        li.BackColor = Color.LightGreen;
                    }
                }
            }
        }

        private void btnBack_OnClick(object sender, EventArgs e)
        {
            CommitteeForm committeeForm = new CommitteeForm(dbConnection);
            committeeForm.Show();
            openCommmitteeForm = true;
            this.Close();
        }
        public void btnApprove_onClick(object sender, EventArgs e)
        {
            if (dbConnection.OpenConnection())
            {
                MySqlCommand command = new MySqlCommand();

                command.Connection = dbConnection.getConnection();
                command.CommandText = "INSERT INTO app_passes (application_id, member_id) VALUES (@application_id, @member_id)";
                command.Parameters.AddWithValue("@application_id", appId);
                command.Parameters.AddWithValue("@member_id", memberId);

                command.ExecuteNonQuery();
                dbConnection.CloseConnection();
                command.Dispose();
            }
            MessageBox.Show("Application Approved!", "EARS System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

             //in the chair's application view, we will query the app_passes database to see if the application has three passes. If not, then it does not show up for the chair.
        }
        private void btnTag_OnClick(object sender, EventArgs e)
        {
            if (dbConnection.OpenConnection())
            {
                MySqlCommand command = new MySqlCommand();

                command.Connection = dbConnection.getConnection();
                command.CommandText = "INSERT INTO tags (application_id, job_id, member_id, tagee_id, tag_id) VALUES (@application_id, @job_id, @tag_mem_id, @member_id, @tag_id)";
                command.Parameters.AddWithValue("@application_id", appId);
                command.Parameters.AddWithValue("@job_id", jobId);
                command.Parameters.AddWithValue("@tag_mem_id", tagId);
                command.Parameters.AddWithValue("@tagee_id", memberId);
                command.Parameters.AddWithValue("@tag_id", appId); //should auto increment, not set up

                command.ExecuteNonQuery();
                dbConnection.CloseConnection();
                command.Dispose();
            }
            MessageBox.Show("Application Approved!", "EARS System Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
        private string getFilePath(string applicationId)
        {
            string filePath = "";
            if (dbConnection.OpenConnection())
            {
                MySqlCommand command = new MySqlCommand();

                command.Connection = dbConnection.getConnection();
                command.CommandText = "SELECT app_path FROM applications WHERE application_id = @application_id";

                command.Parameters.AddWithValue("@application_id", applicationId);

                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    try
                    {
                        while (dr.Read())
                            filePath = dr[0].ToString();
                    }
                    catch (Exception e)
                    { System.Console.WriteLine("Nothing selected..."); }
                }

                dbConnection.CloseConnection();
                command.Dispose();
            }
            return filePath;
        }

        private void btnDownload_OnClick(object sender, EventArgs e)
        {
            try
            {
                string applicationId = applicationList.SelectedItems[0].SubItems[1].Text;
                DownloadResumeForm addJobForm = new DownloadResumeForm(dbConnection, applicationId);
                addJobForm.ShowDialog();
            }
            catch
            { Console.WriteLine("No application selected..."); }

        }
    }
}
