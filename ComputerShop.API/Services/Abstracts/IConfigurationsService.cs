using ComputerShop.Models.ResponseModels;
using System.Threading.Tasks;

namespace ComputerShop.API.Services.Abstracts
{
    public interface IConfigurationsService
    {
        /// <summary>
        /// Returns a list of all confugurations
        /// </summary>
        /// <returns></returns>
        Task<ConfigurationResponse> GetConfigListAsync();
    }
}
