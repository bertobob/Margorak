using Margorak.Api.Dto;
using Margorak.Api.Mapper;
using Margorak.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Margorak.Api.Controllers
{
    [ApiController]
    [Route("api/characters")]
    public class CharacterController : ControllerBase
    {
        private readonly CharacterService _characterService;
        private readonly ItemService _itemService;

        public CharacterController(CharacterService characterService, ItemService itemService)
        {
            _itemService = itemService;
            _characterService = characterService;
        }
            

        [HttpGet("{characterId:int}", Name = "GetCharacterById")]
        public async Task<ActionResult<CharacterDto>> GetCharacterByIdAsync(int characterId)
        {
            var result = await _characterService.GetCharacterByIdAsync(characterId);

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
                    "GetCharacterById",
                    new { characterId = character.Id },
                    characterDto);
            }
            catch (ArgumentException exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        [HttpPatch("{characterId:int}/position")]
        public async Task<IActionResult> UpdateCharacterPositionAsync(
            int characterId,
            [FromBody] UpdateCharacterPositionDto request)
        {
            await _characterService.UpdateCharacterPositionAsync(
                characterId,
                request.MapId,
                request.LocX,
                request.LocY);

            return NoContent();
        }


        [HttpGet("{characterId:int}/inventory")]
        public async Task<ActionResult<List<InventoryItemDto>>> GetInventoryItemsByCharacterIdAsync(int characterId)
        {
            var result = await _itemService.GetInventoryItemsByCharacterIdAsync(characterId);

            return result is null
                ? NotFound()
                : Ok(result);
        }
    }
}
