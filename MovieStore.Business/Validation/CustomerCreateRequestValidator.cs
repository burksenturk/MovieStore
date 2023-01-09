using FluentValidation;
using MovieStore.Core.Model.Request.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Validation
{
    public class CustomerCreateRequestValidator : AbstractValidator<CustomerCreateRequest>
    {
        public CustomerCreateRequestValidator()
        {
            RuleFor(create => create.Name).NotEmpty().MinimumLength(2);
            RuleFor(create => create.Surname).NotEmpty().MinimumLength(2);


        }

    }
}
