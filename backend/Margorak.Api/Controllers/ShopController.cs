using Margorak.Api.Dto;
using Margorak.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Margorak.Api.Controllers
{
    [ApiController]
    [Route("api/shops")]
    public class ShopController : ControllerBase
    {
        private readonly ShopService _shopService;

        public ShopController(ShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet("{mapInteractionId:int}")]
        public async Task<ActionResult<ShopDto>> GetShopByIdAsync(int mapInteractionId)
        {
            var result = await _shopService.GetShopByIdAsync(mapInteractionId);

            return result is null
                ? NotFound()
                : Ok(result);
        }

        [HttpPost("{mapInteractionId:int}/buy")]
        public async Task<ActionResult<TradeItemResponseDto>> BuyItemAsync(
            int mapInteractionId,
            TradeItemRequestDto item)
        {
            var result = await _shopService.BuyItemAsync(mapInteractionId, item);

            return result is null
                ? BadRequest() 
                : Ok(result);
        }

        [HttpPost("{mapInteractionId:int}/sell")]
        public async Task<ActionResult<TradeItemResponseDto>> SellItemAsync(int mapInteractionId, TradeItemRequestDto item)
        {
            var result = await _shopService.SellItemAsync(mapInteractionId, item);

            return result is null
                ? BadRequest()
                : Ok(result);
        }
    }
}
