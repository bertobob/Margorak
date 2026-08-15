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

        public async Task<List<CombatantLoot>> GetLootByCombatantIdAsync(int combatantId)
        {
            return await _db.CombatantLoots
                .Include(cl => cl.Item)
                .Where(cl => cl.CombatantId == combatantId)
                .ToListAsync();
        }
        public async Task<List<CombatantHabitat>> GetCombatantHabitatsByMapIdAsync(int mapId)
        {
            return await _db.CombatantHabitats
                .Include(ch => ch.TerrainType)
                .Include(ch => ch.Combatant)
                .AsNoTracking()
                .Where(ch => ch.MapId == mapId)
                .ToListAsync();
        }

        public async Task<Combatant?> GetCombatantForBattleAsync(int combatantId)
        {
            return await _db.Combatants
                .Include(c => c.CombatantRace)

                .Include(c => c.CombatantAttacks)
                    .ThenInclude(ca => ca.Attack)
                        .ThenInclude(a => a.AttackDamages)
                            .ThenInclude(ad => ad.DamageType)

                .Include(c => c.CombatantAttacks)
                    .ThenInclude(ca => ca.Attack)
                        .ThenInclude(a => a.AttackEffects)
                            .ThenInclude(ae => ae.EffectType)

                .Include(c => c.CombatantAttacks)
                    .ThenInclude(ca => ca.Attack)
                        .ThenInclude(a => a.AttackStatusEffects)
                            .ThenInclude(ase => ase.StatusEffect)

                .Include(c => c.CombatantResistances)
                    .ThenInclude(cr => cr.ResistanceType)

                .Include(c => c.CombatantLoots)
                    .ThenInclude(cl => cl.Item)
                        .ThenInclude(i => i.ItemCategory)

                .AsNoTracking()
                .AsSplitQuery()
                .FirstOrDefaultAsync(c => c.Id == combatantId);
        }
    }
}
