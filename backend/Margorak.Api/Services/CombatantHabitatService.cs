using Margorak.Api.Dto;
using Margorak.Api.Mapper;

namespace Margorak.Api.Services
{
    public class CombatantHabitatService
    {
        private readonly DbAccessService _dbAccessService;

        public CombatantHabitatService(DbAccessService dbAccessService)
        {
            _dbAccessService = dbAccessService;
        }

        public async Task<List<CombatantHabitatDto>> GetCombatantHabitatsByMapIdAsync(int mapId)
        {
            var combatHabitants =  await _dbAccessService.GetCombatantHabitatsByMapIdAsync(mapId);
            var combatHabitatDtos = new List<CombatantHabitatDto>();

            foreach(var  combatantHabitat in combatHabitants)
            {
                combatHabitatDtos.Add(CombatantHabitatMapper.ToDto(combatantHabitat));
            }

            return combatHabitatDtos;
        }
    }
}
