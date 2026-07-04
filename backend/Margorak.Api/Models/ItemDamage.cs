using Microsoft.EntityFrameworkCore;

namespace Margorak.Api.Models
{
    [PrimaryKey(nameof(ItemId), nameof(DamageTypeId))]
    public class ItemDamage
    {
        public int ItemId {  get; set; }
        public Item Item { get; set; }
        public int DamageTypeId {  get; set; }
        public DamageType DamageType { get; set; }
        public int MinDamage {  get; set; }
        public int MaxDamage { get; set; }
    }
}
