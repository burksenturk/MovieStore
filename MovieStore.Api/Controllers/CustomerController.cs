using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Business.Abstract;
using MovieStore.Core.Model.Request.Customer;
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
            if (!ModelState.IsValid)
            {
                return BadRequest("Model Error");
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
