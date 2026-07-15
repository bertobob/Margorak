using Margorak.Api.Models;

namespace Margorak.Api.Interfaces
{
    public interface IMapInteractionRepository
    {
        Task<ShopInteraction?> GetShopInteractionAsync(int id);
        Task<TeleporterInteraction?> GetTeleporterInteractionAsync(int id);
    }
}
