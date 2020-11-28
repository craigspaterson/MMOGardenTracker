using AutoMapper;
using FluentAssertions;
using GT.Web.Api.Controllers;
using GT.Web.Api.Mappings;
using GT.Web.Api.Models;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GT.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CropEntity = GT.Domain.Models.Crop;
using GardenEntity = GT.Domain.Models.Garden;

namespace GT.UnitTests.WebApi.Controllers
{
    [TestClass]
    public class GardensControllerTests
    {
        private Mock<ILogger<GardensController>> _logger;
        private MapperConfiguration _mapperConfiguration;
        private Mock<IGardenRepository> _gardenRepositoryMock;

        [TestInitialize]
        public void InitializeTest()
        {
            _logger = new Mock<ILogger<GardensController>>();
            _mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            _gardenRepositoryMock = new Mock<IGardenRepository>();
        }

        #region Get Gardens

        [TestMethod]
        public async Task GetGardensAsyncTest()
        {
            // Arrange
            IEnumerable<GardenEntity> responseMock = new List<GardenEntity>
            {
                new GardenEntity
                {
                    GardenId = 1,
                    GardenName = "Garden1",
                    Crops = new List<CropEntity>
                    {
                        new CropEntity
                        {
                            GardenId = 1,
                            CropId = 1,
                            CropName = "Crop1",
                            PlantName="Plant1",
                            BeginDate = new DateTimeOffset(),
                            EndDate = new DateTimeOffset().AddDays(1),
                            Notes = "Note1"
                        }
                    }
                }
            };

            var mapper = new Mapper(_mapperConfiguration);

            _gardenRepositoryMock.Setup(r => r.GetGardensAsync()).ReturnsAsync(responseMock);

            var controller = new GardensController(mapper, _logger.Object, _gardenRepositoryMock.Object);

            // Act
            var actionResult = await controller.GetGardensAsync();

            // Assert
            actionResult.Should().NotBeNull();
            actionResult.Should().BeOfType<List<Garden>>();
            actionResult.Count.Should().Be(1);
        }

        #endregion

        #region Get Garden

        [TestMethod]
        public void GetGardenAsyncTest()
        {
            // Arrange

            // Act

            // Assert

        }

        #endregion

        #region Put Garden

        [TestMethod]
        public void PutGardenAsyncTest()
        {
            // Arrange

            // Act

            // Assert

        }

        #endregion

        #region Post Garden

        [TestMethod]
        public void PostGardenAsyncTest()
        {
            // Arrange

            // Act

            // Assert

        }

        #endregion

        #region Delete Garden

        [TestMethod]
        public void DeleteGardenAsyncTest()
        {
            // Arrange

            // Act

            // Assert

        }

        #endregion
    }
}