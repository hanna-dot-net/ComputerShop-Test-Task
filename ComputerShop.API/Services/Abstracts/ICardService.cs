using ComputerShop.Models.RequestModels;
using System;
using System.Threading.Tasks;

namespace ComputerShop.API.Services.Abstracts
{
    public interface ICardService
    {
        /// <summary>
        /// Create new order with provided laptop
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Guid> AddOrderAsync(AddOrderModel model);
    }
}
