using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApiExample.Api.Controllers;
using Xunit;

namespace WebApiExample.Test
{
    public class ValuesTests
    {
        [Fact]
        public async Task Values_GetAsync_With_Silly_HttpClient()
        {
            var sha256 = new Sha256Controller();
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(sha256.Get("22"), Encoding.UTF8)
            };
            var handler = new ResponseHandler();
            handler.AddResponse(new Uri("http://localhost:5000/api/sha256/22"), response);
            var httpClient = new HttpClient(handler);

            var controller = new ValuesController(() => httpClient);
            var result = await controller.GetAsync(22);
            Assert.NotNull(result);
        }
    }
}
