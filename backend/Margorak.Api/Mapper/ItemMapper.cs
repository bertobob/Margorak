using Margorak.Api.Dto;
using Margorak.Api.Models;

namespace Margorak.Api.Mapper
{
    public static class ItemMapper
    {
        public static ItemDto ToDto(Item item)
        {
            var itemCategory = ItemCategoryMapper.ToDto(item.ItemCategory);
            return new ItemDto
            {
                Id = item.Id,
                Name = item.Name,
                ItemCategory = itemCategory,
                Description = item.Description,
                Value = item.Value,
                Weight = item.Weight
            };
        }
    }
}
