using FinalTest.SharedLayer.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FinalTest.DataLayer.Entity
{
    public class CustomerCart : DomainBase
    {
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
