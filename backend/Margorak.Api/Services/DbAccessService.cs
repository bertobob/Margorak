using Margorak.Api.Data;
using Margorak.Api.Dto;
using Margorak.Api.Interfaces;
using Margorak.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Margorak.Api.Services
{
    public class DbAccessService
    {
        private readonly AppDbContext _db;
        
        public DbAccessService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Map>> GetMapsAsync()
        {
            var maps = await _db.Maps
                .Include(x => x.Tiles)
                    .ThenInclude(x => x.Terrain)
                .Include(x => x.Interactions)
                    .ThenInclude(x => x.Category)
                .ToListAsync();
            
            return maps;
        }

        public  async Task<ShopInteraction> GetShopInteractionAsync(int id)
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
