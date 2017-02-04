using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft​.AspNetCore​.Hosting;

namespace WebApi
{

    public class IntegrationTests
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public IntegrationTests()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task ReturnHelloWorld()
        {
            // Act
            var response = await _client.GetAsync("/api/values");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.NotNull(responseString);
        }
    }
}
// https://docs.microsoft.com/en-us/aspnet/core/testing/integration-testing
// "dependencies": {
//   "xunit": "2.1.0",
//   "dotnet-test-xunit": "1.0.0-rc2-build10025",
//   "Microsoft.AspNetCore.TestHost": "1.1.0"
// },
