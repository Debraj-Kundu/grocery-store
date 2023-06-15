using FinalTest.SharedLayer.Domain;
using FinalTest.SharedLayer.Service;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FinalTest.WebAPI.DTO
{
    public class ProductDto : DtoBase
    {
        [Required]
        [MaxLength(100), StringLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(255), StringLength(255)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Discount { get; set; }

        public int CategoryId { get; set; }
        public CategoryDto Category { get; set; }

        [Required]
        public int AvailableQuantity { get; set; }

        //[Required]
        public string ProductImage { get; set; }

        public IFormFile ImageFile { get; set; }

        [MaxLength(100), StringLength(100)]
        public string Specification { get; set; }
    }
}
