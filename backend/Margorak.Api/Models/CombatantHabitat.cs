namespace Margorak.Api.Models
{
    public class CombatantHabitat
    {
        public int Id { get; set; }

        public int CombatantId { get; set; }
        public Combatant Combatant { get; set; } = null!;

        public int MapId { get; set; }
        public Map Map { get; set; } = null!;

        public int HabitatTerrainTypeId { get; set; }
        public HabitatTerrainType HabitatTerrainType { get; set; } = null!;

        public int LocX1 { get; set; }
        public int LocY1 { get; set; }
        public int LocX2 { get; set; }
        public int LocY2 { get; set; }

        public int Probability { get; set; }
        public int AmbushProbability { get; set; }
    }
}
