using MovieStore.Core.Entity;
using MovieStore.Core.Model;
using MovieStore.Core.Model.Request.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Abstract
{
    public interface IActorService
    {
        Task<BaseResponse<Actor>> Create(ActorCreateRequest actorCreateRequest);
        Task<BaseResponse<Actor>> Update(ActorUpdateRequest actorUpdateRequest);
        Task<BaseResponse<Actor>> Delete(int Id);
        Task<BaseResponse<Actor>> Get(Expression<Func<Actor, bool>> filter);
        Task<BaseResponse<List<Actor>>> GetAllByFilter(Expression<Func<Actor, bool>> filter);
        //Task<BaseResponse<Actor>> GetList(Expression<Func<Actor, bool>> filter);
        Task<BaseResponse<List<Actor>>> Getlist();
    }
}
