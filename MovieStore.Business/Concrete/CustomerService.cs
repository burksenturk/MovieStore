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
using MovieStore.Core.Model.Request.Customer;
using AutoMapper;

namespace MovieStore.Business.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Customer>> Create(CustomerCreateRequest customerCreateRequest)
        {
            Customer customer = _mapper.Map<Customer>(customerCreateRequest);
            customer.IsActive = true;
            var resultCustomer = await _customerRepository.Create(customer);

            return resultCustomer;
        }

        public async Task<BaseResponse<Customer>> Delete(int Id)
        {
            var result = await _customerRepository.Get(x => x.Id == Id);
            return await _customerRepository.Delete(result.Data);
        }

    }
}
