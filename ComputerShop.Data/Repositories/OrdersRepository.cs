using ComputerShop.Data.Contracts;
using ComputerShop.Data.Models;
using ComputerShop.Data.Repositories.Abstracts;
using System;
using System.Threading.Tasks;

namespace ComputerShop.Data.Repositories
{
    public class OrdersRepository : IOrdersRepository
    {
        private readonly ComputerShopContext _context;
        public OrdersRepository(ComputerShopContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create new order with provided laptop
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> AddAsync(AddOrderParameter model)
        {
            if(model == null)
            {
                throw new ArgumentNullException(nameof(Order));
            }

            var addedOrder = new Order()
            {
                CustomerName = model.CustomerName,
                LaptopId = model.LaptopId
            };

            _context.Orders.Add(addedOrder);

            await _context.SaveChangesAsync();

            return addedOrder.Id;
        }
    }
}
