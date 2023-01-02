using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Business.Abstract;
using MovieStore.Core.Model.Request.Movie;
using System.Threading.Tasks;

namespace MovieStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(MovieCreateRequest movieCreateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model Error");
            }

            return Ok(await _movieService.Create(movieCreateRequest));
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(MovieUpdateRequest movieUpdateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model Error");
            }

            return Ok(await _movieService.Update(movieUpdateRequest));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int Id)
        {
            return Ok(await _movieService.Delete(Id));
        }

        [HttpGet("getbyıd")]
        public async Task<IActionResult> Get(int Id)
        {
            return Ok(await _movieService.Get(x => x.Id == Id && x.IsActive,x=>x.Type));
        }

        [HttpGet("getbyname")]
        public async Task<IActionResult> Get(string name)
        {
            return Ok(await _movieService.Get(x => x.Name == name && x.IsActive, x => x.Type));  
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _movieService.GetAllByFilter(x=>x.IsActive, x => x.Type));
        }

    }
}

