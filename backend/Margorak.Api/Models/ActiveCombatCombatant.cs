namespace Margorak.Api.Models
{
    public class ActiveCombatCombatant
    {
        public int Id { get; set; }
        public int ActiveCombatId {  get; set; }
        public ActiveCombat ActiveCombat { get; set; } = null!;
        public int CombatantId { get; set; }
        public Combatant Combatant { get; set; } = null!;
        public int CombatantTimeline { get; set; } = 0;
        public int CurrentHp {  get; set; }
        public ICollection<ActiveCombatStatusEffect> ActiveCombatStatusEffects { get; set; } = [];        

    }
}
