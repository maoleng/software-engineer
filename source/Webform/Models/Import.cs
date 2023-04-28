namespace Webform.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Import
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Import()
        {
            this.ImportProducts = new HashSet<ImportProduct>();
        }
    
        public long id { get; set; }
        public double product_price { get; set; }
        public System.DateTime created_at { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImportProduct> ImportProducts { get; set; }
    }
}
