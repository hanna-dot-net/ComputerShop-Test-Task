using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComputerShop.Data.Models
{
    public class Laptop
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [MinLength(0)]
        public double Price{ get; set; }

        public virtual List<LaptopConfiguration> LaptopConfigurations { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
