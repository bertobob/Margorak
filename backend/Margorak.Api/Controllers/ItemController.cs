using Margorak.Api.Dto;
using Margorak.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Margorak.Api.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemController : Controller
    {
        private readonly ItemService _itemService;

        public ItemController(ItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("{itemId:int}", Name ="GetItemById")]
        public async Task<ActionResult<ItemDto>> GetItemByIdAsync(int itemId)
        {
            var result = await _itemService.GetItemByIdAsync(itemId);

            return result is null
                ? NotFound()
                : Ok(result);
        }

    }
}
