using Margorak.Api.Dto;
using Margorak.Api.Models;

namespace Margorak.Api.Mapper
{
    public static class EffectTypeMapper
    {
        public static EffectTypeDto ToDto(EffectType effectType)
        {
            return new EffectTypeDto { Name = effectType.Name };
        }
    }
}
