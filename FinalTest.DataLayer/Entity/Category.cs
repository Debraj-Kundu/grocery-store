using FinalTest.SharedLayer.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FinalTest.DataLayer.Entity
{
    public class Category : DomainBase
    {
        [Required]
        public string Name { get; set; }
    }
}
