using Xunit;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace WebApi
{
    public class Tests
    {
        [Fact]
        public async Task Values_GetAsync()
        {
            var controller = new ValuesController();
            var result = await controller.GetAsync(2);
            Assert.NotNull(result);
        }

        [Fact]
        public void Values_Get()
        {
            var controller = new ValuesController();
            var result = controller.Get(2);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Values_GetAwaitingAsync()
        {
            var controller = new ValuesController();
            var result = await controller.GetAwaitingAsync(2);
            Assert.NotNull(result);
        }
    }
}