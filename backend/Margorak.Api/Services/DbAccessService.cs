using Margorak.Api.Data;
using Margorak.Api.Dto;
using Microsoft.EntityFrameworkCore;

namespace Margorak.Api.Services
{
    public class DbAccessService
    {
        private readonly AppDbContext _db;
        public DbAccessService(AppDbContext db)
        {
            _db = db;
        }
        public async Task<List<MapDto>> GetMapsAsync()
        {
            var maps = await _db.Maps
                .Include(x=>x.Tiles)
                .ToListAsync();
            var terrains = await _db.Terrains
                .ToListAsync();
            var mapList = new List<MapDto>();
            foreach (var map in maps)
            {
                int maxX = map.Tiles.Max(t => t.XCoord);
                int maxY = map.Tiles.Max(t => t.YCoord);

                var tiles = new MapTileDto[maxY + 1][];

                for (int y = 0; y <= maxY; y++)
                {
                    tiles[y] = new MapTileDto[maxX + 1];
                }

                foreach (var tile in map.Tiles)
                {
                    tiles[tile.YCoord][tile.XCoord] = new MapTileDto
                    {
                        TerrainId = tile.TerrainId,                        
                        Accessible = (terrains
                        .First(x => x.TerrainId == tile.TerrainId)
                        .Accessible==1)
                    };
                    var a = terrains
                        .First(x => x.TerrainId == tile.TerrainId).Accessible==1                        ;
                }

                mapList.Add(new MapDto
                {
                    Id = map.MapId,
                    Name = map.Name,
                    Tiles = tiles
                });
            }
            return mapList;


        }
    }
}
