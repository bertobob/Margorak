namespace Margorak.Api.Models
{
    public class TerrainType
    {
        public int Id {  get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<CombatantHabitat> CombatantHabitats { get; set; } = [];
        public ICollection<Terrain> Terrains { get; set; } = [];
    }
}
