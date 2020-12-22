using AutoMapper;
using FluentAssertions;
using GT.Domain.Repositories.Interfaces;
using GT.Web.Api.Controllers;
using GT.Web.Api.Mappings;
using GT.Web.Api.Models;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CropActivityEntity = GT.Domain.Models.CropActivity;
using CropEntity = GT.Domain.Models.Crop;

namespace GT.UnitTests.WebApi.Controllers
{
    [TestClass]
    public class CropsControllerTests
    {
        private Mock<ILogger<CropsController>> _logger;
        private MapperConfiguration _mapperConfiguration;
        private Mock<ICropRepository> _cropRepositoryMock;

        [TestInitialize]
        public void InitializeTest()
        {
            _logger = new Mock<ILogger<CropsController>>();
            _mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            _cropRepositoryMock = new Mock<ICropRepository>();
        }

        #region Get Crops

        [TestMethod]
        public async Task GetCropsAsyncTest()
        {
            // Arrange
            IEnumerable<CropEntity> responseMock = new List<CropEntity>
            {
                new CropEntity
                {
                    CropId = 1,
                    GardenId = 1,
                    CropName = "Garden1",
                    PlantName = "Plant1",
                    BeginDate = DateTimeOffset.UtcNow.AddDays(-1),
                    EndDate = null,
                    Notes = "Some Notes",
                    CropActivities = new List<CropActivityEntity>
                    {
                        new CropActivityEntity{ActivityId = 1, ActivityDate = DateTimeOffset.UtcNow,CropId = 1, CropActivityId = 1}
                    }
                }
            };

            var mapper = new Mapper(_mapperConfiguration);

            _cropRepositoryMock.Setup(r => r.GetCropsAsync()).ReturnsAsync(responseMock);

            var controller = new CropsController(mapper, _logger.Object, _cropRepositoryMock.Object);

            // Act
            var actionResult = await controller.GetCropsAsync();

            // Assert
            actionResult.Should().NotBeNull();
            actionResult.Should().BeOfType<List<Crop>>();
            actionResult.Count.Should().Be(1);
        }

        #endregion


        [TestMethod]
        public void GetCropAsyncTest()
        {
            // Arrange

            // Act

            // Assert
            
        }

        [TestMethod]
        public void PutCropAsyncTest()
        {
            // Arrange

            // Act

            // Assert
            
        }

        [TestMethod]
        public void PostCropAsyncTest()
        {
            // Arrange

            // Act

            // Assert
            
        }

        [TestMethod]
        public void DeleteCropAsyncTest()
        {
            // Arrange

            // Act

            // Assert
            
        }
    }
}