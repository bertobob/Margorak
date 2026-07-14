using Margorak.Api.Data;
using Margorak.Api.Interfaces;
using Margorak.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Margorak.Api.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext _db;

        public ItemRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Item> GetItemByIdAsync(int itemId)
        {
            var item = await _db.Items
                .Include(c => c.ItemCategory)
                .AsNoTracking()
                .FirstAsync(x => x.Id == itemId);

            return item;
        }

        public async Task<List<Item>> GetItemsByIdsAsync(List<int> itemIds)
        {
            var itemList = await _db.Items
                .Include(c => c.ItemCategory)
                .Where(x => itemIds.Contains(x.Id))
                .AsNoTracking()
                .ToListAsync();

            return itemList;
        }
    }
}
