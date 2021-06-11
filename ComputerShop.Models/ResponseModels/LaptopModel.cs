using System;
using System.Collections.Generic;

namespace ComputerShop.Models.ResponseModels
{
    public class LaptopModel
    {
        public Guid Id { get; set; }
     
        public string Name { get; set; }

        public double Price { get; set; }

        public List<ConfigurationModel> Configurations { get; set; }
    }
}
