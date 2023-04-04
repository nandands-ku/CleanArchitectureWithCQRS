using DiziCashier.Application.Commands;
using DiziCashier.Application.Mapper;
using DiziCashier.Application.Response;
using DiziCashier.Core.Command;
using DiziCashier.Core.Entities;
using MediatR;

namespace DiziCashier.Application.Handlers.CommandHandler
{
    public class CreateItemCategoryCommandHandler : IRequestHandler<CreateItemCategoryCommand, ItemCategoryResponse>
    {
        IItemCategoryCommandRepository _repository;
        public CreateItemCategoryCommandHandler(IItemCategoryCommandRepository repository)
        {
            _repository = repository;
        }
        public async Task<ItemCategoryResponse> Handle(CreateItemCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = DiziCashierMapper.Mapper.Map<ItemCategory>(request);

            if (entity is null)
                throw new ApplicationException("There is a problem in mapper");

            var itemcategory = await _repository.AddAsync(entity);
            var response = DiziCashierMapper.Mapper.Map<ItemCategoryResponse>(itemcategory);
            return response;

        }
    }
}
