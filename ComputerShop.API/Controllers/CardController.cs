using ComputerShop.API.Services.Abstracts;
using ComputerShop.Models.RequestModels;
using ComputerShop.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ComputerShop.API.Controllers
{
    [Route("api/v1/orders")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardController(ICardService cardService)
        {
            _cardService = cardService;
        }

        /// <summary>
        /// Creates new order
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync(AddOrderModel model)
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException(string.Join(", ", ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage)));
            }

            var addedOrderId = await _cardService.AddOrderAsync(model);

            return Created("api/v1/orders/" + addedOrderId, new AddedResponse(addedOrderId));
        }
    }
}
