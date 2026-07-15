using Margorak.Api.Dto;
using Margorak.Api.Interfaces;
using Margorak.Api.Models;

namespace Margorak.Api.Services
{
    public class TeleporterInteractionDtoFactory : IMapInteractionDtoFactory
    {
        private readonly IMapInteractionRepository _mapInteractionRepository;
        public TeleporterInteractionDtoFactory(IMapInteractionRepository mapInteractionRepository)
        {
            _mapInteractionRepository = mapInteractionRepository;
        }
        public bool CanHandle(string type)
        {
            return type == "teleporter";
        }

        public async Task<MapInteractionDto> Create(MapInteraction mapInteraction)
        {
            var teleporter = await _mapInteractionRepository.GetTeleporterInteractionAsync(mapInteraction.Id);

            if (teleporter is null)
            {
                throw new InvalidOperationException(
                    $"Teleporter details for map interaction {mapInteraction.Id} were not found.");
            }

            return new TeleporterInteractionDto
            {
                Id = mapInteraction.Id,               
                Description = teleporter.Description ?? string.Empty,
                DestinationMapId = teleporter.DestinationMapId,
                DestinationLocX = teleporter.DestinationLocX,
                DestinationLocY = teleporter.DestinationLocY,
            };
        }
    }
}
