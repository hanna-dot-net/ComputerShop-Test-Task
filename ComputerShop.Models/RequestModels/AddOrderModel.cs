using System;
using System.ComponentModel.DataAnnotations;

namespace ComputerShop.Models.RequestModels
{
    public class AddOrderModel
    {
        [Required]
        public Guid LaptopId { get; set; }

        public string CustomerName { get; set; }
    }
}
