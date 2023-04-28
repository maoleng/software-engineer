namespace Webform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class OrderProduct
    {
        [ForeignKey("Order")]
        public long order_id { get; set; }

        [ForeignKey("Product")]
        public long product_id { get; set; }
        public string name { get; set; }
        public int amount { get; set; }
        public double price { get; set; }
        public double discount_price { get; set; }
        public double original_price { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
