using FluentValidation;
using MovieStore.Core.Model.Request.Actor;
using MovieStore.Core.Model.Request.Movie;
using MovieStore.Core.Model.Request.Order;

namespace MovieStore.Business.Validation
{
    public class OrderUpdateRequestValidator : AbstractValidator<OrderUpdateRequest>
    {
        public OrderUpdateRequestValidator()
        {
            RuleFor(update => update.Id).NotEmpty().GreaterThan(0);
            RuleFor(update => update.MovieId).NotEmpty().GreaterThan(0);
            RuleFor(update => update.CustomerId).NotEmpty().GreaterThan(0);
            RuleFor(update => update.CreatedDate).NotEmpty();
        }

    }
}
