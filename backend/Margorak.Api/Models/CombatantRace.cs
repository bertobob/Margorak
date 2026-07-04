namespace Margorak.Api.Models
{
    public class CombatantRace
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<Combatant> Combatants { get; set; } = [];
    }
}
