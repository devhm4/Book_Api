using books.Model;
using FluentValidation;

namespace books.Validators;

public class AddCategoryValidator : AbstractValidator<AddCategory>
{
    public AddCategoryValidator()
    {
        RuleFor(category => category.name)
            .NotEmpty().WithMessage("The name field is required.")
            .MaximumLength(20).WithMessage("The name must not exceed 20 characters.")
            .MinimumLength(3).WithMessage("The name must be at least 3 characters long.");
    }
    
}