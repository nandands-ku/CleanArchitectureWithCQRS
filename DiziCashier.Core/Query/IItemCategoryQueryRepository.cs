using DiziCashier.Core.Entities;
using DiziCashier.Core.Query.Base;

namespace DiziCashier.Core.Query
{
    public interface IItemCategoryQueryRepository : IQueryRepository<ItemCategory>
    {
        Task<IReadOnlyList<ItemCategory>> GetAllAsync();
        Task<ItemCategory> GetByIdAsync(Guid id);
    }
}
