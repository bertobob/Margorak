using Microsoft.EntityFrameworkCore;

namespace Margorak.Api.Models
{
    [PrimaryKey(nameof(ItemId),nameof(EffectypeId))]
    public class ConsumableEffect
    {
        public int ItemId {  get; set; }
        public Item Item { get; set; } = null!;
        public int EffectypeId {  get; set; }   
        public Effectype Effectype { get; set; } = null!;
        public int MinValue {  get; set; }
        public int MaxValue { get; set; }
        public int Duration {  get; set; }
    }
}
