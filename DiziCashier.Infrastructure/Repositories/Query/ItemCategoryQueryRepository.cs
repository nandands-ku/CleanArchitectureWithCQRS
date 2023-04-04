using DiziCashier.Core.Entities;
using DiziCashier.Core.Query;
using DiziCashier.Infrastructure.Data;
using DiziCashier.Infrastructure.Models;
using DiziCashier.Infrastructure.Repositories.Query.Base;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace DiziCashier.Infrastructure.Repositories.Query
{
    public class ItemCategoryQueryRepository : QueryRepository<ItemCategory>, IItemCategoryQueryRepository
    {

        public ItemCategoryQueryRepository(IOptions<DiziCashierMongoDatabaseSettings> settings) : base(settings)
        {
        }

        public async Task<IReadOnlyList<ItemCategory>> GetAllAsync()
        {
            return await _context.ItemCategories.Find(_ => true).ToListAsync();
        }

        public async Task<ItemCategory> GetByIdAsync(Guid id)
        {
            return await _context.ItemCategories.Find(i => i.Id == id).FirstOrDefaultAsync();
        }
    }
}
