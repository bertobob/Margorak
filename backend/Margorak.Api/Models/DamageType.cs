namespace Margorak.Api.Models
{
    public class DamageType
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<ItemDamage> ItemDamages { get; set; } = [];
        public ICollection<AttackDamage> AttackDamages { get; set; } = [];
    }
}
