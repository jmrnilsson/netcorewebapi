using WebApiExample.Api.Controllers;
using Xunit;

namespace WebApiExample.Test
{
    public class Sha256Tests
    {

        [Fact]
        public void Sha256_Get()
        {
            var controller = new Sha256Controller();
            var result = controller.Get("2");
            Assert.NotNull(result);
        }
    }
}