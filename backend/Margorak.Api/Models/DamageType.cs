namespace Margorak.Api.Models
{
    public class DamageType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ItemDamage> ItemDamages { get; set; } = null!;
    }
}
