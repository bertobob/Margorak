using Margorak.Api.Dto;
using Margorak.Api.Models;

namespace Margorak.Api.Mapper
{
    public static class ConsumableEffectMapper
    {
        public static ConsumableEffectDto ToDto(ConsumableEffect effect)
        {
            return new ConsumableEffectDto
            {
                EffectType = EffectTypeMapper.ToDto(effect.EffectType),
                MinValue = effect.MinValue,
                MaxValue = effect.MaxValue,
                Duration = effect.Duration
            };
        }
    }
}
