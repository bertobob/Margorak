using Margorak.Api.Dto;
using Margorak.Api.Models;

namespace Margorak.Api.Mapper
{
    public static class RequirementTypeMapper
    {
        public static RequirementTypeDto ToDto(RequirementType requirementType)
        {
            return new RequirementTypeDto { Name = requirementType.Name };
        }
    }
}
