//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Final_mvc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DeliveryNote
    {
        public string DeliveryID { get; set; }
        public System.DateTime Date { get; set; }
        public string AID { get; set; }
        public string ProductID { get; set; }
        public double OPrice { get; set; }
        public int Quantity { get; set; }
    
        public virtual Agent Agent { get; set; }
        public virtual OrdersStatu OrdersStatu { get; set; }
        public virtual Product Product { get; set; }
    }
}