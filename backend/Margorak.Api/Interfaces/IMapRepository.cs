using Margorak.Api.Models;

namespace Margorak.Api.Interfaces
{
    public interface IMapRepository
    {
        Task<List<Map>> GetMapsAsync();
        Task<bool> IsAccessiblePositionAsync(int mapId, int locX,int locY);
    }
}
