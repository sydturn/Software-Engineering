﻿using System;
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
    public partial class SecretaryForm : Form
    {
        private DBConnection dbConnection;
        private Boolean openAddApp = false;

        public SecretaryForm(DBConnection dbConnection)
        {
            this.dbConnection = dbConnection;
            InitializeComponent();
        }

        private void SecretaryForm_Load(object sender, EventArgs e)
        {
            jobList.View = View.Details;
            jobList.GridLines = true;
            jobList.FullRowSelect = true;

            jobList.Columns.Add("Job ID", 150);
            jobList.Columns.Add("Job Title", 150);
        }

        public void RefreshJobList()
        {
            jobList.Items.Clear();

            if (dbConnection.OpenConnection())
            {
                MySqlCommand command = new MySqlCommand();

                command.Connection = dbConnection.getConnection();
                command.CommandText = "SELECT job_id, job_name FROM dropboxes";

                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ListViewItem item = new ListViewItem();

                        item.Text = dr[0].ToString();
                        item.SubItems.Add(dr[1].ToString());

                        jobList.Items.Add(item);
                    }
                }

                dbConnection.CloseConnection();
                command.Dispose();
            }
        }

        private void SecretaryForm_Activated(object sender, EventArgs e)
        {
            Console.WriteLine("Form active, refreshing user list.");
            RefreshJobList();
        }

        private void SecretaryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(openAddApp == false)
                Application.Exit();
        }

        private void btnAdd_OnClick(object sender, EventArgs e)
        {
            AddJobForm addJobForm = new AddJobForm(dbConnection);
            addJobForm.ShowDialog();
        }

        private void btnRemove_OnClick(object sender, EventArgs e)
        {
            try
            {
                string jobId = jobList.SelectedItems[0].Text;
                string filePath = getFilePath(jobId);
                DeleteFTPDirectory(filePath);

                if (dbConnection.OpenConnection())
                {
                    MySqlCommand command = new MySqlCommand();

                    command.Connection = dbConnection.getConnection();
                    command.CommandText = "DELETE FROM dropboxes WHERE job_id = @job_id";
                    command.Parameters.AddWithValue("@job_id", jobId);

                    command.ExecuteNonQuery();
                    dbConnection.CloseConnection();
                    command.Dispose();
                }

                RefreshJobList();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Didn't select an option...");
            }
        }

        private string getFilePath(string jobId)
        {
            string filePath = "";
            if (dbConnection.OpenConnection())
            {
                MySqlCommand command = new MySqlCommand();

                command.Connection = dbConnection.getConnection();
                command.CommandText = "SELECT job_path FROM dropboxes WHERE job_id=@job_id";

                command.Parameters.AddWithValue("@job_id", jobId);

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

        private List<string> ListDirectories(string filePath)
        {
            WebRequest request = WebRequest.Create(filePath);
            request.Credentials = new NetworkCredential("ftpuser", "pickleparty");

            request.Method = WebRequestMethods.Ftp.ListDirectory;

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            List<string> result = new List<string>();

            while (!reader.EndOfStream)
            {
                result.Add(reader.ReadLine());
            }

            reader.Close();
            response.Close();

            return result;
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

        private void DeleteFTPDirectory(string filePath)
        {
            WebRequest request = WebRequest.Create(filePath);
            request.Credentials = new NetworkCredential("ftpuser", "pickleparty");

            List<string> filesList = ListDirectories(filePath);

            foreach (string file in filesList)
            {
                DeleteFTPFile("ftp://159.203.38.0/files/" + file);
            }

            request.Method = WebRequestMethods.Ftp.RemoveDirectory;

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

        private void btnView_OnClick(object sender, EventArgs e)
        {
            try
            {
                string jobId = jobList.SelectedItems[0].Text;
                AddApplicationForm addApplicationForm = new AddApplicationForm(dbConnection, jobId);
                addApplicationForm.Show();
                openAddApp = true;
                this.Close();
            }
            catch(Exception ex)
            { Console.WriteLine("Job not selected..."); }
        }
    }
}
