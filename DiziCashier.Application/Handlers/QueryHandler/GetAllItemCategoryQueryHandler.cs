using DiziCashier.Application.Queries;
using DiziCashier.Core.Entities;
using MediatR;

namespace DiziCashier.Application.Handlers.QueryHandler
{
    public class GetAllItemCategoryQueryHandler : IRequestHandler<GetAllItemCategoryQuery, List<ItemCategory>>
    {
        public GetAllItemCategoryQueryHandler()
        {

        }

        Task<List<ItemCategory>> IRequestHandler<GetAllItemCategoryQuery, List<ItemCategory>>.Handle(GetAllItemCategoryQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
