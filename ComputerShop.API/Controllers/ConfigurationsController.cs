using ComputerShop.API.Services.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ComputerShop.API.Controllers
{
    [Route("api/v1/configurations")]
    [ApiController]
    public class ConfigurationsController : ControllerBase
    {
        private readonly IConfigurationsService _configurationsService;

        public ConfigurationsController(IConfigurationsService configurationsService)
        {
            _configurationsService = configurationsService;
        }

        /// <summary>
        /// Returns a list of all laptops
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetLaptopsAsync()
        {
            var configs = await _configurationsService.GetConfigListAsync();

            return Ok(configs);
        }
    }
}
