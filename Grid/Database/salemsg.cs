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
    
    public partial class salemsg
    {
        public short salemsgid { get; set; }
        public string msgname { get; set; }
        public Nullable<decimal> msgtype { get; set; }
        public string msgtitle { get; set; }
        public string msgmemo { get; set; }
        public byte[] msgole { get; set; }
        public bool usecheck { get; set; }
        public string checkmsg { get; set; }
        public Nullable<decimal> printoff { get; set; }
        public string disccode { get; set; }
        public Nullable<short> price_id { get; set; }
        public bool anybranch { get; set; }
        public byte[] timestamp { get; set; }
        public bool isprepay { get; set; }
        public Nullable<decimal> percent { get; set; }
        public string settings { get; set; }
        public string language { get; set; }
    }
}
