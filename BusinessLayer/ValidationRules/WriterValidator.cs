using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("You must enter writer's name !");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("You must enter writer's surname !");
            RuleFor(x => x.WriterAbout).MinimumLength(3).WithMessage("Please enter minimum 3 characters.");
            RuleFor(x => x.WriterSurname).MaximumLength(20).WithMessage("Please don't enter more than 20 characters.");
            RuleFor(x => x.WriterMail).EmailAddress().WithMessage("Please enter a correct email adress!");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Please enter your email adress!");
            RuleFor(x => x.WriterPassword).MinimumLength(8).WithMessage("Your password must consist of at least 8 characters!");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("You must enter a password !");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Writer's title cannot be blank ! ");
        }
    }
}
