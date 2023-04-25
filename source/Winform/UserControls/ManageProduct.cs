using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Winform.UserControls
{
    public partial class ManageProduct : UserControl
    {
        public const int GOOGLE = 1;
        public const int SAMSUNG = 2;
        public const int SONY = 3;
        public const int NOKIA = 4;
        public const int LG = 5;
        public const int XIAOMI = 6;
        public const int VIVO = 7;
        public const int OPPO = 8;
        public const int ONEPLUS = 9;
        public const int HUAWEI = 10;

        SoftwareEngineerEntities db = new SoftwareEngineerEntities();

        public ManageProduct()
        {
            InitializeComponent();
        }

        private void ManageProduct_Load(object sender, EventArgs e)
        {
            tblProduct.DataSource = db.Products.ToList();
            displayCategoryComboBox();
            displayCategoryComboBox();
        }

        private void tblProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = tblProduct.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells[0].Value);
            int category = Convert.ToInt32(row.Cells[1].Value);
            string image = row.Cells[5].Value.ToString();

            displayProductDiscount(id);
            displayProductData(id, image);
            slCategory.SelectedValue = category;
        }

        void displayCategoryComboBox()
        {
            var categoryNames = new[] {
                new { CategoryId = GOOGLE, CategoryName = "GOOGLE" },
                new { CategoryId = SAMSUNG, CategoryName = "SAMSUNG" },
                new { CategoryId = SONY, CategoryName = "SONY" },
                new { CategoryId = NOKIA, CategoryName = "NOKIA" },
                new { CategoryId = LG, CategoryName = "LG" },
                new { CategoryId = XIAOMI, CategoryName = "XIAOMI" },
                new { CategoryId = VIVO, CategoryName = "VIVO" },
                new { CategoryId = OPPO, CategoryName = "OPPO" },
                new { CategoryId = ONEPLUS, CategoryName = "ONEPLUS" },
                new { CategoryId = HUAWEI, CategoryName = "HUAWEI" },
            };

            slCategory.DataSource = categoryNames;
            slCategory.DisplayMember = "CategoryName";
            slCategory.ValueMember = "CategoryId";
        }

        void displayProductData(int id, string image)
        {
            var product = db.Products.Find(id);
            txtName.Text = product.name;
            txtPrice.Text = product.price.ToString();
            rTxtDescription.Text = product.description;
            using (var webClient = new System.Net.WebClient())
            {
                byte[] imageData = webClient.DownloadData(image);
                using (var stream = new MemoryStream(imageData))
                {
                    imgImage.Image = Image.FromStream(stream);
                }
            }
        }

        void displayProductDiscount(int id)
        {
            var discounts = db.Discounts.Where(d => d.product_id == id)
                .Select(x => new { Amount = x.need_amount, x.percent }).ToList();
            tblDiscounts.DataSource = discounts;
        }

    }
}
