using AutoMapper;
using MovieStore.Business.Abstract;
using MovieStore.Core.Entity;
using MovieStore.Core.Model;
using MovieStore.Core.Model.Request.Director;
using MovieStore.Core.Model.Request.Director;

using MovieStore.DataAccess.Abstract;
using MovieStore.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Concrete
{
    public class DirectorService : IDirectorService
    {
        private readonly IDirectorRepository _directorRepository;
        private readonly IMapper _mapper;
        public DirectorService(IDirectorRepository directorRepository, IMapper mapper)
        {
            _directorRepository = directorRepository;
            _mapper = mapper;
        }
        public async Task<BaseResponse<Director>> Create(DirectorCreateRequest directorCreateRequest)
        {
            Director director = _mapper.Map<Director>(directorCreateRequest);
            var resultDirector = await _directorRepository.Create(director);

            return resultDirector;
        }

        public async Task<BaseResponse<Director>> Delete(int Id)
        {
            var result = await _directorRepository.Get(x => x.Id == Id);
            return await _directorRepository.Delete(result.Data);
        }

        public async Task<BaseResponse<Director>> Get(Expression<Func<Director, bool>> filter)
        {
            return await _directorRepository.Get(filter);

        }

        public async Task<BaseResponse<List<Director>>> GetAllByFilter(Expression<Func<Director, bool>> filter)
        {
            return await _directorRepository.GetList(filter);
        }

        public async Task<BaseResponse<List<Director>>> Getlist()
        {
            return await _directorRepository.GetAll();
        }

        public  Task<BaseResponse<Director>> Update(DirectorUpdateRequest directorUpdateRequest)  //?????????
        {

            Director director = _mapper.Map<Director>(directorUpdateRequest);
            return _directorRepository.Update(director);

        }
    }
}
