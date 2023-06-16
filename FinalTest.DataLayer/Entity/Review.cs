using FinalTest.SharedLayer.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTest.DataLayer.Entity
{
    public class Review : DomainBase
    {
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public string Username { get; set; }
        public string Comment { get; set; }

    }
}
