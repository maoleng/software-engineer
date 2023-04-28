namespace Webform.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class ImportProduct
    {
        [ForeignKey("Import")]
        public long import_id { get; set; }

        [ForeignKey("Product")]
        public long product_id { get; set; }
        public int amount { get; set; }
        public double price { get; set; }
    
        public virtual Import Import { get; set; }
        public virtual Product Product { get; set; }
    }
}
