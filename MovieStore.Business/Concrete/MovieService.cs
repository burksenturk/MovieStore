using AutoMapper;
using MovieStore.Core.Entity;
using MovieStore.Core.Model.Request.Movie;
using MovieStore.Core.Model;
using MovieStore.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MovieStore.Business.Abstract;

namespace MovieStore.Business.Concrete
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMovieActorRepository _movieActorRepository;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository movieRepository, IMovieActorRepository movieActorRepository,IMapper mapper)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _movieActorRepository= movieActorRepository;
        }

        public async Task<BaseResponse<Movie>> Create(MovieCreateRequest movieCreateRequest)
        {
            Movie movie = _mapper.Map<Movie>(movieCreateRequest);
            movie.IsActive = true;
            var resultMovie= await _movieRepository.Create(movie);
            if (resultMovie.Status)
            {
                foreach (var actorId in movieCreateRequest.ActorIdList)
                {
                    var movieActor = new MovieActor() { ActorId = actorId, MovieId = movie.Id };
                    await _movieActorRepository.Create(movieActor);
                }
            }
            return resultMovie;
        }

        public async Task<BaseResponse<Movie>> Delete(int Id)
        {
            var result = await _movieRepository.Get(x => x.Id == Id);
            return await _movieRepository.Delete(result.Data);
        }

        public async Task<BaseResponse<Movie>> Get(Expression<Func<Movie, bool>> filter, params Expression<Func<Movie, object>>[] inculudes)
        {
            return await _movieRepository.Get(filter,inculudes);

        }

        public async Task<BaseResponse<List<Movie>>> GetAllByFilter(Expression<Func<Movie, bool>> filter, params Expression<Func<Movie, object>>[] inculudes)
        {
            return await _movieRepository.GetList(filter, inculudes);
        }
        public async Task<BaseResponse<List<Movie>>> Getlist(params Expression<Func<Movie, object>>[] inculudes)
        {
            return await _movieRepository.GetAll(inculudes);
        }

        public Task<BaseResponse<Movie>> Update(MovieUpdateRequest movieUpdateRequest) 
        {
            Movie movie = _mapper.Map<Movie>(movieUpdateRequest);
            return _movieRepository.Update(movie);
        }
    }
}

