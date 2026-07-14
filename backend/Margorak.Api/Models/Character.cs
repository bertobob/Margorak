namespace Margorak.Api.Models
{
    public class Character
    {
        public int Id { get; set; }


        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;

        public int CharacterRaceId { get; set; }
        public CharacterRace CharacterRace { get; set; } = null!;

        public int CharacterClassId { get; set; }
        public CharacterClass CharacterClass { get; set; } = null!;

        public int Level { get; set; } = 1;
        public int Experience { get; set; } = 0;
        public int StatusPoints { get; set; } = 0;

        public int Strength { get; set; } = 10;
        public int Dexterity { get; set; } = 10;
        public int Vitality { get; set; } = 10;
        public int Intelligence { get; set; } = 10;

        public int CurrentHp { get; set; }
        public int MaxHp { get; set; }

        public int CurrentMp { get; set; }
        public int MaxMp { get; set; }

        public int Gold { get; set; }

        public int CurrentMapId { get; set; } = 1;
        public Map CurrentMap { get; set; } = null!;

        public int LocX { get; set; } = 10;
        public int LocY { get; set; } = 10;
        public int Version { get; set; }

        public ICollection<OwnedItem> OwnedItems { get; set; } = [];
        public ICollection<CharacterEquipment> CharacterEquipment { get; set; } = [];
    }
}
