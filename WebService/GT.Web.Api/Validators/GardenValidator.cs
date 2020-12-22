using FluentValidation;
using GT.Web.Api.Models;

namespace GT.Web.Api.Validators
{
    public class GardenValidator : AbstractValidator<Garden>
    {
        public GardenValidator()
        {
            RuleFor(x => x.GardenName)
                .NotEmpty()
                .MaximumLength(60);
        }
    }
}