using FinalTest.SharedLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalTest.WebAPI.DTO
{
    public class ReviewDto : DtoBase
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public string Username { get; set; }
        public string Comment { get; set; }
    }
}
