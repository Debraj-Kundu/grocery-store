using FinalTest.SharedLayer.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTest.BuisnessLayer.Domain
{
    public class ReviewDomain : DomainBase
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public string Username { get; set; }
        public string Comment { get; set; }
    }
}
