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
    
    public partial class unitcode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public unitcode()
        {
            this.customers = new HashSet<customer>();
        }
    
        public short unitcode1 { get; set; }
        public string unit_desc { get; set; }
        public byte[] timestamp { get; set; }
        public Nullable<int> unitofmeasureid { get; set; }
        public string unit_descF { get; set; }
        public string unit_descS { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<customer> customers { get; set; }
        public virtual unitofmeasure unitofmeasure { get; set; }
    }
}
