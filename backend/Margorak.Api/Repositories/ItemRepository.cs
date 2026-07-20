using Margorak.Api.Data;
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
                        .ThenInclude(armorStat => armorStat.EquipSlot)
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
                    .Include(i => i.ItemDamages)
                        .ThenInclude(id => id.DamageType)
                    .Include(i => i.ItemRequirements)
                        .ThenInclude(ir => ir.RequirementType)
                    .Include(i => i.ItemResistances)
                        .ThenInclude(ir => ir.ResistanceType)
                    .Include(i => i.ArmorStat)
                        .ThenInclude(a => a.EquipSlot)
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
                .Where(x => itemIds.Contains(x.Id))
                .AsNoTracking()
                .ToListAsync();

            return itemList;
        }
    }
}
