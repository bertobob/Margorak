namespace Margorak.Api.Models
{
    public class ActiveCombatStatusEffect
    {
        public int Id {  get; set; }
        public int StatusEffectId { get; set; }
        public StatusEffect StatusEffect { get; set; } = null!;
        public int ActiveCombatCombatantId { get; set; }
        public ActiveCombatCombatant ActiveCombatCombatant { get; set; } = null!;        
        public int Duration { get; set; }   
    }
}
