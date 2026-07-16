using Margorak.Api.Dto;
using Margorak.Api.Models;

namespace Margorak.Api.Mapper
{
    public static class BonusTypeMapper
    {
        public static BonusTypeDto ToDto(BonusType bonusType)
        {
            return new BonusTypeDto { Name = bonusType.Name };
        }
    }
}
