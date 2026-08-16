using Margorak.Api.Models;

namespace Margorak.Api.Interfaces
{
    public interface ICombatRepository
    {
        Task<ActiveCombat?> GetActiveCombatAsync(int characterId);
        Task UpdateActiveCombatCombatantHpAsync(ActiveCombatCombatant activeCombatCombatant, int hpChange);
        Task UpdateCharacterTimelineAsync(ActiveCombatCombatant activeCombatCombatant, int value);
        Task UpdateCombatantTimelineAsync(ActiveCombatCombatant activeCombatCombatant, int value);        
    }
}
