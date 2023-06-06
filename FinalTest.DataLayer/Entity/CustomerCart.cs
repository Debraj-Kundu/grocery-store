using FinalTest.SharedLayer.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTest.DataLayer.Entity
{
    public class CustomerCart : DomainBase
    {
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal ItemPrice { get; set; }
    }
}
