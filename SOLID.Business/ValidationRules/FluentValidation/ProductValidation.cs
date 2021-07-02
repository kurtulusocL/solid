using FluentValidation;
using SOLID.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Business.ValidationRules.FluentValidation
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("name can not be empty.");
            RuleFor(p => p.Title).NotEmpty().WithMessage("title name can not be empty.");
            RuleFor(p => p.Subtitle).NotEmpty().WithMessage("subtitle name can not be empty.");
            RuleFor(p => p.Price).NotNull().WithMessage("price can not be null.");
            RuleFor(p => p.CategoryId).NotNull().WithMessage("category name can not be null.");
        }
    }
}
