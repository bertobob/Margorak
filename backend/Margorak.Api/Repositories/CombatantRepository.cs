using Margorak.Api.Data;
using Margorak.Api.Interfaces;
using Margorak.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Margorak.Api.Repositories
{
    public class CombatantRepository : ICombatantRepository
    {
        private readonly AppDbContext _db;

        public CombatantRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<CombatantHabitat>> GetCombatantHabitatsByMapIdAsync(int mapId)
        {
            return await _db.CombatantHabitats
                .Include(ch => ch.TerrainType)
                .AsNoTracking()
                .Where(ch => ch.MapId == mapId)
                .ToListAsync();
        }

        public async Task<Combatant?> GetCombatantForBattleAsync(int combatantId)
        {
            return await _db.Combatants
                .Include(c => c.CombatantAttacks)
                .Include(c => c.CombatantLoots)
                    .ThenInclude(cl => cl.Item)
                        .ThenInclude(i => i.ItemCategory)
                .Include(c => c.CombatantResistances)
                    .ThenInclude(cr => cr.ResistanceType)
                .AsNoTracking()
                .AsSplitQuery()
                .FirstOrDefaultAsync(c => c.Id == combatantId);
        }
    }
}
