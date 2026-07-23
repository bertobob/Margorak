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

    }
}
