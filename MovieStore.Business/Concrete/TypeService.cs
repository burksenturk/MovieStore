using MovieStore.Business.Abstract;
using MovieStore.Core.Entity;
using MovieStore.Core.Model;
using MovieStore.Core.Model.Request.Director;
using MovieStore.Core.Model.Request.Type;
using MovieStore.DataAccess.Abstract;
using MovieStore.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Concrete
{
    public class TypeService : ITypeService
    {
        private readonly ITypeRepository _typeRepository;

        public TypeService(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        public Task<BaseResponse<Core.Entity.Type>> Create(TypeCreateRequest typeCreateRequest)
        {
            Core.Entity.Type type = new Core.Entity.Type();
            type.Name = typeCreateRequest.Name;
            return _typeRepository.Create(type);

        }

        public async Task<BaseResponse<Core.Entity.Type>> Delete(int Id)
        {
            var result = await _typeRepository.Get(x => x.Id == Id);
            return await _typeRepository.Delete(result.Data);
        }

        public async Task<BaseResponse<Core.Entity.Type>> Get(Expression<Func<Core.Entity.Type, bool>> filter)
        {
            return await _typeRepository.Get(filter);
        }

        public async Task<BaseResponse<List<Core.Entity.Type>>> GetAllByFilter(Expression<Func<Core.Entity.Type, bool>> filter)
        {
            return await _typeRepository.GetList(filter);
        }

        public async Task<BaseResponse<List<Core.Entity.Type>>> Getlist()
        {
            return await _typeRepository.GetAll();
        }

        public Task<BaseResponse<Core.Entity.Type>> Update(TypeUpdateRequest typeUpdateRequest)
        {
            Core.Entity.Type type = new Core.Entity.Type();
            type.Name = typeUpdateRequest.Name;
            return _typeRepository.Update(type);

        }
    }
}
