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
    public partial class systemAdminForm : Form
    {
        public systemAdminForm()
        {
            InitializeComponent();
        }

        private void systemAdminForm_Load(object sender, EventArgs e)
        {
            usersListView.View = View.Details;
            usersListView.GridLines = true;
            usersListView.FullRowSelect = true;

            usersListView.Columns.Add("Last Name", 100);
            usersListView.Columns.Add("First Name", 100);
            usersListView.Columns.Add("Type", 100);
            usersListView.Columns.Add("E-mail", 200);
        }
    }
}
