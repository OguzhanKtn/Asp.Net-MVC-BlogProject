using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AdminValidator : AbstractValidator<Admin>
    {
        public AdminValidator() 
        {
            RuleFor(x => x.AdminUserName).NotEmpty().WithMessage("You must enter user name !");
            RuleFor(x => x.AdminPassword).NotEmpty().WithMessage("You must enter passowd !");
            RuleFor(x => x.AdminPassword).MinimumLength(5).WithMessage("Please enter minimum 5 characters.");
            RuleFor(x => x.AdminUserName).MinimumLength(3).WithMessage("Please enter minimum 3 characters.");
            RuleFor(x => x.AdminUserName).MaximumLength(20).WithMessage("Please don't enter more than 20 characters.");
        }
    }
}
