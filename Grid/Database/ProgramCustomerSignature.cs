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
    
    public partial class ProgramCustomerSignature
    {
        public int ProgramCustomerSignature1 { get; set; }
        public int SignatureID { get; set; }
        public int prog_id { get; set; }
        public byte[] timestamp { get; set; }
    
        public virtual program program { get; set; }
        public virtual Signature Signature { get; set; }
    }
}
