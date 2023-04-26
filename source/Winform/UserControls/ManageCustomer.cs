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
using System.Xml.Linq;
using Winform.ComponentForms;
using System.IO;

namespace Winform.UserControls
{
    public partial class ManageCustomer : UserControl
    {

        int userId;
        SoftwareEngineerEntities db = new SoftwareEngineerEntities();

        public ManageCustomer()
        {
            InitializeComponent();
        }

        private void ManageCustomer_Load(object sender, EventArgs e)
        {
            reloadCustomerList();
        }

        void reloadCustomerList()
        {
            tblProduct.DataSource = db.Users.Select(c => new
            {
                c.id,
                Name = c.name,
                Phone = c.phone,
                Email = c.email,
                Address = c.address,
                Agent = c.is_agent,
                Acitve = c.active,
                JoinedAt = c.created_at,
            }).OrderByDescending(c => c.JoinedAt).ToList();
        }

        void clearInput()
        {
            txtName.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";
        }
        private void btnInit_Click(object sender, EventArgs e)
        {
            btnInit.Enabled = false;
            btnCancel.Enabled = true;
            btnCreate.Enabled = true;
            btnUpdate.Enabled = true;
            btnChangePass.Enabled = true;
            btnToggleActive.Enabled = true;

            txtName.Enabled = true;
            txtPhone.Enabled = true;
            txtEmail.Enabled = true;
            txtAddress.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnInit.Enabled = true;
            btnCreate.Enabled = false;
            btnCancel.Enabled = false;
            btnCreate.Enabled = false;
            btnUpdate.Enabled = false;
            btnChangePass.Enabled = false;
            btnToggleActive.Enabled = false;

            txtName.Enabled = false;
            txtPhone.Enabled = false;
            txtEmail.Enabled = false;
            txtAddress.Enabled = false;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.ToString();
            db.Users.Add(new User()
            {
                name = txtName.Text.ToString(),
                phone = txtPhone.Text.ToString(),
                email = email,
                address = txtAddress.Text.ToString(),
                password = BCrypt.Net.BCrypt.HashPassword(email),
                is_agent = true,
                created_at = DateTime.Now,
            });
            db.SaveChanges();
            reloadCustomerList();
            clearInput();

            MessageBox.Show("Created agent successfully");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (userId == 0)
            {
                MessageBox.Show("Please choose a customer");

                return;
            }

            User user = db.Users.Find(userId);
            user.name = txtName.Text;
            user.phone = txtPhone.Text;
            user.email = txtEmail.Text;
            user.address = txtAddress.Text;
            db.SaveChanges();
            reloadCustomerList();

            MessageBox.Show("Updated customer successfully");
        }

        private void tblProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = tblProduct.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells["id"].Value);
            userId = id;
            displayProductData();
        }

        void displayProductData()
        {
            var user = db.Users.Find(userId);
            txtName.Text = user.name;
            txtPhone.Text = user.phone;
            txtEmail.Text = user.email;
            txtAddress.Text = user.address;
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            if (userId == 0)
            {
                MessageBox.Show("Please choose a customer");

                return;
            }

            ChangeCustomerPassword form = new ChangeCustomerPassword(userId);
            form.ShowDialog();
        }

        private void btnToggleActive_Click(object sender, EventArgs e)
        {
            if (userId == 0)
            {
                MessageBox.Show("Please choose a customer");

                return;
            }

            User user = db.Users.Find(userId);
            user.active = !user.active;
            db.SaveChanges();
            reloadCustomerList();

            string message = user.active ? "Locked successfully" : "Unlock successfully";
            MessageBox.Show(message);
        }
    }
}
