using Moq;
using Xunit;

namespace DiziCashier.Application.UnitTest
{
    public class CreateItemCategoryCommandHandlerTest
    {
        [Fact]
        public void Handle_Should_IsSuccess()
        {
            Assert.Equal(5, Add(2, 2));
        }
        private int Add(int a, int b)
        {
            return a + b;
        }
    }
}