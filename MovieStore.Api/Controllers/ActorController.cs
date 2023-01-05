using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Business.Abstract;
using MovieStore.Business.Validation;
using MovieStore.Core.Model;
using MovieStore.Core.Model.Request.Actor;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;

namespace MovieStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        private readonly IActorService _actorService;

        public ActorController(IActorService actorService)
        {
            _actorService = actorService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(ActorCreateRequest actorCreateRequest )
        {
            ActorCreateRequestValidator validator = new ActorCreateRequestValidator();
            var validateResult = validator.Validate(actorCreateRequest);
            if (!validateResult.IsValid)
            {
                BaseResponse<List<string>> result=new BaseResponse<List<string>>();
                result.Status = false;
                result.ErrorMessage = "Hata";
                result.Data=validateResult.Errors.Select(x=>x.ErrorMessage).ToList();
                return BadRequest(result);
            }

            return  Ok(await _actorService.Create(actorCreateRequest));
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(ActorUpdateRequest actorUpdateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model Error");
            }

            return Ok(await _actorService.Update(actorUpdateRequest));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            return Ok(await _actorService.Delete(Id));
        }

        [HttpGet("getbyıd")]
        public async Task<IActionResult> Get(int Id)
        {
            return Ok(await _actorService.Get(x=>x.Id == Id));
        }

        [HttpGet("getbyname")]
        public async Task<IActionResult> Get(string name)   
        {
            return Ok(await _actorService.Get(x => x.Name == name));   
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _actorService.Getlist());
        }

    }
}
