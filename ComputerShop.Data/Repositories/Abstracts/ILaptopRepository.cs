using ComputerShop.Data.Contracts;
using ComputerShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerShop.Data.Repositories
{
    public interface ILaptopRepository
    {
        /// <summary>
        /// Returns a list of all laptops
        /// </summary>
        /// <returns></returns>
        Task<List<Laptop>> GetListAsync();
        
        /// <summary>
        /// Add new laptop with configurations if there are no laptops with same configs
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Guid> AddAsync(AddLaptopParameter model);

        /// <summary>
        /// Returns laptop by id
        /// </summary>
        /// <returns></returns>
        Task<Laptop> GetAsync(Guid id);
    }
}
