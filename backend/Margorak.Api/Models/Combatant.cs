namespace Margorak.Api.Models
{
    public class Combatant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CombatantRaceId {  get; set; }
        public CombatantRace CombatantRace { get; set; } = null!;
        public int Level {  get; set; } 
        public int ExpValue {  get; set; }
        public int BaseHp {  get; set; }
        public int GoldLootMin {  get; set; }
        public int GoldLootMax { get; set; }
        public ICollection<CombatantAttack> CombatantAttacks { get; set; } = [];
        public ICollection<CombatantHabitat> CombatantHabitats { get; set; } = [];
        public ICollection<CombatantLoot> CombatantLoots{ get; set; } = [];
    }
}
