using FinalTest.SharedLayer.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FinalTest.DataLayer.Entity
{
    public class Order : DomainBase
    {
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int CartId { get; set; }
    }
}
