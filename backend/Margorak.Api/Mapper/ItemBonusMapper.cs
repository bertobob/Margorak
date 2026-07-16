using Margorak.Api.Dto;
using Margorak.Api.Models;

namespace Margorak.Api.Mapper
{
    public static class ItemBonusMapper
    {
        public static ItemBonusDto ToDto(ItemBonus itemBonus)
        {
            return new ItemBonusDto
            {
                BonusType = BonusTypeMapper.ToDto(itemBonus.BonusType),
                Value = itemBonus.Value
            };
        }
    }
}
