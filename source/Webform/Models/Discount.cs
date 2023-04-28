namespace Webform.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Discount
    {
        public long id { get; set; }
        public int need_amount { get; set; }
        public int percent { get; set; }
        public long product_id { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
