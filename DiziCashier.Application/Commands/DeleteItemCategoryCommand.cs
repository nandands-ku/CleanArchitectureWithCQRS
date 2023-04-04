namespace DiziCashier.Application.Commands
{
    public class DeleteItemCategoryCommand
    {
        public Guid Id { get; private set; }

        public DeleteItemCategoryCommand(Guid Id)
        {
            this.Id = Id;
        }
    }
}
