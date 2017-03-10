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
    public partial class signInForm : Form
    {
        public signInForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            // TODO: Check for saved username.
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if (txtUsername.TextLength > 0)
            {
                if (txtPassword.TextLength > 0)
                {
                    // TODO: User authentication.
                    // TODO: Create new User object, initialize object with database data.
                    // TODO: Check user type, display appropriate form.
                }
                else
                    MessageBox.Show(this, "Please enter a valid password.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show(this, "Please enter a valid username.", "Invalid Username", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void chkRememberUsername_CheckedChanged(object sender, EventArgs e)
        {
            // TODO: Store/remove the username value in configurationn if not already.
        }
    }
}
