using Margorak.Api.Dto;
using Margorak.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Margorak.Api.Controllers
{
    public class CombatantController : Controller
    {
        private readonly CombatantHabitatService _combatantHabitatService;

        public CombatantController(CombatantHabitatService combatantHabitatService)
        {
            _combatantHabitatService = combatantHabitatService;
        }

        [HttpGet("combatantHabitats/{mapId}")]
        public async Task<ActionResult<List<CombatantHabitatDto>>> GetCombatantHabitatsByMapIdAsync(int mapId)
        {
            var result = await _combatantHabitatService.GetCombatantHabitatsByMapIdAsync(mapId);
            return Ok(result);
        }
    }
}
