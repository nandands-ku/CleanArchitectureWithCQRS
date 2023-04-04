using DiziCashier.Core.Query.Base;
using DiziCashier.Infrastructure.Data;
using DiziCashier.Infrastructure.Models;
using Microsoft.Extensions.Options;

namespace DiziCashier.Infrastructure.Repositories.Query.Base
{
    public class QueryRepository<T> : IQueryRepository<T> where T : class
    {
        protected readonly MongoDBContext _context;
        public QueryRepository(MongoDBContext context)
        {
            _context = context;
        }
    }
}
