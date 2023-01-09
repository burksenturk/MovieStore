using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Business.Abstract;
using MovieStore.Business.Concrete;
using MovieStore.Business.Validation;
using MovieStore.Core.Model.Request.Movie;
using MovieStore.Core.Model;
using MovieStore.Core.Model.Request.Order;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace MovieStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(OrderCreateRequest orderCreateRequest)
        {
            OrderCreateRequestValidator validator = new OrderCreateRequestValidator();
            var validateResult = validator.Validate(orderCreateRequest);
            if (!validateResult.IsValid)
            {
                BaseResponse<List<string>> result = new BaseResponse<List<string>>();
                result.Status = false;
                result.ErrorMessage = "Hata";
                result.Data = validateResult.Errors.Select(x => x.ErrorMessage).ToList();
                return BadRequest(result);
            }

            return Ok(await _orderService.Create(orderCreateRequest));
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(OrderUpdateRequest orderUpdateRequest)
        {
            OrderUpdateRequestValidator validator = new OrderUpdateRequestValidator();
            var validateResult = validator.Validate(orderUpdateRequest);
            if (!validateResult.IsValid)
            {
                BaseResponse<List<string>> result = new BaseResponse<List<string>>();
                result.Status = false;
                result.ErrorMessage = "Hata";
                result.Data = validateResult.Errors.Select(x => x.ErrorMessage).ToList();
                return BadRequest(result);
            }

            return Ok(await _orderService.Update(orderUpdateRequest));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            return Ok(await _orderService.Delete(Id));
        }

        [HttpGet("getbyıd")]
        public async Task<IActionResult> Get(int Id)
        {
            return Ok(await _orderService.Get(x => x.Id == Id));
        }

        [HttpGet("datetime")]
        public async Task<IActionResult> Get(DateTime dateTime)   //???
        {
            return Ok(await _orderService.Get(x => x.CreatedDate == dateTime));
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _orderService.Getlist());
        }
    }
}
