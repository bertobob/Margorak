using Margorak.Api.Dto;
using Margorak.Api.Interfaces;
using Margorak.Api.Mapper;

namespace Margorak.Api.Services
{
    public class ItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {   
            _itemRepository= itemRepository;
        }

        public async Task<ItemDto?> GetItemByIdAsync(int itemId)
        {
            var item  = await _itemRepository.GetItemByIdAsync(itemId);
            
            return item is null
                ? null
                : ItemMapper.ToDto(item);

        }

        public async Task<List<InventoryItemDto>?> GetInventoryItemsByCharacterIdAsync(int characterId)
        {
            var ownedItems = await _itemRepository
                .GetInventoryItemsByCharacterIdAsync(characterId);

            var inventoryItems = ownedItems?
                .Select(ownedItem => new InventoryItemDto
                {
                    Item = ItemMapper.ToDto(ownedItem.Item),
                    Quantity = ownedItem.Quantity

                })
                .ToList();

            return inventoryItems;

        }
    }
}
