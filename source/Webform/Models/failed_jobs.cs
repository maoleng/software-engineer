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
    
    public partial class failed_jobs
    {
        public long id { get; set; }
        public string uuid { get; set; }
        public string connection { get; set; }
        public string queue { get; set; }
        public string payload { get; set; }
        public string exception { get; set; }
        public System.DateTime failed_at { get; set; }
    }
}
