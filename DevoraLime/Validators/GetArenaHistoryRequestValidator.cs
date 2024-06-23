using FluentValidation;
using HeroBattle.API.Requests;

namespace HeroBattle.API.Validators
{
    public class GetArenaHistoryRequestValidator : AbstractValidator<GetArenaHistoryRequest>
    {
        public GetArenaHistoryRequestValidator()
        {
            RuleFor(x => x.ArenaId)
              .NotNull().WithMessage("ArenaId must not be null.")
              .NotEmpty().WithMessage("ArenaId must not be empty.");
        }
    }
}
