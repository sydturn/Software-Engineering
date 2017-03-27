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
    public partial class AddApplicationForm : Form
    {

        private DBConnection dbConnection;
        private string jobId;
        private Boolean openSecretaryForm = false;

        public AddApplicationForm(DBConnection dbConnection, string jobId)
        {
            this.jobId = jobId;
            this.dbConnection = dbConnection;
            InitializeComponent();
        }

        private void AddApplicationForm_Activated(object sender, EventArgs e)
        {
            Console.WriteLine("Form active, refreshing user list.");
            RefreshApplicationList();
        }

        private void AddApplicationForm_Closed(object sender, FormClosedEventArgs e)
        {
            if(openSecretaryForm == false)
                Application.Exit();
        }

        private void AddApplication_Load(object sender, EventArgs e)
        {
            applicationList.View = View.Details;
            applicationList.GridLines = true;
            applicationList.FullRowSelect = true;

            applicationList.Columns.Add("Job ID", 150);
            applicationList.Columns.Add("Application ID", 150);
            applicationList.Columns.Add("Name", 150);
            applicationList.Columns.Add("Phone", 150);
            applicationList.Columns.Add("Email", 150);
        }

        public void RefreshApplicationList()
        {
            applicationList.Items.Clear();

            if (dbConnection.OpenConnection())
            {
                MySqlCommand command = new MySqlCommand();

                command.Connection = dbConnection.getConnection();
                command.CommandText = "SELECT job_id, application_id, name, phone, email FROM applications WHERE job_id = @job_id";
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

                        applicationList.Items.Add(item);
                    }
                }

                dbConnection.CloseConnection();
                command.Dispose();
            }
        }

        private void btnAdd_OnClick(object sender, EventArgs e)
        {
            NewApplicationForm addApplicationForm = new NewApplicationForm(dbConnection, jobId);
            addApplicationForm.ShowDialog();
        }

        private void btnBack_OnClick(object sender, EventArgs e)
        {
            SecretaryForm secretaryForm = new SecretaryForm(dbConnection);
            secretaryForm.Show();
            openSecretaryForm = true;
            this.Close();
        }

        private void btnRemove_OnClick(object sender, EventArgs e)
        {
            try
            {
                string applicationId = applicationList.SelectedItems[0].SubItems[1].Text;
                string filePath = getFilePath(applicationId);
                DeleteFTPFile(filePath);

                if (dbConnection.OpenConnection())
                {
                    MySqlCommand command = new MySqlCommand();

                    command.Connection = dbConnection.getConnection();
                    command.CommandText = "DELETE FROM applications WHERE application_id = @application_id";
                    command.Parameters.AddWithValue("@application_id", applicationId);

                    command.ExecuteNonQuery();
                    dbConnection.CloseConnection();
                    command.Dispose();

                    RefreshApplicationList();
                }
            }
            catch (Exception ex)
            { Console.WriteLine("Didn't select an option..."); }
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

        public void DeleteFTPFile(string filePath)
        {
            WebRequest request = WebRequest.Create(filePath);
            request.Credentials = new NetworkCredential("ftpuser", "pickleparty");

            request.Method = WebRequestMethods.Ftp.DeleteFile;

            string result = string.Empty;
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            long size = response.ContentLength;
            Stream datastream = response.GetResponseStream();
            StreamReader sr = new StreamReader(datastream);
            result = sr.ReadToEnd();
            sr.Close();

            datastream.Close();
            response.Close();
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
