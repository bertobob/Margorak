using Margorak.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Margorak.Api.Data.QueryExtensions
{
    public static class ItemQueryExtensions
    {
        public static IQueryable<Item> IncludeFullItemGraph(this IQueryable<Item> query)
        {
            return query
                .Include(item => item.ItemCategory)
                    .ThenInclude(itemCategory => itemCategory.EquipSlot)
                .Include(item => item.ItemDamages)
                    .ThenInclude(itemDamage => itemDamage.DamageType)
                .Include(item => item.ItemRequirements)
                    .ThenInclude(requirement => requirement.RequirementType)
                .Include(item => item.ItemResistances)
                    .ThenInclude(resistance => resistance.ResistanceType)
                .Include(item => item.ArmorStat)
                .Include(item => item.ConsumableEffect)
                    .ThenInclude(effect => effect.EffectType)
                .Include(item => item.WeaponStat)
                .Include(item => item.ItemBonuses)
                    .ThenInclude(bonus => bonus.BonusType);
        }

        public static IQueryable<OwnedItem> IncludeFullItemGraph(
            this IQueryable<OwnedItem> query)
        {
            return query
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
                        .ThenInclude(bonus => bonus.BonusType);
        }
    }
}
