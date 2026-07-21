using Margorak.Api.Dto;
using Margorak.Api.Models;

namespace Margorak.Api.Mapper
{
    public static class ItemCategoryMapper
    {
        public static ItemCategoryDto ToDto(ItemCategory itemCategory)
        {
            return new ItemCategoryDto
            {
                Id = itemCategory.Id,
                Name = itemCategory.Name,
                EquipSlot = itemCategory.EquipSlot is null
                    ? null
                    : EquipSlotMapper.ToDto(itemCategory.EquipSlot)
            };
        }
    }
}
