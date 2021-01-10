using AutoMapper;
using FluentAssertions;
using GT.Domain.Repositories.Interfaces;
using GT.Web.Api.Controllers;
using GT.Web.Api.Mappings;
using GT.Web.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CropEntity = GT.Domain.Models.Crop;
using GardenEntity = GT.Domain.Models.Garden;

namespace GT.UnitTests.WebApi.Controllers
{
    [TestClass]
    public class GardensControllerTests
    {
        private Mock<ILogger<GardensController>> _logger;
        private MapperConfiguration _mapperConfiguration;
        private IMapper _mapper;
        private Mock<IGardenRepository> _gardenRepositoryMock;

        [TestInitialize]
        public void InitializeTest()
        {
            _logger = new Mock<ILogger<GardensController>>();
            _mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            _mapper = new Mapper(_mapperConfiguration);
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

            var gardenId = 1;

            _gardenRepositoryMock.Setup(r => r.GetGardensAsync()).ReturnsAsync(responseMock);

            var controller = new GardensController(_mapper, _logger.Object, _gardenRepositoryMock.Object);

            // Act
            var result = await controller.GetGardensAsync() as ObjectResult;
            var model = result?.Value;

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<OkObjectResult>();
            result?.StatusCode.Should().Be(StatusCodes.Status200OK);

            model.Should().NotBeNull();
            model.Should().BeOfType<List<Garden>>();
            model.As<List<Garden>>().Count.Should().Be(1);
            model.As<List<Garden>>()[0].GardenId.Should().Be(gardenId);
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