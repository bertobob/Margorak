using Microsoft.EntityFrameworkCore;

namespace Margorak.Api.Models
{
    [PrimaryKey(nameof(ItemId),nameof(EffectTypeId))]
    public class ConsumableEffect
    {
        public int ItemId {  get; set; }
        public Item Item { get; set; } = null!;
        public int EffectTypeId {  get; set; }   
        public EffectType EffectType { get; set; } = null!;
        public int MinValue {  get; set; }
        public int MaxValue { get; set; }
        public int Duration {  get; set; }
    }
}
