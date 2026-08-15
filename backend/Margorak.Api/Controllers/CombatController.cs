using Margorak.Api.Dto;
using Margorak.Api.Interfaces;
using Margorak.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Margorak.Api.Controllers
{
    [ApiController]
    [Route("api/combat")]
    public class CombatController : Controller
    {
        private readonly CharacterService _characterService;
        private readonly CombatService _combatService;

        public CombatController(CharacterService characterService,CombatService combatService)
        {
            _characterService = characterService;
            _combatService = combatService;
        }

        [HttpGet("startCombat")]
        public async Task<ActionResult<ActiveCombatDto>> StartCombat(int characterId,int combatantId)
        {
            var result = await _characterService.StartCombat(characterId, combatantId);

            return Ok(result);
        }
        [HttpDelete("stopCombat")]
        public async Task<ActionResult> StopCombat(int characterId)
        {
            await _characterService.StopCombat(characterId);

            return Ok();
        }

        [HttpPost("attack")]
        public async Task<ActionResult<ActiveCombatDto>> Attack(int characterId)
        {
            var result = await _combatService.Attack(characterId);

            return Ok(result);
        }



    }
}
