using Margorak.Api.Data;
using Margorak.Api.Data.QueryExtensions;
using Margorak.Api.Dto;
using Margorak.Api.Interfaces;
using Margorak.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Margorak.Api.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _db;

        public ItemRepository(AppDbContext db)
        {
            _db = db;
        }

        public void AddOwnedItem(OwnedItem item)
        {
            _db.OwnedItems.Add(item);
        }

        public void RemoveOwnedItem(OwnedItem item)
        {
            _db.OwnedItems
                .Remove(item);
        }


        public async Task<List<OwnedItem>?> GetInventoryItemsByCharacterIdAsync(int characterId)
        {
            var characterExists = await _db.Characters
                .AnyAsync(c => c.Id == characterId);

            if (!characterExists)
            {
                return null;
            }

            return  await _db.OwnedItems
                .Where(ownedItem => ownedItem.CharacterId == characterId)
                .IncludeFullItemGraph()
                .AsNoTracking()
                .AsSplitQuery()
                .ToListAsync();
        }

        public async Task<List<OwnedItem>> GetUnequippedInventoryItemsByCharacterIdAsync(
            int characterId)
        {
            return await _db.OwnedItems
                .Where(ownedItem =>
                    ownedItem.CharacterId == characterId &&
                    !ownedItem.CharacterEquipment.Any())
                .IncludeFullItemGraph()
                .AsNoTracking()
                .AsSplitQuery()
                .ToListAsync();
        }

        public async Task<Item?> GetItemByIdAsync(int itemId)
        {
            return await _db.Items
                    .IncludeFullItemGraph()
                    .AsNoTracking()
                    .AsSplitQuery()
                    .FirstOrDefaultAsync(x => x.Id == itemId);
        }


        public async Task<List<Item>> GetItemsByIdsAsync(List<int> itemIds)
        {
            var itemList = await _db.Items
                .Include(c => c.ItemCategory)
                    .ThenInclude(itemCategory => itemCategory.EquipSlot)
                .Where(x => itemIds.Contains(x.Id))
                .ToListAsync();

            return itemList;
        }

        public Task<OwnedItem?> GetOwnedItemAsync(int characterId, int itemId)
        {
            return _db.OwnedItems
                .FirstOrDefaultAsync(
                    ownedItem => ownedItem.CharacterId == characterId && ownedItem.ItemId == itemId);
        }

        public async Task<List<OwnedItem>> GetOwnedItemsByIdsAsync(
            int characterId,
            IEnumerable<int> ownedItemIds)
        {
            return await _db.OwnedItems
                .Where(ownedItem =>
                    ownedItem.CharacterId == characterId &&
                    ownedItemIds.Contains(ownedItem.Id))
                .Include(ownedItem => ownedItem.Item)
                    .ThenInclude(item => item.ItemCategory)
                .ToListAsync();
        }

        public async Task ReplaceEquipmentAsync(int characterId, EquippedItemDto[] equippedItems)
        {
            var currentEquipment = await _db.CharacterEquipment
                .Where(equipment => equipment.CharacterId == characterId)
                .ToListAsync();

            _db.CharacterEquipment.RemoveRange(currentEquipment);

            var newEquipment = equippedItems
                .Select(equippedItem => new CharacterEquipment
                {
                    CharacterId = characterId,
                    OwnedItemId = equippedItem.OwnedItemId,
                    EquipSlotId = equippedItem.EquipSlotId
                });

            _db.CharacterEquipment.AddRange(newEquipment);
        }
    }
}
