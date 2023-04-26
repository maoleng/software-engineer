using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform.ComponentForms
{
    public partial class DetailOrder : Form
    {

        SoftwareEngineerEntities db = new SoftwareEngineerEntities();
        int orderId;

        public DetailOrder(int orderId)
        {
            this.orderId = orderId;
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void DetailOrder_Load(object sender, EventArgs e)
        {
            tblOrderDetail.DataSource = db.OrderProducts.Where(o => o.order_id == orderId).Select(o => new
            {
                ProductId = o.product_id,
                ProductName = o.name,
                Amount = o.amount,
                Price = o.price,
                Sum = o.amount * o.price,
                DiscountPrice = o.discount_price,
                OriginalPrice = o.original_price,
            }).ToList();

            Order order = db.Orders.Find(orderId);
            txtName.Text = order.name;
            txtPhone.Text = order.phone;
            txtEmail.Text = order.email;
            txtAddress.Text = order.address;
            txtProductPrice.Text = order.product_price.ToString();
            txtShipPrice.Text = order.ship_price.ToString();
            txtTotal.Text = (order.product_price + order.ship_fee).ToString();
            txtTransactionCode.Text = order.transaction_code;
            txtBankCode.Text = order.bank_code;

        }
    }
}
