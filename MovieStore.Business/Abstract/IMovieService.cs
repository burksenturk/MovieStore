using MovieStore.Core.Entity;
using MovieStore.Core.Model.Request.Actor;
using MovieStore.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MovieStore.Core.Model.Request.Movie;

namespace MovieStore.Business.Abstract
{
    public interface IMovieService
    {
        Task<BaseResponse<Movie>> Create(MovieCreateRequest movieCreateRequest);
        Task<BaseResponse<Movie>> Update(MovieUpdateRequest movieUpdateRequest);
        Task<BaseResponse<Movie>> Delete(int Id);
        Task<BaseResponse<Movie>> Get(Expression<Func<Movie, bool>> filter, params Expression<Func<Movie, object>>[] inculudes);
        Task<BaseResponse<List<Movie>>> GetAllByFilter(Expression<Func<Movie, bool>> filter, params Expression<Func<Movie, object>>[] inculudes);
        //Task<BaseResponse<Movie>> GetList(Expression<Func<Movie, bool>> filter);
        Task<BaseResponse<List<Movie>>> Getlist(params Expression<Func<Movie, object>>[] inculudes);
    }
}
