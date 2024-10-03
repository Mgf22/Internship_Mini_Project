using FluentValidation;
using Mini_projeto_Book_Samsys.Models.DTOs;

namespace Mini_projeto_Book_Samsys.Models.Validators
{
    public class AuthorValidator : AbstractValidator<AuthorDTO>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please specify a name for the author");
        }

    }
}
