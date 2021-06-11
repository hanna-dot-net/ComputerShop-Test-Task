using ComputerShop.Data.Contracts;
using ComputerShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputerShop.Data.Repositories
{
    public interface IConfigurationsRepository
    {
        /// <summary>
        /// Returns a list of all configurations
        /// </summary>
        /// <returns></returns>
        Task<List<Configuration>> GetListAsync();

        /// <summary>
        /// Returns a list of all configuration types
        /// </summary>
        /// <returns></returns>
        Task<List<ConfigurationType>> GetTypeListAsync();

        /// <summary>
        /// Returns configuration by id
        /// </summary>
        /// <returns></returns>
        Task<ConfigurationType> GetTypeAsync(Guid id);

        /// <summary>
        /// Returns configuration type by Id
        /// </summary>
        /// <returns></returns>
        Task<Configuration> GetConfigurationAsync(Guid id);

        /// <summary>
        /// Returns configuration type by name and config type
        /// </summary>
        /// <returns></returns>
        Task<Configuration> GetConfigurationAsync(Guid typeId, string value, double price);

        /// <summary>
        /// Add new configuration
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Guid> AddConfigurationAsync(AddConfigurationParameter model);

        /// <summary>
        /// Add new configuration to the laptop by id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Guid> AddLaptopConfigurationAsync(Guid laptopId, Guid configId);
    }
}
