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
    public partial class ViewApplicationForm : Form
    {

        private DBConnection dbConnection;
        private string jobId;
        private Boolean openSecretaryForm = false;

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

        private void AddApplicationForm_Closed(object sender, FormClosedEventArgs e)
        {
            if (openSecretaryForm == false)
                Application.Exit();
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
            CommitteeForm secretaryForm = new CommitteeForm(dbConnection);
            secretaryForm.Show();
            openSecretaryForm = true;
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
