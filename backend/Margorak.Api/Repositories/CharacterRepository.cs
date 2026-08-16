using Margorak.Api.Data;
using Margorak.Api.Dto;
using Margorak.Api.Interfaces;
using Margorak.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Margorak.Api.Repositories
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly AppDbContext _db;
        const int StatPointsPerLevel = 5;
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
                .Include(c => c.CharacterEquipment)
                    .ThenInclude(ce => ce.OwnedItem)
                        .ThenInclude(oe => oe.Item)
                            .ThenInclude(i => i.WeaponStat)
                .Include(c => c.CharacterEquipment)
                    .ThenInclude(ce => ce.OwnedItem)
                        .ThenInclude(oe => oe.Item)
                            .ThenInclude(i => i.ArmorStat)
                .Include(c => c.CharacterEquipment)
                    .ThenInclude(ce => ce.OwnedItem)
                        .ThenInclude(oe => oe.Item)
                            .ThenInclude(i => i.ItemDamages)
                                .ThenInclude(itemDamage => itemDamage.DamageType)
                .Include(c => c.CharacterEquipment)
                    .ThenInclude(ce => ce.OwnedItem)
                        .ThenInclude(oe => oe.Item)
                            .ThenInclude(i => i.ItemResistances)
                                .ThenInclude(itemResistance => itemResistance.ResistanceType)
                .AsNoTracking()
                .AsSplitQuery()
                .FirstOrDefaultAsync(c => c.Id == characterId);

            return character;
        }

        public async Task<Character?> GetCharacterAsync(int characterId)
        {
            return await _db.Characters
                .Include(character => character.CharacterRace)
                .FirstOrDefaultAsync(character => character.Id == characterId);
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

        public async Task AddCharacterAsync(Character character)
        {
            await _db.Characters.AddAsync(character);
        }

        public async Task UpdateCharacterStatsAsync(int characterId, CharacterStatsDto characterStats)
        {
            var character =  await _db.Characters
                .Where(character => character.Id == characterId)
                .FirstOrDefaultAsync();

            character!.Dexterity = characterStats.Dexterity;
            character!.Intelligence = characterStats.Intelligence;
            character!.Strength = characterStats.Strength;
            character!.Vitality = characterStats.Vitality;
            character!.StatusPoints = characterStats.StatusPoints;
        }

        public void StartCombat(int characterId,Combatant combatant)
        {
            var existingCombat = _db.ActiveCombats
                .FirstOrDefault(activeCombat => activeCombat.CharacterId == characterId);

            if (existingCombat != null)
            {
                _db.ActiveCombats.Remove(existingCombat);
            }

            var activeCombat = new ActiveCombat
            {
                CharacterId = characterId,
                ActiveCombatCombatants =
                [
                    new ActiveCombatCombatant
                    {
                       CombatantId = combatant.Id,
                       CurrentHp= combatant.BaseHp,
                    }
                ]
            };

            _db.ActiveCombats.Add(activeCombat);
        }

        public void StopCombat(int characterId)
        {
            var activeCombat = _db.ActiveCombats.FirstOrDefault(comb => comb.CharacterId == characterId);

            if (activeCombat != null)
            {
                _db.ActiveCombats.Remove(activeCombat);
            }
        }

        public async Task UpdateCharacterHpAsync(int characterId, int value)
        {
            var character = await _db.Characters
                .FirstAsync(c  => c.Id == characterId);

            character.CurrentHp += value;
        }

        public async Task AddItemsToInventoryAsync(int characterId,List<Item> itemList,int goldLoot)
        {
            var ownedItems = await _db.OwnedItems
                .Where(ownedItem => ownedItem.CharacterId == characterId)
                .ToListAsync();

            foreach(var item in itemList)
            {
                var ownedItem = ownedItems
                    .FirstOrDefault(oi => oi.ItemId == item.Id);
                if(ownedItem != null)
                {
                    ownedItem.Quantity++;
                }
                else
                {
                    _db.OwnedItems
                        .Add(new OwnedItem
                        {
                            CharacterId = characterId,
                            ItemId = item.Id,
                            Quantity =1 ,
                            Version =1
                        });
                }
            }

            var character = await _db.Characters
                .FirstAsync(c => c.Id == characterId);
            character.Gold += goldLoot;
        }

        public async Task<int> AddExpByCharacterAndCombatantIdAsync(int characterId, int combatantId)
        {
            var combatant = await _db.Combatants
                .FirstAsync(combatant => combatant.Id == combatantId);
            var experience = combatant.ExpValue;
            var character = await _db.Characters
                .FirstAsync(character => character.Id == characterId);

            character.Experience += experience;

            return experience;
        }

        public async Task<int> GetLevelByExperienceAsync(int experience)
        {
            var nextLevel = await _db.Levels
                .FirstAsync(level => level.ExpRequiered > experience);

            return nextLevel.Value - 1;
        }

        public async Task UpdateCharacterLevelAndStatPointsAsync(int characterId, int level)
        {
            var character= await _db.Characters
                .FirstAsync (character => character.Id == characterId);

            character.StatusPoints += StatPointsPerLevel * (level - character.Level);
            character.Level = level;
        }
    }
}
