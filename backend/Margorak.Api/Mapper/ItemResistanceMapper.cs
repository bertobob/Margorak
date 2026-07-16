using Margorak.Api.Dto;
using Margorak.Api.Models;

namespace Margorak.Api.Mapper
{
    public static class ItemResistanceMapper
    {
        public static ItemResistanceDto ToDto(ItemResistance itemResistance)
        {
            return new ItemResistanceDto
            {
                ResistanceType = ResistanceTypeMapper.ToDto(itemResistance.ResistanceType),
                Value = itemResistance.Value
            };
        }
    }
}
