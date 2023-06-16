using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTest.BuisnessLayer.Domain
{
    public class TopOrderDomain
    {
        public int ProductId { get; set; }
        public ProductDomain Product { get; set; }
        public int Quantity { get; set; }
    }
}
