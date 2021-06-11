using AutoMapper;
using ComputerShop.API.Services.Abstracts;
using ComputerShop.Data.Contracts;
using ComputerShop.Data.Repositories;
using ComputerShop.Data.Repositories.Abstracts;
using ComputerShop.Models.RequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.API.Services
{
    public class CardService : ICardService
    {
        private readonly ILaptopRepository _laptopRepository;
        private readonly IOrdersRepository _ordersRepository;
        private readonly IMapper _mapper;

        public CardService(ILaptopRepository laptopRepository,
            IOrdersRepository ordersRepository,
            IMapper mapper)
        {
            _laptopRepository = laptopRepository;
            _ordersRepository = ordersRepository;
            _mapper = mapper;
        }

       // public async Task<List<Order>>

        /// <summary>
        /// Create new order with provided laptop
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> AddOrderAsync(AddOrderModel model)
        {
            if(model == null)
            {
                throw new ArgumentNullException(nameof(AddOrderModel));
            }

            var existentLaptopId = await _laptopRepository.GetAsync(model.LaptopId);
            if(existentLaptopId == null)
            {
                throw new ArgumentNullException($"Laptop with provided id [{existentLaptopId}] cannot be found!");
            }

            var addedOrderId = await _ordersRepository.AddAsync(_mapper.Map<AddOrderParameter>(model));

            return addedOrderId;
        }
    }
}
