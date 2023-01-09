using FluentValidation;
using MovieStore.Core.Model.Request.Director;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Validation
{
    public class DirectorUpdateRequestValidator : AbstractValidator<DirectorUpdateRequest>
    {
        public DirectorUpdateRequestValidator()
        {
            RuleFor(update => update.Name).NotEmpty().MinimumLength(3);
            RuleFor(update => update.Surname).NotEmpty().MinimumLength(3);


        }
    }
}
