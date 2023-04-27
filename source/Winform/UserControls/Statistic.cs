using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Winform.UserControls
{
    public partial class Statistic : UserControl
    {

        SoftwareEngineerEntities db = new SoftwareEngineerEntities();

        public Statistic()
        {
            InitializeComponent();
        }

        private void Statistic_Load(object sender, EventArgs e)
        {
            chartRevenue.Titles.Add("Revenue Chart");
            chartTopProduct.Titles.Add("Top Sold Products Chart");
            loadRevenueChart();
            loadChartTopProduct();
            updateRevenueAndProfit();
        }

        void loadRevenueChart()
        {
            var orders = db.Orders.Where(o => o.status != 5).OrderBy(o => o.created_at).ToList();
            DateTime[] range = getRange();
            int dayDiff = (int)(range[1] - range[0]).TotalDays;
            string format = dayDiff <= 20 ? "dd-MM-yy" : "MM yy";
            var data = orders.Where(o => o.created_at >= range[0] && o.created_at <= range[1])
                .GroupBy(o => o.created_at.ToString(format))
                .Select(g => new { Date = g.Key, Revenue = g.Sum(o => o.product_price) }).ToList();

            double[] revenue = data.Select(d => d.Revenue).ToArray();
            string[] labels = data.Select(d => d.Date).ToArray();

            chartRevenue.Series.Clear();
            chartRevenue.Series.Add("Revenue");
            for (int key = 0; key < revenue.Length; key++)
            {
                chartRevenue.Series["Revenue"].Points.AddXY(labels[key], revenue[key]);
            }
        }

        void loadChartTopProduct()
        {
            DateTime[] range = getRange();
            var startDate = range[0];
            var endDate = range[1];

            var products = db.Products
                .Select(p => new
                    {
                        Name = p.name,
                        Sold = p.OrderProducts
                        .Where(op => op.Order.created_at >= startDate && op.Order.created_at <= endDate && op.Order.status != 5)
                        .Sum(op => (int?)op.amount)
                    })
                .Where(p => p.Sold != null)
                .OrderByDescending(p => p.Sold)
                .ToList();

            var limit = products.Count(p => p.Sold != 0);
            var topProducts = products
                .Where(p => p.Sold != 0)
                .OrderByDescending(p => p.Sold)
                .Take(limit)
                .ToDictionary(p => p.Name, p => p.Sold);

            var labels = topProducts.Keys.ToArray();
            var data = topProducts.Values.ToArray();


            chartTopProduct.Series.Clear();
            chartTopProduct.Series.Add("TopProducs");
            for (int key = 0; key < labels.Length; key++)
            {
                chartTopProduct.Series["TopProducs"].Points.AddXY(labels[key], data[key]);
            }
        }

        void updateRevenueAndProfit()
        {
            DateTime[] range = getRange();
            DateTime start = range[0];
            DateTime end = range[1];

            var orderIds = db.Orders
                .Where(o => o.created_at >= start && o.created_at <= end)
                .Select(o => o.id)
                .ToList();
            var orderProducts = db.OrderProducts
                .Where(op => orderIds.Contains(op.order_id))
                .ToList();

            double revenue = orderProducts.Sum(op => op.amount * op.price);
            double cost = orderProducts.Sum(op => op.amount * op.original_price);
            double profit = revenue - cost;

            txtRevenue.Text = revenue.ToString();
            txtCost.Text = cost.ToString();
            txtProfit.Text = profit.ToString();
        }

        private void cbFilterTimeRange_CheckedChanged(object sender, EventArgs e)
        {
            txtFilterStartTime.Enabled = cbFilterTimeRange.Checked;
            txtFilterEndTime.Enabled = cbFilterTimeRange.Checked;
        }

        private void txtFilterStartTime_ValueChanged(object sender, EventArgs e)
        {
            loadRevenueChart();
            loadChartTopProduct();
            updateRevenueAndProfit();
        }

        private void txtFilterEndTime_ValueChanged(object sender, EventArgs e)
        {
            loadRevenueChart();
            loadChartTopProduct();
            updateRevenueAndProfit();
        }

        DateTime[] getRange()
        {
            DateTime start = DateTime.ParseExact(txtFilterStartTime.Text, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            DateTime end = DateTime.ParseExact(txtFilterEndTime.Text, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            
            return new DateTime[] { start, end };
        }
    }
}
