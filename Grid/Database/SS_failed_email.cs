//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Grid.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class SS_failed_email
    {
        public int fail_id { get; set; }
        public int trans_id { get; set; }
        public Nullable<int> comp_id { get; set; }
        public string toAddress { get; set; }
        public string errType { get; set; }
        public string errMsg { get; set; }
        public System.DateTime failedTime { get; set; }
        public bool @override { get; set; }
        public Nullable<int> smtpcode { get; set; }
    
        public virtual company company { get; set; }
    }
}
