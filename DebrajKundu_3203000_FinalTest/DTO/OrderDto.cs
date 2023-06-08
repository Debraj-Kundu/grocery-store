using FinalTest.SharedLayer.Domain;
using FinalTest.SharedLayer.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FinalTest.WebAPI.DTO
{
    public class OrderDto : DtoBase
    {
        public CustomerDto Customer { get; set; }
        public int CustomerId { get; set; }

        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }

    }
}
