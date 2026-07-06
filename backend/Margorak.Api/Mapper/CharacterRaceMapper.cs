using Margorak.Api.Dto;
using Margorak.Api.Models;

namespace Margorak.Api.Mapper
{
    public static class CharacterRaceMapper
    {
        public static CharacterRaceDto ToDto(CharacterRace characterRace)
        {
            return new CharacterRaceDto
            {
                Id = characterRace.Id,
                Name = characterRace.Name,
                StrengthMod = characterRace.StrengthMod,
                DexterityMod = characterRace.DexteryMod,
                VitalityMod = characterRace.VitalityMod,
                IntelligenceMod = characterRace.IntelligenceMod,
            };
        }
    }
}
