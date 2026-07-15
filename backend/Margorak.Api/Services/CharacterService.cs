using Margorak.Api.Dto;
using Margorak.Api.Interfaces;
using Margorak.Api.Mapper;
using Margorak.Api.Models;

namespace Margorak.Api.Services
{
    public class CharacterService
    {
        private readonly ICharacterRepository _characterRepository;
        private readonly IMapRepository _mapRepository;

        public CharacterService(ICharacterRepository characterRepository, IMapRepository mapRepository)
        {
            _characterRepository = characterRepository;
            _mapRepository = mapRepository;
        }

        public async Task<List<CharacterDto>> GetAllCharactersAsync()
        {
            var characters = await _characterRepository.GetAllCharactersAsync();

            return characters
                .Select(CharacterMapper.ToDto)
                .ToList();
        }

        public async Task<CharacterDto?> GetCharacterByIdAsync(int id)
        {
            var character = await _characterRepository.GetCharacterByIdAsync(id);

            return character is null
                ? null
                : CharacterMapper.ToDto(character);
        }

        public async Task<List<CharacterRaceDto>> GetAvailableRacesAsync()
        {
            var characterRaces = await _characterRepository.GetRacesAsync();
            var races = new List<CharacterRaceDto>();
            foreach(var race in characterRaces)
            {
                races.Add(CharacterRaceMapper.ToDto(race));
            }
            return races;
        }

        public async Task<List<CharacterClassDto>> GetAvailabeClassesAsync()
        {
            var characterClasses = await _characterRepository.GetClassesAsync();
            var classes = new List<CharacterClassDto>();
            foreach (var _class in characterClasses)
            {
                classes.Add(CharacterClassMapper.ToDto(_class));
            }
            return classes;
        }

        public async Task<Character> SaveCharacterAsync(CreateCharacterDto request)
        {
            var race = await _characterRepository.GetRaceByIdAsync(request.CharacterRaceId);

            if (race is null)
            {
                throw new ArgumentException(
                    $"The character race with ID {request.CharacterRaceId} does not exist.");
            }

            var characterClass = await _characterRepository.GetClassByIdAsync(request.CharacterClassId);

            if (characterClass is null)
            {
                throw new ArgumentException(
                    $"The character class with ID {request.CharacterClassId} does not exist.");
            }

            var character = new Character
            {
                Name = request.Name.Trim(),
                CharacterRaceId = race.Id,
                CharacterRace = race,
                CharacterClassId = characterClass.Id,
                CharacterClass = characterClass
            };

            await _characterRepository.SaveNewCharacterAsync(character);

            return character;
        }

        public async Task UpdateCharacterPositionAsync(int characterId, int mapId, int locX,int locY)
        {
            var isAccessible = await _mapRepository.IsAccessiblePositionAsync(mapId, locX, locY);

            if(!isAccessible)
            {
                throw new ArgumentException(
                    $"Position ({locX}, {locY}) on map {mapId} is invalid.");
            }

            var updated = await _characterRepository.UpdateCharacterPositionAsync(characterId, mapId, locX, locY);

            if(!updated)
            {
                throw new KeyNotFoundException(
                    $"Character {characterId} was not found.");
            }
        }

    }
}
