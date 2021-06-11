using System;
using System.ComponentModel.DataAnnotations;

namespace ComputerShop.Models.RequestModels
{
    public class AddLaptopConfigurationModel
    {
        [Required]
        public Guid ConfigurationTypeId { get; set; }

        [Required]
        public string Value { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public double Price { get; set; }
    }
}
