using Margorak.Api.Models;

namespace Margorak.Api.Interfaces
{
    public interface ICombatantRepository
    {
        Task<List<CombatantHabitat>> GetCombatantHabitatsByMapIdAsync(int mapId);
        Task<Combatant?> GetCombatantForBattleAsync(int combatantId);
        Task<List<CombatantLoot>> GetLootByCombatantIdAsync(int combatantId);
    }
}
