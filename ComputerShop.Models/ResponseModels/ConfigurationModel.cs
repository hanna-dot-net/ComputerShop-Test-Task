using System;

namespace ComputerShop.Models.ResponseModels
{
    public class ConfigurationModel
    {
        public Guid Id { get; set; }

        public string ConfigurationTypeName { get; set; }

        public string Value { get; set; }

        public double Price { get; set; }
    }
}
