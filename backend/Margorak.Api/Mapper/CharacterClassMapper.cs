using Margorak.Api.Dto;
using Margorak.Api.Models;

namespace Margorak.Api.Mapper
{
    public static class CharacterClassMapper
    {
        public static CharacterClassDto ToDto(CharacterClass characterClass)
        {
            return new CharacterClassDto
            {
                Id = characterClass.Id,
                Name = characterClass.Name,
            };
        }
    }
}
