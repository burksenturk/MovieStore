using FluentValidation;
using MovieStore.Core.Model.Request.Actor;
using MovieStore.Core.Model.Request.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Validation
{
    public class CustomerUpdateRequestValidator : AbstractValidator<CustomerUpdateRequest>
    {
        public CustomerUpdateRequestValidator()
        {
            RuleFor(update => update.Name).NotEmpty().MinimumLength(2);
            RuleFor(update => update.Surname).NotEmpty().MinimumLength(2);
        }

    }
}
