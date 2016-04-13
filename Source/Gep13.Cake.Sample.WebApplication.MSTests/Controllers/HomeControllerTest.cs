namespace Gep13.Cake.Sample.WebApplication.MSTests.Controllers
{
    using System.Web.Mvc;
    using Gep13.Cake.Sample.WebApplication.Controllers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}