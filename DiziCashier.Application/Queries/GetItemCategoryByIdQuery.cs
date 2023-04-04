using DiziCashier.Core.Entities;
using MediatR;

namespace DiziCashier.Application.Queries
{
    public class GetItemCategoryByIdQuery:IRequest<ItemCategory>
    {
        public Guid Id { get; set; }
        public GetItemCategoryByIdQuery(Guid Id)
        {
            this.Id = Id;
        }
    }
}
