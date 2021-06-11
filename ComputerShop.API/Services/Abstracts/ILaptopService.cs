using ComputerShop.Models.RequestModels;
using ComputerShop.Models.ResponseModels;
using System;
using System.Threading.Tasks;

namespace ComputerShop.API.Services.Abstracts
{
    /// <summary>
    /// Service to manage laptops
    /// </summary>
    public interface ILaptopService
    {
        /// <summary>
        /// Returns a list of all laptops
        /// </summary>
        /// <returns></returns>
        Task<LaptopListResponse> GetLaptopListAsync();

        /// <summary>
        /// Returns a list of all laptops
        /// </summary>
        /// <returns></returns>
        Task<LaptopResponse> GetLaptopAsync(Guid id);

        /// <summary>
        /// Add new laptop with configurations if there are no laptops with same configs
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Guid> AddLaptopAsync(AddLaptopModel model);

        /// <summary>
        /// Add configuration to the provided laptop
        /// </summary>
        /// <param name="laptopId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Guid> AddConfigurationToLaptopAsync(Guid laptopId, AddLaptopConfigurationModel model);
    }
}
