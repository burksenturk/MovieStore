using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieStore.Business.Abstract;
using MovieStore.Business.Concrete;
using MovieStore.Business.Validation;
using MovieStore.Core.Model;
using MovieStore.Core.Model.Request.Director;
using System.Collections.Generic;
using System.Linq;
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
            DirectorCreateRequestValidator validator = new DirectorCreateRequestValidator();
            var validateResult = validator.Validate(directorCreateRequest);
            if (!validateResult.IsValid)
            {
                BaseResponse<List<string>> result = new BaseResponse<List<string>>();
                result.Status = false;
                result.ErrorMessage = "Hata";
                result.Data = validateResult.Errors.Select(x => x.ErrorMessage).ToList();
                return BadRequest(result);
            }

            return Ok(await _directorService.Create(directorCreateRequest));
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(DirectorUpdateRequest directorUpdateRequest)
        {
            DirectorUpdateRequestValidator validator = new DirectorUpdateRequestValidator();
            var validateResult = validator.Validate(directorUpdateRequest);
            if (!validateResult.IsValid)
            {
                BaseResponse<List<string>> result = new BaseResponse<List<string>>();
                result.Status = false;
                result.ErrorMessage = "Hata";
                result.Data = validateResult.Errors.Select(x => x.ErrorMessage).ToList();
                return BadRequest(result);
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
            return Ok(await _directorService.Get(x => x.Name == name));   //getallbyfilter kullansak?  önceki hali Get ti.
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _directorService.Getlist());
        }
    }
}
