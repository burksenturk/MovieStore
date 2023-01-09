using FluentValidation;
using MovieStore.Core.Model.Request.Type;

namespace MovieStore.Business.Validation
{
    public class TypeUpdateRequestValidator : AbstractValidator<TypeUpdateRequest>
    {
        public TypeUpdateRequestValidator()
        {
            RuleFor(update => update.Id).NotEmpty().GreaterThan(0);
            RuleFor(update => update.Name).NotEmpty().MinimumLength(2);
        }

    }
}
