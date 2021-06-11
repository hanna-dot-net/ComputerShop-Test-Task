using System;

namespace ComputerShop.Data.Contracts
{
    public class AddConfigurationParameter
    {
        public Guid ConfigurationTypeId { get; set; }
        public string Value { get; set; }
        public double Price { get; set; }
    }
}
