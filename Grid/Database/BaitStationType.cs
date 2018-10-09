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
    
    public partial class BaitStationType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaitStationType()
        {
            this.BaitStations = new HashSet<BaitStation>();
            this.CompBaitStationTypes = new HashSet<CompBaitStationType>();
            this.ServcdBaitstationtypes = new HashSet<ServcdBaitstationtype>();
        }
    
        public int BaitStationTypeID { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool anybranch { get; set; }
        public bool Active { get; set; }
        public bool HasBarcode { get; set; }
        public Nullable<short> prodcatid { get; set; }
        public Nullable<byte> condcatid { get; set; }
        public byte[] timestamp { get; set; }
        public bool IsSentricon { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaitStation> BaitStations { get; set; }
        public virtual condcat condcat { get; set; }
        public virtual prodcat prodcat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CompBaitStationType> CompBaitStationTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ServcdBaitstationtype> ServcdBaitstationtypes { get; set; }
    }
}
