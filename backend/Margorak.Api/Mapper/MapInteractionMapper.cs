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
                .Category?
                .Name;

            if(string.IsNullOrWhiteSpace(type))
            {
                throw new InvalidOperationException(
                    $"Map interaction {mapInteraction.Id} has no valid category.");
            }

            var factory = factories
                .FirstOrDefault(x => x.CanHandle(type));

            if(factory is null)
            {
                throw new InvalidOperationException(
                     $"No DTO factory is registered for interaction type '{type}' " +
                       $"(interaction ID {mapInteraction.Id}).");                    
            }

            return await factory.Create(mapInteraction);
        }
    }
}
