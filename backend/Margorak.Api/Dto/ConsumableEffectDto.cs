using Margorak.Api.Models;

namespace Margorak.Api.Dto
{
    public class ConsumableEffectDto
    {       
        public EffectTypeDto EffectType { get; set; } = null!;
        public int MinValue { get; set; }
        public int MaxValue { get; set; }
        public int? Duration { get; set; }
    }
}
