using NUnit.Framework;
using dotnetapp.Controllers;
using dotnetapp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureControllerTests
{
    [TestFixture]
    public class FurnitureControllerTests
    {
        private FurnitureController _controller;

        [SetUp]
        public void Setup()
        {
            // Initialize the controller before each test
            _controller = new FurnitureController();
        }

        [Test]
        public void Index_ReturnsViewResultWithFurnitures()
        {
            // Arrange

            // Act
            var result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
            Assert.IsAssignableFrom(typeof(List<Furniture>), result.Model);
        }

        [Test]
        public void Create_ReturnsViewResult()
        {
            // Arrange

            // Act
            var result = _controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOf<ViewResult>(result);
        }
        [Test]
public void Edit_NonExistingId_ReturnsNotFoundResult()
{
    // Arrange
    int nonExistingId = 100; // Assuming there is no furniture item with ID 100

    // Act
    var result = _controller.Edit(nonExistingId) as NotFoundResult;

    // Assert
    Assert.IsNotNull(result);
    Assert.IsInstanceOf<NotFoundResult>(result);
}
     

[Test]
public void Delete_NonExistingId_ReturnsNotFoundResult()
{
    // Arrange
    int nonExistingId = 100; // Assuming there is no furniture item with ID 100

    // Act
    var result = _controller.Delete(nonExistingId) as NotFoundResult;

    // Assert
    Assert.IsNotNull(result);
    Assert.IsInstanceOf<NotFoundResult>(result);
}

[Test]
public void Delete_InvalidId_ReturnsBadRequestResult()
{
    // Arrange
    int invalidId = -1; // Assuming -1 is an invalid ID

    // Act
    var result = _controller.Delete(invalidId) as BadRequestResult;

    // Assert
    Assert.IsNotNull(result);
    Assert.IsInstanceOf<BadRequestResult>(result);
}

    }
}
