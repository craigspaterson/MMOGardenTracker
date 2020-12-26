using FluentValidation.TestHelper;
using GT.Web.Api.Models;
using GT.Web.Api.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GT.UnitTests.WebApi.Validators
{
    [TestClass]
    public class GardenValidatorTests
    {
        private GardenValidator _validator;

        [TestInitialize]
        public void InitializeTest()
        {
            _validator = new GardenValidator();
        }

        [TestMethod]
        public void Should_Not_Have_Error_With_Valid_Properties_Test()
        {
            // Arrange
            var dto = new Garden
            {
                GardenId = 1,
                GardenName = "Garden1"
            };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldNotHaveValidationErrorFor(actual => actual.GardenName);
        }

        [TestMethod]
        public void Should_Have_Error_With_Null_Name_Test()
        {
            // Arrange
            var dto = new Garden
            {
                GardenId = 1,
                GardenName = null
            };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(actual => actual.GardenName);
        }

        [TestMethod]
        public void Should_Have_Error_With_OverMax_Name_Test()
        {
            // Arrange
            var dto = new Garden
            {
                GardenId = 1,
                // ReSharper disable once StringLiteralTypo
                GardenName = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx"
            };

            // Act
            var result = _validator.TestValidate(dto);

            // Assert
            result.ShouldHaveValidationErrorFor(actual => actual.GardenName);
        }

    }
}