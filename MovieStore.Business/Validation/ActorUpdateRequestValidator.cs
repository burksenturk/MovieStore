using FluentValidation;
using MovieStore.Core.Model.Request.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Validation
{
    public class ActorUpdateRequestValidator : AbstractValidator<ActorUpdateRequest>
    {
        public ActorUpdateRequestValidator()
        {
            RuleFor(create => create.Id).NotEmpty().GreaterThan(0);
            RuleFor(create => create.Name).NotEmpty().MinimumLength(3);
            RuleFor(create => create.Surname).NotEmpty().MinimumLength(3);
        }

    }
}
