using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Winform.UserControls
{
    public partial class ManageOrder : UserControl
    {


        SoftwareEngineerEntities db = new SoftwareEngineerEntities();
        int orderId = 0;

        public ManageOrder()
        {
            InitializeComponent();
        }

        private void ManageOrder_Load(object sender, EventArgs e)
        {
            reloadList();
        }

        void reloadList()
        {
            listFormat(db.Orders.ToList());
            displaySelectStatus();
        }

        void displaySelectStatus()
        {
            slFilterStatus.DataSource = getOrderStatus();
            slFilterStatus.DisplayMember = "StatusName";
            slFilterStatus.ValueMember = "StatusId";
            slStatus.DataSource = getOrderStatus();
            slStatus.DisplayMember = "StatusName";
            slStatus.ValueMember = "StatusId";
        }

        OrderStatus[] getOrderStatus()
        {
            return new[] {
                new OrderStatus{ StatusId = 0, StatusName = "Unprocessed" },
                new OrderStatus{ StatusId = 1, StatusName = "Delivering" },
                new OrderStatus{ StatusId = 2, StatusName = "Cancelled" },
                new OrderStatus{ StatusId = 3, StatusName = "Decline" },
                new OrderStatus{ StatusId = 4, StatusName = "Successful" },
                new OrderStatus{ StatusId = 5, StatusName = "Destroy" },
            };
        }

        void listFormat(List<Order> orders)
        {
            tblOrder.DataSource = orders.Select(o => new
            {
                o.id,
                Name = o.name,
                Phone = o.phone,
                Email = o.email,
                Address = o.address,
                Status = getOrderStatus().FirstOrDefault(s => s.StatusId == o.status)?.StatusName,
                PayStatus = o.is_paid,
                ProductPrice = o.product_price,
                ShipPrice = o.ship_price,
                TotalPrice = o.product_price + o.ship_price,
                OrderedAt = o.created_at,
            }).OrderByDescending(c => c.OrderedAt).ToList();
        }

        private void cbFilterStatus_CheckedChanged(object sender, EventArgs e)
        {
            slFilterStatus.Enabled = cbFilterStatus.Checked;
        }

        private void cbFilterTimeRange_CheckedChanged(object sender, EventArgs e)
        {
            txtFilterStartTime.Enabled = cbFilterTimeRange.Checked;
            txtFilterEndTime.Enabled = cbFilterTimeRange.Checked;
        }

        private void cbFilterPaymentStatus_CheckedChanged(object sender, EventArgs e)
        {
            cbIsPaid.Enabled = cbFilterPaymentStatus.Checked;
        }


        List<Order> searchList()
        {
            string q = txtQuery.Text;

            return db.Orders.ToList().Where(o =>
               o.id.ToString().Contains(q) ||
               o.name.Contains(q) ||
               o.phone.Contains(q) ||
               o.email.Contains(q) ||
               o.address.Contains(q)
            ).ToList();
        }

        List<Order> filterStatusList(List<Order> orders)
        {
            var status = slFilterStatus.SelectedValue as int?;

            return orders.Where(o => o.status == status).ToList();
        }
        
        List<Order> filterOrderTimeRange(List<Order> orders)
        {
            DateTime startTime = DateTime.ParseExact(txtFilterStartTime.Text, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            DateTime endTime = DateTime.ParseExact(txtFilterEndTime.Text, "yyyy/MM/dd", CultureInfo.InvariantCulture);

            return orders.Where(o =>
                o.created_at >= startTime &&
                o.created_at <= endTime
            ).ToList();
        }

        List<Order> filter
            PaymentStatus(List<Order> orders)
        {
            return orders.Where(o => o.is_paid == cbIsPaid.Checked).ToList();
        }

        List<Order> getResultSearchFilter()
        {
            List<Order> orders = searchList();

            string a = cbFilterTimeRange.Checked ? " time " : " ";
            string b = cbFilterStatus.Checked ? " status " : " ";
            string c = cbFilterPaymentStatus.Checked ? " payment " : " ";
           

            MessageBox.Show($"Filter by {a} {b} {c}");
            orders = cbFilterTimeRange.Checked ? filterOrderTimeRange(orders) : orders;
            orders = cbFilterStatus.Checked ? filterStatusList(orders) : orders;
            orders = cbFilterPaymentStatus.Checked ? filterPaymentStatus(orders) : orders;

            return orders;
        }

        private void txtQuery_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }
            List<Order> orders = getResultSearchFilter();
            listFormat(orders);
        }

        private void slFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Order> orders = getResultSearchFilter();
            listFormat(orders);
        }

        private void txtFilterStartTime_ValueChanged(object sender, EventArgs e)
        {
            List<Order> orders = getResultSearchFilter();
            listFormat(orders);
        }

        private void cbIsPaid_CheckedChanged(object sender, EventArgs e)
        {
            List<Order> orders = getResultSearchFilter();
            listFormat(orders);
        }
    }

    public class OrderStatus
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }
    }
}
