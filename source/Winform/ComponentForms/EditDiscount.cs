using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Winform.UserControls;

namespace Winform.ComponentForms
{
    public partial class EditDiscount : Form
    {
        private int productId;
        private int discountId;
        SoftwareEngineerEntities db = new SoftwareEngineerEntities();

        public EditDiscount(int productId)
        {
            this.productId = productId;
            InitializeComponent();
        }

        private void EditDiscount_Load(object sender, EventArgs e)
        {
            loadDiscountList();
        }

        void loadDiscountList()
        {
            tblDiscounts.DataSource = db.Discounts.Where(d => d.product_id == productId).Select(d => new
            {
                d.id,
                Amount = d.need_amount,
                Percent = d.percent
            }).OrderBy(d => d.Amount).ToList();
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            btnInit.Enabled = false;
            btnCancel.Enabled = true;
            btnCreate.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

            txtNeedAmount.Enabled = true;
            txtPercent.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnInit.Enabled = true;
            btnCreate.Enabled = false;
            btnCancel.Enabled = false;
            btnCreate.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            txtNeedAmount.Enabled = false;
            txtPercent.Enabled = false;
        }

        void clearInput()
        {
            txtNeedAmount.Text = "";
            txtPercent.Text = "";
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            db.Discounts.Add(new Discount()
            {
                need_amount = Convert.ToInt32(txtNeedAmount.Text),
                percent = Convert.ToInt32(txtPercent.Text),
                product_id = productId,
            });
            db.SaveChanges();
            loadDiscountList();
            clearInput();

            MessageBox.Show("Created discount successfully");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (discountId == 0)
            {
                MessageBox.Show("Please choose a discount");

                return;
            }

            Discount discount = db.Discounts.Find(discountId);
            discount.need_amount = Convert.ToInt32(txtNeedAmount.Text);
            discount.percent = Convert.ToInt32(txtPercent.Text);

            db.SaveChanges();
            loadDiscountList();

            MessageBox.Show("Updated discount successfully");
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (discountId == 0)
            {
                MessageBox.Show("Please choose a discount");

                return;
            }
            Discount discount = db.Discounts.Find(discountId);

            db.Discounts.Remove(discount);
            db.SaveChanges();
            discountId = 0;
            clearInput();
            loadDiscountList();

            MessageBox.Show("Deleted discount successfully");
        }


        private void tblDiscounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = tblDiscounts.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells["id"].Value);
            discountId = id;
            displayDiscountData();
        }

        void displayDiscountData()
        {
            var discount = db.Discounts.Find(discountId);
            txtNeedAmount.Text = discount.need_amount.ToString();
            txtPercent.Text = discount.percent.ToString();
        }

    }
}
