using Microsoft.AspNetCore.Mvc;
using MovieStore.Business.Abstract;
using MovieStore.Business.Validation;
using MovieStore.Core.Model;
using MovieStore.Core.Model.Request.Type;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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
            TypeCreateRequestValidator validator = new TypeCreateRequestValidator();
            var validateResult = validator.Validate(typeCreateRequest);
            if (!validateResult.IsValid)
            {
                BaseResponse<List<string>> result = new BaseResponse<List<string>>();
                result.Status = false;
                result.ErrorMessage = "Hata";
                result.Data = validateResult.Errors.Select(x => x.ErrorMessage).ToList();
                return BadRequest(result);
            }

            return Ok(await _typeService.Create(typeCreateRequest));
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update(TypeUpdateRequest typeUpdateRequest)
        {
            TypeUpdateRequestValidator validator = new TypeUpdateRequestValidator();
            var validateResult = validator.Validate(typeUpdateRequest);
            if (!validateResult.IsValid)
            {
                BaseResponse<List<string>> result = new BaseResponse<List<string>>();
                result.Status = false;
                result.ErrorMessage = "Hata";
                result.Data = validateResult.Errors.Select(x => x.ErrorMessage).ToList();
                return BadRequest(result);
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
