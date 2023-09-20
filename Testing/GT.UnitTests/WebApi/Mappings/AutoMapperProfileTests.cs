using AutoMapper;
using FluentAssertions;
using GT.Web.Api.Mappings;
using GT.Web.Api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CropActivityEntity = GT.Domain.Models.CropActivity;

namespace GT.UnitTests.WebApi.Mappings
{
    [TestClass]
    public class AutoMapperProfileTests
    {
        private MapperConfiguration _mapperConfiguration;

        [TestInitialize]
        public void InitializeTest()
        {
            _mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
        }

        [TestMethod]
        public void AutoMapper_Configuration_IsValid()
        {
            _mapperConfiguration.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void CreateMap_From_CropActivityEntity_To_CropActivityDto_WithValid_Values_Succeeds_Test()
        {
            // Arrange
            var cropActivityEntity = new CropActivityEntity
            {
                CropActivityId = 1,
                CropId = 1,
                ActivityId = (int)Activities.Cloning,
                ActivityDate = DateTimeOffset.UtcNow,
                Notes = "Some notes."
            };

            var mapper = _mapperConfiguration.CreateMapper();

            // Act
            var result = mapper.Map<CropActivity>(cropActivityEntity);

            // Assert
            result.Should().NotBeNull();
            result.CropActivityId.Should().Be(cropActivityEntity.CropActivityId);
            result.CropId.Should().Be(cropActivityEntity.CropId);
            result.ActivityType.Should().Be(Activities.Cloning);
            result.ActivityDate.Should().Be(cropActivityEntity.ActivityDate);
            result.Notes.Should().Be(cropActivityEntity.Notes);
        }

        [TestMethod]
        public void CreateMap_From_CropActivityDto_To_CropActivityEntity_WithValid_Values_Succeeds_Test()
        {
            // Arrange
            var cropActivity = new CropActivity
            {
                CropActivityId = 1,
                CropId = 1,
                ActivityType = Activities.Cloning,
                ActivityDate = DateTimeOffset.UtcNow,
                Notes = "Some notes."
            };

            var mapper = _mapperConfiguration.CreateMapper();

            // Act
            var result = mapper.Map<CropActivityEntity>(cropActivity);

            // Assert
            result.Should().NotBeNull();
            result.CropActivityId.Should().Be(cropActivity.CropActivityId);
            result.CropId.Should().Be(cropActivity.CropId);
            result.ActivityId.Should().Be((int)Activities.Cloning);
            result.ActivityDate.Should().Be(cropActivity.ActivityDate);
            result.Notes.Should().Be(cropActivity.Notes);
        }
    }
}