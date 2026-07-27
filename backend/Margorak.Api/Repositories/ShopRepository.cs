using Margorak.Api.Data;
using Margorak.Api.Data.QueryExtensions;
using Margorak.Api.Interfaces;
using Margorak.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Margorak.Api.Repositories
{
    public class ShopRepository : IShopRepository
    {
        private readonly AppDbContext _db;

        public ShopRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<ShopInteraction?> GetShopByIdAsync(int mapInteractionId)
        {
            return await _db.ShopInteractions
                .AsNoTracking()
                .SingleOrDefaultAsync(shop => shop.MapInteractionId == mapInteractionId);
        }

        public async Task<List<Item>> GetShopItemsAsync(int shopInteractionId)
        {
            return await _db.Items
                .Where(item => item.ShopItems.Any(
                    shopItem => shopItem.ShopInteractionId == shopInteractionId))
                .IncludeFullItemGraph()
                .AsNoTracking()
                .AsSplitQuery()
                .ToListAsync();
        }
    }
}
