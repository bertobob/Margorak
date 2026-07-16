using Margorak.Api.Dto;
using Margorak.Api.Models;

namespace Margorak.Api.Mapper
{
    public static class ItemMapper
    {
        public static ItemDto ToDto(Item item)
        {
            var itemCategory = ItemCategoryMapper.ToDto(item.ItemCategory);
            var armorStat = item.ArmorStat.FirstOrDefault();
            var weaponStat = item.WeaponStat.FirstOrDefault();

            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                ItemCategory = itemCategory,
                ItemDamages = item.ItemDamages.Select(ItemDamageMapper.ToDto).ToList(),
                ItemRequirements = item.ItemRequirements.Select(ItemRequirementMapper.ToDto).ToList(),
                ItemResistances = item.ItemResistances.Select(ItemResistanceMapper.ToDto).ToList(),
                ArmorStat = armorStat is null ? null : ArmorStatMapper.ToDto(armorStat),
                WeaponStat = weaponStat is null ? null : WeaponStatMapper.ToDto(weaponStat),
                ConsumableEffects = item.ConsumableEffect.Select(ConsumableEffectMapper.ToDto).ToList(),
                ItemBonuses = item.ItemBonuses.Select(ItemBonusMapper.ToDto).ToList(),
                Description = item.Description,
                Value = item.Value,
                Weight = item.Weight
            };
        }
    }
}
