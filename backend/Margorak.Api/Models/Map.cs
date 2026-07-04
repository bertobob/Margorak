using System.ComponentModel.DataAnnotations;

namespace Margorak.Api.Models
{
    public class Map
    {        
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int SightRange { get; set; }
        public int ClickRange { get; set; }

        public ICollection<MapTile> Tiles { get; set; } = [];
        public ICollection<CombatantHabitat> CombatantHabitats { get; set; } = [];
        public ICollection<MapInteraction> Interactions { get; set; } = [];
        public ICollection<Character> CurrentCharacters { get; set; } = [];
        public ICollection<TeleporterInteraction> IncomingTeleporters { get; set; } = [];

    }
}
