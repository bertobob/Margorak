using Margorak.Api.Dto;
using Margorak.Api.Enums;
using Margorak.Api.Models;

namespace Margorak.Api.Mapper
{
    public static class CharacterMapper
    {
        public static CharacterDto ToDto(Character character)
        {

            var ownedItems = new List<OwnedItemDto>();
            foreach (var item in character.OwnedItems)
            {
                ownedItems.Add(OwnedItemMapper.ToDto(item));
            }

            var characterEquipment = new List<CharacterEquipmentDto>();
            foreach (var equipment in character.CharacterEquipment)
            {
                characterEquipment.Add(CharacterEquipmentMapper.ToDto(equipment));
            }

            Enum.TryParse(character.Gender, true, out Gender gender);

            CharacterDto c = new CharacterDto
            {
                Id = character.Id,
                Name = character.Name,
                Gender = gender,
                CharacterRace = CharacterRaceMapper.ToDto(character.CharacterRace),
                CharacterClass = CharacterClassMapper.ToDto(character.CharacterClass),
                OwnedItems = ownedItems,
                CharacterEquipment = characterEquipment,
                Level = character.Level,
                Experience = character.Experience,
                StatusPoints = character.StatusPoints,
                Strength = character.Strength,
                Dexterity = character.Dexterity,
                Vitality = character.Vitality,
                Intelligence = character.Intelligence,
                CurrentHp = character.CurrentHp,
                MaxHp = character.MaxHp,
                CurrentMp = character.CurrentMp,
                MaxMp = character.MaxMp,
                Gold = character.Gold,
                CurrentMapId = character.CurrentMapId,
                LocX = character.LocX,
                LocY = character.LocY,
                Version = character.Version,
            };

            return c;
        }
    }
}
