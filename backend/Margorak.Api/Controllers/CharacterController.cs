using Margorak.Api.Dto;
using Margorak.Api.Mapper;
using Margorak.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace Margorak.Api.Controllers
{
    [ApiController]
    [Route("api/characters")]
    public class CharacterController : ControllerBase
    {
        private readonly CharacterService _characterService;
        public CharacterController(CharacterService characterService)
        {
            _characterService = characterService;
        }
            

        [HttpGet("{characterId:int}/load", Name = "LoadCharacter")]
        public async Task<ActionResult<LoadCharacterDto>> LoadCharacterAsync(int characterId)
        {
            var result = await _characterService.LoadCharacterAsync(characterId);

            return result is null
                ? NotFound()
                : Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<CharacterDto[]>> GetAllCharactersAsync()
        {
            var result = await _characterService.GetAllCharactersAsync();

            return Ok(result);
        }

        [HttpGet("options/races")]
        public async Task<ActionResult<CharacterRaceDto[]>> GetAvailableRacesAsync()
        {
            var result = await _characterService.GetAvailableRacesAsync();

            return Ok(result);
        }

        [HttpGet("options/classes")]
        public async Task<ActionResult<CharacterClassDto[]>> GetAvailableClassesAsync()
        {
            var result = await _characterService.GetAvailabeClassesAsync();

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CharacterDto>> CreateCharacterAsync(
            [FromBody] CreateCharacterDto request)
        {
            try
            {
                var character = await _characterService.CreateCharacterAsync(request);
                var characterDto = CharacterMapper.ToDto(character);

                return CreatedAtRoute(
                    "LoadCharacter",
                    new { characterId = character.Id },
                    characterDto);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        [HttpPut("{characterId:int}/save")]
        public async Task<ActionResult> SaveCharacterAsync
            (int characterId,
            [FromBody] SaveCharacterDto request)
        {
            await _characterService.SaveCharacterAsync(characterId,request);

            return NoContent();
        }
    }
}
