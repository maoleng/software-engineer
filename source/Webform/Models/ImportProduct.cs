//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Webform.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ImportProduct
    {
        public long import_id { get; set; }
        public long product_id { get; set; }
        public int amount { get; set; }
        public double price { get; set; }
    
        public virtual Import Import { get; set; }
        public virtual Product Product { get; set; }
    }
}
