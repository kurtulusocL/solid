using FluentValidation;
using SOLID.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Business.ValidationRules.FluentValidation
{
    public class ProductDetailValidation : AbstractValidator<ProductDetail>
    {
        public ProductDetailValidation()
        {
            RuleFor(p => p.Detail).NotEmpty().WithMessage("product detail name can not be empty.");
        }
    }
}
