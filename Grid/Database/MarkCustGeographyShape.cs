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
    
    public partial class MarkCustGeographyShape
    {
        public int MarkCustGeographyShapeID { get; set; }
        public int cust_no { get; set; }
        public int GeographyShapeID { get; set; }
    
        public virtual GeographyShape GeographyShape { get; set; }
        public virtual markcust markcust { get; set; }
    }
}
