using System;
using FluentValidation;
using GT.Web.Api.Models;

namespace GT.Web.Api.Validators
{
    public class CropActivityValidator : AbstractValidator<CropActivity>
    {
        //public CropActivityValidator(Crop parent)
        public CropActivityValidator()
        {
            RuleFor(model => model.CropId)
                .NotEmpty();

            RuleFor(model => model.ActivityType)
                .NotNull()
                .IsInEnum();

            //RuleFor(model => model.ActivityDate)
            //    .Must(activityDate => beginDate <= activityDate)
            //    .Must(activityDate => endDate >= activityDate);

            RuleFor(model => model.Notes)
                .MaximumLength(255);
        }
    }
}