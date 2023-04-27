using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winform.UserControls;

namespace Winform
{
    public partial class MainForm : Form
    {
        NavigationControl navigationControl;

        public MainForm()
        {
            InitializeComponent();
            initializeNavigationControl();
        }

        private void initializeNavigationControl()
        {
            List<UserControl> userControls = new List<UserControl>() {
                new ManageOrder(), 
                new ManageCustomer(), 
                new ManageProduct(),
                new ManageImport(),
                new ManageEmployee(),
                new Statistic(),
            };

            navigationControl = new NavigationControl(userControls, panel2);
            navigationControl.display(0);
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            navigationControl.display(0);
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            navigationControl.display(1);
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            navigationControl.display(2);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            navigationControl.display(3);
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            navigationControl.display(4);
        }

        private void btnStatistic_Click(object sender, EventArgs e)
        {
            navigationControl.display(5);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            MessageBox.Show("Logged out successfully");
            LoginForm form = new LoginForm();
            form.Show();
        }
    }
}
