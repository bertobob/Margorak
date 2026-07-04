namespace Margorak.Api.Models
{
    public class Attack
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public int AttackSpeed {  get; set; }
        public int AttackRating {  get; set; }
        public int AttackRange {  get; set; }

        public ICollection<AttackDamage> AttackDamages { get; set; } = [];
        public ICollection<CombatantAttack> CombatantAttacks { get; set; } = [];
    }
}
