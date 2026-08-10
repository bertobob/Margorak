using Margorak.Api.Dto;
using Margorak.Api.Models;

namespace Margorak.Api.Interfaces
{
    public interface IItemRepository
    {
        Task<Item?> GetItemByIdAsync(int itemId);
        Task<List<Item>> GetItemsByIdsAsync(List<int> itemIds);
        Task<List<OwnedItem>?> GetInventoryItemsByCharacterIdAsync(int characterId);
        Task<List<OwnedItem>> GetUnequippedInventoryItemsByCharacterIdAsync(int characterId);
        Task ReplaceEquipmentAsync(int characterId, EquippedItemDto[] EquippedItems);
        Task<List<OwnedItem>> GetOwnedItemsByIdsAsync(int characterId, IEnumerable<int> ownedItemIds);

        Task<OwnedItem?> GetOwnedItemAsync(int characterId,int itemId);
        void AddOwnedItem(OwnedItem item);
        void RemoveOwnedItem(OwnedItem item);



    }
}
