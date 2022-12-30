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
        public DirectorService(IDirectorRepository directorRepository)
        {
            _directorRepository = directorRepository;
        }
        public Task<BaseResponse<Director>> Create(DirectorCreateRequest directorCreateRequest)
        {
            Director director = new Director();
            director.Name = directorCreateRequest.Name;
            director.Surname = directorCreateRequest.Surname;
            return _directorRepository.Create(director);
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
            

            Director director = new Director();            
            director.Name = directorUpdateRequest.Name;
            director.Surname = directorUpdateRequest.Surname;
            return  _directorRepository.Update(director);

        }
    }
}
