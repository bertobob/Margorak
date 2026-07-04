namespace Margorak.Api.Models
{
    public class HabitatTerrainType
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public ICollection<CombatantHabitat> CombatantHabitats { get; set; } = [];
    }
}
