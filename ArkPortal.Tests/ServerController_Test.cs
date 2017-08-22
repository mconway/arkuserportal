using System;
using Moq;
using Xunit;
using ArkPortalWebApi.Controllers;
using ArkPortalWebApi.Models;

namespace ArkPortal.Tests
{
    public class ServerController_Test
    {
        [Fact]
        public void GetAll_ReturnsJSONString()
        {
            var moq = new Mock<IWebApiClient>();
            var testString = "{ 'test':'test' }";
            moq.Setup(r => r.Get()).Returns(testString);
            var controller = new ServerController(moq.Object);
            var data = controller.Get();
            Assert.True(data == testString);
        }
    }
}
