using Margorak.Api.Dto;
using Margorak.Api.Models;

namespace Margorak.Api.Mapper
{
    public static class MapTileMapper
    {
        public static MapTileDto ToDto(MapTile mapTile, MapInteractionDto? mapInteraction)
        {
            return new MapTileDto
            {
                TerrainId = mapTile.TerrainId,
                Accessible = mapTile.Terrain.Accessible == 1,
                MapInteraction = mapInteraction,
            };
        }
    }
}
