using Margorak.Api.Dto;
using Margorak.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Margorak.Api.Controllers
{
    [ApiController]
    [Route("api/map")]
    public class MapController : Controller
    {
        private DbAccessService _dbAccessService;


        public MapController(DbAccessService dbAccessService)
        {
            _dbAccessService = dbAccessService;
        }

        [HttpGet("maps")]
        public async Task <ActionResult<List<MapDto>>> GetMaps()
        {
            var result = await _dbAccessService.GetMapsAsync();
            return Ok(result);  
        }

      

    }
}
