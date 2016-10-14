using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicShop.Controllers;

namespace MusicShop.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index() {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Album_Valid() {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            PartialViewResult result = controller.Album(1) as PartialViewResult;

            // Assert
            Assert.IsNotNull(result);

            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void Album_Invalid() {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            PartialViewResult result = controller.Album(0) as PartialViewResult;

            // Assert
            Assert.IsNotNull(result);

            Assert.IsNull(result.Model);

        }

    }
}
