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

        [Fact]
        public void About()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.About() as ViewResult;

            // Assert
            if (result != null)
            {
                Assert.Equal("Your application description page.", result.ViewBag.Message);
            }
        }

        [Fact]
        public void Index()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }
    }
}