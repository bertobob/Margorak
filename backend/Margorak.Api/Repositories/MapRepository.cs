using Margorak.Api.Data;
using Margorak.Api.Interfaces;
using Margorak.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Margorak.Api.Repositories
{
    public class MapRepository : IMapRepository
    {
        private readonly AppDbContext _db;

        public MapRepository(AppDbContext db)
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
    }
}
