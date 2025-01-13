using FluentValidation;

namespace books.Validators
{
    public class AddBookModelValidator : AbstractValidator<books.Model.AddBookModel>
    {
        public AddBookModelValidator()
        {
            RuleFor(book => book.name)
                .NotEmpty().WithMessage("The name field is required.")
                .MaximumLength(20).WithMessage("The name must not exceed 20 characters.");

            RuleFor(book => book.author)
                .NotEmpty().WithMessage("The author field is required.");

            RuleFor(book => book.description)
                .MaximumLength(200).WithMessage("The description must not exceed 200 characters.");

            RuleFor(book => book.categoryId)
                .NotEmpty().WithMessage("The category ID is required.")
                .NotEqual(Guid.Empty).WithMessage("The category ID cannot be empty.");
        }
    }
}