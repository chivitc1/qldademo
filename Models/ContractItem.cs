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
    
    public partial class ContractItem
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Nullable<int> UnitId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<double> TotalValue { get; set; }
        public Nullable<int> OriginCountryId { get; set; }
        public string ProducerId { get; set; }
        public Nullable<int> Contract_id { get; set; }
        public string UnitName { get; set; }
        public string OriginCountryName { get; set; }
        public string ProducerName { get; set; }
        public Nullable<double> VATPercent { get; set; }
        public Nullable<double> VAT { get; set; }
    
        public virtual Contract Contract { get; set; }
    }
}
