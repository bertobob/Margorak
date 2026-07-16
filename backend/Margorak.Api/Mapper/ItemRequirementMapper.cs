using Margorak.Api.Dto;
using Margorak.Api.Models;

namespace Margorak.Api.Mapper
{
    public static class ItemRequirementMapper
    {
        public static ItemRequirementDto ToDto(ItemRequirement itemRequirement)
        {
            return new ItemRequirementDto
            {
                RequirementType = RequirementTypeMapper.ToDto(itemRequirement.RequirementType),
                Value = itemRequirement.Value
            };
        }
    }
}
