using FinalTest.SharedLayer.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTest.DataLayer.Entity
{
    public class Product : DomainBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
        public Category Category { get; set; }
        public int Quantity { get; set; }
        public byte[] Image { get; set; }
        public string Specification { get; set; }
    }
}
