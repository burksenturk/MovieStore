using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Business.Abstract;
using MovieStore.Business.Validation;
using MovieStore.Core.Model;
using MovieStore.Core.Model.Request.Customer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(CustomerCreateRequest customerCreateRequest)
        {
            CustomerCreateRequestValidator validator = new CustomerCreateRequestValidator();
            var validateResult = validator.Validate(customerCreateRequest);
            if (!validateResult.IsValid)
            {
                BaseResponse<List<string>> result = new BaseResponse<List<string>>();
                result.Status = false;
                result.ErrorMessage = "Hata";
                result.Data = validateResult.Errors.Select(x => x.ErrorMessage).ToList();
                return BadRequest(result);
            }

            return Ok(await _customerService.Create(customerCreateRequest));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            return Ok(await _customerService.Delete(Id));
        }

    }
}
