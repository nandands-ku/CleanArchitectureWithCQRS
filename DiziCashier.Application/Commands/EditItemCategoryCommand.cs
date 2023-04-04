using DiziCashier.Application.Response;
using MediatR;

namespace DiziCashier.Application.Commands
{
    public class EditItemCategoryCommand : IRequest<ItemCategoryResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CrteatedOn { get; set; }

    }
}
