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
    public partial class SecretaryForm : Form
    {
        private DBConnection dbConnection;

        public SecretaryForm(DBConnection dbConnection)
        {
            this.dbConnection = dbConnection;
            InitializeComponent();
        }

        private void SecretaryForm_Load(object sender, EventArgs e)
        {

        }
    }
}
