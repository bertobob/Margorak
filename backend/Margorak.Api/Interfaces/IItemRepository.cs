using Margorak.Api.Models;

namespace Margorak.Api.Interfaces
{
    public interface IItemRepository
    {
        Task<Item> GetItemByIdAsync(int itemId);
        Task<List<Item>> GetItemsByIdsAsync(List<int> itemIds);
    }
}
