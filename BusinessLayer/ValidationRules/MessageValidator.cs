using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message> 
    { 
        public MessageValidator() 
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("You must enter receiver adress !");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("You must enter receiver adress !");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("You must enter minimum 3 characters !");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("You must enter less than 100 characters !");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("You must enter message content !");
        }
    }
    
}
