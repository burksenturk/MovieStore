using AutoMapper;
using MovieStore.Business.Abstract;
using MovieStore.Core.Entity;
using MovieStore.Core.Model;
using MovieStore.Core.Model.Request.Actor;
using MovieStore.Core.Model.Request.Order;
using MovieStore.DataAccess.Abstract;
using MovieStore.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;


namespace MovieStore.Business.Concrete
{
    public class ActorService : IActorService
    {
        private readonly IActorRepository _actorRepository;
        private readonly IMapper _mapper;
        public ActorService(IActorRepository actorRepository, IMapper mapper)
        {
            _actorRepository = actorRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<Actor>> Create(ActorCreateRequest actorCreateRequest)
        {
            Actor actor = _mapper.Map<Actor>(actorCreateRequest);
            var resultActor = await _actorRepository.Create(actor);

            return resultActor;
        }

        public async Task<BaseResponse<Actor>> Delete(int Id)
        {
            var result = await _actorRepository.Get(x => x.Id == Id);
            return await _actorRepository.Delete(result.Data);
        }

        public async Task<BaseResponse<Actor>> Get(Expression<Func<Actor, bool>> filter)
        {
            return await _actorRepository.Get(filter);

        }

        public async Task<BaseResponse<List<Actor>>> GetAllByFilter(Expression<Func<Actor, bool>> filter)
        {
            return await _actorRepository.GetList(filter);
        }
        public async Task<BaseResponse<List<Actor>>> Getlist()
        {
            return await _actorRepository.GetAll();
        }

        public Task<BaseResponse<Actor>> Update(ActorUpdateRequest actorUpdateRequest) ///????
        {
            Actor actor = _mapper.Map<Actor>(actorUpdateRequest);
            return _actorRepository.Update(actor);
        }
    }
}
