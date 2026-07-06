using Margorak.Api.Dto;
using Margorak.Api.Interfaces;
using Margorak.Api.Models;

namespace Margorak.Api.Mapper
{
    public static class MapInteractionMapper
    {
        public static async Task<MapInteractionDto> ToDto(MapInteraction mapInteraction, IEnumerable<IMapInteractionDtoFactory> factories)
        {
            var type = mapInteraction
                .Category
                .Name;

            var factory = factories
                .First(x => x.CanHandle(type));

            return await factory.Create(mapInteraction);
        }
    }
}
