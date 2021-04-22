using Estimating_Issue_Log;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace estimatedOvertime
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }



        private void wipeTxt(int num)
        {
            if (num == 1) //wipe both
            {
                txtPassword.Text = "";
                txtUsername.Text = "";
            }
            else if (num == 2) //only wipe pass
                txtPassword.Text = "";
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin.PerformClick();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
             session sessionLogin = new session();
            sessionLogin.login(txtUsername.Text, txtPassword.Text);
            if (sessionLogin.passwordWrong == true)
            {
                MessageBox.Show("Wrong username/password!");
                wipeTxt(2);
                return;
            }
            frmMain frm = new frmMain(sessionLogin.isOfficeManager);
            frm.Show();
            this.Hide();
        }

        private void txtPassword_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin.PerformClick();
        }
    }
}
