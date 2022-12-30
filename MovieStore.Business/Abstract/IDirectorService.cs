using MovieStore.Core.Entity;
using MovieStore.Core.Model.Request.Actor;
using MovieStore.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MovieStore.Core.Model.Request.Director;

namespace MovieStore.Business.Abstract
{
    public interface IDirectorService
    {
        Task<BaseResponse<Director>> Create(DirectorCreateRequest directorCreateRequest);
        Task<BaseResponse<Director>> Update(DirectorUpdateRequest directorUpdateRequest);
        Task<BaseResponse<Director>> Delete(int Id);
        Task<BaseResponse<Director>> Get(Expression<Func<Director, bool>> filter);
        Task<BaseResponse<List<Director>>> GetAllByFilter(Expression<Func<Director, bool>> filter);
        //Task<BaseResponse<Director>> GetList(Expression<Func<Director, bool>> filter);
        Task<BaseResponse<List<Director>>> Getlist();
    }
}
