using Margorak.Api.Models;

namespace Margorak.Api.Interfaces
{
    public interface IShopRepository
    {
        Task<ShopInteraction?> GetShopByIdAsync(int shopInteractionId);
        Task<List<Item>> GetShopItemsAsync(int shopInteractionId);
    }
}
