using System.Data;
using FluentValidation;

namespace Blocks.API.Application.Validators
{
    public class StringEmptyOrWhiteSpaceValidator : AbstractValidator<string>
    {
        public StringEmptyOrWhiteSpaceValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .Must(u => !u.Any(x => char.IsWhiteSpace(x)));
        }
    }
}