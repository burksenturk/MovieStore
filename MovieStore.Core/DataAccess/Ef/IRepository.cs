using MovieStore.Core.Entity;
using MovieStore.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Core.DataAccess.Ef
{
    public interface IRepository<T> where T : class, IBaseEntity, new()
    {
        Task<BaseResponse<T>> Get(Expression<Func<T, bool>> filter,params Expression<Func<T, object>>[]inculudes);
        Task<BaseResponse<List<T>>> GetList(Expression<Func<T, bool>> filter,params Expression<Func<T, object>>[]inculudes);
        Task<BaseResponse<List<T>>> GetAll(params Expression<Func<T, object>>[] inculudes);


        Task<BaseResponse<T>> Update(T entity);
        Task<BaseResponse<T>> Delete(T entity);
        Task<BaseResponse<T>> Create(T entity);
    }
}
