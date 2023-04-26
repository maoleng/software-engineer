namespace Winform.UserControls
{
    partial class ManageOrder
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbFilterStatus = new System.Windows.Forms.CheckBox();
            this.cbFilterPaymentStatus = new System.Windows.Forms.CheckBox();
            this.cbFilterTimeRange = new System.Windows.Forms.CheckBox();
            this.cbIsPaid = new System.Windows.Forms.CheckBox();
            this.txtFilterEndTime = new System.Windows.Forms.DateTimePicker();
            this.txtFilterStartTime = new System.Windows.Forms.DateTimePicker();
            this.slFilterStatus = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tblOrder = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupActionOrder = new System.Windows.Forms.GroupBox();
            this.btnView = new System.Windows.Forms.Button();
            this.cbPaidStatus = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.slStatus = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblOrder)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupActionOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbFilterStatus);
            this.groupBox2.Controls.Add(this.cbFilterPaymentStatus);
            this.groupBox2.Controls.Add(this.cbFilterTimeRange);
            this.groupBox2.Controls.Add(this.cbIsPaid);
            this.groupBox2.Controls.Add(this.txtFilterEndTime);
            this.groupBox2.Controls.Add(this.txtFilterStartTime);
            this.groupBox2.Controls.Add(this.slFilterStatus);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(16, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(918, 120);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filter";
            // 
            // cbFilterStatus
            // 
            this.cbFilterStatus.AutoSize = true;
            this.cbFilterStatus.Location = new System.Drawing.Point(21, 26);
            this.cbFilterStatus.Name = "cbFilterStatus";
            this.cbFilterStatus.Size = new System.Drawing.Size(166, 33);
            this.cbFilterStatus.TabIndex = 23;
            this.cbFilterStatus.Text = "Order status";
            this.cbFilterStatus.UseVisualStyleBackColor = true;
            this.cbFilterStatus.CheckedChanged += new System.EventHandler(this.cbFilterStatus_CheckedChanged);
            // 
            // cbFilterPaymentStatus
            // 
            this.cbFilterPaymentStatus.AutoSize = true;
            this.cbFilterPaymentStatus.Location = new System.Drawing.Point(592, 26);
            this.cbFilterPaymentStatus.Name = "cbFilterPaymentStatus";
            this.cbFilterPaymentStatus.Size = new System.Drawing.Size(196, 33);
            this.cbFilterPaymentStatus.TabIndex = 22;
            this.cbFilterPaymentStatus.Text = "Payment status";
            this.cbFilterPaymentStatus.UseVisualStyleBackColor = true;
            this.cbFilterPaymentStatus.CheckedChanged += new System.EventHandler(this.cbFilterPaymentStatus_CheckedChanged);
            // 
            // cbFilterTimeRange
            // 
            this.cbFilterTimeRange.AutoSize = true;
            this.cbFilterTimeRange.Location = new System.Drawing.Point(219, 26);
            this.cbFilterTimeRange.Name = "cbFilterTimeRange";
            this.cbFilterTimeRange.Size = new System.Drawing.Size(218, 33);
            this.cbFilterTimeRange.TabIndex = 22;
            this.cbFilterTimeRange.Text = "Order time range";
            this.cbFilterTimeRange.UseVisualStyleBackColor = true;
            this.cbFilterTimeRange.CheckedChanged += new System.EventHandler(this.cbFilterTimeRange_CheckedChanged);
            // 
            // cbIsPaid
            // 
            this.cbIsPaid.AutoSize = true;
            this.cbIsPaid.Enabled = false;
            this.cbIsPaid.Location = new System.Drawing.Point(592, 62);
            this.cbIsPaid.Name = "cbIsPaid";
            this.cbIsPaid.Size = new System.Drawing.Size(106, 33);
            this.cbIsPaid.TabIndex = 21;
            this.cbIsPaid.Text = "Is paid";
            this.cbIsPaid.UseVisualStyleBackColor = true;
            this.cbIsPaid.CheckedChanged += new System.EventHandler(this.cbIsPaid_CheckedChanged);
            // 
            // txtFilterEndTime
            // 
            this.txtFilterEndTime.CustomFormat = "yyyy/MM/dd";
            this.txtFilterEndTime.Enabled = false;
            this.txtFilterEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFilterEndTime.Location = new System.Drawing.Point(401, 62);
            this.txtFilterEndTime.Name = "txtFilterEndTime";
            this.txtFilterEndTime.Size = new System.Drawing.Size(167, 34);
            this.txtFilterEndTime.TabIndex = 19;
            // 
            // txtFilterStartTime
            // 
            this.txtFilterStartTime.CustomFormat = "yyyy/MM/dd";
            this.txtFilterStartTime.Enabled = false;
            this.txtFilterStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFilterStartTime.Location = new System.Drawing.Point(219, 62);
            this.txtFilterStartTime.Name = "txtFilterStartTime";
            this.txtFilterStartTime.Size = new System.Drawing.Size(167, 34);
            this.txtFilterStartTime.TabIndex = 18;
            this.txtFilterStartTime.ValueChanged += new System.EventHandler(this.txtFilterStartTime_ValueChanged);
            // 
            // slFilterStatus
            // 
            this.slFilterStatus.Enabled = false;
            this.slFilterStatus.FormattingEnabled = true;
            this.slFilterStatus.Location = new System.Drawing.Point(21, 62);
            this.slFilterStatus.Name = "slFilterStatus";
            this.slFilterStatus.Size = new System.Drawing.Size(177, 37);
            this.slFilterStatus.TabIndex = 17;
            this.slFilterStatus.SelectedIndexChanged += new System.EventHandler(this.slFilterStatus_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tblOrder);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 376);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(918, 354);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Order List";
            // 
            // tblOrder
            // 
            this.tblOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblOrder.Location = new System.Drawing.Point(21, 40);
            this.tblOrder.Name = "tblOrder";
            this.tblOrder.RowHeadersWidth = 51;
            this.tblOrder.RowTemplate.Height = 24;
            this.tblOrder.Size = new System.Drawing.Size(874, 299);
            this.tblOrder.TabIndex = 2;
            this.tblOrder.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblOrder_CellContentClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtQuery);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(16, 149);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(263, 98);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Search";
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(22, 33);
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(216, 34);
            this.txtQuery.TabIndex = 0;
            this.txtQuery.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuery_KeyDown);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(494, 55);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(129, 47);
            this.btnUpdate.TabIndex = 20;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // groupActionOrder
            // 
            this.groupActionOrder.Controls.Add(this.btnView);
            this.groupActionOrder.Controls.Add(this.cbPaidStatus);
            this.groupActionOrder.Controls.Add(this.label1);
            this.groupActionOrder.Controls.Add(this.slStatus);
            this.groupActionOrder.Controls.Add(this.btnUpdate);
            this.groupActionOrder.Enabled = false;
            this.groupActionOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupActionOrder.Location = new System.Drawing.Point(288, 149);
            this.groupActionOrder.Name = "groupActionOrder";
            this.groupActionOrder.Size = new System.Drawing.Size(646, 190);
            this.groupActionOrder.TabIndex = 21;
            this.groupActionOrder.TabStop = false;
            this.groupActionOrder.Text = "Action";
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(24, 123);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(129, 47);
            this.btnView.TabIndex = 27;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // cbPaidStatus
            // 
            this.cbPaidStatus.AutoSize = true;
            this.cbPaidStatus.Location = new System.Drawing.Point(241, 61);
            this.cbPaidStatus.Name = "cbPaidStatus";
            this.cbPaidStatus.Size = new System.Drawing.Size(196, 33);
            this.cbPaidStatus.TabIndex = 26;
            this.cbPaidStatus.Text = "Payment status";
            this.cbPaidStatus.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 29);
            this.label1.TabIndex = 25;
            this.label1.Text = "Status";
            // 
            // slStatus
            // 
            this.slStatus.FormattingEnabled = true;
            this.slStatus.Location = new System.Drawing.Point(24, 61);
            this.slStatus.Name = "slStatus";
            this.slStatus.Size = new System.Drawing.Size(177, 37);
            this.slStatus.TabIndex = 24;
            // 
            // ManageOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupActionOrder);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "ManageOrder";
            this.Size = new System.Drawing.Size(950, 750);
            this.Load += new System.EventHandler(this.ManageOrder_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblOrder)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupActionOrder.ResumeLayout(false);
            this.groupActionOrder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView tblOrder;
        private System.Windows.Forms.ComboBox slFilterStatus;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.CheckBox cbFilterStatus;
        private System.Windows.Forms.CheckBox cbFilterPaymentStatus;
        private System.Windows.Forms.CheckBox cbFilterTimeRange;
        private System.Windows.Forms.CheckBox cbIsPaid;
        private System.Windows.Forms.DateTimePicker txtFilterEndTime;
        private System.Windows.Forms.DateTimePicker txtFilterStartTime;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox groupActionOrder;
        private System.Windows.Forms.ComboBox slStatus;
        private System.Windows.Forms.CheckBox cbPaidStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnView;
    }
}
