using System;

namespace ComputerShop.Data.Contracts
{
    public class AddOrderParameter
    {
        public string CustomerName { get; set; }

        public Guid LaptopId { get; set; }
    }
}
