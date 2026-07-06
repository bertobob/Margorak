using Margorak.Api.Dto;
using Margorak.Api.Models;

namespace Margorak.Api.Mapper
{
    public static class TerrainTypeMapper
    {
        public static TerrainTypeDto ToDto(TerrainType terrainType)
        {
            return new TerrainTypeDto
            {
                Id = terrainType.Id,
                Name = terrainType.Name
            };
        }
    }
}
