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
    public partial class ChangePassword : Form
    {

        int id;
        string type;
        SoftwareEngineerEntities db = new SoftwareEngineerEntities();

        public ChangePassword(int id, string type)
        {
            InitializeComponent();
            this.id = id;
            this.type = type;
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
            if (type == "admin")
            {
                Admin admin = db.Admins.Where(u => u.id == id).First();
                admin.password = BCrypt.Net.BCrypt.HashPassword(password);
                db.SaveChanges();
                MessageBox.Show($"Change {admin.name}'s password successfully");
            } else
            {
                User user = db.Users.Where(u => u.id == id).First();
                user.password = BCrypt.Net.BCrypt.HashPassword(password);
                db.SaveChanges();
                MessageBox.Show($"Change {user.name}'s password successfully");
            }

            this.Close();
        }
    }
}
