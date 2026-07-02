using Margorak.Api.Dto;
using Margorak.Api.Models;

namespace Margorak.Api.Interfaces
{
    public interface IMapInteractionDtoFactory
    {
        bool CanHandle(string type);
        Task<MapInteractionDto> Create(MapInteraction mapInteraction);
    }
}
