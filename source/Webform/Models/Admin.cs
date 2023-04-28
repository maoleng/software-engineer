namespace Webform.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Admin
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Admin()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public long id { get; set; }
        public string name { get; set; }
        public bool is_admin_master { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool active { get; set; }
        public System.DateTime created_at { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
