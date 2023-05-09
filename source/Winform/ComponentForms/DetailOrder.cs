using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            saveDialog.FileName = "output.pdf";
            saveDialog.DefaultExt = ".pdf";
            DialogResult result = saveDialog.ShowDialog();
            
            if (result == DialogResult.OK)
            {
                string filePath = saveDialog.FileName;
                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));

                document.Open();

                iTextSharp.text.Font boldFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 20, iTextSharp.text.Font.BOLD);
                Paragraph customerInfo = new Paragraph($"Customer info: \n\n", boldFont);
                document.Add(customerInfo);

                Paragraph customer = new Paragraph(
                    $"Customer name: {txtName.Text}\n" +
                    $"Customer phone: {txtPhone.Text}\n" +
                    $"Customer email: {txtEmail.Text}\n" +
                    $"Customer address: {txtAddress.Text}\n\n"
                );
                document.Add(customer);

                Paragraph paymentInFo = new Paragraph($"Payment info: \n\n", boldFont);
                document.Add(paymentInFo);

                Paragraph payment = new Paragraph(
                    $"Product price: {txtProductPrice.Text}\n" +
                    $"Ship price: {txtShipPrice.Text}\n" +
                    $"Total price: {txtTotal.Text}\n" +
                    $"Transaction code: {txtTransactionCode.Text}\n" +
                    $"Bank code: {txtBankCode.Text}\n\n" +
                    $"Ordered time: {txtCreatedAt.Text}\n\n"
                );
                document.Add(payment);

                Paragraph orderDetail = new Paragraph($"Order detail: \n\n", boldFont);
                document.Add(orderDetail);


                PdfPTable table = new PdfPTable(tblOrderDetail.Columns.Count);
                for (int i = 0; i < tblOrderDetail.Columns.Count; i++)
                {
                    table.AddCell(new PdfPCell(new Phrase(tblOrderDetail.Columns[i].HeaderText)));
                }
                for (int i = 0; i < tblOrderDetail.Rows.Count; i++)
                {
                    for (int j = 0; j < tblOrderDetail.Columns.Count; j++)
                    {
                        table.AddCell(new PdfPCell(new Phrase(tblOrderDetail.Rows[i].Cells[j].Value.ToString())));
                    }
                }
                document.Add(table);
                document.Close();

                MessageBox.Show("Print successfully");
            }
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
            txtTotal.Text = (order.product_price + order.ship_price).ToString();
            txtCreatedAt.Text = order.created_at.ToString();
            txtTransactionCode.Text = order.transaction_code;
            txtBankCode.Text = order.bank_code;

        }
    }
}
