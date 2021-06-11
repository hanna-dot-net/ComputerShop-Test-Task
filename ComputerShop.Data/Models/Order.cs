using System;
using System.ComponentModel.DataAnnotations;

namespace ComputerShop.Data.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(100)]
        public string CustomerName { get; set; }

        public Guid LaptopId { get; set; }

        public virtual Laptop Laptop { get; set; }
    }
}
