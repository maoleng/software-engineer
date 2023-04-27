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
using System.Xml.Linq;
using System.Data.Entity;

namespace Winform.ComponentForms
{
    public partial class DetailImport : Form
    {

        SoftwareEngineerEntities db = new SoftwareEngineerEntities();
        int importId = 0;

        public DetailImport(int importId)
        {
            InitializeComponent();
            this.importId = importId;
        }

        private void DetailImport_Load(object sender, EventArgs e)
        {
          
            tblImportDetail.DataSource = db.ImportProducts.Where(i => i.import_id == importId).Join(db.Products,
                i => i.product_id,
                p => p.id,
                (i, p) => new {
                    PID = p.id,
                    ProductName = p.name,
                    Price = i.price,
                    Amount = i.amount,
                    Sum = i.price * i.amount,
                }
            ).ToList();
            Import import = db.Imports.Find(importId);

            txtImportId.Text = import.id.ToString();
            txtTotal.Text = import.product_price.ToString();
            txtCreatedAt.Text = import.created_at.ToString();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
            saveDialog.FileName = "ImportData.pdf";
            saveDialog.DefaultExt = ".pdf";
            DialogResult result = saveDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filePath = saveDialog.FileName;
                Document document = new Document();
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));

                document.Open();

                iTextSharp.text.Font boldFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 20, iTextSharp.text.Font.BOLD);
                Paragraph headOverview = new Paragraph($"Overview: \n\n", boldFont);
                document.Add(headOverview);

                Paragraph overview = new Paragraph(
                    $"Import ID: {txtImportId.Text}\n" +
                    $"Total: {txtTotal.Text}\n" +
                    $"Imported At: {txtCreatedAt.Text}\n"
                );
                document.Add(overview);

                Paragraph importDetail = new Paragraph($"Import detail: \n\n", boldFont);
                document.Add(importDetail);


                PdfPTable table = new PdfPTable(tblImportDetail.Columns.Count);
                for (int i = 0; i < tblImportDetail.Columns.Count; i++)
                {
                    table.AddCell(new PdfPCell(new Phrase(tblImportDetail.Columns[i].HeaderText)));
                }
                for (int i = 0; i < tblImportDetail.Rows.Count; i++)
                {
                    for (int j = 0; j < tblImportDetail.Columns.Count; j++)
                    {
                        table.AddCell(new PdfPCell(new Phrase(tblImportDetail.Rows[i].Cells[j].Value.ToString())));
                    }
                }
                document.Add(table);
                document.Close();

                MessageBox.Show("Print successfully");
            }
        }
    }
}
