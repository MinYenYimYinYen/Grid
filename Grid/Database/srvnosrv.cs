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
    
    public partial class srvnosrv
    {
        public int srvnosrvid { get; set; }
        public Nullable<int> service_id { get; set; }
        public Nullable<short> nosrvid { get; set; }
        public Nullable<System.DateTime> nosrvdate { get; set; }
        public byte[] timestamp { get; set; }
        public string emp_id { get; set; }
    
        public virtual service service { get; set; }
    }
}
