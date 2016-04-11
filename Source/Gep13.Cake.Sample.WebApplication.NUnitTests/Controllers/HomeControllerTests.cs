namespace Gep13.Cake.Sample.WebApplication.NUnitTests.Controllers
{
    using System.Web.Mvc;
    using Gep13.Cake.Sample.WebApplication.Controllers;
    using NUnit.Framework;

    [TestFixture]
    public class HomeControllerTests
    {
        [Test]
        public void Index()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void About()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.About() as ViewResult;

            // Assert
            if (result != null)
            {
                Assert.AreEqual("Your application description page.", result.ViewBag.Message);
            }
        }

        [Test]
        public void Contact()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}