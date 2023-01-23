using FluentValidation;
using MovieStore.Core.Model.Request.Actor;


namespace MovieStore.Business.Validation
{
    public class ActorUpdateRequestValidator : AbstractValidator<ActorUpdateRequest>
    {
        public ActorUpdateRequestValidator()
        {
            RuleFor(update => update.Id).NotEmpty().GreaterThan(0);
            RuleFor(update => update.Name).NotEmpty().MinimumLength(3);
            RuleFor(update => update.Surname).NotEmpty().MinimumLength(3);
        }

    }
}
