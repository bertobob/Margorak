using Margorak.Api.Data;
using Margorak.Api.Dto;
using Margorak.Api.Interfaces;
using Margorak.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Margorak.Api.Services
{
    public class DbAccessService
    {
        private readonly AppDbContext _db;
        
        public DbAccessService(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Map>> GetMapsAsync()
        {
            var maps = await _db.Maps
                .Include(x => x.Tiles)
                    .ThenInclude(x => x.Terrain)
                .Include(x => x.Interactions)
                    .ThenInclude(x => x.Category)
                .ToListAsync();
            
            return maps;
        }

        public  async Task<ShopInteraction> GetShopInteractionAsync(int id)
        {
            var shop = await _db.ShopInteractions                
                .FirstAsync(x => x.MapInteractionId == id);
            return shop;
        }

        public async Task<TeleporterInteraction> GetTeleporterInteractionAsync(int id)
        {
            var teleporter = await _db.TeleporterInteractions
                .FirstAsync(x => x.MapInteractionId == id);
            return teleporter;
        }

        public async Task<Item> GetItemByIdAsync(int itemId)
        {
            var item = await _db.Items
                .Include(c => c.ItemCategory)
                .AsNoTracking()
                .FirstAsync( x => x.Id == itemId);
            return item;
        }

        public async Task<List<Item>> GetItemsByIdsAsync(List<int> itemIds)
        {
            var itemList = await _db.Items
                .Include(c => c.ItemCategory)
                .Where(x => itemIds.Contains(x.Id))
                .AsNoTracking()
                .ToListAsync();

            return itemList;
        }
        
        public async Task<Character?> GetCompleteCharacterAsync(int characterId)
        {
            var character = await _db.Characters
                .Include(c => c.CharacterClass)
                .Include(c => c.CharacterRace)
                .Include(c => c.OwnedItems)
                    .ThenInclude(o => o.Item)
                        .ThenInclude(i => i.ItemCategory)
                .Include(c => c.CharacterEquipment)
                    .ThenInclude(ce => ce.EquipSlot)
                .Include(c=> c.CharacterEquipment)
                    .ThenInclude(ce => ce.OwnedItem)
                        .ThenInclude(oe => oe.Item)
                            .ThenInclude(i => i.ItemCategory)
                .AsNoTracking()
                .AsSplitQuery()
                .FirstOrDefaultAsync(c => c.Id == characterId);

            return character;
        }

        public async Task<List<CombatantHabitat>> GetCombatantHabitatsByMapIdAsync(int mapId)
        {
            return await _db.CombatantHabitats
                .Include(ch => ch.HabitatTerrainType)
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

        public async Task UpdateCharacterPositionAsync(int characterId, int mapId, int locX, int locY)
        {
            var character = await _db.Characters
                .Where(c => c.Id == characterId)
                .FirstOrDefaultAsync();

            if (character == null) { return; }

            character.CurrentMapId = mapId;
            character.LocX=locX;
            character.LocY=locY;

            await _db.SaveChangesAsync();
            
        }

        //public async Task equip

    }
}
