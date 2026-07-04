using Microsoft.EntityFrameworkCore;

namespace Margorak.Api.Models
{
    [PrimaryKey(nameof(ItemId), nameof(DamageTypeId))]
    public class ItemDamage
    {
        public int ItemId {  get; set; }
        public Item Item { get; set; } = null!;
        public int DamageTypeId {  get; set; }
        public DamageType DamageType { get; set; } = null!;
        public int MinDamage {  get; set; }
        public int MaxDamage { get; set; }
    }
}
