using Margorak.Api.Dto;
using Margorak.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Margorak.Api.Controllers
{
    [ApiController]
    [Route("api/map")]
    public class MapController : Controller
    {
        private MapService _mapService;


        public MapController(MapService mapService)
        {
            _mapService = mapService;
        }

        [HttpGet("maps")]
        public async Task <ActionResult<List<MapDto>>> GetMaps()
        {
            var result = await _mapService.GetMapsAsync();
            return Ok(result);  
        }

      

    }
}
