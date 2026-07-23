using Margorak.Api.Data;
using Margorak.Api.Dto;
using Margorak.Api.Interfaces;
using Margorak.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Margorak.Api.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _db;

        public ItemRepository(AppDbContext db)
        {
            _db = db;
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
                .Include(ownedItem => ownedItem.Item)
                    .ThenInclude(item => item.ItemCategory)
                        .ThenInclude(itemCategory => itemCategory.EquipSlot)
                .Include(ownedItem => ownedItem.Item)
                    .ThenInclude(item => item.ItemDamages)
                        .ThenInclude(itemDamage => itemDamage.DamageType)
                .Include(ownedItem => ownedItem.Item)
                    .ThenInclude(item => item.ItemRequirements)
                        .ThenInclude(requirement => requirement.RequirementType)
                .Include(ownedItem => ownedItem.Item)
                    .ThenInclude(item => item.ItemResistances)
                        .ThenInclude(resistance => resistance.ResistanceType)
                .Include(ownedItem => ownedItem.Item)
                    .ThenInclude(item => item.ArmorStat)
                .Include(ownedItem => ownedItem.Item)
                    .ThenInclude(item => item.ConsumableEffect)
                        .ThenInclude(effect => effect.EffectType)
                .Include(ownedItem => ownedItem.Item)
                    .ThenInclude(item => item.WeaponStat)
                .Include(ownedItem => ownedItem.Item)
                    .ThenInclude(item => item.ItemBonuses)
                        .ThenInclude(bonus => bonus.BonusType)
                .AsNoTracking()
                .AsSplitQuery()
                .ToListAsync();
        }

        public async Task<Item?> GetItemByIdAsync(int itemId)
        {
            return await _db.Items
                    .Include(i => i.ItemCategory)
                        .ThenInclude(itemCategory => itemCategory.EquipSlot)
                    .Include(i => i.ItemDamages)
                        .ThenInclude(id => id.DamageType)
                    .Include(i => i.ItemRequirements)
                        .ThenInclude(ir => ir.RequirementType)
                    .Include(i => i.ItemResistances)
                        .ThenInclude(ir => ir.ResistanceType)
                    .Include(i => i.ArmorStat)
                    .Include(i => i.ConsumableEffect)
                        .ThenInclude(ce => ce.EffectType)
                    .Include(i => i.WeaponStat)
                    .Include(i => i.ItemBonuses)
                        .ThenInclude(ib => ib.BonusType)
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

        public async Task SaveEquipmentAsync(int characterId, EquippedItemDto[] equippedItems)
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

            await _db.SaveChangesAsync();
        }
    }
}
