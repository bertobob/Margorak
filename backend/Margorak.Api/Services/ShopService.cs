using Margorak.Api.Dto;
using Margorak.Api.Interfaces;
using Margorak.Api.Mapper;
using Margorak.Api.Models;

namespace Margorak.Api.Services
{
    public class ShopService
    {
        private readonly IShopRepository _shopRepository;
        private readonly IMapInteractionRepository _interactionRepository;
        private readonly ICharacterRepository _characterRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ShopService(
            IShopRepository shopRepository,
            IMapInteractionRepository interactionRepository, 
            ICharacterRepository characterRepository,
            IItemRepository itemRepository,
            IUnitOfWork unitOfWork)
        {
            _shopRepository = shopRepository;
            _interactionRepository = interactionRepository;
            _characterRepository = characterRepository;
            _itemRepository = itemRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ShopDto?> GetShopByIdAsync(int shopInteractionId)
        {
            var shop = await _shopRepository.GetShopByIdAsync(shopInteractionId);

            if (shop is null)
            {
                return null;
            }

            var items = await _shopRepository.GetShopItemsAsync(shop.Id);

            return new ShopDto
            {
                Greed = shop.Greed,
                ShopItems = items.Select(ItemMapper.ToDto).ToList()
            };
        }
        public async Task<TradeItemResponseDto?> SellItemAsync(int mapInteractionId, TradeItemRequestDto tradeItem)
        {
            var mapInteraction = await _interactionRepository.GetMapInteractionAsync(mapInteractionId);
            var character = await _characterRepository.GetCharacterAsync(tradeItem.CharacterId);
            var item = await _itemRepository.GetItemByIdAsync(tradeItem.ItemId);

            if (mapInteraction == null || character == null || item == null)
            {
                return null;
            }

            if (mapInteraction.Greed <= 0)
            {
                return null;
            }

            bool itemRemoved = await RemoveItemFromInventoryAsync(character, item);

            if (!itemRemoved)
            {
                return null;
            }

            int itemPrice = (int)(item.Value / mapInteraction.Greed);
            character.Gold += itemPrice;
            await _unitOfWork.SaveChangesAsync();

            var inventoryItemsNew =
                await _itemRepository.GetUnequippedInventoryItemsByCharacterIdAsync(character.Id);

            return new TradeItemResponseDto
            {
                InventoryItems = inventoryItemsNew
                              .Select(item => new InventoryItemDto
                              {
                                  Item = ItemMapper.ToDto(item.Item),
                                  OwnedItemId = item.Id,
                                  Quantity = item.Quantity,
                              }).ToList(),
                RemainingGold = character.Gold,
            };


        }

        public async Task<TradeItemResponseDto?> BuyItemAsync(int mapInteractionId, TradeItemRequestDto buyItemDto)
        {
            var mapInteraction = await _interactionRepository.GetMapInteractionAsync(mapInteractionId);
            var character = await _characterRepository.GetCharacterAsync(buyItemDto.CharacterId);
            var item = await _itemRepository.GetItemByIdAsync(buyItemDto.ItemId);

            if(mapInteraction == null || character == null || item == null)
            {
                return null;
            }

            if (mapInteraction.Greed <= 0)
            {
                return null;
            }

            int itemPrice = (int)(item.Value * mapInteraction.Greed);
            bool itemAvailable = mapInteraction.ShopItems
                .Any(shopItem => shopItem.ItemId == item.Id);

            if (!itemAvailable || character.Gold < itemPrice)
            {
                return null;
            }            

            character.Gold -= itemPrice;
            await AddItemToInventory(character, item);
            await _unitOfWork.SaveChangesAsync();

            var inventoryItemsNew =
                await _itemRepository.GetUnequippedInventoryItemsByCharacterIdAsync(character.Id);

            return new TradeItemResponseDto
            {
                InventoryItems = inventoryItemsNew
                              .Select(item => new InventoryItemDto
                              {
                                  Item = ItemMapper.ToDto(item.Item),
                                  OwnedItemId = item.Id,
                                  Quantity = item.Quantity,
                              }).ToList(),
                RemainingGold = character.Gold,
            };

        }

        private async Task AddItemToInventory(Character character, Item item)
        {
            var ownedItem = await _itemRepository.GetOwnedItemAsync(character.Id, item.Id);

            if(ownedItem is not null)
            {
                ownedItem.Quantity++;
                return;
            }

            _itemRepository.AddOwnedItem(new OwnedItem
            {
                CharacterId = character.Id,
                ItemId = item.Id,
                Quantity = 1
            });
        }

        private async Task<bool> RemoveItemFromInventoryAsync(Character character, Item item)
        {
            var ownedItem = await _itemRepository.GetOwnedItemAsync(character.Id, item.Id);

            if(ownedItem is null)
            {
                return false;
            }

            if(--ownedItem.Quantity > 0)
            {
                return true;
            }                            

            _itemRepository.RemoveOwnedItem(ownedItem);
            return true;
        }
    }
}
