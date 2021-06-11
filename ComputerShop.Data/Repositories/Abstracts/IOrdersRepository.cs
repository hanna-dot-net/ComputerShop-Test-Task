using ComputerShop.Data.Contracts;
using System;
using System.Threading.Tasks;

namespace ComputerShop.Data.Repositories.Abstracts
{
    public interface IOrdersRepository
    {
        /// <summary>
        /// Create new order with provided laptop
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<Guid> AddAsync(AddOrderParameter model);
    }
}
