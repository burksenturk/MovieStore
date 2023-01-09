using FluentValidation;
using MovieStore.Core.Model.Request.Actor;
using MovieStore.Core.Model.Request.Movie;

namespace MovieStore.Business.Validation
{
    public class MovieUpdateRequestValidator : AbstractValidator<MovieUpdateRequest>
    {
        public MovieUpdateRequestValidator()
        {
            RuleFor(update => update.Id).NotEmpty().GreaterThan(0);
            RuleFor(update => update.Price).NotEmpty().GreaterThan(0);
            RuleFor(update => update.Name).NotEmpty().MinimumLength(3);
        }

    }
}
