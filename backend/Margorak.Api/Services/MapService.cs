using Margorak.Api.Dto;
using Margorak.Api.Interfaces;

namespace Margorak.Api.Services
{
    public class MapService
    {
        private readonly DbAccessService _dbAccessService;
        private readonly IEnumerable<IMapInteractionDtoFactory> _factories;
        public MapService(DbAccessService dbAccessService,IEnumerable<IMapInteractionDtoFactory> factories)
        {
            _dbAccessService = dbAccessService;
            _factories = factories;
        }

        public async Task<List<MapDto>> GetMapsAsync()
        {
            var maps = await _dbAccessService.GetMapsAsync();

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
                    var mapInteraction = map.Interactions
                        .Where(x => x.LocX == tile.XCoord && x.LocY == tile.YCoord)
                        .FirstOrDefault();

                    MapInteractionDto? mapInteractionDto = null;
                    if (mapInteraction != null)
                    {
                        var type = mapInteraction
                            .Category
                            .Name;

                        var factory = _factories
                            .First(x => x.CanHandle(type));
                        mapInteractionDto = await factory.Create(mapInteraction);
                    }
                    tiles[tile.YCoord][tile.XCoord] = new MapTileDto
                    {
                        TerrainId = tile.TerrainId,
                        Accessible = tile.Terrain.Accessible == 1,
                        MapInteraction = mapInteractionDto
                    }; ;
                }

                mapList.Add(new MapDto
                {
                    Id = map.Id,
                    Name = map.Name,
                    Tiles = tiles,
                    SightRange = map.SightRange,
                    ClickRange = map.ClickRange
                });
            }
            return mapList;
        }
    }
}
