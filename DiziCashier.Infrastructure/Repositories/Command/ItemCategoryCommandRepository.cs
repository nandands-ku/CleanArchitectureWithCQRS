using DiziCashier.Core.Command;
using DiziCashier.Core.Entities;
using DiziCashier.Infrastructure.Data;
using DiziCashier.Infrastructure.Repositories.Command.Base;

namespace DiziCashier.Infrastructure.Repositories.Command
{
    public class ItemCategoryCommandRepository : CommandRepository<ItemCategory>, IItemCategoryCommandRepository
    {
        public ItemCategoryCommandRepository(DiziDBContext dBContext) : base(dBContext)
        {

        }
        
    }
}
