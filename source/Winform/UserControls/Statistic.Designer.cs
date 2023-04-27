namespace Winform.UserControls
{
    partial class Statistic
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtFilterStartTime = new System.Windows.Forms.DateTimePicker();
            this.txtFilterEndTime = new System.Windows.Forms.DateTimePicker();
            this.cbFilterTimeRange = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chartTopProduct = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtRevenue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProfit = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCost = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartTopProduct)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chartTopProduct);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(247, 377);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(687, 360);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Top products";
            // 
            // chartRevenue
            // 
            chartArea2.Name = "ChartArea1";
            this.chartRevenue.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartRevenue.Legends.Add(legend2);
            this.chartRevenue.Location = new System.Drawing.Point(14, 33);
            this.chartRevenue.Name = "chartRevenue";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartRevenue.Series.Add(series2);
            this.chartRevenue.Size = new System.Drawing.Size(667, 329);
            this.chartRevenue.TabIndex = 37;
            this.chartRevenue.Text = "chartRevenue";
            // 
            // txtFilterStartTime
            // 
            this.txtFilterStartTime.CustomFormat = "yyyy/MM/dd";
            this.txtFilterStartTime.Enabled = false;
            this.txtFilterStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFilterStartTime.Location = new System.Drawing.Point(6, 69);
            this.txtFilterStartTime.Name = "txtFilterStartTime";
            this.txtFilterStartTime.Size = new System.Drawing.Size(167, 34);
            this.txtFilterStartTime.TabIndex = 38;
            this.txtFilterStartTime.Value = new System.DateTime(2020, 1, 1, 15, 46, 0, 0);
            this.txtFilterStartTime.ValueChanged += new System.EventHandler(this.txtFilterStartTime_ValueChanged);
            // 
            // txtFilterEndTime
            // 
            this.txtFilterEndTime.CustomFormat = "yyyy/MM/dd";
            this.txtFilterEndTime.Enabled = false;
            this.txtFilterEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.txtFilterEndTime.Location = new System.Drawing.Point(6, 109);
            this.txtFilterEndTime.Name = "txtFilterEndTime";
            this.txtFilterEndTime.Size = new System.Drawing.Size(167, 34);
            this.txtFilterEndTime.TabIndex = 39;
            this.txtFilterEndTime.ValueChanged += new System.EventHandler(this.txtFilterEndTime_ValueChanged);
            // 
            // cbFilterTimeRange
            // 
            this.cbFilterTimeRange.AutoSize = true;
            this.cbFilterTimeRange.Location = new System.Drawing.Point(6, 33);
            this.cbFilterTimeRange.Name = "cbFilterTimeRange";
            this.cbFilterTimeRange.Size = new System.Drawing.Size(159, 33);
            this.cbFilterTimeRange.TabIndex = 40;
            this.cbFilterTimeRange.Text = "Time range";
            this.cbFilterTimeRange.UseVisualStyleBackColor = true;
            this.cbFilterTimeRange.CheckedChanged += new System.EventHandler(this.cbFilterTimeRange_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chartRevenue);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(247, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(687, 367);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Revenue";
            // 
            // chartTopProduct
            // 
            chartArea1.Name = "ChartArea1";
            this.chartTopProduct.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartTopProduct.Legends.Add(legend1);
            this.chartTopProduct.Location = new System.Drawing.Point(14, 33);
            this.chartTopProduct.Name = "chartTopProduct";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartTopProduct.Series.Add(series1);
            this.chartTopProduct.Size = new System.Drawing.Size(667, 315);
            this.chartTopProduct.TabIndex = 41;
            this.chartTopProduct.Text = "chart1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.txtCost);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.txtProfit);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtRevenue);
            this.groupBox3.Controls.Add(this.cbFilterTimeRange);
            this.groupBox3.Controls.Add(this.txtFilterEndTime);
            this.groupBox3.Controls.Add(this.txtFilterStartTime);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(16, 23);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(225, 702);
            this.groupBox3.TabIndex = 38;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Import Product";
            // 
            // txtRevenue
            // 
            this.txtRevenue.Location = new System.Drawing.Point(6, 190);
            this.txtRevenue.Name = "txtRevenue";
            this.txtRevenue.Size = new System.Drawing.Size(167, 34);
            this.txtRevenue.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 29);
            this.label1.TabIndex = 42;
            this.label1.Text = "Total Revenue";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 354);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 29);
            this.label2.TabIndex = 44;
            this.label2.Text = "Total Profit";
            // 
            // txtProfit
            // 
            this.txtProfit.Location = new System.Drawing.Point(6, 387);
            this.txtProfit.Name = "txtProfit";
            this.txtProfit.Size = new System.Drawing.Size(167, 34);
            this.txtProfit.TabIndex = 43;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 29);
            this.label3.TabIndex = 46;
            this.label3.Text = "Total Cost";
            // 
            // txtCost
            // 
            this.txtCost.Location = new System.Drawing.Point(6, 282);
            this.txtCost.Name = "txtCost";
            this.txtCost.Size = new System.Drawing.Size(167, 34);
            this.txtCost.TabIndex = 45;
            // 
            // Statistic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "Statistic";
            this.Size = new System.Drawing.Size(950, 750);
            this.Load += new System.EventHandler(this.Statistic_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartTopProduct)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartTopProduct;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenue;
        private System.Windows.Forms.DateTimePicker txtFilterStartTime;
        private System.Windows.Forms.DateTimePicker txtFilterEndTime;
        private System.Windows.Forms.CheckBox cbFilterTimeRange;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtRevenue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProfit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCost;
    }
}
