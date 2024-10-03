using FluentValidation;
using Mini_projeto_Book_Samsys.Models.DTOs;

namespace Mini_projeto_Book_Samsys.Models.Validators
{
    public class BookValidator : AbstractValidator<BookDTO>
    {
        public BookValidator()
        {
            RuleFor(x => x.ISBN).NotEmpty().Length(13).WithMessage("ISBN must have 13 numbers");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please specify a name for the book");
            //RuleFor(x => x.IdAuthor).NotNull().WithMessage("Please specify a id for the author");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Please insert in the valid format (eg: 12.50)");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price can't be negative");
        }
    }
}
