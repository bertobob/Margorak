using Margorak.Api.Dto;
using Margorak.Api.Interfaces;
using Margorak.Api.Mapper;

namespace Margorak.Api.Services
{
    public class MapService
    {
        private readonly IMapRepository _mapRepository;
        private readonly IEnumerable<IMapInteractionDtoFactory> _factories;
        public MapService(IEnumerable<IMapInteractionDtoFactory> factories, IMapRepository mapRepository)
        {
            _factories = factories;
            _mapRepository = mapRepository;
        }

        public async Task<List<MapDto>> GetMapsAsync()
        {
            var maps = await _mapRepository.GetMapsAsync();

            var mapList = new List<MapDto>();

            foreach (var map in maps)
            {
                mapList.Add(await MapMapper.ToDto(map, _factories));
            }
            return mapList;
        }
    }
}
