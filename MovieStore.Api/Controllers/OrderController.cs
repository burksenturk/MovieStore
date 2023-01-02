using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Business.Abstract;
using MovieStore.Core.Model.Request.Order;
using System;
using System.Threading.Tasks;

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
            if (!ModelState.IsValid)
            {
                return BadRequest("Model Error");
            }

            return Ok(await _orderService.Create(orderCreateRequest));
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(OrderUpdateRequest orderUpdateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model Error");
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
