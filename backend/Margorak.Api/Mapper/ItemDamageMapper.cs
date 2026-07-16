using Margorak.Api.Dto;
using Margorak.Api.Models;

namespace Margorak.Api.Mapper
{
    public static class ItemDamageMapper
    {
        public static ItemDamageDto ToDto(ItemDamage itemDamage)
        {
            return new ItemDamageDto
            {
                DamageType = DamageTypeMapper.ToDto(itemDamage.DamageType),
                MinDamage = itemDamage.MinDamage,
                MaxDamage = itemDamage.MaxDamage
            };
        }
    }
}
