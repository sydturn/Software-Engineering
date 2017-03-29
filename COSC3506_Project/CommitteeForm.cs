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
    public partial class CommitteeForm : Form
    {
        private DBConnection dbConnection;
        private Boolean openAddApp = false;

        public CommitteeForm(DBConnection dbConnection)
        {
            this.dbConnection = dbConnection;
            InitializeComponent();
        }

        private void CommitteeForm_Load(object sender, EventArgs e)
        {
            jobList.View = View.Details;
            jobList.GridLines = true;
            jobList.FullRowSelect = true;

            jobList.Columns.Add("Job ID", 150);
            jobList.Columns.Add("Job Title", 150);
            jobList.Columns.Add("Job Status", 150);
        }

        public void RefreshJobList()
        {
            jobList.Items.Clear();

            if (dbConnection.OpenConnection())
            {
                MySqlCommand command = new MySqlCommand();

                command.Connection = dbConnection.getConnection();
                command.CommandText = "SELECT job_id, job_name, job_status FROM dropboxes";

                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ListViewItem item = new ListViewItem();

                        item.Text = dr[0].ToString();
                        item.SubItems.Add(dr[1].ToString());
                        item.SubItems.Add(dr[2].ToString());

                        jobList.Items.Add(item);
                    }
                }

                dbConnection.CloseConnection();
                command.Dispose();

                foreach (ListViewItem li in jobList.Items)
                {
                    if (li.SubItems[2].Text == "Approved")
                    {
                        li.BackColor = Color.LightGreen;
                    }
                }
            }
        }

        private void CommitteeForm_Activated(object sender, EventArgs e)
        {
            Console.WriteLine("Form active, refreshing user list.");
            RefreshJobList();
        }

        private void CommitteeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (openAddApp == false)
                Application.Exit();
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


        private void btnView_OnClick(object sender, EventArgs e)
        {
            try
            {
                string jobId = jobList.SelectedItems[0].Text;
                ViewApplicationForm addApplicationForm = new ViewApplicationForm(dbConnection, jobId);
                addApplicationForm.Show();
                openAddApp = true;
                this.Close();
            }
            catch (Exception ex)
            { Console.WriteLine("Job not selected..."); }
        }

        private void jobList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
