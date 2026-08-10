using Microsoft.EntityFrameworkCore;

namespace Margorak.Api.Models
{
    [PrimaryKey(nameof(ItemId), nameof(StatusEffectId))]
    public class ItemStatusEffect
    {
        public int ItemId { get; set; }
        public Item Item { get; set; } = null!;
        public int StatusEffectId { get; set; }
        public StatusEffect StatusEffect { get; set; } = null!;
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public int MinDuration { get; set; }
        public int MaxDuration { get; set; }
    }
}
