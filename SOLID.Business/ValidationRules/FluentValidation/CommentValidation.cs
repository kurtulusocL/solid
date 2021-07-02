using FluentValidation;
using SOLID.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Business.ValidationRules.FluentValidation
{
    public class CommentValidation : AbstractValidator<Comment>
    {
        public CommentValidation()
        {
            RuleFor(p => p.NameSurname).NotEmpty().WithMessage("name surname name can not be empty.");
            RuleFor(p => p.EMail).NotEmpty().WithMessage("e-mail address name can not be empty.");
            RuleFor(p => p.Subject).NotEmpty().WithMessage("subject name can not be empty.");
            RuleFor(p => p.Text).NotEmpty().WithMessage("comment text name can not be empty.");
        }
    }
}
