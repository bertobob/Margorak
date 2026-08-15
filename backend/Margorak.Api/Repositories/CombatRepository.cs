using Margorak.Api.Data;
using Margorak.Api.Interfaces;
using Margorak.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Margorak.Api.Repositories
{
    public class CombatRepository : ICombatRepository
    {
        private readonly AppDbContext _db;
        public CombatRepository(AppDbContext db)
        {
            _db=db;
        }
        public async Task<ActiveCombat?> GetActiveCombatAsync(int characterId)
        {
            var activeCombat =await  _db.ActiveCombats
                .Include(ac => ac.ActiveCombatCombatants)
                    .ThenInclude(acc => acc.Combatant)
                .FirstOrDefaultAsync(activeCombat => activeCombat.CharacterId == characterId);

            return activeCombat;
        }

        public async Task UpdateActiveCombatCombatantHpAsync(ActiveCombatCombatant activeCombatCombatant,int hpChange)
        {
            var combatant =await _db.ActiveCombatCombatants
                .FirstAsync(acc => acc.Id == activeCombatCombatant.Id);
            combatant.CurrentHp += hpChange;
        }

        public async Task UpdateCharacterTimelineAsync(ActiveCombatCombatant activeCombatCombatant, int value)
        {
            var combat = await _db.ActiveCombats
                .FirstAsync(ac => ac.ActiveCombatCombatants.First().Id == activeCombatCombatant.Id);

            combat.CharacterTimeline += value;
        }

        public async Task UpdateCombatantTimelineAsync(ActiveCombatCombatant activeCombatCombatant, int value)
        {
            var combatant = await _db.ActiveCombatCombatants
                .FirstAsync(ac => ac.Id == activeCombatCombatant.Id);

            combatant.CombatantTimeline += value;
        }
    }
}
