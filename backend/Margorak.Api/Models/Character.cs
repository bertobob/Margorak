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

        public int Level { get; set; }
        public int Experience { get; set; }
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
        public Map CurrentMap { get; set; } = null!;

        public int LocX { get; set; }
        public int LocY { get; set; }
        public int Version { get; set; }

        public ICollection<OwnedItem> OwnedItems { get; set; } = [];
        public ICollection<CharacterEquipment> CharacterEquipment { get; set; } = [];
    }
}
