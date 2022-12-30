using MovieStore.Core.Entity;
using MovieStore.Core.Model.Request.Director;
using MovieStore.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MovieStore.Core.Model.Request.Type;

namespace MovieStore.Business.Abstract
{
    public interface ITypeService
    {
        Task<BaseResponse<Core.Entity.Type>> Create(TypeCreateRequest typeCreateRequest);
        Task<BaseResponse<Core.Entity.Type>> Update(TypeUpdateRequest typeUpdateRequest);
        Task<BaseResponse<Core.Entity.Type>> Delete(int Id);
        Task<BaseResponse<Core.Entity.Type>> Get(Expression<Func<Core.Entity.Type, bool>> filter);
        Task<BaseResponse<List<Core.Entity.Type>>> GetAllByFilter(Expression<Func<Core.Entity.Type, bool>> filter);
        Task<BaseResponse<List<Core.Entity.Type>>> Getlist();
    }
}
