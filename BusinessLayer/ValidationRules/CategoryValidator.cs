using EntityLayer.Concrete;
using FluentValidation;


namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("You must enter category name !");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("You must enter category description !");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Please enter minimum 3 characters.");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Please don't enter more than 20 characters.");
        }
    }
}
