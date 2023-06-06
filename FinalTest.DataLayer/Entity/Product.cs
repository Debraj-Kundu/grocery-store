using FinalTest.SharedLayer.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FinalTest.DataLayer.Entity
{
    public class Product : DomainBase
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        [Required]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        [Required]
        public decimal Discount { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public int AvailableQuantity { get; set; }
        //[Required]
        public byte[] Image { get; set; }
        public string Specification { get; set; }
    }
}
