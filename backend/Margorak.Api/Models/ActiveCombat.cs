namespace Margorak.Api.Models
{
    public class ActiveCombat
    {
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public Character Character { get; set; } = null!;
        public int CharacterTimeline { get; set; } = 0;
        public ICollection<ActiveCombatCombatant> ActiveCombatCombatants { get; set; } = [];
    }
}
