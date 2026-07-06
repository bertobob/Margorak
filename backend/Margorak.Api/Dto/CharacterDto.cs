using Margorak.Api.Enums;

namespace Margorak.Api.Dto
{
    public class CharacterDto
    {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public CharacterRaceDto CharacterRace { get; set; } = null!;
        public CharacterClassDto CharacterClass { get; set; } = null!;
        public List<OwnedItemDto> OwnedItems { get; set; } = [];
        public List<CharacterEquipmentDto> CharacterEquipment {  get; set; } = [];
        public int Level {  get; set; }
        public int Experience {  get; set; }
        public int StatusPoints { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Vitality { get; set; }
        public int Intelligence { get; set; }
        public int CurrentHp { get; set; }
        public int MaxHp { get; set; }
        public int CurrentMp { get; set; }
        public int MaxMp { get; set; }
        public int Gold { get; set; }
        public int CurrentMapId { get; set; }
        public int LocX { get; set; }
        public int LocY { get; set; }
        public int Version { get; set; }
    }
}
