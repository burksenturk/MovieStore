using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Business.Abstract;
using MovieStore.Business.Concrete;
using MovieStore.Core.Model.Request.Director;
using System.Threading.Tasks;

namespace MovieStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorController : ControllerBase
    {
        private readonly IDirectorService _directorService;

        public DirectorController(IDirectorService directorService)
        {
            _directorService = directorService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(DirectorCreateRequest directorCreateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model Error");
            }

            return Ok(await _directorService.Create(directorCreateRequest));
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(DirectorUpdateRequest directorUpdateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model Error");
            }

            return Ok(await _directorService.Update(directorUpdateRequest));
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            return Ok(await _directorService.Delete(Id));
        }

        [HttpGet("getbyıd")]
        public async Task<IActionResult> Get(int Id)
        {
            return Ok(await _directorService.Get(x => x.Id == Id));
        }

        [HttpGet("getbyname")]
        public async Task<IActionResult> Get(string name)
        {
            return Ok(await _directorService.GetAllByFilter(x => x.Name == name));   //getallbyfilter kullansak?  önceki hali Get ti.
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _directorService.Getlist());
        }
    }
}
