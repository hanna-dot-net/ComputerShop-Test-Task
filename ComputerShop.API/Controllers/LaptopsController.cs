using ComputerShop.API.Services.Abstracts;
using ComputerShop.Models.RequestModels;
using ComputerShop.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.API.Controllers
{
    [Route("api/v1/laptops")]
    [ApiController]
    public class LaptopsController : ControllerBase
    {
        private readonly ILaptopService _laptopService;
        public LaptopsController(ILaptopService laptopService)
        {
            _laptopService = laptopService;
        }

        /// <summary>
        /// Returns a list of all laptops
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetLaptopsAsync()
        {
            var laptops = await _laptopService.GetLaptopListAsync();

            return Ok(laptops);
        }

        /// <summary>
        /// Returns a list of all laptops
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLaptopAsync([FromRoute]Guid id)
        {
            var laptop = await _laptopService.GetLaptopAsync(id);

            return Ok(laptop);
        }

        /// <summary>
        /// Create new laptop with provided configurationa
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddLaptopAsync([FromBody] AddLaptopModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException(string.Join(", ", ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage)));
            }

            var addedLaptopGuid = await _laptopService.AddLaptopAsync(model);

            return Created("api/v1/laptops/" + addedLaptopGuid, new AddedResponse(addedLaptopGuid));
        }

        /// <summary>
        /// Create new laptop with provided configurationa
        /// </summary>
        /// <returns></returns>
        [HttpPost("{id}/configurations")]
        public async Task<IActionResult> AddLaptopConfigAsync([FromRoute]Guid id, [FromBody] AddLaptopConfigurationModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException(string.Join(", ", ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage)));
            }

            var addedLaptopConfigId = await _laptopService.AddConfigurationToLaptopAsync(id, model);

            return Created($"api/v1/laptops/{id}/configurations/{addedLaptopConfigId}", new AddedResponse(addedLaptopConfigId));
        }
    }
}
