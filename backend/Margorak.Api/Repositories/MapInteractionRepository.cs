using Margorak.Api.Data;
using Margorak.Api.Interfaces;
using Margorak.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Margorak.Api.Repositories
{
    public class MapInteractionRepository : IMapInteractionRepository
    {
        private readonly AppDbContext _db;

        public MapInteractionRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<ShopInteraction> GetShopInteractionAsync(int id)
        {
            var shop = await _db.ShopInteractions
                .FirstAsync(x => x.MapInteractionId == id);

            return shop;
        }

        public async Task<TeleporterInteraction> GetTeleporterInteractionAsync(int id)
        {
            var teleporter = await _db.TeleporterInteractions
                .FirstAsync(x => x.MapInteractionId == id);

            return teleporter;
        }
    }
}
