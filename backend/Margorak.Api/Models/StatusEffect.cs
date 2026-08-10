namespace Margorak.Api.Models
{
    public class StatusEffect
    {
        public int Id { get; set; } 
        public string Name { get; set; }   =string.Empty;
        public ICollection<ActiveCombatStatusEffect> ActiveCombatStatusEffects { get; set; } = [];
        public ICollection<AttackStatusEffect> AttackStatusEffects { get; set; } = [];
        public ICollection<ItemStatusEffect> ItemStatusEffects { get; set; } = [];
    }
}
