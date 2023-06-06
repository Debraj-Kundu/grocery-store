using FinalTest.SharedLayer.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FinalTest.BuisnessLayer.Domain
{
    public class Category : DomainBase
    {
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
