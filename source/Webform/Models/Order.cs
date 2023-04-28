namespace Webform.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.OrderProducts = new HashSet<OrderProduct>();
        }
    
        public long id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public int status { get; set; }
        public bool is_paid { get; set; }
        public double ship_fee { get; set; }
        public double product_price { get; set; }
        public double ship_price { get; set; }
        public Nullable<long> user_id { get; set; }
        public Nullable<long> admin_id { get; set; }
        public string bank_code { get; set; }
        public string transaction_code { get; set; }
        public System.DateTime created_at { get; set; }
    
        public virtual Admin Admin { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
