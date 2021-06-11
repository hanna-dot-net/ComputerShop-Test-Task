using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ComputerShop.Models.RequestModels
{
    public class AddLaptopModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public double Price { get; set; }

        public List<Guid> Configurations { get; set; }
    }
}
