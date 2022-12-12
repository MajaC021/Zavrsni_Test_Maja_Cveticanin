using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zavrsni_Test_Maja_Cveticanin.Controllers;
using Zavrsni_Test_Maja_Cveticanin.IRepository;
using Zavrsni_Test_Maja_Cveticanin.Models;
using Zavrsni_Test_Maja_Cveticanin.Models.DTO;
using Zavrsni_Test_Maja_Cveticanin.Models.Profil;

namespace TestProject.Controllers
{
    public class StanoviControllerTest
    {
        [Fact]
        public void GetStan_ValidId_ReturnsObject()
        {
            // Arrange
            Stan Stan = new Stan()
            {
               Id = 12,
               BrojKvadrata = 16,
               BrojStana = "555",
               CenaStana = 65000,
               TipStana = "Dvosobni",
               Zgrada = new Zgrada() { Id = 1, Adresa = "Ivana Boldizara 179", GodinaIzgradnje = 1965}

            };

            StanDetailsDTO StanDto = new StanDetailsDTO()
            {
                Id = 12,
                BrojKvadrata = 16,
                BrojStana = "555",
                CenaStana = 65000,
                TipStana = "Dvosobni",
                ZgradaAdresa = "Ivana Boldizara 179"

            };

            var mockRepository = new Mock<IStanRepository>();
            mockRepository.Setup(x => x.GetById(12)).Returns(Stan);

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new StanProfil()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new StanoviController(mockRepository.Object, mapper);

            var actionResult = controller.GetStan(12) as OkObjectResult;

            // Assert
            Assert.NotNull(actionResult);
            Assert.NotNull(actionResult.Value);

            StanDetailsDTO dtoResult = (StanDetailsDTO)actionResult.Value;     
            Assert.Equal(StanDto, dtoResult);
        }
        [Fact]
        public void DeleteStan_InvalidId_ReturnsNotFound()
        {
            // Arrange
            var mockRepository = new Mock<IStanRepository>();

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new StanProfil()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new StanoviController(mockRepository.Object, mapper);

            // Act
            var actionResult = controller.DeleteStan(12) as NotFoundResult;

            // Assert
            Assert.NotNull(actionResult);
        }
        [Fact]
        public void DeleteStan_ValidId_ReturnsNoContent()
        {
            // Arrange
            Stan Stan = new Stan()
            {
                Id = 12,
                BrojKvadrata = 16,
                BrojStana = "99",
                CenaStana = 65000,
                TipStana = "Dvosobni",
                Zgrada = new Zgrada() { Id = 1, Adresa = "Test", GodinaIzgradnje = 1965 }
            };

            var mockRepository = new Mock<IStanRepository>();
            mockRepository.Setup(x => x.GetById(12)).Returns(Stan);

            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new StanProfil()));
            IMapper mapper = new Mapper(mapperConfiguration);

            var controller = new StanoviController(mockRepository.Object, mapper);

            // Act
            var actionResult = controller.DeleteStan(12) as NoContentResult;

            // Assert
            Assert.NotNull(actionResult);
        }
    }
}

