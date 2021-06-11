using AutoMapper;
using ComputerShop.API.Services.Abstracts;
using ComputerShop.Data.Contracts;
using ComputerShop.Data.Repositories;
using ComputerShop.Models.RequestModels;
using ComputerShop.Models.ResponseModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.API.Services
{
    /// <summary>
    /// Service to manage laptops
    /// </summary>
    public class LaptopService : ILaptopService
    {
        private readonly ILaptopRepository _laptopRepository;
        private readonly IConfigurationsRepository _configurationsRepository;
        private readonly IMapper _mapper;

        public LaptopService(ILaptopRepository laptopRepository,
            IConfigurationsRepository configurationsRepository,
            IMapper mapper)
        {
            _laptopRepository = laptopRepository;
            _configurationsRepository = configurationsRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns a list of all laptops
        /// </summary>
        /// <returns></returns>
        public async Task<LaptopListResponse> GetLaptopListAsync()
        {
            var laptops = await _laptopRepository.GetListAsync();
            var laptopList = laptops.Select(l => _mapper.Map<LaptopModel>(l)).ToList();

            return new LaptopListResponse() { Laptops = laptopList };
        }

        /// <summary>
        /// Returns a list of all laptops
        /// </summary>
        /// <returns></returns>
        public async Task<LaptopResponse> GetLaptopAsync(Guid id)
            => _mapper.Map<LaptopResponse>(await _laptopRepository.GetAsync(id));

        /// <summary>
        /// Add new laptop with configurations if there are no laptops with same configs
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> AddLaptopAsync(AddLaptopModel model)
        { 
            if(model == null)
            {
                throw new ArgumentNullException(nameof(AddLaptopModel));
            }

            if(model.Configurations != null && model.Configurations.Count() > 0)
            {
                foreach (Guid configId in model.Configurations)
                {
                    var existentConfiguration = await _configurationsRepository.GetConfigurationAsync((Guid)configId);
                    if (existentConfiguration == null)
                    {
                        throw new ArgumentException($"Configuration with id [{configId}] cannot be found!");
                    }
                }
            }

            return await _laptopRepository.AddAsync(_mapper.Map<AddLaptopParameter>(model));
        }

        /// <summary>
        /// Add configuration to the provided laptop
        /// </summary>
        /// <param name="laptopId"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Guid> AddConfigurationToLaptopAsync(Guid laptopId, AddLaptopConfigurationModel model)
        {
            if(model == null)
            {
                throw new ArgumentNullException(nameof(AddLaptopConfigurationModel));
            }

            var laptop = await _laptopRepository.GetAsync(laptopId);
            if(laptop == null)
            {
                throw new ArgumentException($"Laptop with id [{laptopId}] cannot be found!");
            }

            var configurationType = await _configurationsRepository.GetTypeAsync(model.ConfigurationTypeId);
            if (configurationType == null)
            {
                throw new ArgumentException($"Configuration type with id [{model.ConfigurationTypeId}] cannot be found!");
            }

            if (laptop.LaptopConfigurations.Any(c => c.Configuration.ConfigurationTypeId == model.ConfigurationTypeId))
            {
                throw new ArgumentException($"Same configuration for provided laptop already exists!");
            }

            var existentConfig = await _configurationsRepository.GetConfigurationAsync(model.ConfigurationTypeId, model.Value, model.Price);
            if (existentConfig == null)
            {
                var createdConfigurationId = await _configurationsRepository.AddConfigurationAsync(_mapper.Map<AddConfigurationParameter>(model));

                return await _configurationsRepository.AddLaptopConfigurationAsync(laptopId, createdConfigurationId);
            }

            return await _configurationsRepository.AddLaptopConfigurationAsync(laptopId, existentConfig.Id);
        }
    }
}
