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
        public ProductDto Product { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
