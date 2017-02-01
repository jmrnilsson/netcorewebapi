using System;
using Xunit;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace AptSalaryImport
{
    public class Tests
    {
        [Fact]
        public void HttpClient_TrueIsTrue()
        {
            Assert.Equal(true, true);
        }

        [Fact]
        public async Task Values_Index()
        {
            // Arrange
            var controller = new ValuesController();

            // Act
            var result = await controller.Get(2);

            // Assert
            Assert.NotNull(result);
        }
    }
}