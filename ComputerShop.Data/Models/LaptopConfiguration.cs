using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComputerShop.Data.Models
{
    public class LaptopConfiguration
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid LaptopId { get; set; }
        [Required]
        public Guid ConfigurationId { get; set; }

        public virtual Laptop Laptop { get; set; }
        public virtual Configuration Configuration { get; set; }
    }
}
