using FluentValidation;

using MovieStore.Core.Model.Request.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Validation
{
    public class OrderCreateRequestValidator : AbstractValidator<OrderCreateRequest>
    {
        public OrderCreateRequestValidator()
        {
            RuleFor(create => create.MovieId).NotEmpty().GreaterThan(0);
            RuleFor(create => create.CustomerId).NotEmpty().GreaterThan(0);
            RuleFor(create => create.CreatedDate).NotEmpty();

        }



    }
}
