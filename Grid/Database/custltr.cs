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
    
    public partial class custltr
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public custltr()
        {
            this.programs = new HashSet<program>();
        }
    
        public int custltrid { get; set; }
        public short letterid { get; set; }
        public Nullable<int> cust_no { get; set; }
        public Nullable<System.DateTime> printdate { get; set; }
        public Nullable<decimal> amount { get; set; }
        public Nullable<int> batch_no { get; set; }
        public byte[] timestamp { get; set; }
        public Nullable<int> mcust_no { get; set; }
        public string letterurl { get; set; }
    
        public virtual customer customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<program> programs { get; set; }
    }
}
