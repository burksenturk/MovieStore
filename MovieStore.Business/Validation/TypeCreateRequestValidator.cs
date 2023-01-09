using FluentValidation;
using MovieStore.Core.Model.Request.Actor;
using MovieStore.Core.Model.Request.Movie;
using MovieStore.Core.Model.Request.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Validation
{
    public class TypeCreateRequestValidator : AbstractValidator<TypeCreateRequest>
    {
        public TypeCreateRequestValidator()
        {
            RuleFor(update => update.Name).NotEmpty().MinimumLength(2);

        }



    }
}
