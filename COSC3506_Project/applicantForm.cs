using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COSC3506_Project
{
    public partial class applicantForm : Form
    {
        private bool hasResume;

        public applicantForm()
        {
            // TODO: Check if a resume exists for the applicant. Update hasResume
            InitializeComponent();
        }

        private void applicantForm_Load(object sender, EventArgs e)
        {
            // TODO: Update welcome message with the applicants name.
            // TODO: Update buttons/label if the user has a resume on file.
        }
    }
}
