using Margorak.Api.Data;
using Margorak.Api.Interfaces;
using Margorak.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Margorak.Api.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly AppDbContext _db;
        public CharacterRepository(AppDbContext db)
        {            
            _db = db;
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
                .Include(c => c.CharacterEquipment)
                    .ThenInclude(ce => ce.OwnedItem)
                        .ThenInclude(oe => oe.Item)
                            .ThenInclude(i => i.ItemCategory)
                .AsNoTracking()
                .AsSplitQuery()
                .FirstOrDefaultAsync(c => c.Id == characterId);

            return character;
        }

        public async Task<bool> UpdateCharacterPositionAsync(int characterId, int mapId, int locX, int locY)
        {
            var character = await _db.Characters
                .Where(c => c.Id == characterId)
                .FirstOrDefaultAsync();

            if (character == null ) { return false; }

            character.CurrentMapId = mapId;
            character.LocX = locX;
            character.LocY = locY;



            await _db.SaveChangesAsync();

            return true;

        }

        public async Task<List<CharacterRace>> GetRacesAsync()
        {
            var races = await _db.CharacterRaces
                .ToListAsync();

            return races;
        }

        public async Task<List<CharacterClass>> GetClassesAsync()
        {
            var classes = await _db.CharacterClasses
                .ToListAsync();

            return classes;
        }

        public async Task<Character?> GetCharacterByIdAsync(int characterId)
        {
            var character = await _db.Characters
                .Where(c => c.Id == characterId)
                .Include(c => c.CharacterClass)
                .Include(c => c.CharacterRace)
                .FirstOrDefaultAsync();

            return character;
        }


        public async Task<List<Character>> GetAllCharactersAsync()
        {
            var characters = await _db.Characters
                .Include(c => c.CharacterClass)
                .Include(c => c.CharacterRace)
                .ToListAsync();

            return characters;
        }

        public async Task<CharacterRace?> GetRaceByIdAsync(int raceId)
        {
            return await _db.CharacterRaces
                .FindAsync(raceId);
        }

        public async Task<CharacterClass?> GetClassByIdAsync(int classId)
        {
            return await _db.CharacterClasses
                .FindAsync(classId);
        }

        public async Task SaveNewCharacterAsync(Character character)
        {
            await _db.Characters.AddAsync(character);
            await _db.SaveChangesAsync();
        }
    }
}
