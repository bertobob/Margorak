using Margorak.Api.Dto;
using Margorak.Api.Interfaces;
using Margorak.Api.Mapper;

namespace Margorak.Api.Services
{
    public class CombatantHabitatService
    {
        private readonly ICombatantRepository _combatantRepository;

        public CombatantHabitatService(ICombatantRepository combatantRepository)
        {
            _combatantRepository = combatantRepository;
        }

        public async Task<List<CombatantHabitatDto>> GetCombatantHabitatsByMapIdAsync(int mapId)
        {
            var combatantHabitats = await _combatantRepository.GetCombatantHabitatsByMapIdAsync(mapId);
            var combatHabitatDtos = new List<CombatantHabitatDto>();

            foreach(var combatantHabitat in combatantHabitats)
            {
                combatHabitatDtos.Add(CombatantHabitatMapper.ToDto(combatantHabitat));
            }

            return combatHabitatDtos;
        }
    }
}
