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
    
    public partial class prgmcd
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public prgmcd()
        {
            this.programs = new HashSet<program>();
            this.PrgmCdPackages = new HashSet<PrgmCdPackage>();
        }
    
        public short progdefid { get; set; }
        public string prgm_code { get; set; }
        public string prgm_desc { get; set; }
        public bool available { get; set; }
        public string progspec { get; set; }
        public string progtype { get; set; }
        public Nullable<short> unitcode { get; set; }
        public string billtype { get; set; }
        public string repeat { get; set; }
        public Nullable<short> rep_every { get; set; }
        public string repeatby { get; set; }
        public bool defconfirm { get; set; }
        public bool noprtprev { get; set; }
        public Nullable<short> price_id { get; set; }
        public Nullable<System.DateTime> endon { get; set; }
        public bool autorenew { get; set; }
        public bool workord { get; set; }
        public string reqdfields { get; set; }
        public Nullable<decimal> coreoraddl { get; set; }
        public Nullable<short> estformid { get; set; }
        public Nullable<short> mapsymbol { get; set; }
        public Nullable<short> mapsymbol2 { get; set; }
        public Nullable<short> mapsymbol3 { get; set; }
        public Nullable<short> mapsymbol4 { get; set; }
        public Nullable<short> mapdays1 { get; set; }
        public Nullable<short> mapdays2 { get; set; }
        public Nullable<short> mapdays3 { get; set; }
        public string serv_code { get; set; }
        public bool anybranch { get; set; }
        public byte[] timestamp { get; set; }
        public Nullable<short> budgetid { get; set; }
        public bool webavail { get; set; }
        public Nullable<short> minprepsrv { get; set; }
        public Nullable<int> backcolor { get; set; }
        public Nullable<int> forecolor { get; set; }
        public Nullable<short> max { get; set; }
        public Nullable<short> fullminsrv { get; set; }
        public string prgm_descF { get; set; }
        public string prgm_descS { get; set; }
        public bool locksched { get; set; }
        public string initialserv { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<program> programs { get; set; }
        public virtual servcd servcd { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrgmCdPackage> PrgmCdPackages { get; set; }
    }
}
