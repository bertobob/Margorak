using Margorak.Api.Dto;
using Margorak.Api.Mapper;
using Margorak.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Margorak.Api.Controllers
{
    [ApiController]
    [Route("api/character")]
    public class CharacterController : Controller
    {
        private readonly CharacterService _characterService;

        public CharacterController(CharacterService characterService)
        {
            _characterService = characterService;
        }
            

        [HttpGet("character/{characterId}")]
        public async Task<ActionResult<CharacterDto>> GetCharacterByIdAsync(int characterId)
        {
            var result = await _characterService.GetCharacterByIdAsync(characterId);

            return result is null
                ? NotFound()
                : Ok(result);
        }

        [HttpGet("characters")]
        public async Task<ActionResult<CharacterDto[]>> GetAllCharactersAsync()
        {
            var result = await _characterService.GetAllCharactersAsync();

            return Ok(result);
        }

        [HttpGet("races")]
        public async Task<ActionResult<CharacterRaceDto[]>> GetAvailableRacesAsync()
        {
            var result = await _characterService.GetAvailableRacesAsync();

            return Ok(result);
        }

        [HttpGet("classes")]
        public async Task<ActionResult<CharacterClassDto[]>> GetAvailableClassesAsync()
        {
            var result = await _characterService.GetAvailabeClassesAsync();

            return Ok(result);
        }

        [HttpPost("characters")]
        public async Task<ActionResult<CharacterDto>> SaveCharacterAsync(
            [FromBody] CreateCharacterDto request)
        {
            try
            {
                var character = await _characterService.SaveCharacterAsync(request);
                var characterDto = CharacterMapper.ToDto(character);

                return CreatedAtAction(
                    nameof(GetCharacterByIdAsync),
                    new { characterId = character.Id },
                    characterDto);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }
    }
}
