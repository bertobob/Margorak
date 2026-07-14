using Margorak.Api.Models;

namespace Margorak.Api.Interfaces
{
    public interface IMapRepository
    {
        Task<List<Map>> GetMapsAsync();
    }
}
