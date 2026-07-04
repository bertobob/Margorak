namespace Margorak.Api.Models
{
    public class CombatantRace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Combatant> Combatants { get; set; } = [];
    }
}
