using Margorak.Api.Dto;
using Margorak.Api.Interfaces;
using Margorak.Api.Mapper;

namespace Margorak.Api.Services
{
    public class MapService
    {
        private readonly DbAccessService _dbAccessService;
        private readonly IEnumerable<IMapInteractionDtoFactory> _factories;
        public MapService(DbAccessService dbAccessService,IEnumerable<IMapInteractionDtoFactory> factories)
        {
            _dbAccessService = dbAccessService;
            _factories = factories;
        }

        public async Task<List<MapDto>> GetMapsAsync()
        {
            var maps = await _dbAccessService.GetMapsAsync();

            var mapList = new List<MapDto>();

            foreach (var map in maps)
            {
                mapList.Add(await MapMapper.ToDto(map, _factories));
            }
            return mapList;
        }
    }
}
