using Newtonsoft.Json;
using System;
    using System.Collections.Specialized;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Windows.Forms;

namespace Winform.UserControls
{

    public partial class ManageProduct : UserControl
    {

        SoftwareEngineerEntities db = new SoftwareEngineerEntities();
        int productId = 0;

        public ManageProduct()
        {
            InitializeComponent();
        }

        private void ManageProduct_Load(object sender, EventArgs e)
        {
            reloadProductList();
            displayCategoryComboBox();
        }

        void reloadProductList()
        {
            var products = db.Products.ToList();
            Category[] categories = getCategories();
            var productsWithCategories = products.Select(p => new
            {
                p.id,
                p.name,
                Category = categories.FirstOrDefault(c => c.CategoryId == p.category)?.CategoryName,
                Price = p.price,
                Description = p.description,
                Image = p.image,
                CreatedAt = p.created_at,
            }).OrderByDescending(c => c.CreatedAt).ToList();

            tblProduct.DataSource = productsWithCategories;
        }

        private void tblProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = tblProduct.Rows[e.RowIndex];
            int id = Convert.ToInt32(row.Cells["id"].Value);
            this.productId = id;
            string category = row.Cells["Category"].Value.ToString();
            string image = row.Cells["Image"].Value.ToString();

            displayProductDiscount(id);
            displayProductData(id, image);
            slCategory.SelectedIndex = slCategory.FindStringExact(category);
        }

        private void tblDiscounts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEditDiscount.Enabled = true;
        }

        void displayCategoryComboBox()
        {
            slCategory.DataSource = getCategories();
            slCategory.DisplayMember = "CategoryName";
            slCategory.ValueMember = "CategoryId";
        }

        Category[] getCategories()
        {
            return new[] {
                new Category{ CategoryId = 1, CategoryName = "GOOGLE" },
                new Category{ CategoryId = 2, CategoryName = "SAMSUNG" },
                new Category{ CategoryId = 3, CategoryName = "SONY" },
                new Category{ CategoryId = 4, CategoryName = "NOKIA" },
                new Category{ CategoryId = 5, CategoryName = "LG" },
                new Category{ CategoryId = 6, CategoryName = "XIAOMI" },
                new Category{ CategoryId = 7, CategoryName = "VIVO" },
                new Category{ CategoryId = 8, CategoryName = "OPPO" },
                new Category{ CategoryId = 9, CategoryName = "ONEPLUS" },
                new Category{ CategoryId = 10, CategoryName = "HUAWEI" },
            };
        }

        string GetCategoryName(int categoryId)
        {
            var categories = getCategories();
            var category = categories.FirstOrDefault(c => c.CategoryId == categoryId);
            return category != null ? category.CategoryName : "Unknown";
        }

        void displayProductData(int id, string image)
        {
            var product = db.Products.Find(id);
            txtName.Text = product.name;
            txtPrice.Text = product.price.ToString();
            txtImage.Text = product.image;
            rTxtDescription.Text = product.description;
            using (var webClient = new System.Net.WebClient())
            {
                byte[] imageData = webClient.DownloadData(image);
                using (var stream = new MemoryStream(imageData))
                {
                    imgImage.Image = System.Drawing.Image.FromStream(stream);
                }
            }
        }

        void displayProductDiscount(int id)
        {
            var discounts = db.Discounts.Where(d => d.product_id == id)
                .Select(x => new { Amount = x.need_amount, x.percent }).ToList();
            tblDiscounts.DataSource = discounts;
        }

        private void btnInit_Click(object sender, EventArgs e)
        {
            btnInit.Enabled = false;
            btnCancel.Enabled = true;
            btnCreate.Enabled = true;
            btnUpdate.Enabled = true;
            
            txtName.Enabled = true;
            txtPrice.Enabled = true;
            txtImage.Enabled = true;
            rTxtDescription.Enabled = true;
            slCategory.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnInit.Enabled = true;
            btnCreate.Enabled = false;
            btnCancel.Enabled = false;
            btnCreate.Enabled = false;
            btnUpdate.Enabled = false;

            txtName.Enabled = false;
            txtPrice.Enabled = false;
            txtImage.Enabled = false;
            rTxtDescription.Enabled = false;
            slCategory.Enabled = false;
        }

        private void imgImage_Click(object sender, EventArgs e)
        {
            if (btnInit.Enabled)
            {
                return;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                string extension = Path.GetExtension(fileName);

                byte[] fileData = File.ReadAllBytes(fileName);

                using (WebClient client = new WebClient())
                {
                    client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                    string apiUrl = "https://api.imgbb.com/1/upload";
                    string apiKey = "44c3abcbb4d3f91a34d5d66a5f232cce";
                    string expiration = "0";
                    string imageData = Convert.ToBase64String(fileData);

                    NameValueCollection requestBody = new NameValueCollection();
                    requestBody.Add("key", apiKey);
                    requestBody.Add("expiration", expiration);
                    requestBody.Add("image", imageData);

                    byte[] responseBytes = client.UploadValues(apiUrl, "POST", requestBody);
                    string response = Encoding.UTF8.GetString(responseBytes);

                    dynamic jsonResponse = JsonConvert.DeserializeObject<dynamic>(response);
                    string imageUrl = jsonResponse.data.image.url;
                    txtImage.Text = imageUrl;

                    Bitmap image = new Bitmap(openFileDialog.FileName);
                    imgImage.Image = image;
                }
            }

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            db.Products.Add(new Product()
            {
                category = Convert.ToInt32(slCategory.SelectedValue),
                name = txtImage.Text,
                price = Convert.ToInt32(txtPrice.Text),
                description = rTxtDescription.Text,
                image = txtImage.Text,
                created_at = DateTime.Now,
            });
            db.SaveChanges();
            reloadProductList();

            txtName.Text = "";
            txtPrice.Text = "";
            txtImage.Text = "";
            rTxtDescription.Text = "";

            MessageBox.Show("Created product successfully");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (productId == 0)
            {
                MessageBox.Show("Please choose a product");

                return;
            }

            Product product = db.Products.Find(productId);
            product.name = txtName.Text;
            product.price = Convert.ToInt32(txtPrice.Text);
            product.image = txtImage.Text;
            product.description = rTxtDescription.Text;
            product.category = Convert.ToInt32(slCategory.SelectedValue);

            db.SaveChanges();
            reloadProductList();

            MessageBox.Show("Updated product successfully");
        }
    }

    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
