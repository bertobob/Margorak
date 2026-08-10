namespace Margorak.Api.Models
{
    public class ActiveCombat
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; } = null!;
        public ICollection<ActiveCombatCombatant> ActiveCombatCombatants { get; set; } = [];
    }
}
