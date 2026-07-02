using Margorak.Api.Dto;
using Margorak.Api.Interfaces;
using Margorak.Api.Models;

namespace Margorak.Api.Services
{
    public class TeleporterInteractionDtoFactory : IMapInteractionDtoFactory
    {
        private readonly DbAccessService _dbAccessService;
        public TeleporterInteractionDtoFactory(DbAccessService dbAccessService)
        {
            _dbAccessService = dbAccessService;
        }
        public bool CanHandle(string type)
        {
            return type == "teleporter";
        }

        public async Task<MapInteractionDto> Create(MapInteraction mapInteraction)
        {
            var teleporter = await _dbAccessService.GetTeleporterInteractionAsync(mapInteraction.Id);
            return new TeleporterInteractionDto
            {
                Id = mapInteraction.Id,
                Type = "teleporter",
                Description = teleporter.Description,
                DestinationMapId = teleporter.DestinationMapId,
                DestinationLocX = teleporter.DestinationLocX,
                DestinationLocY = teleporter.DestinationLocY,
            };
        }
    }
}
