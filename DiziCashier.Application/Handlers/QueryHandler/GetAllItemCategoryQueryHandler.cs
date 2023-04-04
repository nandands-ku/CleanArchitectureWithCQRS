using DiziCashier.Application.Queries;
using DiziCashier.Core.Entities;
using DiziCashier.Core.Query;
using MediatR;

namespace DiziCashier.Application.Handlers.QueryHandler
{
    public class GetAllItemCategoryQueryHandler : IRequestHandler<GetAllItemCategoryQuery, List<ItemCategory>>
    {
        private readonly IItemCategoryQueryRepository _repository;
        public GetAllItemCategoryQueryHandler(IItemCategoryQueryRepository repository)
        {
            _repository = repository;
        }

        async Task<List<ItemCategory>> IRequestHandler<GetAllItemCategoryQuery, List<ItemCategory>>.Handle(GetAllItemCategoryQuery request, CancellationToken cancellationToken)
        {
            return (List<ItemCategory>)await _repository.GetAllAsync();
        }
    }
}
