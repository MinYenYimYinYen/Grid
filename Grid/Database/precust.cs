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
    
    public partial class precust
    {
        public int precustid { get; set; }
        public int cust_no { get; set; }
        public int contactid { get; set; }
        public byte[] timestamp { get; set; }
    
        public virtual customer customer { get; set; }
    }
}
