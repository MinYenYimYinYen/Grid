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
    
    public partial class HistorySignature
    {
        public int HistorySignatureID { get; set; }
        public int SignatureID { get; set; }
        public int hist_id { get; set; }
        public byte[] timestamp { get; set; }
    
        public virtual history history { get; set; }
        public virtual Signature Signature { get; set; }
    }
}
