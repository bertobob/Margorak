using Margorak.Api.Models;

namespace Margorak.Api.Interfaces;

public interface IStartingItemService
{
    Task<List<OwnedItem>> GetStartingItemsAsync(int characterClassId);
}
