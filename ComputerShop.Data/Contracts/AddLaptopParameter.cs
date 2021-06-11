using System;
using System.Collections.Generic;

namespace ComputerShop.Data.Contracts
{
    /// <summary>
    /// Parameter class to provide data about laptop creation
    /// </summary>
    public class AddLaptopParameter
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public List<Guid> Configurations { get; set; }
    }
}
