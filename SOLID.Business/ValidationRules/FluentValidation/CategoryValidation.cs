using FluentValidation;
using SOLID.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Business.ValidationRules.FluentValidation
{
    public class CategoryValidation:AbstractValidator<Category>
    {
        public CategoryValidation()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("category name name can not be empty.");
        }
    }
}
