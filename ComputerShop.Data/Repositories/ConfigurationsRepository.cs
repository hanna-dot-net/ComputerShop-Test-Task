using ComputerShop.Data.Contracts;
using ComputerShop.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.Data.Repositories
{
    public class ConfigurationsRepository : IConfigurationsRepository
    {
        private readonly ComputerShopContext _context;
        public ConfigurationsRepository(ComputerShopContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Returns a list of all configurations
        /// </summary>
        /// <returns></returns>
        public async Task<List<Configuration>> GetListAsync()
            => await _context.Configurations
                .Include(c => c.ConfigurationType)
                .ToListAsync();

        /// <summary>
        /// Returns a list of all configuration types
        /// </summary>
        /// <returns></returns>
        public async Task<List<ConfigurationType>> GetTypeListAsync()
            => await _context.ConfigurationTypes.ToListAsync();

        /// <summary>
        /// Returns configuration by id
        /// </summary>
        /// <returns></returns>
        public async Task<ConfigurationType> GetTypeAsync(Guid id)
            => await _context
                .ConfigurationTypes
                .Where(l => l.Id == id)
                .FirstOrDefaultAsync();

        /// <summary>
        /// Returns configuration type by Id
        /// </summary>
        /// <returns></returns>
        public async Task<Configuration> GetConfigurationAsync(Guid id)
            => await _context
                .Configurations
                .Where(l => l.Id == id)
                .FirstOrDefaultAsync();

        /// <summary>
        /// Returns configuration type by value and config type
        /// </summary>
        /// <returns></returns>
        public async Task<Configuration> GetConfigurationAsync(Guid typeId, string value, double price)
            => await _context
                .Configurations
                .Where(l => l.ConfigurationTypeId == typeId && string.Equals(l.Value, value) && l.Price == price)
                .FirstOrDefaultAsync();

        /// <summary>
        /// Add new configuration
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> AddConfigurationAsync(AddConfigurationParameter model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(Configuration));
            }

            var addedConfig = new Configuration()
            {
                ConfigurationTypeId = model.ConfigurationTypeId,
                Price = model.Price,
                Value = model.Value
            };

            _context.Configurations.Add(addedConfig);

            await _context.SaveChangesAsync();

            return addedConfig.Id;
        }

        /// <summary>
        /// Add new configuration to the laptop by id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> AddLaptopConfigurationAsync(Guid laptopId, Guid configId)
        {

            var addedLaptopConfig = new LaptopConfiguration()
            {
                ConfigurationId = configId,
                LaptopId = laptopId,
            };

            _context.LaptopConfigurations.Add(addedLaptopConfig);

            await _context.SaveChangesAsync();

            return addedLaptopConfig.Id;
        }
    }
}
