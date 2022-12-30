using MovieStore.Core.Entity;
using MovieStore.Core.Model.Request.Customer;
using MovieStore.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Abstract
{
    public interface ICustomerService
    {
        Task<BaseResponse<Customer>> Create(CustomerCreateRequest customerCreateRequest);
        Task<BaseResponse<Customer>> Delete(int Id);
    }
}
