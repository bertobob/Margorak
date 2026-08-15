using Margorak.Api.Dto;
using Margorak.Api.Models;
using Margorak.Api.Repositories;
using System.Threading.Tasks;

namespace Margorak.Api.Interfaces
{
    public interface ICharacterRepository
    {
        Task<Character?> GetCompleteCharacterAsync(int characterId);
        Task<Character?> GetCharacterAsync(int characterId);
        Task<bool> UpdateCharacterPositionAsync(int characterId, int mapId, int locX, int locY);
        Task<List<CharacterRace>> GetRacesAsync();
        Task<List<CharacterClass>> GetClassesAsync();
        Task<List<Character>> GetAllCharactersAsync();
        Task<CharacterRace?> GetRaceByIdAsync(int raceId);
        Task<CharacterClass?> GetClassByIdAsync(int classId);
        Task AddCharacterAsync(Character newCharacter);
        Task UpdateCharacterStatsAsync(int characterId, CharacterStatsDto characterStats);
        Task UpdateCharacterHpAsync(int characterId, int value);
        Task AddItemsToInventoryAsync(int characterId,List<Item> itemList,int goldLoot);
        Task<int> AddExpByCharacterAndCombatantIdAsync(int characterId, int combatantId);
        Task<int> GetLevelByExperienceAsync(int experience);
        Task UpdateCharacterLevelAndStatPointsAsync(int characterId, int level);
        void StartCombat(int characterId, Combatant combatant);
        void StopCombat(int characterId);


    }
}
