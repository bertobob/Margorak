using Margorak.Api.Dto;
using Margorak.Api.Models;

namespace Margorak.Api.Mapper
{
    public static class ResistanceTypeMapper
    {
        public static ResistanceTypeDto ToDto(ResistanceType resistanceType)
        {
            return new ResistanceTypeDto { Name = resistanceType.Name };
        }
    }
}
