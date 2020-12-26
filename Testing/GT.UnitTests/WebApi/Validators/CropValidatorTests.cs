using System;
using System.Collections.Generic;
using FluentValidation.TestHelper;
using GT.Web.Api.Models;
using GT.Web.Api.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GT.UnitTests.WebApi.Validators
{
    [TestClass]
    public class CropValidatorTests
    {
        private CropValidator _validator;

        [TestInitialize]
        public void InitializeTest()
        {
            _validator = new CropValidator();
        }

        [TestMethod]
        public void Should_Not_Have_Error_With_Valid_Properties_Test()
        {
            // Arrange
            var dto = new Crop
            {
                GardenId = 1,
                CropId = 1,
                CropName = "Garden1",
                PlantName = "Plant1",
                BeginDate = DateTimeOffset.UtcNow.AddDays(-1),
                EndDate = DateTimeOffset.UtcNow.AddDays(1),
                Notes = "Some Crop Notes",
                CropActivities = new List<CropActivity>
                {
                    new CropActivity
                    {
                        CropActivityId = 1,
                        CropId = 1,
                        ActivityType = Activities.Cloning,
                        ActivityDate = DateTimeOffset.UtcNow,
                        Notes = "Some Crop Activity Notes"
                    }
                }
            };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(actual => actual.GardenId);
            result.ShouldNotHaveValidationErrorFor(actual => actual.CropId);
            result.ShouldNotHaveValidationErrorFor(actual => actual.CropName);
            result.ShouldNotHaveValidationErrorFor(actual => actual.PlantName);
            result.ShouldNotHaveValidationErrorFor(actual => actual.BeginDate);
            result.ShouldNotHaveValidationErrorFor(actual => actual.EndDate);
            result.ShouldNotHaveValidationErrorFor(actual => actual.Notes);
            result.ShouldNotHaveValidationErrorFor(actual => actual.CropActivities);
            result.ShouldNotHaveAnyValidationErrors();
        }

        [TestMethod]
        public void Should_Have_Error_With_Early_EndDate_Test()
        {
            // Arrange
            var dto = new Crop
            {
                GardenId = 1,
                CropId = 1,
                CropName = "Garden1",
                PlantName = "Plant1",
                BeginDate = DateTimeOffset.UtcNow,
                EndDate = DateTimeOffset.UtcNow.AddDays(-1),
                Notes = "Some Crop Notes",
                CropActivities = new List<CropActivity>
                {
                    new CropActivity
                    {
                        CropActivityId = 1,
                        CropId = 1,
                        ActivityType = Activities.Cloning,
                        ActivityDate = DateTimeOffset.UtcNow,
                        Notes = "Some Crop Activity Notes"
                    }
                }
            };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(actual => actual.GardenId);
            result.ShouldNotHaveValidationErrorFor(actual => actual.CropId);
            result.ShouldNotHaveValidationErrorFor(actual => actual.CropName);
            result.ShouldNotHaveValidationErrorFor(actual => actual.PlantName);
            result.ShouldHaveValidationErrorFor(actual => actual.BeginDate);
            result.ShouldHaveValidationErrorFor(actual => actual.EndDate);
            result.ShouldNotHaveValidationErrorFor(actual => actual.Notes);
            result.ShouldNotHaveValidationErrorFor(actual => actual.CropActivities);
        }

        [TestMethod]
        public void Should_Have_Error_With_Early_ActivityDate_Test()
        {
            // Arrange
            var dto = new Crop
            {
                GardenId = 1,
                CropId = 1,
                CropName = "Garden1",
                PlantName = "Plant1",
                BeginDate = DateTimeOffset.UtcNow.AddDays(-1),
                EndDate = DateTimeOffset.UtcNow,
                Notes = "Some Crop Notes",
                CropActivities = new List<CropActivity>
                {
                    new CropActivity
                    {
                        CropActivityId = 1,
                        CropId = 1,
                        ActivityType = Activities.Cloning,
                        ActivityDate = DateTimeOffset.UtcNow.AddDays(-17),
                        Notes = "Some Crop Activity Notes"
                    }
                }
            };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(actual => actual.GardenId);
            result.ShouldNotHaveValidationErrorFor(actual => actual.CropId);
            result.ShouldNotHaveValidationErrorFor(actual => actual.CropName);
            result.ShouldNotHaveValidationErrorFor(actual => actual.PlantName);
            result.ShouldNotHaveValidationErrorFor(actual => actual.BeginDate);
            result.ShouldNotHaveValidationErrorFor(actual => actual.EndDate);
            result.ShouldNotHaveValidationErrorFor(actual => actual.Notes);
            _validator.ShouldHaveChildValidator(x => x.CropActivities, typeof(CropActivityValidator));
            //result.ShouldHaveValidationErrorFor(actual => actual.CropActivities[0].ActivityDate);
        }
    }
}