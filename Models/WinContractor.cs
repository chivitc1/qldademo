//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class WinContractor
    {
        public int Id { get; set; }
        public string DecisionNo { get; set; }
        public Nullable<System.DateTime> DecisionDate { get; set; }
        public string Signee { get; set; }
        public string SigneePosition { get; set; }
        public Nullable<double> WinPrice { get; set; }
        public string Note { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<int> Contractor_id { get; set; }
        public Nullable<int> BidPack_id { get; set; }
    
        public virtual BidPack BidPack { get; set; }
        public virtual Contractor Contractor { get; set; }
    }
}