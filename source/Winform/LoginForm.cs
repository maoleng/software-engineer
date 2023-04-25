using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BCrypt.Net;


namespace Winform
{
    public partial class LoginForm : Form
    {

        SoftwareEngineerEntities db = new SoftwareEngineerEntities();

        public LoginForm()
        {

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Admin admin = db.Admins.SingleOrDefault(c => c.email == txtEmail.Text);
            if (admin == null)
            {
                MessageBox.Show("Email or Password is incorrect!");

                return;
            }

            bool check = BCrypt.Net.BCrypt.Verify(txtPassword.Text, admin.password);

            if (!check)
            {
                MessageBox.Show("Email or Password is incorrect!");

                return;
            }
            MessageBox.Show("Login successfully");
            this.Hide();
            (new MainForm()).Show();
        }
    }
}
