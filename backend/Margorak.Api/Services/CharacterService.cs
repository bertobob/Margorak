using Margorak.Api.Dto;
using Margorak.Api.Interfaces;
using Margorak.Api.Mapper;
using Margorak.Api.Models;

namespace Margorak.Api.Services
{
    public class CharacterService
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapRepository _mapRepository;
        private readonly IStartingItemService _startingItemService;
        private readonly IItemRepository _itemRepository;

        public CharacterService(
            ICharacterRepository characterRepository,
            IMapRepository mapRepository,
            IStartingItemService startingItemService,
            IItemRepository itemRepository)
        {
            _characterRepository = characterRepository;
            _mapRepository = mapRepository;
            _startingItemService = startingItemService;
            _itemRepository = itemRepository;
        }

        public async Task<List<CharacterDto>> GetAllCharactersAsync()
        {
            var characters = await _characterRepository.GetAllCharactersAsync();

            return characters
                .Select(CharacterMapper.ToDto)
                .ToList();
        }

        public async Task<List<CharacterRaceDto>> GetAvailableRacesAsync()
        {
            var characterRaces = await _characterRepository.GetRacesAsync();
            var races = new List<CharacterRaceDto>();
            foreach(var race in characterRaces)
            {
                races.Add(CharacterRaceMapper.ToDto(race));
            }
            return races;
        }

        public async Task<List<CharacterClassDto>> GetAvailabeClassesAsync()
        {
            var characterClasses = await _characterRepository.GetClassesAsync();
            var classes = new List<CharacterClassDto>();
            foreach (var _class in characterClasses)
            {
                classes.Add(CharacterClassMapper.ToDto(_class));
            }
            return classes;
        }

        public async Task<Character> CreateCharacterAsync(CreateCharacterDto request)
        {
            var race = await _characterRepository.GetRaceByIdAsync(request.CharacterRaceId);

            if (race is null)
            {
                throw new ArgumentException(
                    $"The character race with ID {request.CharacterRaceId} does not exist.");
            }

            var characterClass = await _characterRepository.GetClassByIdAsync(request.CharacterClassId);

            if (characterClass is null)
            {
                throw new ArgumentException(
                    $"The character class with ID {request.CharacterClassId} does not exist.");
            }

            var name = request.Name.Trim();
            
            if(name=="")
            {
                throw new ArgumentException(
                    $"Name is empty");
            }
            var startingItems = await _startingItemService
                .GetStartingItemsAsync(characterClass.Id);

            var character = new Character
            {
                Name = name,
                CharacterRaceId = race.Id,
                CharacterRace = race,
                CharacterClassId = characterClass.Id,
                CharacterClass = characterClass,
                OwnedItems = startingItems
            };

            await _characterRepository.SaveNewCharacterAsync(character);

            return character;
        }
        public async Task<LoadCharacterDto?> LoadCharacterAsync(int characterId)
        {
            var character = await _characterRepository.GetCompleteCharacterAsync(characterId);
            if (character is null)
            {
                return null;
            }

            var ownedItems =
                await _itemRepository.GetInventoryItemsByCharacterIdAsync(characterId) ?? [];

            return new LoadCharacterDto
            {
                Character = CharacterMapper.ToDto(character),
                InventoryItems = ownedItems
                    .Select(ownedItem => new InventoryItemDto
                    {
                        Item = ItemMapper.ToDto(ownedItem.Item),
                        OwnedItemId = ownedItem.Id,
                        Quantity = ownedItem.Quantity
                    })
                    .ToList(),
                EquippedItems = character.CharacterEquipment
                    .Select(equipment => new EquippedItemDto
                    {
                        OwnedItemId = equipment.OwnedItemId,
                        EquipSlotId = equipment.EquipSlotId
                    })
                    .ToArray()
            };
        }

        public async Task SaveCharacterAsync(int characterId,SaveCharacterDto request)
        {
            await UpdateCharacterPositionAsync(characterId,request.Location);
            await SaveEquipmentAsync(characterId, request.EquippedItems);
        }

        private async Task SaveEquipmentAsync(int characterId, EquippedItemDto[] equippedItems)
        {
            var ownedItemIds = equippedItems.Select(item => item.OwnedItemId);
            var ownedItems = await _itemRepository.GetOwnedItemsByIdsAsync(characterId, ownedItemIds);

            var equippedOwnedItems = equippedItems
                .Select(equippedItem => new
                {
                    equippedItem.EquipSlotId,
                    OwnedItem = ownedItems.FirstOrDefault(ownedItem =>
                        ownedItem.Id == equippedItem.OwnedItemId)
                });

            var allItemsOwned = equippedOwnedItems
                .All(equippedItem => equippedItem.OwnedItem is not null);

            if (!allItemsOwned)
            {
                throw new InvalidOperationException(
                    "At least one item does not belong to the character.");
            }

            var allSlotsValid = equippedOwnedItems
                .All(equippedItem => equippedItem.EquipSlotId == equippedItem.OwnedItem!.Item.ItemCategory.EquipSlotId);

            if(!allSlotsValid)
            {
                throw new InvalidOperationException("Equippement Configuration not valid");
            }

            await _itemRepository.SaveEquipmentAsync(characterId, equippedItems);
        }

        private async Task UpdateCharacterPositionAsync(int characterId, LocationDto location)
        {
            var (mapId,locX,locY) = (location.MapId,location.LocX,location.LocY);
            var isAccessible = await _mapRepository.IsAccessiblePositionAsync(mapId, locX, locY);

            if (!isAccessible)
            {
                throw new ArgumentException(
                    $"Position ({locX}, {locY}) on map {mapId} is invalid.");
            }

            var updated = await _characterRepository.UpdateCharacterPositionAsync(characterId, mapId, locX, locY);

            if (!updated)
            {
                throw new KeyNotFoundException(
                    $"Character {characterId} was not found.");
            }
        }

    }
}
