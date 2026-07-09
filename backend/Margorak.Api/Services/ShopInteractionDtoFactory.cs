using Margorak.Api.Dto;
using Margorak.Api.Interfaces;
using Margorak.Api.Models;

namespace Margorak.Api.Services
{
    public class ShopInteractionDtoFactory : IMapInteractionDtoFactory
    {
        private readonly DbAccessService _dbAccessService;
        
        public ShopInteractionDtoFactory(DbAccessService dbAccessService)
        {
            _dbAccessService = dbAccessService;
        }

        public bool CanHandle(string type)
        {
            return type == "shop";
        }

        public async Task<MapInteractionDto> Create(MapInteraction mapInteraction)
        {
            var shop = await _dbAccessService.GetShopInteractionAsync(mapInteraction.Id);
            
            return new ShopInteractionDto
            {
                Id = mapInteraction.Id,
                ShopName = shop.Name,
                Description = shop.Description ?? string.Empty
            };
        }
    }
}
