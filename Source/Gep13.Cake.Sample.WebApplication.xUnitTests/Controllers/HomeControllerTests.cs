namespace Gep13.Cake.Sample.WebApplication.xUnitTests.Controllers
{
    using System.Web.Mvc;
    using Gep13.Cake.Sample.WebApplication.Controllers;
    using Xunit;

    public class HomeControllerTests
    {
        [Fact]
        public void Contact()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Contact() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }
    }
}