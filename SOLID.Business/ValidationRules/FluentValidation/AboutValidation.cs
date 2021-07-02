using FluentValidation;
using SOLID.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Business.ValidationRules.FluentValidation
{
    public class AboutValidation: AbstractValidator<About>
    {
        public AboutValidation()
        {
            RuleFor(p => p.Title).NotEmpty().WithMessage("title name can not be empty.");
            RuleFor(p => p.Subtitle).NotEmpty().WithMessage("subtitle name can not be empty.");
            RuleFor(p => p.Description).NotEmpty().WithMessage("description name can not be empty.");
            RuleFor(p => p.Photo).NotEmpty().WithMessage("image name can not be empty.");
        }
    }
}
