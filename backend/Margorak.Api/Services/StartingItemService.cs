using Margorak.Api.Configuration;
using Margorak.Api.Interfaces;
using Margorak.Api.Models;
using Microsoft.Extensions.Options;

namespace Margorak.Api.Services;

public sealed class StartingItemService : IStartingItemService
{
    private readonly IItemRepository _itemRepository;
    private readonly StartingItemOptions _options;

    public StartingItemService(
        IItemRepository itemRepository,
        IOptions<StartingItemOptions> options)
    {
        _itemRepository = itemRepository;
        _options = options.Value;
    }

    public async Task<List<OwnedItem>> GetStartingItemsAsync(int characterClassId)
    {
        var definitions = _options.ByClass.GetValueOrDefault(characterClassId)
            ?? _options.Default;

        var itemIds = definitions
            .Select(definition => definition.ItemId)
            .Distinct()
            .ToList();

        var items = await _itemRepository.GetItemsByIdsAsync(itemIds);
        var itemsById = items.ToDictionary(item => item.Id);

        return definitions.Select(definition =>
        {
            if (!itemsById.TryGetValue(definition.ItemId, out var item))
            {
                throw new KeyNotFoundException(
                    $"Starting item {definition.ItemId} does not exist.");
            }

            return new OwnedItem
            {
                ItemId = item.Id,
                Item = item,
                Quantity = definition.Quantity
            };
        }).ToList();
    }
}
