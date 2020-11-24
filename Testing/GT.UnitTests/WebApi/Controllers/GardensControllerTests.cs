using System;
using System.Collections.Generic;
using AutoMapper;
using FluentAssertions;
using GT.Web.Api.Mappings;
using GT.Web.Api.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GT.UnitTests.WebApi.Controllers
{
    [TestClass]
    public class GardensControllerTests
    {
        private MapperConfiguration _mapperConfiguration;

        [TestInitialize]
        public void InitializeTest()
        {
            _mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
        }

        [TestMethod]
        public void GetGardensAsyncTest()
        {
            // Arrange
            IList<Garden> responseMock = new List<Garden>
            {
                new Garden
                {
                    GardenId = 1,
                    GardenName = "Garden1",
                    Crops = new List<Crop>
                    {
                        new Crop
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

            // Act

            // Assert

        }

        [TestMethod]
        public void GetGardenAsyncTest()
        {
            // Arrange

            // Act

            // Assert
            
        }

        [TestMethod]
        public void PutGardenAsyncTest()
        {
            // Arrange

            // Act

            // Assert
            
        }

        [TestMethod]
        public void PostGardenAsyncTest()
        {
            // Arrange

            // Act

            // Assert
            
        }

        [TestMethod]
        public void DeleteGardenAsyncTest()
        {
            // Arrange

            // Act

            // Assert
            
        }
    }
}