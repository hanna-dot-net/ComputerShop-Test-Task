using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComputerShop.Data.Models
{
    public class Configuration
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid ConfigurationTypeId { get; set; }
        [Required]
        public string Value { get; set; }
        [Required]
        [MinLength(0)]
        public double Price { get; set; }

        public virtual ConfigurationType ConfigurationType { get; set; }
        public virtual List<LaptopConfiguration> Laptops { get; set; }
    }
}
