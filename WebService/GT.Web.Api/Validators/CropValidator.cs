using System.Security.Cryptography.X509Certificates;
using FluentValidation;
using GT.Web.Api.Models;

namespace GT.Web.Api.Validators
{
    public class CropValidator : AbstractValidator<Crop>
    {
        public CropValidator()
        {
            RuleFor(model => model.GardenId)
                .NotEmpty();

            RuleFor(model => model.CropName)
                .NotEmpty()
                .MaximumLength(60);

            RuleFor(model => model.PlantName)
                .NotEmpty()
                .MaximumLength(60);

            RuleFor(model => model.BeginDate)
                .NotNull()
                .LessThan(x => x.EndDate).When(x => x.EndDate != null);

            RuleFor(model => model.EndDate)
                .NotNull()
                .GreaterThan(x => x.BeginDate);

            RuleFor(model => model.Notes)
                .MaximumLength(255);

            RuleForEach(model => model.CropActivities)
                .SetValidator(model => new CropActivityValidator());
        }
    }
}
