using Microsoft.EntityFrameworkCore;

namespace Margorak.Api.Models
{
    [PrimaryKey(nameof(AttackId), nameof(EffectTypeId))]
    public class AttackEffect
    {
        public int AttackId { get; set; }
        public Attack Attack { get; set; } = null!;
        public int EffectTypeId { get; set; }
        public EffectType EffectType { get; set; } = null!;
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
    }
}
