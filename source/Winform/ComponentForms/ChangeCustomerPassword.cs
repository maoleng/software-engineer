using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Winform.ComponentForms
{
    public partial class ChangeCustomerPassword : Form
    {

        int userId;
        SoftwareEngineerEntities db = new SoftwareEngineerEntities();

        public ChangeCustomerPassword(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string password = txtPassword.Text;
            string rePassword = txtRePassword.Text;
            if (password != rePassword)
            {
                MessageBox.Show("Password and retype password is not match");

                return;
            }

            User user = db.Users.Where(u => u.id == userId).First();
            user.password = BCrypt.Net.BCrypt.HashPassword(password);
            db.SaveChanges();

            MessageBox.Show($"Change {user.name}'s password successfully");

            this.Close();
        }
    }
}
