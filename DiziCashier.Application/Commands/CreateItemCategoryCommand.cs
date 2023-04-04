using DiziCashier.Application.Response;
using MediatR;

namespace DiziCashier.Application.Commands
{
    public class CreateItemCategoryCommand : IRequest<ItemCategoryResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CrteatedOn { get; set; }
        public CreateItemCategoryCommand()
        {
            CrteatedOn = DateTime.UtcNow;
        }
    }
}
