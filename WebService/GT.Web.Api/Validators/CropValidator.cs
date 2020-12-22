using FluentValidation;
using GT.Web.Api.Models;

namespace GT.Web.Api.Validators
{
    public class CropValidator : AbstractValidator<Crop>
    {
        public CropValidator()
        {
            RuleFor(x => x.GardenId)
                .NotEmpty();

            RuleFor(x => x.CropName)
                .NotEmpty()
                .MaximumLength(60);

            RuleFor(x => x.PlantName)
                .NotEmpty()
                .MaximumLength(60);

            RuleFor(x => x.BeginDate)
                .NotNull()
                .LessThan(x => x.EndDate).When(x => x.EndDate != null);

            RuleFor(x => x.EndDate)
                .NotNull()
                .GreaterThan(x => x.BeginDate);

            RuleFor(x => x.Notes)
                .MaximumLength(250);
        }
    }
}
