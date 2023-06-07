using FinalTest.SharedLayer.Domain;
using FinalTest.SharedLayer.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FinalTest.WebAPI.DTO
{
    public class CategoryDto : DtoBase
    {
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
