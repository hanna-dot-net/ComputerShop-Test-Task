using AutoMapper;
using ComputerShop.API.Services.Abstracts;
using ComputerShop.Data.Repositories;
using ComputerShop.Models.ResponseModels;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.API.Services
{

    public class ConfigurationsService : IConfigurationsService
    {
        private readonly IConfigurationsRepository _configurationsRepository;
        private readonly IMapper _mapper;

        public ConfigurationsService(IConfigurationsRepository configurationsRepository,
            IMapper mapper)
        {
            _configurationsRepository = configurationsRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns a list of all confugurations
        /// </summary>
        /// <returns></returns>
        public async Task<ConfigurationResponse> GetConfigListAsync()
        {
            var configs = await _configurationsRepository.GetListAsync();

            return new ConfigurationResponse
            {
                Configurations = configs.Select(c => _mapper.Map<ConfigurationModel>(c))
            };
        }
    }
}
