using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Business.Abstract;
using MovieStore.Core.Model.Request.Actor;
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
            if (!ModelState.IsValid)
            {
                return BadRequest("Model Error");
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
            return Ok(await _actorService.GetAllByFilter(x => x.Name == name));   //getallbyfilter kullansak?  önceki hali Get ti.
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _actorService.Getlist());
        }

    }
}
