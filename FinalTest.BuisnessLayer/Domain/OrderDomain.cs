using FinalTest.SharedLayer.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FinalTest.BuisnessLayer.Domain
{
    public class OrderDomain : DomainBase
    {
        public int CustomerId { get; set; }
        public CustomerDomain Customer { get; set; }
        public int ProductId { get; set; }
        public ProductDomain Product { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
