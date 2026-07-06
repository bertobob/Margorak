using Margorak.Api.Dto;
using Margorak.Api.Interfaces;
using Margorak.Api.Models;

namespace Margorak.Api.Mapper
{
    public static class MapMapper
    {
        public static async Task<MapDto> ToDto(Map map, IEnumerable<IMapInteractionDtoFactory> factories)
        {
            var tiles = await CreateTiles(map, factories);

            return new MapDto
            {
                Id = map.Id,
                Name = map.Name,
                Tiles = tiles,
                SightRange = map.SightRange,
                ClickRange = map.ClickRange,
            };
        }

        private static async Task<MapTileDto[][]> CreateTiles(Map map, IEnumerable<IMapInteractionDtoFactory> factories)
        {
            if (map.Tiles.Count == 0)
            {
                return [];
            }

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
                    mapInteractionDto = await MapInteractionMapper.ToDto(mapInteraction, factories);
                }

                tiles[tile.YCoord][tile.XCoord] = MapTileMapper.ToDto(tile, mapInteractionDto);
            }

            return tiles;
        }
    }
}
