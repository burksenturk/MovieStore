using MovieStore.Core.Entity;
using MovieStore.Core.Model.Request.Customer;
using MovieStore.Core.Model;
using MovieStore.DataAccess.Abstract;
using MovieStore.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MovieStore.Business.Abstract;

namespace MovieStore.Business.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<BaseResponse<Customer>> Create(CustomerCreateRequest customerCreateRequest)
        {
            Customer customer = new Customer();
            customer.Name = customerCreateRequest.Name;
            customer.Surname = customerCreateRequest.Surname;
            return _customerRepository.Create(customer);
        }

        public async Task<BaseResponse<Customer>> Delete(int Id)
        {
            var result = await _customerRepository.Get(x => x.Id == Id);
            return await _customerRepository.Delete(result.Data);
        }

    }
}
