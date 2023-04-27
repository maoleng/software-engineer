﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform.UserControls
{
    public partial class ManageImport : UserControl
    {

        SoftwareEngineerEntities db = new SoftwareEngineerEntities();
        int productId = 0;
        int importId = 0;
        List<ImportProduct> importProducts = new List<ImportProduct>();

        public ManageImport()
        {
            InitializeComponent();
        }

        private void ManageImport_Load(object sender, EventArgs e)
        {
            reloadImportList();
            reloadProductList();
        }

        void reloadProductList()
        {
            tblProduct.DataSource = db.Products.Select(p => new
            {
                p.id,
                Name = p.name, 
                Price = p.price
            }).ToList();
        }


        void reloadImportList()
        {
            tblImport.DataSource = db.Imports.Select(p => new
            {
                p.id,
                Total = p.product_price,
                CreatedAt = p.created_at,
            }).OrderByDescending(c => c.CreatedAt).ToList();
        }

        private void tblProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = tblProduct.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells["id"].Value);
            productId = id;

            txtProductId.Text = id.ToString();

            ImportProduct importProduct = importProducts.Where(i => i.product_id == productId).SingleOrDefault();
            txtAmount.Text = importProduct == null ? "0" : importProduct.amount.ToString();
            txtPrice.Text = importProduct == null ? "0" : importProduct.price.ToString();

            txtAmount.Enabled = true;
            txtPrice.Enabled = true;
            btnAdd.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (productId == 0)
            {
                MessageBox.Show("Please choose a product");

                return;
            }
            if (txtAmount.Text == "" || txtPrice.Text == "")
            {
                MessageBox.Show("Please fill amount and price");

                return;
            }
            addProductToList();
            updateTableAddedList();
            toogleButtonImport();
        }

        void addProductToList()
        {
            ImportProduct importProduct = importProducts.Where(i => i.product_id == productId).SingleOrDefault();
            int amount = Convert.ToInt32(txtAmount.Text);
            if (importProduct == null)
            {
                if (amount == 0)
                {
                    return;
                }
                importProducts.Add(new ImportProduct
                {
                    product_id = productId,
                    amount = amount,
                    price = Convert.ToInt32(txtPrice.Text),
                });
            }
            else
            {
                if (amount == 0)
                {
                    importProducts.Remove(importProduct);

                    return;
                }
                importProduct.amount = amount;
                importProduct.price = Convert.ToInt32(txtPrice.Text);
            }
        }

        void updateTableAddedList()
        {
            tblAddedList.DataSource = importProducts.Select(i => new
            {
                PID = i.product_id,
                Amount = i.amount,
                Price = i.price
            }).ToList();
        }

        void toogleButtonImport()
        {
            btnImport.Enabled = importProducts.Any();
        }
    }
}
