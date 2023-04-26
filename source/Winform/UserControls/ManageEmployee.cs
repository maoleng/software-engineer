using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winform.ComponentForms;

namespace Winform.UserControls
{
    public partial class ManageEmployee : UserControl
    {
        
        int adminId = 0;
        SoftwareEngineerEntities db = new SoftwareEngineerEntities();

        public ManageEmployee()
        {
            InitializeComponent();
        }

        private void ManageEmployee_Load(object sender, EventArgs e)
        {
            reloadList();
        }


        void reloadList()
        {
            tblProduct.DataSource = db.Admins.Select(a => new
            {
                a.id,
                Name = a.name,
                Email = a.email,
                Acitve = a.active,
                MasterAdmin = a.is_admin_master,
                JoinedAt = a.created_at,
            }).OrderByDescending(a => a.JoinedAt).ToList();
        }

        void clearInput()
        {
            txtName.Text = "";
            txtEmail.Text = "";
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
            txtEmail.Enabled = true;
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
            txtEmail.Enabled = false;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.ToString();
            db.Admins.Add(new Admin()
            {
                name = txtName.Text.ToString(),
                email = email,
                password = BCrypt.Net.BCrypt.HashPassword(email),
                is_admin_master = false,
                created_at = DateTime.Now,
            });
            db.SaveChanges();
            reloadList();
            clearInput();

            MessageBox.Show("Created employee successfully");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (adminId == 0)
            {
                MessageBox.Show("Please choose an admin");

                return;
            }

            Admin admin = db.Admins.Find(adminId);
            admin.name = txtName.Text;
            admin.email = txtEmail.Text;
            db.SaveChanges();
            reloadList();

            MessageBox.Show("Updated customer successfully");
        }

        private void tblProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = tblProduct.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells["id"].Value);
            adminId = id;
            displayDetailData();
        }

        void displayDetailData()
        {
            var admin = db.Admins.Find(adminId);
            txtName.Text = admin.name;
            txtEmail.Text = admin.email;
        }

        private void btnToggleActive_Click(object sender, EventArgs e)
        {
            if (adminId == 0)
            {
                MessageBox.Show("Please choose an admin");

                return;
            }

            Admin admin = db.Admins.Find(adminId);
            if (admin.is_admin_master)
            {
                MessageBox.Show("Can not handle on admin master");

                return;
            }
            admin.active = ! admin.active;
            db.SaveChanges();
            reloadList();

            string message = admin.active ? "Locked successfully" : "Unlock successfully";
            MessageBox.Show(message);
        }

        private void btnChangePass_Click(object sender, EventArgs e)
        {
            if (adminId == 0)
            {
                MessageBox.Show("Please choose an admin");

                return;
            }

            ChangePassword form = new ChangePassword(adminId, "admin");
            form.ShowDialog();
        }
    }
}
