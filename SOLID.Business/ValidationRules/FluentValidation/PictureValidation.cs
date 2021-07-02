using FluentValidation;
using SOLID.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Business.ValidationRules.FluentValidation
{
    public class PictureValidation : AbstractValidator<Picture>
    {
        public PictureValidation()
        {
            RuleFor(p => p.ImageUrl).NotEmpty().WithMessage("image can not be empty.");
        }
    }
}
