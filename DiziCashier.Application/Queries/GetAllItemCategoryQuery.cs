using DiziCashier.Core.Entities;
using MediatR;

namespace DiziCashier.Application.Queries
{
    public record GetAllItemCategoryQuery : IRequest<List<ItemCategory>>
    {

    }
}
