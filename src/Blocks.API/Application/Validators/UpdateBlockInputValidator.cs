using Blocks.API.Application.Inputs;
using FluentValidation;

namespace Blocks.API.Application.Validators
{
    public class UpdateBlockInputValidator : AbstractValidator<UpdateBlockInput>
    {
        public UpdateBlockInputValidator()
        {
            RuleFor(x => x.Id).NotNull();

            //Others validations
        }
    }
}