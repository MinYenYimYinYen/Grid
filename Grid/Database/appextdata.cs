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
    
    public partial class appextdata
    {
        public int dataid { get; set; }
        public int appextid { get; set; }
        public string type { get; set; }
        public string action { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public string value { get; set; }
        public string parentcontrol { get; set; }
    
        public virtual appext appext { get; set; }
    }
}
