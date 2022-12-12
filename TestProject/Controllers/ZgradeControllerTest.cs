using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zavrsni_Test_Maja_Cveticanin.Controllers;
using Zavrsni_Test_Maja_Cveticanin.IRepository;
using Zavrsni_Test_Maja_Cveticanin.Models;

namespace TestProject.Controllers
{
    public class ZgradeControllerTest
    {
        [Fact]
        public void GetZgrade_ValidZgrade_ReturnsCollection()
        {
            // Arrange
            List<Zgrada> sporedne = new List<Zgrada>() {
                new Zgrada() { Id = 1, Adresa = "Test 1", GodinaIzgradnje = 1980},
                new Zgrada() { Id = 2, Adresa = "Test 2", GodinaIzgradnje = 2005  }
            };

            var mockRepository = new Mock<IZgradaRepository>();
            mockRepository.Setup(x => x.GetAll()).Returns(sporedne);

            var mockLogger = new Mock<ILogger<ZgradeController>>();

            var controller = new ZgradeController(mockRepository.Object, mockLogger.Object);

            // Act
            var actionResult = controller.GetZgrade() as OkObjectResult;

            // Assert
            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);

            List<Zgrada> listResult = (List<Zgrada>)actionResult.Value;

            Assert.Equal(sporedne[0], listResult[0]);
            Assert.Equal(sporedne[1], listResult[1]);
        }

        [Fact]
        public void PutZgrade_InvalidId_ReturnsBadRequest()
        {
            // Arrange
            Zgrada zgrada = new Zgrada() { Id = 1, Adresa = "Test 1", GodinaIzgradnje = 1980 };

            var mockRepository = new Mock<IZgradaRepository>();

            var mockLogger = new Mock<ILogger<ZgradeController>>();

            var controller = new ZgradeController(mockRepository.Object, mockLogger.Object);

            // Act
            var actionResult = controller.PutZgrada(24, zgrada) as BadRequestResult;

            // Assert
            Assert.NotNull(actionResult);
        }

        [Fact]
        public void PostZgrada_ValidZgrada_SetsLocationHeader()
        {
            // Arrange
            Zgrada zgrada = new Zgrada() { Id = 2, Adresa = "Test 1", GodinaIzgradnje = 1980 };

            var mockRepository = new Mock<IZgradaRepository>();

            var mockLogger = new Mock<ILogger<ZgradeController>>();

            var controller = new ZgradeController(mockRepository.Object, mockLogger.Object);

            // Act
            var actionResult = controller.PostZgrada(zgrada) as CreatedAtActionResult;

            // Assert
            Assert.NotNull(actionResult);
            Assert.Equal("GetZgrada", actionResult.ActionName);
            Assert.Equal(2, actionResult.RouteValues["id"]);
            Assert.Equal(zgrada, actionResult.Value);
        }
    }
}
