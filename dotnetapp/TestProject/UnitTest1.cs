// using NUnit.Framework;
// using Moq;
// using Microsoft.AspNetCore.Mvc;
// using dotnetapp.Models;
// using System.Collections.Generic;

// namespace dotnetapp.Tests
// {
//     [TestFixture]
//     public class FurnitureControllerTests
//     {
//         [Test]
//         public void Index_ReturnsViewResult_WithListOfFurniture()
//         {
//             // Arrange
//             var mockRepository = new Mock<IRepository<Furniture>>();
//             var furnitureList = new List<Furniture>
//             {
//                 new Furniture { id = 1, Product = "Chair", Description = "Wooden chair", Material = "Wood", Dimensions = "40x40x80", Price = 100 },
//                 new Furniture { id = 2, Product = "Table", Description = "Glass top table", Material = "Glass", Dimensions = "120x80x75", Price = 200 }
//             };
//             mockRepository.Setup(repo => repo.GetAll()).Returns(furnitureList);
//             var controller = new FurnitureController(mockRepository.Object);

//             // Act
//             var result = controller.Index() as ViewResult;

//             // Assert
//             Assert.IsNotNull(result);
//             Assert.IsInstanceOf<ViewResult>(result);
//             Assert.AreEqual(furnitureList, result.Model);
//         }
//     }
// }