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
    
    public partial class personal_access_tokens
    {
        public long id { get; set; }
        public string tokenable_type { get; set; }
        public long tokenable_id { get; set; }
        public string name { get; set; }
        public string token { get; set; }
        public string abilities { get; set; }
        public Nullable<System.DateTime> last_used_at { get; set; }
        public Nullable<System.DateTime> expires_at { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
    }
}
