using FluentValidation;
using HeroBattle.API.Requests;

namespace HeroBattle.API.Validators
{
    public class CreateArenaRequestValidator : AbstractValidator<CreateArenaRequest>
    {
        public CreateArenaRequestValidator()
        {
            RuleFor(x => x.NumberOfHeroes)
                .NotNull().WithMessage("NumberOfHeroes must not be null.")
                .NotEmpty().WithMessage("NumberOfHeroes must not be empty.")
                .GreaterThan(2).WithMessage("NumberOfHeroes must be greater than 2.");
        }
    }
}
