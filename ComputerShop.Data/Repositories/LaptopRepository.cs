using ComputerShop.Data.Contracts;
using ComputerShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.Data.Repositories
{
    public class LaptopRepository : ILaptopRepository
    {
        private readonly ComputerShopContext _context;
        public LaptopRepository(ComputerShopContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns a list of all laptops
        /// </summary>
        /// <returns></returns>
        public async Task<List<Laptop>> GetListAsync()
            => await _context.Laptops
                .Include(l => l.LaptopConfigurations)
                    .ThenInclude(l => l.Configuration)
                    .ThenInclude(l => l.ConfigurationType)
                .ToListAsync();

        /// <summary>
        /// Returns laptop by id
        /// </summary>
        /// <returns></returns>
        public async Task<Laptop> GetAsync(Guid id)
            => await _context.Laptops
                .Include(l => l.LaptopConfigurations)
                    .ThenInclude(l => l.Configuration)
                    .ThenInclude(l => l.ConfigurationType)
                .Where(l => l.Id == id)
                .FirstOrDefaultAsync();

        /// <summary>
        /// Add new laptop with configurations if there are no laptops with same configs
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> AddAsync(AddLaptopParameter model)
        {
            if(model is null)
            {
                throw new ArgumentNullException(nameof(AddLaptopParameter));
            }

            if (model.Configurations != null && model.Configurations.Count() > 0)
            {
                var existentLaptops = from requestedConfigs in model.Configurations
                                      join existentConfigs in _context.LaptopConfigurations on requestedConfigs equals existentConfigs.ConfigurationId
                                      group new { requestedConfigs, existentConfigs } by existentConfigs.LaptopId into lapropConfigs
                                      let laptopId = lapropConfigs.Key
                                      let configCount = lapropConfigs.Count(l => l.existentConfigs != null)
                                      let totalCount = lapropConfigs.Count()
                                      where configCount == model.Configurations.Count && configCount == totalCount
                                      select laptopId;

                if (existentLaptops != null && existentLaptops.Count() > 0)
                {
                    throw new ArgumentException($"Laptop(s) with the same configurations is(are) already exists! Id(s): [{string.Join(',', existentLaptops)}]");
                }
            }

            var addedlaptop = new Laptop()
            {
                Name = model.Name,
                Price = model.Price
            };
            _context.Laptops.Add(addedlaptop);

            await _context.SaveChangesAsync();

            if (model.Configurations != null && model.Configurations.Count() > 0)
            {
                _context.LaptopConfigurations.AddRange(model.Configurations
                .Select(c => new LaptopConfiguration
                {
                    LaptopId = addedlaptop.Id,
                    ConfigurationId = c
                }));

                await _context.SaveChangesAsync();
            }

            return addedlaptop.Id;
        }
    }
}
