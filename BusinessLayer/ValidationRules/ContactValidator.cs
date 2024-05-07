using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator() 
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("You must enter your mail adress !");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("You must enter a subject !");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("You must enter an username !");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("You must enter minimum three characters !");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("You must enter minimum three characters !");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("You must enter less than fifty characters !");
        }
    }
}
