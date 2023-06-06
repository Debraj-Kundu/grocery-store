using FinalTest.SharedLayer.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTest.DataLayer.Entity
{
    public class Order : DomainBase
    {
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
