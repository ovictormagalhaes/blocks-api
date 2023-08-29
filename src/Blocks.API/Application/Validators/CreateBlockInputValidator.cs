using System.Data;
using Blocks.API.Application.Inputs;
using FluentValidation;

namespace Blocks.API.Application.Validators
{
    public class CreateBlockInputValidator : AbstractValidator<CreateBlockInput>
    {
        public CreateBlockInputValidator()
        {
            RuleFor(x => x.Id).NotNull();

            //Others validations
        }
    }
}