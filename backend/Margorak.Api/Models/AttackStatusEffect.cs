using Microsoft.EntityFrameworkCore;

namespace Margorak.Api.Models
{
    [PrimaryKey(nameof(AttackId), nameof(StatusEffectId))]
    public class AttackStatusEffect
    {
        public int AttackId { get; set; }
        public Attack Attack { get; set; } = null!;
        public int StatusEffectId { get; set; }
        public StatusEffect StatusEffect { get; set; } = null!;
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public int MinDuration { get; set; }
        public int MaxDuration { get; set; }
    }
}
