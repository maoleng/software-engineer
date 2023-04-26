namespace Winform.UserControls
{
    partial class ManageProduct
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tblProduct = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tblDiscounts = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtImage = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.imgImage = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rTxtDescription = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.slCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.tblProduct)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblDiscounts)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgImage)).BeginInit();
            this.SuspendLayout();
            // 
            // tblProduct
            // 
            this.tblProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblProduct.Location = new System.Drawing.Point(21, 40);
            this.tblProduct.Name = "tblProduct";
            this.tblProduct.RowHeadersWidth = 51;
            this.tblProduct.RowTemplate.Height = 24;
            this.tblProduct.Size = new System.Drawing.Size(593, 299);
            this.tblProduct.TabIndex = 2;
            this.tblProduct.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblProduct_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tblDiscounts);
            this.groupBox1.Controls.Add(this.tblProduct);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 376);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(918, 354);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Product List";
            // 
            // tblDiscounts
            // 
            this.tblDiscounts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblDiscounts.Location = new System.Drawing.Point(632, 40);
            this.tblDiscounts.Name = "tblDiscounts";
            this.tblDiscounts.RowHeadersWidth = 51;
            this.tblDiscounts.RowTemplate.Height = 24;
            this.tblDiscounts.Size = new System.Drawing.Size(270, 299);
            this.tblDiscounts.TabIndex = 3;
            this.tblDiscounts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblDiscounts_CellContentClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtImage);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.btnCreate);
            this.groupBox2.Controls.Add(this.btnInit);
            this.groupBox2.Controls.Add(this.imgImage);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.rTxtDescription);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.slCategory);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtPrice);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(15, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(918, 354);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Product Detail";
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(785, 301);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(118, 47);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(347, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 29);
            this.label5.TabIndex = 15;
            this.label5.Text = "Image";
            // 
            // txtImage
            // 
            this.txtImage.Enabled = false;
            this.txtImage.Location = new System.Drawing.Point(352, 128);
            this.txtImage.Name = "txtImage";
            this.txtImage.Size = new System.Drawing.Size(551, 34);
            this.txtImage.TabIndex = 14;
            // 
            // btnCancel
            // 
            this.btnCancel.Enabled = false;
            this.btnCancel.Location = new System.Drawing.Point(414, 301);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 47);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(661, 301);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(118, 47);
            this.btnUpdate.TabIndex = 11;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Enabled = false;
            this.btnCreate.Location = new System.Drawing.Point(530, 301);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(125, 47);
            this.btnCreate.TabIndex = 10;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(279, 301);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(129, 47);
            this.btnInit.TabIndex = 9;
            this.btnInit.Text = "Initialize";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // imgImage
            // 
            this.imgImage.Location = new System.Drawing.Point(21, 33);
            this.imgImage.Name = "imgImage";
            this.imgImage.Size = new System.Drawing.Size(267, 253);
            this.imgImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgImage.TabIndex = 8;
            this.imgImage.TabStop = false;
            this.imgImage.Click += new System.EventHandler(this.imgImage_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(347, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 29);
            this.label4.TabIndex = 7;
            this.label4.Text = "Description";
            // 
            // rTxtDescription
            // 
            this.rTxtDescription.Enabled = false;
            this.rTxtDescription.Location = new System.Drawing.Point(352, 213);
            this.rTxtDescription.Name = "rTxtDescription";
            this.rTxtDescription.Size = new System.Drawing.Size(550, 73);
            this.rTxtDescription.TabIndex = 6;
            this.rTxtDescription.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(719, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Category";
            // 
            // slCategory
            // 
            this.slCategory.Enabled = false;
            this.slCategory.FormattingEnabled = true;
            this.slCategory.Location = new System.Drawing.Point(724, 48);
            this.slCategory.Name = "slCategory";
            this.slCategory.Size = new System.Drawing.Size(179, 37);
            this.slCategory.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(556, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Price";
            // 
            // txtPrice
            // 
            this.txtPrice.Enabled = false;
            this.txtPrice.Location = new System.Drawing.Point(561, 48);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(156, 34);
            this.txtPrice.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(347, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(352, 48);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(182, 34);
            this.txtName.TabIndex = 0;
            // 
            // ManageProduct
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ManageProduct";
            this.Size = new System.Drawing.Size(950, 750);
            this.Load += new System.EventHandler(this.ManageProduct_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblProduct)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblDiscounts)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView tblProduct;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView tblDiscounts;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.PictureBox imgImage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox rTxtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox slCategory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtImage;
        private System.Windows.Forms.Button btnDelete;
    }
}
