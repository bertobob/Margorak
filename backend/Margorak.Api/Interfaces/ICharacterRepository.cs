using Margorak.Api.Models;

namespace Margorak.Api.Interfaces
{
    public interface ICharacterRepository
    {
        Task<Character?> GetCompleteCharacterAsync(int characterId);
        Task<bool> UpdateCharacterPositionAsync(int characterId, int mapId, int locX, int locY);
        Task<List<CharacterRace>> GetRacesAsync();
        Task<List<CharacterClass>> GetClassesAsync();
        Task<Character?> GetCharacterByIdAsync(int characterId);
        Task<List<Character>> GetAllCharactersAsync();
        Task<CharacterRace?> GetRaceByIdAsync(int raceId);
        Task<CharacterClass?> GetClassByIdAsync(int classId);

        Task SaveNewCharacterAsync(Character newCharacter);
    }
}
