using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Business.Abstract;
using MovieStore.Business.Concrete;
using MovieStore.Core.Model.Request.Type;
using System.Threading.Tasks;

namespace MovieStore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly ITypeService _typeService;

        public TypeController(ITypeService typeService)
        {
            _typeService = typeService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(TypeCreateRequest typeCreateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model Error");
            }

            return Ok(await _typeService.Create(typeCreateRequest));
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(TypeUpdateRequest typeUpdateRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model Error");
            }

            return Ok(await _typeService.Update(typeUpdateRequest));
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            return Ok(await _typeService.Delete(Id));
        }

        [HttpGet("getbyıd")]
        public async Task<IActionResult> Get(int Id)
        {
            return Ok(await _typeService.Get(x => x.Id == Id));
        }

        [HttpGet("getbyname")]
        public async Task<IActionResult> Get(string name)
        {
            return Ok(await _typeService.GetAllByFilter(x => x.Name == name));   //getallbyfilter kullansak?  önceki hali Get ti.
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _typeService.Getlist());
        }
    }
}
