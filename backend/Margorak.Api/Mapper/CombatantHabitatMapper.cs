using Margorak.Api.Dto;
using Margorak.Api.Models;

namespace Margorak.Api.Mapper
{
    public static class CombatantHabitatMapper
    {
        public static CombatantHabitatDto ToDto(CombatantHabitat combatantHabitat)
        {            
            var habitatTerrainTypeId = combatantHabitat.TerrainTypeId;
            return new CombatantHabitatDto
            {
                CombatantHabitatId = combatantHabitat.CombatantId,
                TerrainTypeId = habitatTerrainTypeId,
                LocX1=combatantHabitat.LocX1,
                LocX2=combatantHabitat.LocX2,
                LocY1=combatantHabitat.LocY1,
                LocY2=combatantHabitat.LocY2,
                Probability = combatantHabitat.Probability,
                AmbushProbability=combatantHabitat.AmbushProbability
            };
        }
        
    }
}
