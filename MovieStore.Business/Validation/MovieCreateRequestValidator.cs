using FluentValidation;
using MovieStore.Core.Model.Request.Actor;
using MovieStore.Core.Model.Request.Movie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Validation
{
    public class MovieCreateRequestValidator : AbstractValidator<MovieCreateRequest>
    {
        public MovieCreateRequestValidator()
        {
            RuleFor(create => create.Name).NotEmpty().MinimumLength(3);
            RuleFor(create => create.Price).NotEmpty().GreaterThan(0);

        }



    }
}
