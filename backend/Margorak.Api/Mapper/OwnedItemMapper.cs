using Margorak.Api.Dto;
using Margorak.Api.Models;

namespace Margorak.Api.Mapper
{
    public static class OwnedItemMapper
    {
        public static OwnedItemDto ToDto(OwnedItem ownedItem)
        {
            var itemDto = ItemMapper.ToDto(ownedItem.Item);
            return new OwnedItemDto
            {
                Id = ownedItem.Id,
                Item = itemDto,
                Quantity = ownedItem.Quantity,
                Version = ownedItem.Version
            };
        }
    }
}
